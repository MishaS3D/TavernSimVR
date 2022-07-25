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

    int timesClonedO1;
    int timesClonedO2;
    int timesClonedO3;

    GameObject newOrder1;
    GameObject newOrder2;
    GameObject newOrder3;
    // Start is called before the first frame update
    void Start()
    {
        timesClonedO1 = 0;
        timesClonedO2 = 0;
        timesClonedO3 = 0;

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
                    if (currentOrder == order1)
                    {
                        if (timesClonedO1 == 0)
                        {

                            newOrder1 = Instantiate(order1, pickUp.currentPlatePosition, Quaternion.identity);
                            newOrder1.name = order1.name;
                            timesClonedO1++;
                            pickUp.selectedPlate.SetActive(false);
                        }
                        else
                        {
                           newOrder1 = Instantiate(newOrder1, pickUp.currentPlatePosition, Quaternion.identity);
                           newOrder1.name = order1.name;
                           pickUp.selectedPlate.SetActive(false);
                        }
                      
       

                    }
                    else if (currentOrder == order2)
                    {

                        if (timesClonedO2 == 0)
                        {

                            newOrder2 = Instantiate(order2, pickUp.currentPlatePosition, Quaternion.identity);
                            newOrder2.name = order2.name;
                            timesClonedO2++;
                            pickUp.selectedPlate.SetActive(false);
                        }
                        else
                        {
                            newOrder2 = Instantiate(newOrder2, pickUp.currentPlatePosition, Quaternion.identity);
                            newOrder2.name = order2.name;
                            pickUp.selectedPlate.SetActive(false);
                        }



                    }
                    else if (currentOrder == order3)
                    {

                        if (timesClonedO3 == 0)
                        {

                            newOrder3 = Instantiate(order3, pickUp.currentPlatePosition, Quaternion.identity);
                            newOrder3.name = order3.name;
                            timesClonedO3++;
                            pickUp.selectedPlate.SetActive(false);
                        }
                        else
                        {
                            newOrder3 = Instantiate(newOrder3, pickUp.currentPlatePosition, Quaternion.identity);
                            newOrder3.name = order3.name;
                            pickUp.selectedPlate.SetActive(false);
                        }



                    }
                    Debug.Log("Completed Order");
                    SelectOrder();
                    SelectTable();


                    break;

                }
            }
        }
       
    }
}
