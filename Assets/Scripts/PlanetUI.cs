using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUI : MonoBehaviour
{
    public Planet planet;

    public void Generate()
    {
        if (planet != null)
        {
            planet.GeneratePlanet();
        }
    }

    public void SetPersistance(float value)
    {
        if (planet != null)
        {
            if (planet.shapeSettings.noiseLayers[0] != null)
            {
                planet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.persistence = value;
            }
        }
    }

    public void SetStrength(float value)
    {
        if (planet != null)
        {
            if (planet.shapeSettings.noiseLayers[0] != null)
            {
                planet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.strength = value;
            }
        }
    }

    public void SetBaseRoughness(float value)
    {
        if (planet != null)
        {
            if (planet.shapeSettings.noiseLayers[0] != null)
            {
                planet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.baseRoughness = value;
            }
        }
    }

    public void SetRoughness(float value)
    {
        if (planet != null)
        {
            if (planet.shapeSettings.noiseLayers[0] != null)
            {
                planet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.roughness = value;
            }
        }
    }

    public void SetNoiseCenter(float value)
    {
        if (planet != null)
        {
            if (planet.shapeSettings.noiseLayers[0] != null)
            {
                planet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.centre.x = value;
            }
        }
    }

    public void SetMinNoiseValue(float value)
    {
        if (planet != null)
        {
            if (planet.shapeSettings.noiseLayers[0] != null)
            {
                planet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.minValue = value;
            }
        }
    }
}
