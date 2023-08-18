using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public Transform target; // 注視対象のTransform（通常はプレイヤーオブジェクト）

    public float sensitivity = 2.0f; // マウス感度
    public float smoothing = 2.0f;   // スムージング

    private Vector2 mouseLook;       // マウスの向き
    private Vector2 smoothV;         // スムージング用

    public float walkSpeed = 5.0f;  // 通常の移動速度
    public float dashSpeed = 10.0f; // ダッシュ時の移動速度
    public float dashDuration = 1.0f; // ダッシュの持続時間

    private float currentSpeed; // 現在の移動速度

    PlayerLife life = new PlayerLife();

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
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        //   mouseLook.x = Mathf.Clamp(mouseLook.x, -90f, 90f);

        // カメラとプレイヤーの向きを更新
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);

        float newRotationY = mouseLook.y + 180f;


        // マウスホイールが押されているかどうかをチェック
        bool isWheelCrick = Input.GetMouseButtonDown(2);

        // Todo:ホイールクリック時は視点を180°反対方向に回転させる
        mouseLook.x = isWheelCrick ? mouseLook.x + newRotationY : mouseLook.x;


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Shiftキーが押されているかどうかをチェック
        bool isDashing = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // ダッシュ中はダッシュ速度、そうでなければ通常の速度を使用
        currentSpeed = isDashing ? dashSpeed : walkSpeed;

        // 移動ベクトルに速度をかけて移動
        transform.Translate(moveDirection.normalized * currentSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Return))
        {
            life.changeScene();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life.changeScene();
        }
    }

}

public class PlayerLife
{
    public static int life = 3;

    public void changeScene()
    {
        life = System.Math.Max(life - 1, 0);

        if (life <= 0)
        {
            SceneManager.LoadScene("gameoverScene");
        }
        else
        {
            SceneManager.LoadScene("RemainingLifeScene");
        }
    }
}