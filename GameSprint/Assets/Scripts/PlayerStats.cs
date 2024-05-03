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
        weaponDamage = 35;
        playerSpeed = 5;
        weaponKnockBack = 3;
        weaponDurability = 20;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
