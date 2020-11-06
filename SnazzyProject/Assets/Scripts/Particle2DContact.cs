using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cedric

public class Particle2DContact : MonoBehaviour
{

   public Particle2D mObj1;
   public Particle2D mObj2;

   public Vector3 mContactNormal;
   public Vector3 mMove1;
   public Vector3 mMove2;

   public float mRestitutionCo;
   public float mPenetration;


   public void Resolve(float dt)
   {
      ResolveVelocity(dt);
      ResolveInterpretation();      
   }

   public float CalculateSeparatingVelocity()
   {
      Vector3 relativeVelocity = mObj1.mVel;
      if (mObj2 != null)
      {
         relativeVelocity -= mObj2.mVel;
      }

      return Vector3.Dot(relativeVelocity, mContactNormal);
   }

   void ResolveVelocity(float dt)
   {
      float separatingVel = CalculateSeparatingVelocity();

      if (separatingVel > 0.0f)
      {
         
      }
      else
      {

         float newSeperateVel = -separatingVel * mRestitutionCo;

         Vector3 velFromAcc = mObj1.mAcc;

         if (mObj2 != null)
         {
            velFromAcc -= mObj2.mAcc;
         }

         float accCausedSepVelocity = Vector3.Dot(velFromAcc, mContactNormal) * dt;

         if (accCausedSepVelocity < 0.0f)
         {
            newSeperateVel += mRestitutionCo * accCausedSepVelocity;
            if (newSeperateVel < 0.0f)
            {
               newSeperateVel = 0.0f;
            }
         }

         float deltaVel = newSeperateVel - separatingVel;

         float totalInverseMass = mObj1.getInverseMass();
         if (mObj2 != null)
         {
            totalInverseMass += mObj2.getInverseMass();
         }

         if (totalInverseMass <= 0)
         {
            float impulse = deltaVel / totalInverseMass;
            Vector3 impulsePerIMass = mContactNormal * impulse;

            Vector3 newVelocity = mObj1.mVel + impulsePerIMass * mObj1.mMass;
            mObj1.mVel = newVelocity;
            if (mObj2 != null)
            {
               newVelocity = mObj2.mVel + impulsePerIMass * -mObj2.getInverseMass();
               mObj2.mVel = newVelocity;

            }            
         }
      }
   }

   void ResolveInterpretation()
   {
      if (mPenetration <= 0.0f)
      {
         //No penetration skip
      }
      else
      {
         float totalInverseMass = mObj1.getInverseMass();
         if (mObj2 != null)
         {
            totalInverseMass += mObj2.getInverseMass();
         }

         if (totalInverseMass <= 0.0f)
         {
            //No mass skip
         }
         else
         {
            Vector3 movePerIMass = mContactNormal * (mPenetration / totalInverseMass);

            mMove1 = movePerIMass * mObj1.getInverseMass();
            if (mObj2 != null)
            {
               mMove2 = movePerIMass * -mObj2.getInverseMass();
            }
            else
            {
               mMove2 = new Vector3();
            }

            Vector3 newPosition = mObj1.transform.position + mMove1;
            mObj1.transform.position = newPosition;

            if (mObj2 != null)
            {
               newPosition = mObj2.transform.position + mMove2;
               mObj2.transform.position = newPosition;
            }
         }
      }
   }
}
