using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OrderChecker : MonoBehaviour
{
    public PickUp pickUpScript;
    public OrderManager orderManager;
    public bool atTable;
    public GameObject checkedTable;
    private void Start()
    {
        atTable = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            atTable=true;
            checkedTable = this.gameObject;


            if (pickUpScript.placed == true)
            {
                orderManager.CheckOrder();
                pickUpScript.placed = false;

                //Debug.Log(pickUpScript.currentPlateName);
            }
        }
    }

   
}
