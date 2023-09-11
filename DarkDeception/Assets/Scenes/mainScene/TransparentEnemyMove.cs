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

        // autoBraking �𖳌��ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ����܂�
        //(�܂�A�G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă�
        // ���x�����Ƃ��܂���)
        agent.autoBraking = false;

        normalSpeed = agent.speed;

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
                anim.SetTrigger("look");
            }
            agent.speed = trackingPlayerSpeed;
            targetPos = playerPos;
            agent.destination = targetPos;
        }
        else
        {
            //Player��trackingRange���߂Â�����ǐՊJ�n
            if (distance < trackingRange)
            {
                // �΂����Đ�
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
        //trackingRange�͈̔͂�Ԃ����C���[�t���[���Ŏ���
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRange�͈̔͂�����C���[�t���[���Ŏ���
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }
}
