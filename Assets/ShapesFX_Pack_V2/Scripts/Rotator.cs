using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapesFX
{
    public class Rotator : MonoBehaviour
    {
        public float speed = 1;
        public Vector3 direction = new Vector3(1, 0, 0);
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(direction * speed * Time.deltaTime);
        }
    }
}