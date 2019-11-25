using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    private Planet myPlanet;

    // Start is called before the first frame update
    void Start()
    {
        myPlanet = GetComponentInChildren<Planet>();

        myPlanet.GeneratePlanet();
    }
}
