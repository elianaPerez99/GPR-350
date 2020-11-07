using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
//Cedric

public static class ContactResolver
{
   public static List<Particle2DContact> mContacts = new List<Particle2DContact>();

   static int mIterations = 1;
   static int mIterationUsed = 0;

   public static void setIterations(int iterations)
   {
      mIterations = iterations;
   }

   public static void addParticleContact(Particle2DContact contact)
   {
      mContacts.Add(contact);
   }

   public static void ResolveContacts()
   {
      while (mIterationUsed < mIterations)
      {
         float max = float.MaxValue;

         int numContacts = mContacts.Count;
         int maxIndex = numContacts;

         for (int i = 0; i < numContacts; i++)
         {
            float sepVel = mContacts[i].CalculateSeparatingVelocity();
            if (sepVel < max && (sepVel < 0.0f || mContacts[i].mPenetration > 0.0f))
            {
               max = sepVel;
               maxIndex = i;
            }
         }

         if (maxIndex == numContacts)
         {

         }
         else
         {

            mContacts[maxIndex].Resolve(Time.deltaTime);

            for (int i = 0; i < numContacts; i++)
            {
               if (mContacts[i].mObj1 == mContacts[maxIndex].mObj1)
               {
                  mContacts[i].mPenetration -= Vector3.Dot(mContacts[maxIndex].mMove1, mContacts[i].mContactNormal);
               }
               else if (mContacts[i].mObj1 == mContacts[maxIndex].mObj2)
               {
                  mContacts[i].mPenetration -= Vector3.Dot(mContacts[maxIndex].mMove2, mContacts[i].mContactNormal);
               }

               if (mContacts[i].mObj2)
               {
                  if (mContacts[i].mObj2 == mContacts[maxIndex].mObj1)
                  {
                     mContacts[i].mPenetration += Vector3.Dot(mContacts[maxIndex].mMove1, mContacts[i].mContactNormal);
                  }
                  else if (mContacts[i].mObj2 == mContacts[maxIndex].mObj2)
                  {
                     mContacts[i].mPenetration -= Vector3.Dot(mContacts[maxIndex].mMove2, mContacts[i].mContactNormal);
                  }
               }



            }
            mIterations++;





         }









      }




   }



}
