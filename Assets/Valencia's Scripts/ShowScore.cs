using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public OrderManager orderManager;
    public TextMeshProUGUI postscoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        postscoreText.text = orderManager.score.ToString();
    }
}
