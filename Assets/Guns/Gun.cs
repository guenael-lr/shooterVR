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
    // Start is called before the first frame update
    void Start()
    {
        //device is the right controller 
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics RightCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
       
        InputDevices.GetDevicesWithCharacteristics(RightCharacteristics, devices);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

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
        if(triggerValue > 0.1f)
        {
            if (shootTime > shootSpeed)
            {

                //create prefab bullet to his own rotation and coordinates
                bullet.transform.position = transform.position;
                //set rotation to the same as the controller - 90 degres on x axis
                bullet.transform.rotation = transform.rotation * Quaternion.Euler(-90, 0, 0);
                //set position to the same far from the gun + 1.f on y axis

                Instantiate(bullet);
                shootTime = 0.0f;
        }

        }

    }
}
