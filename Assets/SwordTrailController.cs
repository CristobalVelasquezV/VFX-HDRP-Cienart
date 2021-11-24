using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
[ExecuteInEditMode]
public class SwordTrailController : MonoBehaviour
{
    [SerializeField] VisualEffect _vfx;
    [SerializeField] ObjectPoolBehaviour _psPrefabPool;
    [SerializeField] Transform target;
    [SerializeField] Transform trailTransform;
    [SerializeField] bool useVFX;
    [SerializeField] float timeToDeactivatePS;
    float minDistanceActivation;

    VFXEventAttribute vFXEventAttribute;
    private bool isVFXEnable;
    private string distanceOfActivationProperty;
    private int distanceOfActivationPropertyHash;
    private void Start()
    {
        LastPosition = target.position;
        isVFXEnable = true;
        distanceOfActivationProperty = "MinDistanceActivation";
        distanceOfActivationPropertyHash = Shader.PropertyToID(distanceOfActivationProperty);

        
    }
    private float minDistanceActivationVFX;
    Vector3 LastPosition;
    void Update()
    {
        if (useVFX && !_vfx.isActiveAndEnabled)
        {
            _vfx.gameObject.SetActive(true);
        }
        else if(!useVFX&&_vfx.isActiveAndEnabled) {
            _vfx.gameObject.SetActive(false);
        }
        if (_vfx.HasFloat(distanceOfActivationPropertyHash))
        {
            minDistanceActivationVFX = _vfx.GetFloat(distanceOfActivationPropertyHash);
            if (isVFXEnable && Vector3.Distance(LastPosition, target.position) > minDistanceActivationVFX)
            {
                if (vFXEventAttribute == null) {
                    vFXEventAttribute = _vfx.CreateVFXEventAttribute();
                    //add spawn attribs
                }
                _vfx.SendEvent("OnManualSpawn");
                LastPosition = target.position;
            }
        }
        else {
            if (isVFXEnable && Vector3.Distance(LastPosition, target.position) > minDistanceActivation)
            {
                if (vFXEventAttribute == null)
                {
                    vFXEventAttribute = _vfx.CreateVFXEventAttribute();
                    //add spawn attribs
                }
                _vfx.SendEvent("OnManualSpawn");
                LastPosition = target.position;
            }
        }

    }

    public void EnableVFX()
    {
        if (useVFX) { 
            isVFXEnable = true;
        }

    }

    public void DisableVFX() {
        isVFXEnable = false;
    }

    public void ActivatePS()
    {
        if (!useVFX)
        {
            GameObject ps = _psPrefabPool.GetPooledObject();
            ps.transform.position = trailTransform.position;
            ps.transform.rotation = Quaternion.LookRotation(trailTransform.forward); ;
            ps.SetActive(true);
            StartCoroutine(DeactivatePS(timeToDeactivatePS, ps));
        }

    }
    IEnumerator DeactivatePS(float time,GameObject go)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(false);

    }
}
