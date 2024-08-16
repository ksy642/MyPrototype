using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 30f;
    public float sprintMultiplier = 2.5f; // �޸��� �ӵ� ���

    void Update()
    {
        //bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 rotation = new Vector3(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotation);

        //// WASD �Է� ��������
        //float verticalInput = Input.GetAxis("Vertical");

        //// �̵� ���� ���
        //Vector3 moveDirection = new Vector3(0f, 0f, verticalInput);

        //// �̵� �ӵ��� �޸��� �ӵ� ����� ����
        //float currentMoveSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

        //// �̵� ���Ϳ� �̵� �ӵ��� ���Ͽ� ���� �̵� ���� ����
        //Vector3 movement = moveDirection * currentMoveSpeed * Time.deltaTime;

        //// �÷��̾� �̵�
        //transform.Translate(movement, Space.Self);
    }
}
