using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI orderText;
    public string order;
    public OrderManager OrderManager;

    private void Start()
    {
        OrderManager.WrongOrder = false;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (OrderManager.WrongOrder == true)
        {

            order = "Wrong Order";
            orderText.text = order;

        }

        else
        {
            order = OrderManager.currentTable.name + " ordered " + OrderManager.currentOrder.name;
            orderText.text = order;
        }
        
        
        

    }


}
