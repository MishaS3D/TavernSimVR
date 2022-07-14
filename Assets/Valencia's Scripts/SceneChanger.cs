using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public void VRScene()
    {
        SceneManager.LoadScene("Grab Interaction 1");
    }

    public void FPScene()
    {
        SceneManager.LoadScene("Tavern FP");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
