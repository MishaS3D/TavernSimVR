using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI orderText;
    string order;
    public OrderManager OrderManager;
    // Start is called before the first frame update
    void Start()
    {
      

        
    }

    // Update is called once per frame
    void Update()
    {
        order = OrderManager.currentTable.name + " ordered " + OrderManager.currentOrder.name;
        orderText.text = order;

    }


}
