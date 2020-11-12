
using UnityEngine;
//Eliana
public static class Integrator
{
    //functions
    public static void Integrate(Particle2D pData)
    {
        if (!float.IsNaN(pData.mVel.x) || !float.IsNaN(pData.mVel.y))
        {
            pData.transform.position += (pData.mVel * Time.deltaTime);
            Vector3 resultingAcc = pData.mAcc;
            if (!pData.mShouldIgnoreForces)
            {
                resultingAcc += pData.accumlatedForces / pData.mMass;
            }

            pData.mVel += resultingAcc * Time.deltaTime;
            pData.mVel *= pData.mDamp;

            pData.accumlatedForces = new Vector3(0, 0, 0);
        }
            
        
    }

}
