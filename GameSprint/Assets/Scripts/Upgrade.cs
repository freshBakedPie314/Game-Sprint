using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeTemplate")]
public class Upgrade : ScriptableObject
{
    public string text;
    public int index;
    public PlayerStats data;
    public static Action upgradeSelected;
    public void PerformUpgrade()
    {
        if (index == 0)
        {
            data.health -= 2;
            data.weaponDamage += 1;
            upgradeSelected?.Invoke();
        }
        else if (index == 1)
        {
            data.health -= 1;
            data.weaponKnockBack += 2;
            upgradeSelected?.Invoke();
        }
        else if (index == 2)
        {
            data.weaponDamage -= 1;
            data.weaponKnockBack += 2;
            upgradeSelected?.Invoke();
        }
        else if (index == 3)
        {
            data.weaponDamage -= 1;
            data.weaponDurability += 5;
            upgradeSelected?.Invoke();
        }
        else if (index == 4)
        {
            data.weaponDurability -= 2;
            data.weaponKnockBack += 1;
            upgradeSelected?.Invoke();
        }
        else if (index == 5)
        {
            data.weaponDurability += 5;
            data.health -= 1;
            upgradeSelected?.Invoke();
        }
    }
}
