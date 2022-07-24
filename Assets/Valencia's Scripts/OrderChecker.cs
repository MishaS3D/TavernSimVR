using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OrderChecker : MonoBehaviour
{
    public PickUp pickUpScript;
    public OrderManager orderManager;
 
    public GameObject checkedTable;
    private void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player is in" + gameObject.name);
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
