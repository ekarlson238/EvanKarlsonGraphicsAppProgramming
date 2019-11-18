using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcMesh : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] trianglePoints;

    [Tooltip("The magnitude of each vector from the orgin")]
    public float magnitude;
    private const int minVert = 5;
    [Tooltip("Must be greater than 5")]
    public int vertNum = minVert;
    private int numOfFaces;

    private int vertSave = 0;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        numOfFaces = (vertNum - 2) * 2;
    }

    private void Update()
    {
        MakeMeshData2();
        //UpdateDynamicProcMeshIfFaceChange();
        CreateMesh();
    }

    void Make3DMeshData()
    {
        vertices = new Vector3[] { new Vector3(-0.5f, 0, 0),
            new Vector3(0, 0, -0.5f),
            new Vector3(0, 0, 0.5f),
            new Vector3(0, 1, 0) };

        trianglePoints = new int[12];
        
        trianglePoints[0] = trianglePoints[8] = trianglePoints[9] = 0;
        trianglePoints[2] = trianglePoints[3] = trianglePoints[10] = 1;
        trianglePoints[5] = trianglePoints[6] = trianglePoints[11] = 2;
        trianglePoints[1] = trianglePoints[4] = trianglePoints[7] = 3;
    }

    void MakeMeshData()
    {
        vertices = new Vector3[] { new Vector3(-0.5f, 0, 0),
            new Vector3(0, 0, -0.5f),
            new Vector3(0, 0, 0.5f),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0) };

        trianglePoints = new int[18];

        trianglePoints[0] = trianglePoints[8] = trianglePoints[11] = trianglePoints[15] = 0;
        trianglePoints[2] = trianglePoints[3] = trianglePoints[9] = trianglePoints[14] = 1;
        trianglePoints[5] = trianglePoints[6] = trianglePoints[12] = trianglePoints[17] = 2;
        trianglePoints[1] = trianglePoints[4] = trianglePoints[7] = 3;
        trianglePoints[10] = trianglePoints[13] = trianglePoints[16] = 4;
    }

    void MakeMeshData2()
    {
        vertices = new Vector3[] { new Vector3(-1, 0, 0),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0) };

        trianglePoints = new int[24];

        trianglePoints[0] = trianglePoints[11] = trianglePoints[12] = trianglePoints[23] = 0;
        trianglePoints[2] = trianglePoints[3] = trianglePoints[20] = trianglePoints[21] = 1;
        trianglePoints[8] = trianglePoints[9] = trianglePoints[14] = trianglePoints[15] = 2;
        trianglePoints[1] = trianglePoints[4] = trianglePoints[7] = trianglePoints[10] = 3;
        trianglePoints[13] = trianglePoints[16] = trianglePoints[19] = trianglePoints[22] = 4;
        trianglePoints[5] = trianglePoints[6] = trianglePoints[17] = trianglePoints[18] = 5;
    }

    void MakeDynamicMeshData()
    {
        vertices = new Vector3[numOfFaces];

        int numOfCenterSections; //TODO use this later

        int numOfCenterVerts = vertNum - 2;
        float radSectionValue = 2 / numOfCenterVerts;
        float radPosition = 0;

        //creating vertices
        for (int i = 0; i < vertNum; i++)
        {
            if (i == 0)
                vertices[i] = new Vector3(0, magnitude, 0);
            else if (i == 1)
                vertices[i] = new Vector3(0, -magnitude, 0);
            else
            {
                vertices[i] = new Vector3(Mathf.Sin(radSectionValue * radPosition), 0, Mathf.Cos(radSectionValue * radPosition)).normalized * magnitude;
                radPosition++;
            }
        }

        int triangleCenterPointCounter = 0;
        int builtFaceCount = 0;
        //creating triangles
        for (int i = 0; i < numOfFaces; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j + 1 % 2 == 0)
                {
                    if (builtFaceCount >= numOfFaces / 2)
                        trianglePoints[i + 1 + builtFaceCount] = 1; //bottom
                    else
                        trianglePoints[i + 1 + builtFaceCount] = 0; //top
                }
                else //TODO Finish this part, it wont work yet!
                {
                    //top
                    if (builtFaceCount < numOfFaces / 2)
                    {
                        //skip the top and bottom points
                        trianglePoints[i + builtFaceCount] = trianglePoints[i + builtFaceCount + 1] = i + 2 - triangleCenterPointCounter;
                        triangleCenterPointCounter++;
                    }
                    else //bottom
                    {
                        if (builtFaceCount == numOfFaces / 2)
                        {
                            trianglePoints[i] = i + 2 - triangleCenterPointCounter - numOfFaces;
                            triangleCenterPointCounter++;
                        }
                    }
                }
            }
            
            builtFaceCount++;
            triangleCenterPointCounter = 0;
        }
    }

    private void UpdateDynamicProcMeshIfFaceChange()
    {
        if (vertNum >= minVert && vertNum != vertSave)
        {
            MakeDynamicMeshData();
            vertSave = vertNum;
        }
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = trianglePoints;

        mesh.RecalculateNormals();
    }
}
