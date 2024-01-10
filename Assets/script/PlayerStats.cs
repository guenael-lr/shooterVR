using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public ChangeScene changeScene;
    public int health = 50;
    public int money = 100;
    public int shootDamage = 1;
    public int shootSpeed = 1;
    public int bombsAvailable = 2;
    public Text moneyText;
    public Text bombText;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
        bombText.text = bombsAvailable.ToString();
        healthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Game Over");
            changeScene.ChangeSceneTo();
        }
    }
    public void addBomb()
    {
        bombsAvailable += 1;
    }

    public void addMoney()
    {
        money += 10;
    }

    public void addShootSpeed()
    {
        shootSpeed += 5;
    }

    public void addShootDamage()
    {
        shootDamage += 1;
    }
}
