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

           // Debug.Log("Player is at  " + this.gameObject);
            checkedTable = this.gameObject;


            if (pickUpScript.placed == true && atTable == true)
            {

                orderManager.CheckOrder();
                pickUpScript.placed = false;
                atTable = false;

                //Debug.Log(pickUpScript.currentPlateName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            atTable = false;

            checkedTable = this.gameObject;
        }
        
    }


}
