using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> points;
    public List<GameObject> enimies;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
