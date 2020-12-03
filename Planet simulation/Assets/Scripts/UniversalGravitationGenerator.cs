using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class UniversalGravitationGenerator
{
    public static float G = (float)(6.67408 * Math.Pow(10, -11));

    public static Vector3 CalculateForce(PlanetaryObject bigger, PlanetaryObject smaller)
    {
        float xMagnitude = 0;
        float zMagnitude = 0;
        if (smaller.transform.position.x != 0)
        {
            xMagnitude = (float)((G * bigger.mMass * smaller.mMass) / Math.Pow(smaller.transform.position.x, 2));
        }
        if (smaller.transform.position.z != 0)
        {
            zMagnitude = (float)((G * bigger.mMass * smaller.mMass) / Math.Pow(smaller.transform.position.z, 2));
        }

        return new Vector3(xMagnitude, 0.0f, zMagnitude);
    }

    //get acceleration from force
    private static Vector3 GetAcc(float mass, Vector3 force)
    {
        return force / mass;
    }

    //get current velocity based on current acceleration
    private static Vector3 GetVel(Vector3 acc)
    {
        return acc / Time.deltaTime;
    }

    //assuming acceleration and velocity have already been updated based on the force
    private static void UpdatePosition(PlanetaryObject planet)
    {
        planet.transform.position += planet.mCurrentVel * Time.deltaTime + planet.mCurrentAcc * (float)Math.Pow(Time.deltaTime, 2);
    }

    public static void Integrate(PlanetaryObject planet)
    {
        UpdatePosition(planet);
        planet.mCurrentAcc = GetAcc(planet.mMass, planet.mCurrentForces);
        planet.mCurrentVel = GetVel(planet.mCurrentAcc);
        planet.mCurrentForces = new Vector3(0, 0, 0);
    }
}