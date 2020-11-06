using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cedric and Eliana 
public class Particle2D : MonoBehaviour
{
   public float mMass;
   public float mDamp;
   public Vector3 mVel;
   public Vector3 mAcc;
   public bool mShouldIgnoreForces;
   public bool mIsTarget = false;
   public bool mIsPlayer = false;

   public Vector3 accumlatedForces;

   public float getInverseMass() { return 1 / mMass; }

   private void Start()
    {
        
        ParticleManager.mParticles.Add(this);
    }
    private void Update()
    {
        CheckTarget();
    }
    private void FixedUpdate()
    {
        ForceManager.ApplyForce(this);
        Integrator.Integrate(this);
    }

    private void OnDestroy()
    {
        ParticleManager.mParticles.Remove(this);
    }

    private void CheckTarget()
    {
        GameObject target = GameObject.FindGameObjectsWithTag("Target")[0];
        bool inXRange = transform.position.x >= target.GetComponent<Target>().xRange.x && transform.position.x <= target.GetComponent<Target>().xRange.y;
        bool inYRange = transform.position.y >= target.GetComponent<Target>().yRange.x && transform.position.y <= target.GetComponent<Target>().yRange.y;
        if (!mIsPlayer && !mIsTarget && inXRange && inYRange)
        {
            target.GetComponent<Target>().Respawn();
            Destroy(gameObject);
        }
    }
}
