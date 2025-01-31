using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Xml.Serialization;

public class ButtonManager : MonoBehaviour
{
    Image thisButton;
    TextMeshProUGUI textButton;

    [Header("Other buttons")]
    [SerializeField] Image otherButton1;
    [SerializeField] Image otherButton2;
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] GameObject buttonStart;
    [SerializeField] Button buttonSetart;
    [SerializeField] Button buttonPause;

    [Space]

    [SerializeField] GameObject textTimer;
    [SerializeField] TextMeshProUGUI timerText;

    [Space]

    [Header("Game manager")]
    [SerializeField] gameManager managerGame;

    [Space]

    [Header("Bar meters")]
    [SerializeField] GameObject barMeters;

    void Start()
    {
        buttonPause.interactable = false;
        thisButton = GetComponent<Image>();
        textButton = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void button30s()
    {
        managerGame.playButtonClicked();
        thisButton.color = Color.black;
        textButton.color = Color.white;
        managerGame.gameTimer = 30;
        managerGame.setGameTimer = managerGame.gameTimer;
        otherButton1.color = Color.white;
        text1.color = Color.black;
        otherButton2.color = Color.white;
        text2.color = Color.black;
        Debug.Log(managerGame.gameTimer);
    }

    public void button10s()
    {
        managerGame.playButtonClicked();
        thisButton.color = Color.black;
        textButton.color = Color.white;
        managerGame.gameTimer = 10;
        managerGame.setGameTimer = managerGame.gameTimer;
        otherButton1.color = Color.white;
        text1.color = Color.black;
        otherButton2.color = Color.white;
        text2.color = Color.black;
        Debug.Log(managerGame.gameTimer);
    }

    public void button1s()
    {
        managerGame.playButtonClicked();
        thisButton.color = Color.black;
        textButton.color = Color.white;
        managerGame.gameTimer = 1;
        managerGame.setGameTimer = managerGame.gameTimer;
        otherButton1.color = Color.white;
        text1.color = Color.black;
        otherButton2.color = Color.white;
        text2.color = Color.black;
        Debug.Log(managerGame.gameTimer);
    }

    public void okButton()
    {
        managerGame.playButtonClicked();
        if(managerGame.gameTimer == 0)
        {
            Debug.Log("Choose something first loco!");
        } else
            {
                Debug.Log("ok button get clicked");
                managerGame.selectionOverlay.SetActive(false);
                buttonSetart.enabled = true;
                buttonPause.interactable = true;
            }
    }

    public void startButton()
    {
        managerGame.playButtonClicked();
        Time.timeScale = 1;
        managerGame.randomizeLevel();
        buttonStart.SetActive(false);
        textTimer.SetActive(true);
        barMeters.SetActive(true);
    }

    public void gotoMainScreen()
    {
        managerGame.playButtonClicked();
        SceneManager.LoadScene("HomeScene");
    }
    public void gotoPlayScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void goToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void khususAdmin()
    {
        SceneManager.LoadScene("videoExsudif");
    }
    public void devineButton()
    {
        managerGame.devineSound();
        managerGame.isDevineInteruption = true;
        gameObject.GetComponent<Button>().interactable = false;
        managerGame.devineActivate = false;
    }

    public void pauseButton()
    {
        buttonPause.interactable = false;
        managerGame.pauseScene.SetActive(true);
        managerGame.playerScript.enabled = false;
        Time.timeScale = 0f;
    }

    public void resumeButton()
    {
        buttonPause.interactable = true;
        managerGame.pauseScene.SetActive(false);
        managerGame.playerScript.enabled = true;
        Time.timeScale = 1f;
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
