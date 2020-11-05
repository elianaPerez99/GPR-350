using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cedric and Eliana 
public class Particle2D : MonoBehaviour
{
    private void Start()
    {
        ParticleManager.mParticles.Add(this);
    }
    private void Update()
    {
        ForceManager.ApplyForce(this);
        Integrator.Integrate(this);
    }

    private void OnDestroy()
    {
        ParticleManager.mParticles.Remove(this);
    }
    public float mMass;
   public float mDamp;
   public Vector3 mVel;
   public Vector3 mAcc;
   public bool mShouldIgnoreForces;

   public Vector3 accumlatedForces;
}
