using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntilTheEnd
{
    public class FireBullet : MonoBehaviour
    {
        // �Ѿ�
        public GameObject bulletPrefab;

        // �ѱ� ��ġ
        public Transform firePosition;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullets = Instantiate(bulletPrefab);

                // �Ѿ˹߻�(�Ѿ��� �ѱ� ��ġ�� ������ �д�.)
                //bullets.transform.position = firePosition.transform.position;
            }
        }
    }
}