using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private static PickupManager instance;
    [SerializeField] GameObject pickupHealth;
    [SerializeField] GameObject pickupMana;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
    public static PickupManager GetInstance()
    {
        return instance;
    }

    public void OnTriggerEnter(Collider other)
    {


    }






}
