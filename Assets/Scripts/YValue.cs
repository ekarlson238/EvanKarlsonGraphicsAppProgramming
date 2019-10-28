using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YValue : MonoBehaviour
{
    public float yValue = 0;
    public static YValue ins;

    private void Awake()
    {
        ins = this;
    }
}
