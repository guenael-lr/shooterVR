using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // get the grenade collider of explosion radius
    public Collider explosionRadius;
    public GameObject explosionEffect;
    public AudioSource explosionAudio;
    // Start is called before the first frame update
    void Start()
    {
        explosionRadius.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");
        //check if collision withh another grenade or the socket of the gun 
        if (collision.gameObject.tag == "Grenade" || collision.gameObject.tag == "SocketGun")
        {
            return;
        }
        Explode();
    }

    void Explode()
    {
        explosionAudio.Play();
        Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
        Collider[] touchedItems = Physics.OverlapSphere(transform.position, explosionRadius.bounds.size.x / 2);
        Debug.Log(touchedItems.Length);
        foreach (Collider item in touchedItems)
        {
            if (item.gameObject.tag == "Enemy")
            {
                item.gameObject.GetComponent<MobLife>().Hit(100);
            }
        }
        //wait 1s before destroying the grenade
        Destroy(gameObject, 1);
    }

    public void PlacedOnTower()
    {
        //Deactivate spheric trigger
        explosionRadius.enabled = false;
    }
}
