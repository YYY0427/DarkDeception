using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    CharacterController con;

    [SerializeField] private GameObject[] enemyObj = new GameObject[5];

    public float walkSpeed = 5.0f;  // �ʏ�̈ړ����x
    public float dashSpeed = 10.0f; // �_�b�V�����̈ړ����x
    private float currentSpeed; // ���݂̈ړ����x
    public float gravity = 10f;    // �d�͂̑傫��

    public float sensitivity = 2.0f; // �}�E�X���x
    public float smoothing = 2.0f;   // �X���[�W���O

    private Vector2 mouseLook;       // �}�E�X�̌���
    private Vector2 smoothV;         // �X���[�W���O�p

    Vector3 moveDirection = Vector3.zero; // �ړ��x�N�g��

    PlayerLife life = new PlayerLife();

    GameObject _singletonObj;

    public static int _enemyKind; // �|���ꂽ�Ƃ��G���L�����邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        // enemyObj[4] = GameObject.Find("Transparent");
        _enemyKind = 1;
        con = GetComponent<CharacterController>();
        _singletonObj = GameObject.Find("Singleton");
        Debug.Log(_singletonObj.name);
    }

    // Update is called once per frame
    void Update()
    {
        // �}�E�X�̓��͂��擾
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // �X���[�W���O
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothV;

        // �㉺�����̉�]�𐧌�
        mouseLook.y = Mathf.Clamp(mouseLook.y, -85f, 85f);
        if (GameOver.gameOver)
        {
            //mouseLook.x = Mathf.Clamp(mouseLook.x, -90f, 90f);
            mouseLook.y = Mathf.Clamp(mouseLook.y, 0, 0);
        }

        // �J�����ƃv���C���[�̌������X�V
        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
        transform.localRotation = Quaternion.Euler(-mouseLook.y, mouseLook.x, 0);

        float newRotationY = mouseLook.y + 180f;

        // �}�E�X�z�C�[����������Ă��邩�ǂ������`�F�b�N
        bool isWheelCrick = Input.GetMouseButtonDown(2);

        // Todo:�z�C�[���N���b�N���͎��_��180�����Ε����ɉ�]������
        mouseLook.x = isWheelCrick ? mouseLook.x + newRotationY : mouseLook.x;



        // �ړ����x���擾
        float speed = Input.GetKey(KeyCode.LeftShift) ? dashSpeed : walkSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");    // a��s
        float verticalInput = Input.GetAxis("Vertical");        // w��s

        // �J�����̌�������ɂ������ʕ����̃x�N�g��
        Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;

        // �O�㍶�E�̓��́iWASD�L�[�j����A�ړ��̂��߂̃x�N�g�����v�Z
        // Input.GetAxis("Vertical") �͑O��iWS�L�[�j�̓��͒l
        // Input.GetAxis("Horizontal") �͍��E�iAD�L�[�j�̓��͒l
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //�@�O��i�J������j�@ 
        Vector3 moveX = transform.right * Input.GetAxis("Horizontal") * speed; // ���E�i�J������j

        Vector3 move = (moveZ + moveX);

        if (move.magnitude > speed)
        {
            move = move.normalized * speed;
        }

        // �n�ʂɂ��邩�ǂ���
        if (con.isGrounded)
        {
            moveDirection = move;
        }
        else
        {
            // �d�͂���������
            moveDirection = move + new Vector3(0, moveDirection.y, 0);
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move �͎w�肵���x�N�g�������ړ������閽��
        con.Move(moveDirection * Time.deltaTime);

        for (int i = 0; i < enemyObj.Length; i++)
        {
            Vector3 playerToEnemy = (enemyObj[i].transform.position -
                this.transform.position);

            float dist = Mathf.Abs(playerToEnemy.magnitude);

            if (dist < Mathf.Abs(12.0f) && !GameOver.gameOver)
            {
                GameOver.gameOver = true;
                GameOver.enemyObj = enemyObj[i];
                life.lifeDecrease();
                if (PlayerLife.life <= 0)
                {
                    SingletonScript.instance = null;
                    Destroy(_singletonObj);

                }
                //life.changeScene();
                _enemyKind = i;
                
                SceneManager.LoadScene("KnockDownScene");
            }

            Debug.Log(dist);
        }
        //Debug.Log("tintin");
    }
}

public class PlayerLife
{
    public static int life = 3;
    static public void changeScene()
    {

        if (life <= 0)
        {
            SceneManager.LoadScene("gameoverScene");
        }
        else
        {
            SceneManager.LoadScene("RemainingLifeScene");
        }
    }

    public void lifeDecrease()
    {
        life = System.Math.Max(life - 1, 0);
    }

}
