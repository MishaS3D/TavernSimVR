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

    public Transform order1Position;
    public Transform order2Position;
    public Transform order3Position;

    public bool WrongOrder;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

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
        WrongOrder = false;

    }

    // Update is called once per frame
    void Update()
    {
     // CheckOrder();

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

  
    IEnumerator WrongOrderTimer()
    {
        WrongOrder = true;
        yield return new WaitForSeconds(1);
        WrongOrder = false;
    }
   
    public void SpawnPlateCorrect()
    {
        if (currentOrder.name == order1.name)
        {
            if (timesClonedO1 == 0)
            {

                newOrder1 = Instantiate(order1, order1Position.position, Quaternion.identity);
                newOrder1.name = order1.name;
                timesClonedO1++;
                pickUp.selectedPlate.SetActive(false);
            }
            else
            {
                newOrder1 = Instantiate(newOrder1, order1Position.position, Quaternion.identity);
                newOrder1.name = order1.name;
                pickUp.selectedPlate.SetActive(false);
            }



        }
        else if (currentOrder.name == order2.name)
        {

            if (timesClonedO2 == 0)
            {

                newOrder2 = Instantiate(order2, order2Position.position, Quaternion.identity);
                newOrder2.name = order2.name;
                timesClonedO2++;
                pickUp.selectedPlate.SetActive(false);
            }
            else
            {
                newOrder2 = Instantiate(newOrder2, order2Position.position, Quaternion.identity);
                newOrder2.name = order2.name;
                pickUp.selectedPlate.SetActive(false);
            }



        }
        else if (currentOrder.name == order3.name)
        {

            if (timesClonedO3 == 0)
            {

                newOrder3 = Instantiate(order3, order3Position.position, Quaternion.identity);
                newOrder3.name = order3.name;
                timesClonedO3++;
                pickUp.selectedPlate.SetActive(false);
            }
            else
            {
                newOrder3 = Instantiate(newOrder3, order3Position.position, Quaternion.identity);
                newOrder3.name = order3.name;
                pickUp.selectedPlate.SetActive(false);
            }



        }
    }

    public void SpawnPlateWrong()
    {

        if (pickUp.selectedPlate.name == order1.name)
        {
            if (timesClonedO1 == 0)
            {

                newOrder1 = Instantiate(order1, order1Position.position, Quaternion.identity);
                newOrder1.name = order1.name;
                timesClonedO1++;
                pickUp.selectedPlate.SetActive(false);
                return;
            }
            else
            {
                newOrder1 = Instantiate(newOrder1, order1Position.position, Quaternion.identity);
                newOrder1.name = order1.name;
                pickUp.selectedPlate.SetActive(false);
                return;
            }



        }
        else if (pickUp.selectedPlate.name == order2.name)
        {
            Debug.Log("Spawn Plate wrong - Order 2");
            if (timesClonedO2 == 0)
            {

                newOrder2 = Instantiate(order2, order2Position.position, Quaternion.identity);
                newOrder2.name = order2.name;
                timesClonedO2++;
                pickUp.selectedPlate.SetActive(false);
                return;
            }
            else
            {
                newOrder2 = Instantiate(newOrder2, order2Position.position, Quaternion.identity);
                newOrder2.name = order2.name;
                pickUp.selectedPlate.SetActive(false);
                return;
            }



        }
        else if (pickUp.selectedPlate.name == order3.name)
        {
            Debug.Log("Spawn Plate wrong - Order 3");
            if (timesClonedO3 == 0)
            {

                newOrder3 = Instantiate(order3, order3Position.position, Quaternion.identity);
                newOrder3.name = order3.name;
                timesClonedO3++;
                pickUp.selectedPlate.SetActive(false);
                return;
            }
            else
            {
                newOrder3 = Instantiate(newOrder3, order3Position.position, Quaternion.identity);
                newOrder3.name = order3.name;
                pickUp.selectedPlate.SetActive(false);
                return;
            }



        }
    }

    public void CheckOrder()
    {
        foreach (OrderChecker orderChecker in orderCheckers)
        {

         
            if (currentTable.name == orderChecker.checkedTable.name )
            {
                if (currentOrder.name == pickUp.selectedPlate.name)
                {
                    WrongOrder = false;
                    score++;
                    scoreText.text = score.ToString();
                    orderChecker.atTable = false;


                    SpawnPlateCorrect();


                    SelectOrder();
                    SelectTable();


                    break;

                }
                else 
                {

                    StartCoroutine(WrongOrderTimer());
                    SpawnPlateWrong();
                    break;
  
                }
               
                
            }
            
        }
       
    }
}
