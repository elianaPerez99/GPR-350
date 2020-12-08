using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour
{
    //Variables
    public float mMass;
    public PlanetaryObject orbitingAround;
    public Vector3 mCurrentForces;
    public Vector3 mInitialVel; //we might need this we might not
    public Vector3 mCurrentVel;
    public Vector3 mCurrentAcc;
    public float semiMajorAxis;

    //Functions
    // Start is called before the first frame update
    void Start()
    {
       // mInitialVel.z = Mathf.Sqrt(6.67408f * Mathf.Pow(10, -11)* mMass *(2.0f/transform.position.x - 1.0f/semiMajorAxis));
        mCurrentVel = mInitialVel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
