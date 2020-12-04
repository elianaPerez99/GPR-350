using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class UniversalGravitationGenerator
{
   public static float G = (float)(6.67408 * Math.Pow(10, -11));

   public static Vector3 CalculateForce(PlanetaryObject bigger, PlanetaryObject smaller)
   {
      //float magnitude = (float)((G * bigger.mMass * smaller.mMass) / Math.Pow(smaller.transform.position.magnitude, 2));

      //Vector3 planetDiff = bigger.transform.position - smaller.transform.position
      //float magnitude = G * ((bigger.mMass * smaller.mMass) / Vector3.Dot(planetDiff, planetDiff));

      //Debug.Log(Vector3.Dot(planetDiff, planetDiff));

      float magnitude = (float)((G * bigger.mMass * smaller.mMass) / Math.Pow(smaller.transform.position.magnitude, 2));
      float angle = (float)Math.Atan(magnitude);
      angle *= Mathf.Rad2Deg;


      float xMagnitude = (float)Math.Cos(angle) * magnitude;
      if (smaller.transform.position.x < 0)
      {
         xMagnitude *= -1;
      }

      float zMagnitude = (float)Math.Cos(angle) * magnitude;
      if (smaller.transform.position.z < 0)
      {
         zMagnitude *= -1;
      }

      return new Vector3(xMagnitude, 0.0f, zMagnitude);
   }

   //get acceleration from force
   private static Vector3 GetAcc(float mass, Vector3 force)
   {
      return force / mass;
   }

   //get current velocity based on current acceleration
   private static Vector3 GetVel(Vector3 acc)
   {
      return acc * Time.deltaTime;//Cedric Code
      //return acc / Time.deltaTime;
   }

   //assuming acceleration and velocity have already been updated based on the force
   private static void UpdatePosition(PlanetaryObject planet)
   {
      planet.transform.position += planet.mCurrentVel * Time.deltaTime; //Cedric Code
      //planet.transform.position += planet.mCurrentVel * Time.deltaTime + planet.mCurrentAcc * (float)Math.Pow(Time.deltaTime, 2);
   }

   public static void Integrate(PlanetaryObject planet)
   {
      UpdatePosition(planet);
      planet.mCurrentAcc = GetAcc(planet.mMass, planet.mCurrentForces);
      planet.mCurrentVel = GetVel(planet.mCurrentAcc);
      planet.mCurrentForces = new Vector3(0, 0, 0);
   }
}