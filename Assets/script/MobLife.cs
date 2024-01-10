using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLife : MonoBehaviour
{
    public int life = 100;
    public PlayerStats playerStats;
    public AudioSource DamageSound;
    public AudioSource DieSound;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hit(int damage)
    {
        life -= damage;
        DamageSound.Play();
        anim.SetTrigger("hit");
        if (life <= 0)
        {
            DamageSound.Stop();
            DieSound.Play();
            anim.SetBool("death", true);
            playerStats.addMoney();
            playerStats.mobsKilled += 1;
            //desactivate the rigidbody and collider
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            //destroy the gameobject after 1 second 
            Destroy(gameObject, 1);
        }
    }

    public void OnDestroy()
    {
    }

    public void killedByPass()
    {
        playerStats.mobsPassed += 1;
        playerStats.TakeDamage(5);
        Destroy(gameObject);
    }
}
