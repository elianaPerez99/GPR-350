using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour
{
    //Variables
    public float mMass;
    public Vector3 mCurrentForces;
    public Vector3 mInitialVel; //we might need this we might not
    public Vector3 mCurrentVel;
    public Vector3 mCurrentAcc;

    //Functions
    // Start is called before the first frame update
    void Start()
    {
        mCurrentVel = mInitialVel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
