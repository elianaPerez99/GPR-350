using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGenerator : MonoBehaviour
{
    //variables
    public bool mShouldAffectAll;
    public float mMagnitude;

    //functions
    private void Start()
    {
        ForceManager.AddForceGenerator(this);
    }
    private void OnDestroy()
    {
        //ForceManager.RemoveForceGenerator(this); //this leads to an error when you close the project
    }
    public virtual void UpdateForces(Particle2D pData)
    {
        Vector3 diff = transform.position - pData.transform.position;
        float range = 1000;
        float rangeSQ = range * range;
        float distSQ = diff.sqrMagnitude;
        if(distSQ < rangeSQ)
        {
            float dist = diff.magnitude;
            float proportionAway = dist / range;
            proportionAway = 1 - proportionAway;
            diff = diff.normalized;
            Vector3 test = (diff * (mMagnitude * proportionAway));
            Debug.Log(test.ToString());
            pData.accumlatedForces += (diff * (mMagnitude * proportionAway));
        }

    }
}
