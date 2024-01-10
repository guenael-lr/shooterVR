using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public ChangeScene changeScene;
    public int health = 50;
    public int money = 100;
    public int shootDamage = 1;
    public float shootSpeed = 1;
    public int bombsAvailable = 2;
    public Text moneyText;
    public Text bombText;
    public Text healthText;

    public GameObject scoresUI;
    public GameObject spawningMobLoop;
    public AudioSource damagePlayer;

    public int mobsKilled = 0;
    public int mobsPassed = 0;
    public int totalMoney = 0;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoresUI.SetActive(false);
        spawningMobLoop.SetActive(true);
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
            scoresUI.SetActive(true);
            this.displayStats();
            spawningMobLoop.SetActive(false);
        }
    }
    public void addBomb()
    {
        bombsAvailable += 1;
    }

    public void addMoney(int amount = 10)
    {
        money += amount;
        totalMoney += amount;
    }

    public void addShootSpeed()
    {
        shootSpeed += 0.5f;
    }

    public void addShootDamage()
    {
        shootDamage += 1;
    }

    public void displayStats()
    {
        //Display stats
        scoresUI.GetNamedChild("MobsPassed").GetComponent<Text>().text = "Mobs passed : " + mobsPassed.ToString();
        scoresUI.GetNamedChild("MobsKilled").GetComponent<Text>().text = "Mobs killed : " + mobsKilled.ToString();
        scoresUI.GetNamedChild("Money").GetComponent<Text>().text = "Total money : " + totalMoney.ToString();
        scoresUI.GetNamedChild("Score").GetComponent<Text>().text = "Score : " + score.ToString();
        scoresUI.GetNamedChild("Health").GetComponent<Text>().text = "Health remaining : " + health.ToString();
    }
}
