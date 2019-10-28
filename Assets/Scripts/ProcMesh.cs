using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcMesh : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        
    }

    private void Update()
    {
        MakeMeshData2();
        CreateMesh();
    }

    void Make3DMeshData()
    {
        vertices = new Vector3[] { new Vector3(-0.5f, 0, 0),
            new Vector3(0, 0, -0.5f),
            new Vector3(0, 0, 0.5f),
            new Vector3(0, 1, 0) };

        triangles = new int[12];
        
        triangles[0] = triangles[8] = triangles[9] = 0;
        triangles[2] = triangles[3] = triangles[10] = 1;
        triangles[5] = triangles[6] = triangles[11] = 2;
        triangles[1] = triangles[4] = triangles[7] = 3;
    }

    void MakeMeshData()
    {
        vertices = new Vector3[] { new Vector3(-0.5f, 0, 0),
            new Vector3(0, 0, -0.5f),
            new Vector3(0, 0, 0.5f),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0) };

        triangles = new int[18];

        triangles[0] = triangles[8] = triangles[11] = triangles[15] = 0;
        triangles[2] = triangles[3] = triangles[9] = triangles[14] = 1;
        triangles[5] = triangles[6] = triangles[12] = triangles[17] = 2;
        triangles[1] = triangles[4] = triangles[7] = 3;
        triangles[10] = triangles[13] = triangles[16] = 4;
    }

    void MakeMeshData2()
    {
        vertices = new Vector3[] { new Vector3(-1, 0, 0),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0) };

        triangles = new int[24];

        triangles[0] = triangles[11] = triangles[12] = triangles[23] = 0;
        triangles[2] = triangles[3] = triangles[20] = triangles[21] = 1;
        triangles[8] = triangles[9] = triangles[14] = triangles[15] = 2;
        triangles[1] = triangles[4] = triangles[7] = triangles[10] = 3;
        triangles[13] = triangles[16] = triangles[19] = triangles[22] = 4;
        triangles[5] = triangles[6] = triangles[17] = triangles[18] = 5;
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
