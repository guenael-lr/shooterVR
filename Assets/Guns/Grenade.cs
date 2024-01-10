using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // get the grenade collider of explosion radius
    public Collider explosionRadius;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");
        Explode();
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
        Collider[] touchedItems = Physics.OverlapSphere(transform.position, explosionRadius.bounds.size.x / 2);
        Debug.Log(touchedItems.Length);
        foreach (Collider item in touchedItems)
        {
            if (item.gameObject.tag == "Enemy")
            {
                Destroy(item.gameObject);
            }
        }
        Destroy(gameObject);
    }

    public void PlacedOnTower()
    {
        //Deactivate spheric trigger
        explosionRadius.enabled = false;
    }
}
