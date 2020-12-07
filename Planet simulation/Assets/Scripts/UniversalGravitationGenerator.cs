using System;
using UnityEngine;

public static class UniversalGravitationGenerator
{
   public static float G = (float)(6.67408 * Math.Pow(10, -11));

   public static Vector3 ZeroDegreeVector = Vector3.right;

   public static Vector3 CalculateGravForce(PlanetaryObject bigger, PlanetaryObject smaller)
   {
      Vector3 planetDist =  smaller.transform.position - bigger.transform.position;

      Vector3 force = (-G * bigger.mMass * smaller.mMass) / Vector3.Dot(planetDist, planetDist) * planetDist.normalized;
      //Debug.Log("Attraction " + (-G * bigger.mMass * smaller.mMass) / Vector3.Dot(planetDist, planetDist));
      return force;
   }


   public static Vector3 SatOrbit(PlanetaryObject smaller)
   {
      Vector3 vec = (float)Math.Sqrt((G * smaller.mMass) / smaller.transform.position.magnitude) * smaller.transform.position.normalized;

      return vec;
   }


   //get acceleration from force
   private static Vector3 GetAcc(float mass, Vector3 force)
   {
      return force / mass;
   }

   //get current velocity based on current acceleration
   private static Vector3 GetVel(Vector3 acc)
   {
      return acc * Time.deltaTime;
   }

   //assuming acceleration and velocity have already been updated based on the force
   private static void UpdatePosition(PlanetaryObject planet)
   {

      //planet.transform.position = planet.mCurrentVel * Time.deltaTime;
      planet.transform.position += planet.mInitialVel * Time.deltaTime + planet.mCurrentAcc * (float)Math.Pow(Time.deltaTime, 2) * 0.5f;

     //Debug.Log("Update: " + planet.mCurrentForces);
      

   }

   public static void Integrate(PlanetaryObject planet)
   {
        
        //UpdatePosition(planet);
        //testing
        planet.mCurrentAcc += GetAcc(planet.mMass, planet.mCurrentForces);
        planet.mCurrentVel += GetVel(planet.mCurrentAcc);
        planet.transform.position += planet.mCurrentVel * Time.deltaTime;
        planet.mCurrentForces = new Vector3(0, 0, 0);
   }

   public static Vector3 SqrtVector3(Vector3 vec)
   {
      vec.x = Mathf.Sqrt(vec.x);
      vec.y = Mathf.Sqrt(vec.y);
      vec.z = Mathf.Sqrt(vec.z);

      return vec;
   }


   public static Vector3 AbsVector3(Vector3 vec)
   {
      float x = Math.Abs(vec.x);
      float y = Math.Abs(vec.y);
      float z = Math.Abs(vec.z);

      return new Vector3(x, y, z);
   }


}