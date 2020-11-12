
using UnityEngine;

//Cedric and Eliana 
public class Particle2D : MonoBehaviour
{
   public float mMass = 1.0f;
   public float mDamp = .99f;
   public Vector3 mVel;
   public Vector3 mAcc;
   public bool mShouldIgnoreForces;
   public bool mIsTarget = false;
   public bool mIsPlayer = false;

   public Vector3 accumlatedForces;

   public float getInverseMass() { return 1 / mMass; }

    private void Start()
    {
       GameObject.FindGameObjectsWithTag("manager")[0].GetComponent<ParticleManager>().mParticles.Add(this);
        mAcc = new Vector3(0, 0, 0);
    }
    private void FixedUpdate()
    {
        ForceManager.ApplyForce(this);
        Integrator.Integrate(this);
    }

    private void OnDestroy()
    {
        GameObject.FindGameObjectsWithTag("manager")[0].GetComponent<ParticleManager>().mParticles.Remove(this);
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
