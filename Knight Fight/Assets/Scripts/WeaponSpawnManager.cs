using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnManager : MonoBehaviour
{
    private List<GameObject> weaponSpawnPointList = new List<GameObject>();
    public List<GameObject> weaponsList = new List<GameObject>();
    public int maxWeaponsActive; 
    public float weaponSpawnRate = 5.0f;
    private float spawnTimer = 0;
    [HideInInspector] public int activeWeapons;
    private int SpawnPointCount;
    private int WeaponsCount;
    void Start()
    {
        activeWeapons = 0;
        weaponSpawnPointList.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));
        SpawnPointCount = weaponSpawnPointList.Count;
        WeaponsCount = weaponsList.Count;
    }

    void Update()
    {
        spawnTimer = spawnTimer + Time.deltaTime;
        Debug.Log(activeWeapons);
        if (spawnTimer >= weaponSpawnRate && activeWeapons < maxWeaponsActive)
        {
            SpawnWeapon();
            activeWeapons++;
            spawnTimer = 0;
        }

    }

    void SpawnWeapon()
    {
        // Väljer vilken spawn vapnet kommer ifrån
        int randomInt = Random.Range(0, SpawnPointCount);
        GameObject spawnPoint = weaponSpawnPointList[randomInt];
        Vector3 spawnPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        // Väljer vilket vapen helt random ej baserat på rarity ännu
        randomInt = Random.Range(0, WeaponsCount);
        GameObject newWeapon = Instantiate(weaponsList[randomInt]);
        newWeapon.transform.position = spawnPos;
        newWeapon.transform.rotation = spawnPoint.transform.rotation;
        newWeapon.GetComponent<Rigidbody>().velocity += (newWeapon.transform.forward * spawnPoint.GetComponent<WeaponSpawnPoint>().forwardSpeed) + (newWeapon.transform.up * spawnPoint.GetComponent<WeaponSpawnPoint>().upSpeed);
        
    }

}
