using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerMeter : MonoBehaviour
{
    [SerializeField] gameManager gameManager;
    [SerializeField] Image barMeter;

    float timeAtStart;

    void Start()
    {
        timeAtStart = gameManager.gameTimer;
        barMeter.fillAmount = timeAtStart / timeAtStart;
    }

    // Update is called once per frame
    void Update()
    {
        barMeter.fillAmount = gameManager.gameTimer / timeAtStart;
    }
}
