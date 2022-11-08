using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public int width;
    public int depth;

    bool isXStreet = false;
    bool isYStreet = false;

    // Start is called before the first frame update
    void Start()
    {
        GenCity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenCity()
    {
        for (int x = 0; x < width; x++)
        {
            if (Random.Range(1, 10) < 2) isXStreet = true;

            for (int z = 0; z < depth; z++)
            {
                float y = Random.Range(1f, 3.5f);

                if (!isXStreet)
                {
                    GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    building.transform.position = new Vector3(x, (y / 2), z);
                    building.transform.localScale = new Vector3(.75f, y, .75f);
                }
            }

            isXStreet = false;
        }
    }
}
