using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject spawnLocation;
    public GameObject player;
    private Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        //Går in i Resource mappen och hämtar prefaben Cube.
        //player = (GameObject)Resources.Load("Cube", typeof(GameObject));

        spawnLocation = GameObject.FindGameObjectWithTag("SpawnPoint");

        //Sätter respawnLocation till spelarens position, vet inte riktigt meningen med denna raden kod, kommer från någon tutorial.
        //https://www.youtube.com/watch?time_continue=22&v=6jJ6T8M_DcM&feature=emb_logo
        respawnLocation = player.transform.position;

        //player.transform.position = new Vector3();

        SpawnCharacter();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCharacter()
    {
        GameObject.Instantiate(player, spawnLocation.transform.position, Quaternion.identity);

    }
}
