using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExplode : MonoBehaviour
{
    bool hasGrenade = false;
    public Collider explosionRadius;
    public Collider socketCollider;
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
                        Destroy(item.gameObject);
                    }
                }
                // Get all grenade in socketCollider and destroy them
                Collider[] grenades = Physics.OverlapSphere(transform.position, socketCollider.bounds.size.x / 2);
                foreach (Collider grenade in grenades)
                {
                    if (grenade.gameObject.tag == "Grenade")
                    {
                        Destroy(grenade.gameObject);
                    }
                }
                hasGrenade = false;
                explosionRadius.enabled = false;
            }
        }
    }

    public void OnItemPlaced()
    {
        hasGrenade = true;
        explosionRadius.enabled = true;
        Debug.Log(explosionRadius.enabled);
    }
}
