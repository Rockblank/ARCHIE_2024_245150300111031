using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class winPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] gameManager gameManager;
    [SerializeField] GameObject khususAdmin;
    [SerializeField] GameObject divineButton;

    void Start()
    {
        if(gameManager.playerScore == 8)
        {
            khususAdmin.SetActive(true);
            ScoreText.text = "PERFECT SCORE 8";
        } else { ScoreText.text = "Your Score: "+gameManager.playerScore ;}

        divineButton.SetActive(false);
    }
}
