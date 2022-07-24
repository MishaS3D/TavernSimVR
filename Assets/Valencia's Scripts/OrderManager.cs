using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public GameObject order1;
    public GameObject order2;
    public GameObject order3;
    public int selectedOrder;
    public GameObject currentOrder;

    public GameObject table1;
    public GameObject table2;
    public GameObject table3;
    public int selectedTable;
    public GameObject currentTable;

    public OrderChecker [] orderCheckers;
    public int score;
    public TextMeshProUGUI scoreText;
    public PickUp pickUp;

    // Start is called before the first frame update
    void Start()
    {

        SelectOrder();
        SelectTable();
        score = 0;
        scoreText.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectOrder()
    {
        selectedOrder = Random.Range(1, 4);
        switch (selectedOrder)
        {
            case 1:
                currentOrder = order1;
                break;
            case 2:
                currentOrder = order2;
                break;
            case 3:
                currentOrder = order3;
                break;
            default:
                Debug.Log("No order selected");
                break;
        }

    }

    public void SelectTable()
    {
        selectedTable = Random.Range(1, 4);
        switch (selectedTable)
        {
            case 1:
                currentTable = table1;
                break;
            case 2:
                currentTable = table2;
                break;
            case 3:
                currentTable = table3;
                break;
            default:
                Debug.Log("No table selected");
                break;
        }
 
    }

    public void CheckOrder()
    {
        foreach (OrderChecker orderChecker in orderCheckers)
        {
            if (currentTable.name == orderChecker.checkedTable.name)
            {
                if (currentOrder.name == pickUp.currentPlateName)
                {
                    Debug.Log("Increase Score");
                    score++;
                    scoreText.text = score.ToString();
                    SelectOrder();
                    SelectTable();
                    break;

                }
            }
        }
       
    }
}
