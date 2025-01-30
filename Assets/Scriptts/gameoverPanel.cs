using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameoverPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] gameManager gameManager;

    void Start()
    {
        ScoreText.text = "Your Score: " + gameManager.playerScore;
    }
}
