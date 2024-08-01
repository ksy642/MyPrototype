using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform firePosition;   // �Ѿ��� �߻�� ��ġ
    public float bulletSpeed = 24f; // �Ѿ��� �ӵ�

    void Update()
    {
        // Fire1 ��ư�� ������ �� �߻�
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullets = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);

        // �Ѿ˿� Rigidbody ������Ʈ�� �ִٸ� ���� ����
        Rigidbody bulletRigidbody = bullets.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.linearVelocity = firePosition.forward * bulletSpeed;
        }
    }
}
