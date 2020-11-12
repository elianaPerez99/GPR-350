using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cedric

public static class CollisionDetector
{

   public static bool DetectCollision(Particle2D par1, Particle2D par2)
   {
        float radius = par1.GetComponent<Renderer>().bounds.extents.magnitude;
        float xp = par1.transform.position.x;
        float xc = par2.transform.position.x;
        float yp = par1.transform.position.y;
        float yc = par2.transform.position.y;
        float pow1 = (float)Math.Pow((xp - xc), 2.0f);
        float pow2 = (float)Math.Pow((yp - yc), 2.0f);
        float distance = (float)Math.Sqrt(pow1+pow2);
        return distance <= radius;
    }





}
