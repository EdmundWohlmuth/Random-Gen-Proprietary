using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    [Header("City Params")]
    public float width;
    public float depth;
    public float amplitude;
    public int blocks;

    [Range(0, 10)]
    public int streetFrequency;

    private float xOffSet;
    private float zOffSet;
    bool isXStreet = false;

    [Header("Other Values")]
    public float[] zStreets;
    public GameObject levelMesh;


    // Start is called before the first frame update
    void Start()
    {
        NewGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(0);
        }
    }

    void NewGeneration()
    {
        xOffSet = 0;
        zOffSet = 0;

        for (int f = 0; f < blocks; f++)
        {
            for (int i = 0; i < blocks; i++)
            {
                CreateZStreets();
                GenCity();
                zOffSet += depth + 2;
            }
            this.transform.position = new Vector3(xOffSet, 0, zOffSet);
            zOffSet = 0;
            xOffSet += width + 2;
        }
    }

    void GenCity()
    {
        int i = 1;

        for (int x = 1; x < width; x += 2)
        {
            if (Random.Range(1, 10) <= streetFrequency) isXStreet = true;

            for (int z = 1; z < depth; z += 2)
            {
                if (!isXStreet)
                {
                    if (z != zStreets[i])
                    {

                        float Y = Random.Range(1f, amplitude);
                        float X = Random.Range(0.75f, 2.5f);
                        float Z = Random.Range(0.75f, 2.5f);

                        GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        building.transform.position = new Vector3(x + xOffSet, (Y / 2), z + zOffSet);
                        building.transform.localScale = new Vector3(X, Y, Z);
                        building.transform.parent = levelMesh.transform;
                    }
                }
                else
                {
                    /*GameObject test = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    test.transform.position = new Vector3(x, 0, z);
                    test.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);*/
                }
                i += 2;
            }
            i = 1;
            isXStreet = false;
        }
    }

    void CreateZStreets()
    {
        zStreets = new float[((long)width)];

        for (int x = 1; x < width; x += 2)
        {
            if (Random.Range(1, 10) <= streetFrequency)
            {

                for (int z = 1; z < depth; z +=2)
                {
                    /*GameObject test = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    test.transform.position = new Vector3(z, 0, x);
                    test.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);*/

                    //Debug.Log(x);

                    zStreets[x] = x;
                }
            }

        }

    }

    float PerlinNoise2D(float x, float y)
    {
        return ((Mathf.PerlinNoise(x, y) * 2.0f) - 1.0f);
    }
}
