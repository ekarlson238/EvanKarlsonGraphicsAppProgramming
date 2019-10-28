using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToOrbit;

    [SerializeField]
    private float speed = 20;

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(objectToOrbit.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
