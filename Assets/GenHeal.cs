using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenHeal : MonoBehaviour
{
    [SerializeField] ObjectPoolBehaviour HealParticleSystemPool;
    [SerializeField] float waitTime;
    [SerializeField] float waitTimeBuff;
    [SerializeField] ObjectPoolBehaviour BuffParticleSystemPool;
    bool onHealParticleColdown;
    public void GotHealed(){
        GameObject go = HealParticleSystemPool.GetPooledObject();
        go.SetActive(true);
        StartCoroutine(DeactivatePS(go));
    }

    public void GotBuffed() { 
        GameObject go = BuffParticleSystemPool.GetPooledObject();
        go.SetActive(true);
        StartCoroutine(DeactivatePSBuff(go));
    }
    IEnumerator DeactivatePSBuff(GameObject go)
    {
        yield return new WaitForSeconds(waitTimeBuff);
        go.SetActive(false);
    }
    IEnumerator DeactivatePS(GameObject go) {
        yield return new WaitForSeconds(waitTime);
        go.SetActive(false);
    }
}
