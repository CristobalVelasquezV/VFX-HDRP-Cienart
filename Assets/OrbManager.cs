using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    [SerializeField]Projectile projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            projectile.transform.position = transform.position;
            projectile.gameObject.SetActive(true);
            projectile.Shoot();
        }
    }
}
