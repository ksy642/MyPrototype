using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntilTheEnd
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 5;

        void Update()
        {
            Vector3 dir = Vector3.forward;
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}