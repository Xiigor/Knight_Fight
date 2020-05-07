using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    // Start is called before the first frame update
    private float rainTimer, rainResetTime;
    public GameObject FishPrefab;
    void Start()
    {
        rainResetTime = 5;
        rainTimer = rainResetTime;
    }

    // Update is called once per frame
    void Update()
    {
        rainTimer -= Time.deltaTime;

        if (rainTimer < 0)
        {
            GameObject Fish = Instantiate(FishPrefab, new Vector3(Random.Range(-62, 4.8f), 320, Random.Range(149f, 249f)), Quaternion.identity) as GameObject;
            Fish.transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            //Destroy(Fish, 3);
            if (rainTimer < -1)
            {
                rainTimer = rainResetTime;
            }
        }
    }
}
