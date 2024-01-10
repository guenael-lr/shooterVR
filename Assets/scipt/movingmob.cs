using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movingmob : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] NavMeshAgent agent;
    Transform target;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void SetDestinationFromSpawner(Transform destination)
    {
        target = destination;
    }
}
