using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cedric

public class Particle2DLink : MonoBehaviour
{
   public Particle2D mObj1;
   public Particle2D mObj2;

   public float GetCurrentLength()
   {
      Vector3 temp = mObj1.transform.position - mObj2.transform.position;
      return temp.magnitude;
   }

   public virtual void CreateContacts(List<Particle2DContact> mContacts) { }
  
}
