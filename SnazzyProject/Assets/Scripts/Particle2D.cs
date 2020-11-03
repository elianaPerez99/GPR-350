using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
   public float mMass;
   public float mDamp;
   public Vector2 mVel;
   public Vector2 mAcc;

   Vector2 accumlatedForces;
}
