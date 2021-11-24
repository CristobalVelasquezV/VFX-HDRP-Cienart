using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TestRumble : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource source;
    private void Start()
    {
        StartCoroutine(Rumble());
    }

    IEnumerator Rumble() {
        while (true) {
            source.GenerateImpulse();
            yield return new WaitForSeconds(2f);
        }
    }
}
