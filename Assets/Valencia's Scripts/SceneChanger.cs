using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public TextMeshProUGUI  scoreNumber;
    public string displayScoreNumber;
    public GameObject inGameUI;
    public GameObject endGameUI;
    public bool endGame;
    private void Start()
    {
        Cursor.visible = true;
        endGame = false;
        inGameUI.SetActive(true);
        endGameUI.SetActive(false);
    }
    public void FPScene()
    {
        SceneManager.LoadScene("TavernSimulatorFP");
    }

    public void EndScene()
    {

        endGameUI.SetActive(true);
        inGameUI.SetActive(false);
        endGame = true;

    }

}
