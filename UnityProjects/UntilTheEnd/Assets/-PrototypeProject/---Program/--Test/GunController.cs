using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePosition;   // 총알이 발사될 위치
    public float bulletSpeed = 24f; // 총알의 속도

    void Update()
    {
        // Fire1 버튼이 눌렸을 때 발사
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullets = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);

        // 총알에 Rigidbody 컴포넌트가 있다면 힘을 가함
        Rigidbody bulletRigidbody = bullets.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = firePosition.forward * bulletSpeed;
        }
    }
}
