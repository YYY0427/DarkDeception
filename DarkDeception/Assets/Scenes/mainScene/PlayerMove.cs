using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    CharacterController con;

    [SerializeField] private GameObject[] enemyObj = new GameObject[3];

    public float walkSpeed = 5.0f;  // 通常の移動速度
    public float dashSpeed = 10.0f; // ダッシュ時の移動速度
    private float currentSpeed; // 現在の移動速度
    public float gravity = 10f;    // 重力の大きさ

    public float sensitivity = 2.0f; // マウス感度
    public float smoothing = 2.0f;   // スムージング

    private Vector2 mouseLook;       // マウスの向き
    private Vector2 smoothV;         // スムージング用

    Vector3 moveDirection = Vector3.zero; // 移動ベクトル

    PlayerLife life = new PlayerLife();

    GameObject _singletonObj;

    static GameObject _enemyObj; // シーン移行時にenemyの種類を確認するための変数

    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
        _singletonObj = GameObject.Find("Singleton");
        Debug.Log(_singletonObj.name);
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの入力を取得
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // スムージング
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothV;

        // 上下方向の回転を制限
        mouseLook.y = Mathf.Clamp(mouseLook.y, -85f, 85f);
        //mouseLook.x = Mathf.Clamp(mouseLook.x, -90f, 90f);

        // カメラとプレイヤーの向きを更新
        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
        transform.localRotation = Quaternion.Euler(-mouseLook.y, mouseLook.x, 0); ;

        float newRotationY = mouseLook.y + 180f;

        // マウスホイールが押されているかどうかをチェック
        bool isWheelCrick = Input.GetMouseButtonDown(2);

        // Todo:ホイールクリック時は視点を180°反対方向に回転させる
        mouseLook.x = isWheelCrick ? mouseLook.x + newRotationY : mouseLook.x;



        // 移動速度を取得
        float speed = Input.GetKey(KeyCode.LeftShift) ? dashSpeed : walkSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");    // aとs
        float verticalInput = Input.GetAxis("Vertical");        // wとs

        // カメラの向きを基準にした正面方向のベクトル
        Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;

        // 前後左右の入力（WASDキー）から、移動のためのベクトルを計算
        // Input.GetAxis("Vertical") は前後（WSキー）の入力値
        // Input.GetAxis("Horizontal") は左右（ADキー）の入力値
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //　前後（カメラ基準）　 
        Vector3 moveX = transform.right * Input.GetAxis("Horizontal") * speed; // 左右（カメラ基準）

        Vector3 move = (moveZ + moveX);

        if(move.magnitude > speed)
        {
            move = move.normalized * speed;
        }

        // 地面にいるかどうか
        if (con.isGrounded)
        {
            moveDirection = move;
        }
        else
        {
            // 重力を効かせる
            moveDirection = move + new Vector3(0, moveDirection.y, 0);
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move は指定したベクトルだけ移動させる命令
        con.Move(moveDirection * Time.deltaTime);

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

        for (int i = 0; i < enemyObj.Length; i++)
        {
            Vector3 playerToEnemy = (enemyObj[i].transform.position -
                this.transform.position);

            float dist = Mathf.Abs(playerToEnemy.magnitude);

            if (dist < Mathf.Abs(12.0f))
            {
                life.lifeDecrease();
                if (PlayerLife.life <= 0)
                {
                    SingletonScript.instance = null;
                    Destroy(_singletonObj);

                }
                life.changeScene();
            }

            Debug.Log(dist);
        }
        //Debug.Log("tintin");
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
