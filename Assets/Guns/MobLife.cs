using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLife : MonoBehaviour
{
    public int life = 100;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        playerStats.addMoney();
    }
}