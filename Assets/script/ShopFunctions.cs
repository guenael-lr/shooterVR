using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFunctions : MonoBehaviour
{
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyBomb()
    {
        if (playerStats.money >= 10)
        {
            playerStats.money -= 10;
            playerStats.addBomb();
        }
    }

    public void buySpeed()
    {
        if (playerStats.money >= 10)
        {
            playerStats.money -= 10;
            playerStats.addShootSpeed();
        }
    }

    public void buyDamage()
    {
        if (playerStats.money >= 10)
        {
            playerStats.money -= 10;
            playerStats.addShootDamage();
        }
    }
}
