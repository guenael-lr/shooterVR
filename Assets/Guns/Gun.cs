using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    InputDevice device;
    private InputDevice targetDevice;
    private float shootSpeed;
    private float shootTime;
    public GameObject bullet;
    public GameObject RefBulletPos;
    public GameObject Grenade;
    public GameObject SocketGrenade;
    private bool grenadeInSocket = false;
    private GameObject grenadeOfGun = null;
    public PlayerStats playerStats;
    public AudioSource fireSound;
    public AudioSource reloadSound;



    // Start is called before the first frame update
    void Start()
    {
        //device is the right controller 
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics RightCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
       
        InputDevices.GetDevicesWithCharacteristics(RightCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        else
            Debug.Log("No devices");

        shootSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        shootSpeed = 0.6f - (playerStats.shootSpeed / 5);
        //fire every shootspeed
        shootTime += Time.deltaTime;
       

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        //get A button on socketButton Device
        if(triggerValue > 0.1f)
        {
            if (shootTime > shootSpeed)
            {

                //create prefab bullet to his own rotation and coordinates
                bullet.transform.position = RefBulletPos.transform.position;
                //set rotation to the same as the controller - 90 degres on x axis
                bullet.transform.rotation = RefBulletPos.transform.rotation;
                //set position to the same far from the gun + 1.f on y axis

                Instantiate(bullet);
                fireSound.Play();
                bullet.GetComponent<bullet>().playerStats = playerStats;
                shootTime = 0.0f;
            }

        }

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool socketButtonValue);
        
        if (socketButtonValue)
        {
            //activate the socket socketGrenade

            if (playerStats.bombsAvailable < 1)
            {
                return;
            }
            //check for item in collider of socket grenade
            grenadeInSocket = false;
            Collider[] touchedItems = Physics.OverlapSphere(transform.position, SocketGrenade.layer);
            foreach (Collider item in touchedItems)
            {
                if (item.gameObject.tag == "Grenade")
                {
                    grenadeInSocket = true;
                }
            }


            if (grenadeOfGun == null && grenadeInSocket == false) {
                //spawn grenade
                grenadeOfGun = Instantiate(Grenade);
                grenadeOfGun.transform.position = SocketGrenade.transform.position;
                grenadeOfGun.transform.rotation = SocketGrenade.transform.rotation;
                playerStats.bombsAvailable -= 1;
            }

        }
        else
        {
            if (grenadeOfGun)
            {
                Destroy(grenadeOfGun);
                grenadeOfGun = null;
                playerStats.bombsAvailable += 1;
            }
        }
    }

    public void OnExitSocket(SelectExitEventArgs args)
    {
        Debug.Log("exit");
        grenadeOfGun = null;
    }

    public void OnEnterSocket(SelectEnterEventArgs args)
    {
        Debug.Log("Onenter");
        grenadeOfGun = args.interactableObject.transform.gameObject;
    }
}
