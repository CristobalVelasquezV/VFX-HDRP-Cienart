using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] float timeDisable;
    private void OnEnable()
    {
        StartCoroutine(DisableArrow());
    }

    IEnumerator DisableArrow()
    {
        yield return new WaitForSeconds(timeDisable);
        gameObject.SetActive(false);
    }
}
