using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int health;
    public float weaponDamage;
    public float playerSpeed;
    public float weaponKnockBack;
    public float weaponDurability;

    
    private void OnEnable()
    {
        health = 5;
        weaponDamage = 2;
        playerSpeed = 5;
        weaponKnockBack = 5.5f;
        weaponDurability = 20;
    }
}
