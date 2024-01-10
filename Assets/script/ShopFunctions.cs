using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFunctions : MonoBehaviour
{
    public PlayerStats playerStats;
    public int numberOfSpeedBought = 0;
    public AudioSource buy;
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
            buy.Play();
            playerStats.money -= 10;
            playerStats.addBomb();
        }
    }

    public void buySpeed()
    {
        if (numberOfSpeedBought >= 4)
        {
            return;
        }
        if (playerStats.money >= 100)
        {
            buy.Play();
            playerStats.money -= 100;
            playerStats.addShootSpeed();
            numberOfSpeedBought += 1;
        }
    }

    public void buyDamage()
    {
        if (playerStats.money >= 10)
        {
            buy.Play();
            playerStats.money -= 10;
            playerStats.addShootDamage();
        }
    }
}
