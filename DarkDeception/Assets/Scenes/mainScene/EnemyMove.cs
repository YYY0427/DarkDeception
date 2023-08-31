using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{

    public Transform[] points;
    [SerializeField] int destPoint = 0;
    private NavMeshAgent agent;

    private Animator animator;
    AnimatorStateInfo stateInfo;

    Vector3 playerPos;
    GameObject player;
    float distance;
    [SerializeField] float trackingRange = 3f;
    [SerializeField] float quitRange = 5f;
    [SerializeField] bool tracking = false;
    [SerializeField] float trackigHeight = 10f;

    int timer = 0;
    bool isGoal = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = false;

        GotoNextPoint();

        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");
    }


    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;
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
                animator.SetTrigger("normal");
            }

            //Playerを目標とする
            agent.destination = playerPos;
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (distance < trackingRange)
            {
                tracking = true;
                animator.SetTrigger("fly");
            }

            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f && !isGoal)
            {
                Debug.Log("なんでお前通るんや");
                isGoal = true;
                agent.speed = 0f;
                agent.updateRotation = false;    
                animator.SetTrigger("look");

            }
            if(isGoal)
            {
                timer++;
                if (timer > 750)
                {
                    timer = 0;
                    isGoal = false;
                    agent.speed = 20f;
                    agent.updateRotation = true;
                    animator.SetTrigger("normal");
                    GotoNextPoint();
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + (trackigHeight / 2.0f), transform.position.z), trackingRange);

        //quitRangeの範囲を青いワイヤーフレームで示す
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + (trackigHeight / 2.0f), transform.position.z), quitRange);
    }
}