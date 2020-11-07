using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyForceGenerator : ForceGenerator
{
   public float mSurfaceHeight;
   public float mWaterDensity;
   float mArea;
   float mSubmergeDepth;

   private void Start()
   {
      ForceManager.AddForceGenerator(this);
   }

   public override void UpdateForces(Particle2D pData)
   {
      float radius = pData.gameObject.GetComponent<Renderer>().bounds.extents.magnitude;
      mSubmergeDepth = radius;
      mArea = (radius * radius) * Mathf.PI;//2D circle area formula

      //Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

      Vector3 final = new Vector3();

      Vector3 pos = pData.transform.position;

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
      pData.accumlatedForces += final;
   }

   






}
