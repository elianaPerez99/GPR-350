using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    //variables
    public List<PlanetaryObject> mPlanets;
    //pointer to the sun
    //methods
    private void Start()
    {
        mPlanets = new List<PlanetaryObject>(FindObjectsOfType<PlanetaryObject>());
    }
}
