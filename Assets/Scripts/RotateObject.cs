using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 10;

    private float yRotation ;

    private void Start()
    {
        yRotation = this.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += rotateSpeed * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
