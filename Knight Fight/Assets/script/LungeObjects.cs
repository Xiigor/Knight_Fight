using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeObjects : MonoBehaviour
{
    // Start is called before the first frame update

    private float spawnTimer;
    public GameObject BoxPrefab;
    public GameObject[] positions;
    private List<GameObject> lungeObjs;
    private float onOffTimer;
    void Start()
    {
        spawnTimer = 0.1f;
        onOffTimer = 3;
    }


    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        onOffTimer -= Time.deltaTime;

        if(onOffTimer < 0)
        {
            if (spawnTimer <= 0)
            {

                GameObject box = Instantiate(BoxPrefab, transform.position, Quaternion.identity) as GameObject;
                box.GetComponent<lungedBox>().Target = positions[Random.Range(0, positions.Length)];
                spawnTimer = 0.01f;
            }
            if(onOffTimer < -3)
            {
                onOffTimer = 3;
            }
        }
       
    }


}
