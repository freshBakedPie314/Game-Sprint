using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> points;
    public List<GameObject> enimies;

    GameObject player;
    public Transform playerSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Spwan();
        Upgrade.upgradeSelected += Spwan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spwan()
    {
        foreach (Transform t in points)
        {
            Instantiate(enimies[Random.Range(0 , enimies.Count)] , t.position , Quaternion.identity);
        }

        player.GetComponent<Rigidbody2D>().MovePosition(playerSpawn.position);
    }
}
