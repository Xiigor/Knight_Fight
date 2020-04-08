using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    private float range;
    private Vector3 hitPos;
    private float hitTime;
    private bool activateCol;
    public GameObject weaponCol;
    void Start()
    {
        hitTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        hitTime -= Time.deltaTime;
        Debug.Log(range);
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && hitTime <= 0)
        {

            activateCol = true;
            hitTime = 0.1f;
        }
        if(activateCol)
        {
            weaponCol.SetActive(true);
        }
        else
        {
            weaponCol.SetActive(false);
        }
        
        if(hitTime <= 0)
        {
            activateCol = false;
            
        }
        
    }
}
