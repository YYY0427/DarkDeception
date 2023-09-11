using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class TransparentEnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public AudioSource trackingSound;
    Vector3 playerPos;
    Vector3 initPos;
    Vector3 targetPos;
    GameObject player;

    float normalSpeed;
    float distance;
    [SerializeField] float trackingRange = 3f;
    [SerializeField] float quitRange = 5f;
    [SerializeField] bool tracking = false;
    [SerializeField] float trackigHeight = 10f;
    [SerializeField] float trackingPlayerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        targetPos = initPos;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        trackingSound = GetComponent<AudioSource>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = false;

        normalSpeed = agent.speed;

        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //Playerとこのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y + (trackigHeight / 2.0f), this.transform.position.z), playerPos);

        if (tracking)
        {
            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange)
            {
                tracking = false;
                anim.SetTrigger("look");
            }
            agent.speed = trackingPlayerSpeed;
            targetPos = playerPos;
            agent.destination = targetPos;
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (distance < trackingRange)
            {
                // 笑い声再生
                trackingSound.Play();
                tracking = true;
                anim.SetTrigger("fly");
            }
            agent.speed = normalSpeed;
            targetPos = initPos;
            agent.destination = targetPos;
        }
        DoMove(targetPos);
    }

    private void DoMove(Vector3 targetPosition)
    {
        Quaternion moveRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);
        moveRotation.z = 0;
        moveRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, moveRotation, 0.1f);

        agent.velocity = (agent.steeringTarget - transform.position).normalized * agent.speed;
        transform.forward = agent.steeringTarget - transform.position;
    }

    void OnDrawGizmosSelected()
    {
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRangeの範囲を青いワイヤーフレームで示す
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }
}
