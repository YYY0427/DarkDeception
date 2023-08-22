using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public Transform target; // �����Ώۂ�Transform�i�ʏ�̓v���C���[�I�u�W�F�N�g�j
    private Rigidbody rb;

    public float sensitivity = 2.0f; // �}�E�X���x
    public float smoothing = 2.0f;   // �X���[�W���O

    private Vector2 mouseLook;       // �}�E�X�̌���
    private Vector2 smoothV;         // �X���[�W���O�p

    public float walkSpeed = 5.0f;  // �ʏ�̈ړ����x
    public float dashSpeed = 10.0f; // �_�b�V�����̈ړ����x
    public float dashDuration = 1.0f; // �_�b�V���̎�������

    private float currentSpeed; // ���݂̈ړ����x

    PlayerLife life = new PlayerLife();

    GameObject _singletonObj;

    private void Start()
    {
        _singletonObj = GameObject.Find("Singleton");
        rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
    }

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
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        //   mouseLook.x = Mathf.Clamp(mouseLook.x, -90f, 90f);

        // �J�����ƃv���C���[�̌������X�V
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);

        float newRotationY = mouseLook.y + 180f;

        // �}�E�X�z�C�[����������Ă��邩�ǂ������`�F�b�N
        bool isWheelCrick = Input.GetMouseButtonDown(2);

        // Todo:�z�C�[���N���b�N���͎��_��180�����Ε����ɉ�]������
        mouseLook.x = isWheelCrick ? mouseLook.x + newRotationY : mouseLook.x;

        float horizontalInput = Input.GetAxis("Horizontal");    // a��s
        float verticalInput = Input.GetAxis("Vertical");        // w��s

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, horizontalInput);
        Vector3 moveDirection2 = new Vector3(verticalInput, 0.0f, verticalInput);

        // Shift�L�[��������Ă��邩�ǂ������`�F�b�N
        bool isDashing = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // �_�b�V�����̓_�b�V�����x�A�����łȂ���Βʏ�̑��x���g�p
        currentSpeed = isDashing ? dashSpeed : walkSpeed;

        // �ړ��x�N�g���ɑ��x�������Ĉړ�
        //   transform.Translate(moveDirection.normalized * currentSpeed * Time.deltaTime);
        rb.AddForce(Vector3.Scale(transform.forward, moveDirection2.normalized) * currentSpeed/** Time.deltaTime*/, ForceMode.Force);
        rb.AddForce(Vector3.Scale(transform.right, moveDirection.normalized) * currentSpeed/** Time.deltaTime*/, ForceMode.Force);

        if(rb.velocity.magnitude > currentSpeed)
        {
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }

        if(horizontalInput == 0 && verticalInput == 0)
        {
            Stop();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            life.lifeDecrease();
            if (PlayerLife.life <= 0)
            {
                SingletonScript.instance = null;
                Destroy(_singletonObj);

            }
            life.changeScene();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life.lifeDecrease();
            if (PlayerLife.life <= 0)
            {
                SingletonScript.instance = null;
                Destroy(_singletonObj);

            }
            life.changeScene();
        }
    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

public class PlayerLife
{
    public static int life = 3;
    public void changeScene()
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