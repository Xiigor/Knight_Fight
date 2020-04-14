using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] Cubes;
    new Vector3 mapSizeMax;
    new Vector3 mapSizeMin;
    void Start()
    {
        mapSizeMax = new Vector3(1587, 1587);
        mapSizeMin = new Vector3(-1587, -1587);
        Cubes = GameObject.FindGameObjectsWithTag("Cub");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mapSizeMax.x);
        Debug.Log(mapSizeMin.x);
        if (mapSizeMax.x > 0 || mapSizeMax.z > 0)
        {
            mapSizeMax.x -= Time.deltaTime * 100;
            mapSizeMax.y -= Time.deltaTime * 100;
        }

        if (mapSizeMin.x < 0 || mapSizeMin.z < 0)
        {
            mapSizeMin.x += Time.deltaTime * 100;
            mapSizeMin.y += Time.deltaTime * 100;
        }

        for (int i = 0; i < Cubes.Length; i++)
        {
            if (Cubes[i] != null)
            {
                if (Cubes[i].transform.position.x > mapSizeMax.x && Cubes[i].transform.position.z > mapSizeMax.z ||
                    Cubes[i].transform.position.x < mapSizeMin.x && Cubes[i].transform.position.z < mapSizeMin.z)
                {
                    Destroy(Cubes[i]);
                }
            }


        }
    }
}
