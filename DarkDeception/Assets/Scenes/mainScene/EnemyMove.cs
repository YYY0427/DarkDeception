using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent�g���Ƃ��ɕK�v
using UnityEngine.AI;

//�I�u�W�F�N�g��NavMeshAgent�R���|�[�l���g��ݒu
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
    public float trackingPlayerSpeed;

    private Rigidbody rb;
    private NavMeshAgent agent;
    private Animator animator;
    Vector3 playerPos;
    Vector3 targetPos;
    GameObject player;
    float normalSpeed = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

        // autoBraking �𖳌��ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ����܂�
        //(�܂�A�G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă����x�����Ƃ��܂���)
        agent.autoBraking = false;
        normalSpeed = agent.speed;

        GotoNextPoint();

        //�ǐՂ������I�u�W�F�N�g�̖��O������
        player = GameObject.Find("Player");
    }


    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ��܂�
        if (points.Length == 0)
            return;

        // �G�[�W�F���g�����ݐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɐݒ肵�܂�
        targetPos = points[destPoint].position;
        agent.destination = targetPos; 

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ肵�A
        // �K�v�Ȃ�Ώo���n�_�ɂ��ǂ�܂�
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        //Player�Ƃ��̃I�u�W�F�N�g�̋����𑪂�
        playerPos = player.transform.position;
        distance = Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y + (trackigHeight / 2.0f), this.transform.position.z), playerPos);

        if (tracking)
        {
            //�ǐՂ̎��AquitRange��苗�������ꂽ�璆�~
            if (distance > quitRange)
            {
                tracking = false;
                animator.SetTrigger("look");
            }

            agent.speed = trackingPlayerSpeed;

            //Player��ڕW�Ƃ���
            targetPos = playerPos;
            agent.destination = targetPos;
        }
        else
        {
            agent.speed = normalSpeed;
            //Player��trackingRange���߂Â�����ǐՊJ�n
            if (distance < trackingRange)
            {
                tracking = true;
                animator.SetTrigger("fly");
            }

            // �G�[�W�F���g�����ڕW�n�_�ɋ߂Â��Ă�����A
            // ���̖ڕW�n�_��I�����܂�
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
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
        //trackingRange�͈̔͂�Ԃ����C���[�t���[���Ŏ���
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRange�͈̔͂�����C���[�t���[���Ŏ���
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }
}