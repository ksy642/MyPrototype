using UnityEngine;

namespace UntilTheEnd
{
    public class Bullet : MonoBehaviour
    {
        public float lifeTime = 1.5f; // �Ѿ��� ����
        public GameObject particlePrefab; // �Ѿ��� �ݶ��̴��� ��ġ���� �� ��ƼŬ

        void Start()
        {
            // �Ѿ� ����
            transform.Rotate(90f, 0f, 0f);

            // ���� �ð� �Ŀ� �Ѿ� �ı�
            Destroy(gameObject, lifeTime);
        }

        void OnCollisionEnter(Collision collision)
        {
            // �浹 ������ ��ƼŬ ����
            if (particlePrefab != null)
            {
                Instantiate(particlePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                //Do nothing
            }

            // �浹 �� �Ѿ� �ı�
            Destroy(gameObject);
        }
    }
}