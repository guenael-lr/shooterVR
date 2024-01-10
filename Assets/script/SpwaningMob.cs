using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

//here the goal is to spawn monster under a timer
//when timer is of, no more monster spawning
public class SpwaningMob : MonoBehaviour
{
    public float timer = 0;
    public List<GameObject> monsterPrefabs;
    float startTime;
    public Transform startPos;
    public Transform destination;
    public PlayerStats playerstats;
    public GameObject ScoreUI;
    public void Spwaner()
    {
        GameObject monsterPrefab = monsterPrefabs[UnityEngine.Random.Range(0, monsterPrefabs.Count)];
        GameObject spawnedObject = Instantiate(monsterPrefab, startPos.position, startPos.rotation);

        if (spawnedObject.GetComponent<movingmob>()) 
        {
            spawnedObject.GetComponent<movingmob>().SetDestinationFromSpawner(destination);
        }

        if (spawnedObject.GetComponent<MobLife>())
        {
            spawnedObject.GetComponent<MobLife>().playerStats = playerstats;
        }

        /*if (spawnedObject.GetComponent<MovingMob2>())
        {
            spawnedObject.GetComponent<MovingMob2>(); //TODO: give destination infos to MovingMob2
        }*/

    }

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        startTime = Time.time;
        
        while (Time.time < startTime + timer) 
        {
            yield return new WaitForSeconds(5);
            Spwaner();
        }

        Debug.Log("Wave Done");
        //set active scoreui true
        ScoreUI.SetActive(true);
        playerstats.displayStats();
    }
}
