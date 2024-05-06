using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 30f;
    public float sprintMultiplier = 2.5f; // 달리기 속도 배수

    void Update()
    {
        //bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 rotation = new Vector3(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotation);

        //// WASD 입력 가져오기
        //float verticalInput = Input.GetAxis("Vertical");

        //// 이동 벡터 계산
        //Vector3 moveDirection = new Vector3(0f, 0f, verticalInput);

        //// 이동 속도에 달리기 속도 배수를 적용
        //float currentMoveSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

        //// 이동 벡터에 이동 속도를 곱하여 최종 이동 벡터 생성
        //Vector3 movement = moveDirection * currentMoveSpeed * Time.deltaTime;

        //// 플레이어 이동
        //transform.Translate(movement, Space.Self);
    }
}
