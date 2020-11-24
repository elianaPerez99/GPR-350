using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour
{
    //Variables
    public float mMass;
    public float mInitialVel; //we might need this we might not
    public float mCurrentVel;
    public float mCurrentAcc;

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
