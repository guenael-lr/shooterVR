using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfPath : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if (playerStats != null)
            {
                playerStats.GetComponent<PlayerStats>().TakeDamage(1);
            }
        }
    }
}
