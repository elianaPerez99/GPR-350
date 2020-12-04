using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CentripalForceGenerator
{


   public static Vector3 CalcCentripalAcc(Vector3 vel, float radius, float mass)
   {

      float temp = Vector3.Dot(vel, vel) / radius * mass;

      // velocity = sqrt(G * earthMass / r)



      return new Vector3();
   }








}
