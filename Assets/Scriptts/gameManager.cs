using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using System.Linq;

public class gameManager : MonoBehaviour
{
    
    [Header("Game Timer")]
    public float gameTimer = 0;
    public float setGameTimer;
    [SerializeField] GameObject meteranTimer;
    [SerializeField] GameObject timerSekrip;

    [Space]

    [Header("Game objects")]
    public GameObject selectionOverlay;
    [SerializeField] Button startButton;
    [SerializeField] GameObject player;
    [SerializeField] GameObject flag;

    [Space]

    [Header("Scripts player and flag")]
    [SerializeField] playerManager playerScript;
    [SerializeField] flagRandomPosition flagScript;

    [Space]

    [Header("Randomize Levels")]
    [SerializeField] List<GameObject> mazeObject;
    [SerializeField] TextMeshProUGUI levelText;
    public GameObject activeLevel;
    int currentLevel = 0;
    int levelPlayed = 1;

    [Header ("Life Settings, DONT EDIT THE FUCKING LIFE!")]
    [SerializeField] int lifeCount = 3;
    [SerializeField] Image[] lifeImage;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] playerManager playerrr;

    [Header ("Point settings, DONT EDIT THIS I DOUBLE DARE YOU!")]
    public int playerScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    [Space]

    [Header("DEVine Interuptions settings")]
    [SerializeField] GameObject devineInteruptionButton;
    public bool isDevineInteruption = false;

    [Space]

    [Header("Audio Setting")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip foundFlag;
    [SerializeField] AudioClip hitWall;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip buttonClicked;
    [SerializeField] AudioClip uiWin;
    [SerializeField] AudioClip uiLose;
    [SerializeField] AudioClip devine;

    [Space]

    [Header("Jumpscare scene")]
    [SerializeField] GameObject jumpscareScene;

    // Start is called before the first frame update
    void Start()
    {
        jumpscareScene.SetActive(false);
        devineInteruptionButton.SetActive(false);
        selectionOverlay.SetActive(true);
        startButton.enabled = false;
        player.SetActive(false);
        flag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(levelPlayed >= 2 && lifeCount == 1) 
        {
            devineInteruptionButton.SetActive(true);
        }
    }

    public void randomizeLevel()
    {
        if(activeLevel != null)
        {
            activeLevel.SetActive(false);
        }

        int levelNum;
        do
        {
          levelNum = Random.Range(0,mazeObject.Count - 1);
        } while (currentLevel == levelNum);

        currentLevel = levelNum;

        activeLevel = mazeObject[levelNum];
        activeLevel.SetActive(true);
        Debug.Log("Succesfully randoming level!");
    }

    public void hideMaze(GameObject maze)
    {
        SpriteRenderer[] renderers = maze.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in renderers)
        {
            spriteRenderer.enabled = false;
        }
    }

    public void showMaze(GameObject maze)
    {
        SpriteRenderer[] renderers = maze.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in renderers)
        {
            spriteRenderer.enabled = true;
        }
    }

    public void decreaseLife()
    {
        lifeCount--;
        if(lifeCount < 0)
        {
            lifeCount = 0;
        }
        lifeImage[lifeCount].fillAmount = 0;
        if(lifeCount == 0)
        {
            Time.timeScale = 0f;
            playUiLose();
            gameOverPanel.SetActive(true);
            jumpscareScene.SetActive(false);
            playerrr.isOkToMove = false;
        }
    }

    public void addScore()
    {
        playerScore++;
        levelPlayed++;

        levelText.text = levelPlayed + "/8";
        scoreText.text = "Your Score: " + playerScore;

        if(isDevineInteruption)
        {
            lifeCount += 2;
            lifeImage[lifeImage.Count()-1].fillAmount = 1;
            lifeImage[lifeImage.Count() - 2].fillAmount = 1;
            isDevineInteruption = false;
        } 

        if(levelPlayed == 9)
        {
            levelText.text = levelPlayed-1 + "/8";
            flag.SetActive(false);
            player.SetActive(false);
            activeLevel.SetActive(false);
            Time.timeScale = 0f;
            winPanel.SetActive(true);
            playUiWin();
            playerrr.isOkToMove = false;
        } else if (levelPlayed <= 8)
            {
                playerScript.randomPosition();
                flagScript.randomPosition();
                player.SetActive(false);
                flag.SetActive(false);
                gameTimer = setGameTimer;
                randomizeLevel();
                meteranTimer.SetActive(true);
                timerSekrip.SetActive(true);
            }
    }

    public void decreaseScore()
    {
        playerScore--;
        if(playerScore < 0)
        {
            playerScore = 0;
        }
        scoreText.text = "Your Score: " + playerScore;
    }

    public void playWalkSFX()
    {
        audioSource.PlayOneShot(walk);
    }

    public void playFoundFlag()
    {
        audioSource.PlayOneShot(foundFlag);
    }

    public void PlayHitwallSfx()
    {
        audioSource.PlayOneShot(hitWall);
    }

    public void playButtonClicked()
    {
        audioSource.PlayOneShot(buttonClicked);
    }

    public void playUiWin()
    {
        audioSource.PlayOneShot(uiWin);
    }

    public void playUiLose()
    {
        audioSource.PlayOneShot(uiLose);
    }

    public void devineSound()
    {
        audioSource.PlayOneShot(devine);
    }

    public void showJumpscare()
    {
        jumpscareScene.SetActive(true);
    }
}
