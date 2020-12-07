using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
   //variables
   public List<PlanetaryObject> mPlanets;
   //pointer to the sun
   public PlanetaryObject sun;

   //methods
   private void Start()
   {
      mPlanets = new List<PlanetaryObject>(FindObjectsOfType<PlanetaryObject>());
   }


   private void FixedUpdate()
   {

      foreach (PlanetaryObject item in mPlanets)
      {
         if (!item.Equals(sun))
         {
            item.mCurrentForces = UniversalGravitationGenerator.CalculateGravForce(sun, item);
            //Debug.Log("Intergrate: " + item.mCurrentForces);



            UniversalGravitationGenerator.Integrate(item);

         }

      }

   }


}
