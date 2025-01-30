using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.ShaderKeywordFilter;

public class gameoverPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] gameManager gameManager;
    [SerializeField] GameObject divineButton;

    void Start()
    {
        ScoreText.text = "Your Score: " + gameManager.playerScore;
        divineButton.SetActive(false);
    }
}
