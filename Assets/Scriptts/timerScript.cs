using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class timerScript : MonoBehaviour
{
    [Header ("Game manager")]
    [SerializeField] gameManager ManajerGame;
    [SerializeField] GameObject player;
    [SerializeField] GameObject flag;
    [SerializeField] GameObject timerMeters;

    TextMeshProUGUI timerTextOriginal;
    // Start is called before the first frame update
    void Start()
    {
        timerTextOriginal = GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (ManajerGame.gameTimer > 0)
        {
            ManajerGame.gameTimer -= Time.deltaTime;
            timerTextOriginal.text = ManajerGame.gameTimer.ToString("F1");
        } else if (ManajerGame.gameTimer < 0)
        {
            ManajerGame.gameTimer = 0;
            timerTextOriginal.text = "0";
            ManajerGame.hideMaze(ManajerGame.activeLevel);
            timerMeters.SetActive(false);
            gameObject.SetActive(false);
            player.SetActive(true);
            flag.SetActive(true);
            Debug.Log("timer activated!");
        }
    }
}
