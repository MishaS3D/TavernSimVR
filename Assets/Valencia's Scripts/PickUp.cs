using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp: MonoBehaviour
{
    [SerializeField] LayerMask PickupMask;
    [SerializeField] LayerMask DropOffMask;
    [SerializeField] Camera PlayerCamera;
    [SerializeField] Transform PickupTarget;
    [SerializeField] Transform DropOffTarget;
    [Space]
    [SerializeField] float PickupRange;

    [SerializeField] float speed;
    //Rigidbody CurrentObject;
    GameObject currentPlate;
    public float minDistance;
    public GameObject Player;

   

    // Update is called once per frame
    void Update()
    {



        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PickUpMethod();
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            DropoffMethod();
        }

    }
    
    public void PickUpMethod()
    {
        Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, PickupRange, PickupMask))
        {

            currentPlate = GameObject.FindGameObjectWithTag("PickUp");

            currentPlate.transform.position = PickupTarget.position;
            currentPlate.transform.parent = PickupTarget;

            currentPlate.tag = "DropOff";
            currentPlate.layer = 7;

        }


        //CurrentObject = hitInfo.rigidbody;
        //CurrentObject.useGravity = false;

        Debug.Log("Mouse was clicked");
    }
    
    public void DropoffMethod()
    {
        float dist = Vector3.Distance(DropOffTarget.position, Player.transform.position);
        //Ray CameraRay2 = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));




        if (dist < minDistance)
        {
            Debug.Log("Player is close enough");
            Debug.Log("Dropping Off");
            currentPlate = GameObject.FindGameObjectWithTag("DropOff");

            currentPlate.transform.position = DropOffTarget.position;
            currentPlate.transform.parent = DropOffTarget;


        }

    }


}
