using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespwanMob : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Object destroyed");
        }
    }

}
