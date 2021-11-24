using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] VisualEffect _vfx;
    [SerializeField] Transform target;
    [SerializeField] float speed;

    VFXEventAttribute vFXEventAttribute;
    Rigidbody rb;
    private string trialParticlesRateAmount;
    private string orbVelocity;
    private int trialParticlesRateAmountHash;
    private int orbVelocityHash;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {

        trialParticlesRateAmount = "ParticlesAmountRate";
        orbVelocity = "ParticleVelocity";
        orbVelocityHash = Shader.PropertyToID(orbVelocity);

        trialParticlesRateAmountHash = Shader.PropertyToID(trialParticlesRateAmount);
    }


    void FixedUpdate()
    {
        _vfx.SetFloat(trialParticlesRateAmountHash, rb.velocity.magnitude);
        _vfx.SetVector3(orbVelocityHash, rb.velocity);
        if (vFXEventAttribute == null)
        {
            vFXEventAttribute = _vfx.CreateVFXEventAttribute();
            vFXEventAttribute.SetVector3(trialParticlesRateAmountHash, rb.velocity);
            //add spawn attribs
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("orb collision");
    }
    public void Shoot()
    {
        rb.velocity = transform.forward * speed;
    }
}
