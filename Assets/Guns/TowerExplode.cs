using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TowerExplode : MonoBehaviour
{
    bool hasGrenade = false;
    public Collider explosionRadius;
    public Collider socketCollider;
    public GameObject Socket;
    private GameObject grenade;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGrenade)
        {
            Collider[] touchedItems = Physics.OverlapSphere(transform.position, explosionRadius.bounds.size.x / 2);
            int count_ennemies = 0;
            foreach (Collider item in touchedItems)
            {
                if (item.gameObject.tag == "Enemy")
                {
                    count_ennemies++;
                }
            }
            if (count_ennemies > 2)
            {
                foreach (Collider item in touchedItems)
                {
                    if (item.gameObject.tag == "Enemy")
                    {
                        //hit the enemy
                        item.gameObject.GetComponent<MobLife>().Hit(300);
                    }
                }
                //Explode grenade
                grenade.gameObject.GetComponent<Grenade>().Explode();
                hasGrenade = false;
                explosionRadius.enabled = false;
            }
        }
    }

    public void OnItemPlaced(SelectEnterEventArgs args)
    {
        //get item in the socket and use selectTarget
        grenade = args.interactableObject.transform.gameObject;
        Debug.Log(grenade.name);
        hasGrenade = true;
        explosionRadius.enabled = true;
        Debug.Log(explosionRadius.enabled);
    }
}
