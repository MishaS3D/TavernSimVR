using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public void VRScene()
    {
        SceneManager.LoadScene("TavernSimVR01");
    }

    public void FPScene()
    {
        SceneManager.LoadScene("TavernSimulatorFP");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
