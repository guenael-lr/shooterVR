using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public ChangeScene changeScene;
    public int health = 50;
    public int money = 100;
    public int shootDamage = 1;
    public int shootSpeed = 1;
    public int bombsAvailable = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
