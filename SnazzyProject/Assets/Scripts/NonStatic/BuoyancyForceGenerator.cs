using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyForceGenerator : ForceGenerator
{
   public Particle2D mObj;

   public float mSurfaceHeight;
   public float mWaterDensity;
   float mArea;
   float mSubmergeDepth;

   private void Start()
   {
      float radius = GetComponent<Renderer>().bounds.extents.magnitude;
      mSubmergeDepth = radius;
      mArea = (radius * radius) * Mathf.PI;//2D circle area formula
      ForceManager.AddForceGenerator(this);
   }

   public void UpdateForces(Particle2D pData)
   {
      Vector3 final = new Vector3();

      Vector3 pos = mObj.transform.position;

      float damp = 1 / (mSurfaceHeight - pos.y);

      if (pos.y < (mSurfaceHeight - mSubmergeDepth))
      {
         final = new Vector3(); // Not in water
      }
      else if (pos.y > (mSurfaceHeight + mSubmergeDepth))//submerged in water
      {
         final.y = -(mArea * mWaterDensity);
      }
      else//in the middle
      {
         float calc = (mWaterDensity * mArea * (pos.y - mSubmergeDepth - mSurfaceHeight) / (2 * mSubmergeDepth));
         final.y = -calc;
      }

      //Add Forces
      mObj.accumlatedForces += final;
   }

   






}
