using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntilTheEnd
{
    public class FireBullet : MonoBehaviour
    {
        // ÃÑ¾Ë
        public GameObject bulletPrefab;

        // ÃÑ±¸ À§Ä¡
        public Transform firePosition;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullets = Instantiate(bulletPrefab);

                // ÃÑ¾Ë¹ß»ç(ÃÑ¾ËÀ» ÃÑ±¸ À§Ä¡·Î °¡Á®´Ù µÐ´Ù.)
                //bullets.transform.position = firePosition.transform.position;
            }
        }
    }
}