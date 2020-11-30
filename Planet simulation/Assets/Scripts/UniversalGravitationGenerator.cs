using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class UniversalGravitationGenerator
{
    public static float G = (float)(6.67408 * Math.Pow(10, -11));

    public static float CalculateForce(PlanetaryObject bigger, PlanetaryObject smaller)
    {
        return (float)((G * bigger.mMass * smaller.mMass) / Math.Pow(smaller.transform.position.x,2));
    }

    //get acceleration from force
    public static float getAcc(float mass, float force)
    {
        return force / mass;
    }

    //get current velocity based on current acceleration
    public static float getVel(float acc)
    {
        return acc / Time.deltaTime;
    }

    //assuming acceleration and velocity have already been updated based on the force
    public static void UpdatePosition(PlanetaryObject planet)
    {
        planet.transform.position += planet.mCurrentVel * Time.deltaTime + planet.mCurrentAcc * (float)Math.Pow(Time.deltaTime, 2);
    }
}