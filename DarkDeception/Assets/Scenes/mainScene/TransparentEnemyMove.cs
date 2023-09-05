using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//�I�u�W�F�N�g��NavMeshAgent�R���|�[�l���g��ݒu
[RequireComponent(typeof(NavMeshAgent))]

public class TransparentEnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    Vector3 playerPos;
    Vector3 initPos;
    Vector3 targetPos;
    GameObject player;
    
    float distance;
    [SerializeField] float trackingRange = 3f;
    [SerializeField] float quitRange = 5f;
    [SerializeField] bool tracking = false;
    [SerializeField] float trackigHeight = 10f;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        targetPos = initPos;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        // autoBraking �𖳌��ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ����܂�
        //(�܂�A�G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă�
        // ���x�����Ƃ��܂���)
        agent.autoBraking = false;

        //�ǐՂ������I�u�W�F�N�g�̖��O������
        player = GameObject.Find("Player");
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
                targetPos = initPos;
                agent.destination = targetPos;
                anim.SetTrigger("look");
            }
        }
        else
        {
            //Player��trackingRange���߂Â�����ǐՊJ�n
            if (distance < trackingRange)
            {
                tracking = true;
                targetPos = playerPos;
                agent.destination = targetPos;
                anim.SetTrigger("fly");
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
}
