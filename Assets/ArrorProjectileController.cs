using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrorProjectileController : MonoBehaviour
{
    [SerializeField] ObjectPoolBehaviour arrowPrefabsPool;
    [SerializeField] GameObject arrowPlaceHolder;
    [SerializeField] float arrowForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootArrow()
    {
        arrowPlaceHolder.SetActive(false);
        GameObject arrow = arrowPrefabsPool.GetPooledObject();
        arrow.transform.position = arrowPlaceHolder.transform.position;
        arrow.transform.rotation = arrowPlaceHolder.transform.rotation;
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
        arrow.SetActive(true);
        arrowRb.AddForce(arrow.transform.forward * arrowForce);
    }

    public void ReloadArrow()
    {

        arrowPlaceHolder.SetActive(true);

    }
}
