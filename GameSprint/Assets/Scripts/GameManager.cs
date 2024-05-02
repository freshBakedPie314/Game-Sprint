using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enimies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enimies.Length <= 0) door.isClosed = false;
    }
}
