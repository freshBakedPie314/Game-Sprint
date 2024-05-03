using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeTemplate")]
public class Upgrade : ScriptableObject
{
    public string text;
    public void PerformUpgrade()
    {
        Debug.Log(text);
    }
}
