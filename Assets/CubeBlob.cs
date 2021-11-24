using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBlob : MonoBehaviour
{
    [SerializeField] float period;
    [SerializeField] float offset;
    [SerializeField] float amp;
    [SerializeField] Material waterMat;
    void Start()
    {
        height = new Vector3();
    }
    Vector3 height;
    // Update is called once per frame
    void Update()
    {
        waterMat.SetVector("_CubePosition", transform.position);
        height.y = blobPosition();
        transform.position += height;
    }
    float blobPosition()
    {
        return amp*Mathf.Sin(period*Time.time+offset);

    }

}
