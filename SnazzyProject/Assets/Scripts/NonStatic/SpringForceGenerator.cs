using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Eliana
public class SpringForceGenerator : ForceGenerator
{
    //variables
    public Particle2D mP1;
    public Particle2D mP2;
    public float springConstant;
    public float restLength;
    void Start()
    {
        mShouldAffectAll = false;
    }

    private void FixedUpdate()
    {
        UpdateForces();
    }

    public void UpdateForces()
    {
        //actual spring stuff
        if (mP1.Equals(null) || mP2.Equals(null))
        {
            return;
        }
        Vector2 pos1 = new Vector2(mP1.transform.position.x, mP1.transform.position.y);
        Vector2 pos2 = new Vector2(mP2.transform.position.x, mP2.transform.position.y);
        Vector2 diff = pos1 - pos2;
        float dist = diff.magnitude;
        float mag = dist - restLength;
        if (mag < 0.0f)
        {
            mag = -mag;
        }
        mag *= springConstant;
        diff = diff.normalized;
        diff *= -mag;
        mP1.accumlatedForces += new Vector3(diff.x, diff.y, 0) ;
        mP2.accumlatedForces += new Vector3(-diff.x, -diff.y, 0);
    }
}
