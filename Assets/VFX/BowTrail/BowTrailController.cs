using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class BowTrailController : MonoBehaviour
{
    [SerializeField] VisualEffect _vfx;
    [SerializeField] Transform target;

    float minDistanceActivation;

    VFXEventAttribute vFXEventAttribute;
    private bool isVFXEnable;
    private string distanceOfActivationProperty;
    private int distanceOfActivationPropertyHash;
    private void Start()
    {
        LastPosition = target.position;
        isVFXEnable = false;
        distanceOfActivationProperty = "MinDistanceActivation";
        distanceOfActivationPropertyHash = Shader.PropertyToID(distanceOfActivationProperty);
        EnableVFX();
    }
    private float minDistanceActivationVFX;
    Vector3 LastPosition;
    void LateUpdate()
    {
        if (_vfx.HasFloat(distanceOfActivationPropertyHash))
        {

            minDistanceActivationVFX = _vfx.GetFloat(distanceOfActivationPropertyHash);
            if (isVFXEnable && Vector3.Distance(LastPosition, target.position) > minDistanceActivationVFX)
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
        else
        {
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
        isVFXEnable = true;
    }

    public void DisableVFX()
    {
        isVFXEnable = false;
    }
}
