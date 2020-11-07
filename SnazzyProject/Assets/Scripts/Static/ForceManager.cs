using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Eliana
public static class ForceManager
{
    //variables
    private static List<ForceGenerator> mGenerators = new List<ForceGenerator>();

    //functions
    public static void AddForceGenerator(ForceGenerator generator)
    {
        mGenerators.Add(generator);
    }
    public static void RemoveForceGenerator(ForceGenerator generator)
    {
        foreach (ForceGenerator gen in mGenerators)
        {
            if (gen.gameObject.Equals(generator.gameObject))
            {
                mGenerators.Remove(gen);
            }
        }
    }

    public static void ApplyForce(Particle2D pData)
    {
        foreach (ForceGenerator gen in mGenerators)
        {
            if (gen.mShouldAffectAll && !pData.mShouldIgnoreForces)
            {
               gen.UpdateForces(pData);
            }
        }
    }
}
