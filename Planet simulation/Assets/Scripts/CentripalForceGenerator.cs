using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CentripalForceGenerator
{

   public static Vector3 CalcCentripalForce(Vector3 vel, float centripitalForces, float radius, float mass)
   {

      //float temp = Vector3.Dot(vel, vel) / radius * mass;

      // velocity = sqrt((force centripital / mass) * r)
      float finVel = Mathf.Sqrt((centripitalForces / mass) * radius);

      float angle = (float)Mathf.Atan(finVel);
      angle *= Mathf.Rad2Deg;


      float x = (float)Mathf.Cos(angle) * finVel;

      float z = (float)Mathf.Cos(angle) * finVel;

      return new Vector3(x, 0.0f, z);
   }


   public static void CalcCentripalForce(PlanetaryObject bigger, PlanetaryObject smaller)
   {
      //float temp = Vector3.Dot(vel, vel) / radius * mass;

      Vector3 planetDiff = bigger.transform.position - smaller.transform.position;

      // velocity = sqrt((force centripital / mass) * r)
      float finVel = Mathf.Sqrt((smaller.mCurrentForces.magnitude / smaller.mMass) * planetDiff.magnitude);

      float angle = (float)Mathf.Atan(finVel);
      angle *= Mathf.Rad2Deg;


      float x = (float)Mathf.Cos(angle) * finVel;

      float z = (float)Mathf.Cos(angle) * finVel;

      smaller.mCurrentVel = new Vector3(x, 0.0f, z);
   }







}
