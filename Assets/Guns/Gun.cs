using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
                shootTime = 0.0f;
            }

        }

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool socketButtonValue);
        
        if (socketButtonValue)
        {
            //activate the socket socketGrenade
            SocketGrenade.SetActive(true);


            if (playerStats.bombsAvailable < 1)
            {
                return;
            }
            if(grenadeOfGun == null) {

                Collider[] touchedItems = Physics.OverlapSphere(SocketGrenade.transform.position, SocketGrenade.GetComponent<SphereCollider>().bounds.size.x / 2);
                grenadeInSocket = false;
               
                foreach (Collider item in touchedItems)
                {
                    if (item.gameObject.tag == "Grenade")
                    {
                        grenadeInSocket = true;
                    }
                }

                if (!grenadeInSocket)
                {
                    OnExitSocket();
                    Grenade.transform.position = SocketGrenade.transform.position;
                    Grenade.transform.rotation = SocketGrenade.transform.rotation;
                    grenadeOfGun = Instantiate(Grenade);
                }

            }

        }
        else
        {
            SocketGrenade.SetActive(false);
            if (grenadeOfGun)
            {
                //check if grenadeofgun is in sphere collider of socketgrenade
                if (!SocketGrenade.GetComponent<SphereCollider>().bounds.Contains(grenadeOfGun.transform.position))
                {
                    grenadeOfGun = null;
                    
                }
            }
        }
    }

    public void OnExitSocket()
    {
        playerStats.bombsAvailable -= 1;
    }

    public void OnEnterSocket()
    {
        playerStats.bombsAvailable += 1;
    }
}
