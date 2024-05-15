using UnityEngine;

namespace UntilTheEnd
{
    public class Bullet : MonoBehaviour
    {
        public float lifeTime = 1.5f; // 총알의 수명
        public GameObject particlePrefab; // 총알이 콜라이더에 터치했을 때 파티클

        void Start()
        {
            // 총알 눕힘
            transform.Rotate(90f, 0f, 0f);

            // 일정 시간 후에 총알 파괴
            Destroy(gameObject, lifeTime);
        }

        void OnCollisionEnter(Collision collision)
        {
            // 충돌 지점에 파티클 생성
            if (particlePrefab != null)
            {
                Instantiate(particlePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                //Do nothing
            }

            // 충돌 시 총알 파괴
            Destroy(gameObject);
        }
    }
}