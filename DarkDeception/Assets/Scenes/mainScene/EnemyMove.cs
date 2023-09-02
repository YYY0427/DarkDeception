using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
//[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    public int destPoint = 0;
    public Transform[] points;
    float distance;
    public float trackingRange = 3f;
    public float quitRange = 5f;
    public bool tracking = false;
    public float trackigHeight = 10f;

    private Rigidbody rb;
    private NavMeshAgent agent;
    private Animator animator;
    Vector3 playerPos;
    Vector3 targetPos;
    GameObject player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

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
        //    agent.destination = points[destPoint].position;
        targetPos = points[destPoint].position;

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
                animator.SetTrigger("look");
            }

            //Playerを目標とする
            targetPos = playerPos;
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
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
        DoMove(targetPos);
    }

    private void DoMove(Vector3 targetPosition)
    {
        if (agent && agent.enabled)
        {
            agent.SetDestination(targetPosition);

            foreach (var pos in agent.path.corners)
            {
                var diff2d = new Vector2(
                    Mathf.Abs(pos.x - transform.position.x),
                    Mathf.Abs(pos.z - transform.position.z)
                );

                if (0.1f <= diff2d.magnitude)
                {
                    targetPosition = pos;
                    break;
                }
            }

            Debug.DrawLine(transform.position, targetPosition, Color.red);
        }

        Quaternion moveRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);
        moveRotation.z = 0;
        moveRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, moveRotation, 0.1f);

        float forward_x = transform.forward.x * 30.0f;
        float forward_z = transform.forward.z * 30.0f;

        rb.velocity = new Vector3(forward_x, rb.velocity.y, forward_z);
        //rb.AddForce(rb.velocity, ForceMode.Force);
        //rb.AddForce(new Vector3(30, 0, 30), ForceMode.Force);
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