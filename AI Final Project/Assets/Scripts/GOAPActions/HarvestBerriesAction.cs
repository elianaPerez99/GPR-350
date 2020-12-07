using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestBerriesAction : GOAPAction
{
   bool done = false;

   BerryBush bushTarget;

   public float startTime = 0;
   public float actionDuration = 2.0f;

   public HarvestBerriesAction()
   {
      actionCost = 8f;
      addPrecondition("hasFood", false);
      addEffect("hasFood", true);
   }

   public override bool isDone()
   {
      return done;
   }
   public override void reset()
   {
      startTime = 0;
      done = false;
      bushTarget = null;
   }
   public override bool requiresInRange()
   {
      return true;
   }

   public override bool checkProceduralPrecondition(GameObject agent)
   {
      BerryBush[] bushes = FindObjectsOfType<BerryBush>();
      BerryBush closestBush = null;
      float closestDist = 0f;

      foreach (BerryBush bush in bushes)
      {
         if (closestBush == null)
         {
            closestBush = bush;
            closestDist = (bush.transform.position - agent.transform.position).magnitude;
         }
         else
         {
            float temp = (bush.transform.position - agent.transform.position).magnitude;
            if (temp < closestDist)
            {
               closestBush = bush;
               closestDist = temp;
            }
         }

         bushTarget = closestBush;
         target = closestBush.gameObject;
      }

      return closestBush != null;
   }

   

   public override bool perform(GameObject agent)
   {
      if (startTime == 0)
      {
         startTime = Time.time;
      }

      if (Time.time - startTime > actionDuration)
      {
         

      }



      return true;
   }

}
