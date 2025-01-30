using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagRandomPosition : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    [SerializeField] gameManager manajerGame;

    bool isGetflag = false;
    int horizontal, vertical;
    Vector2 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        randomPosition();
    }

    public void randomPosition()
    {
        randomizePosition();
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLocation.position == transform.position)
            {
                manajerGame.playFoundFlag();
                getTheflag();
            }
    }

    public void getTheflag()
    {
        manajerGame.showMaze(manajerGame.activeLevel);
        manajerGame.addScore();
        Debug.Log("You got the flag.");
    }

    void randomizePosition()
    {
        do 
        {
             int horPos = Random.Range(0,6);
             int vertPos = Random.Range(0,2);

            if(horPos == 0)
            {
                horizontal = -6;
            }if(horPos == 1)
            {
                horizontal = -4;
            }if(horPos == 2)
            {
                horizontal = -2;
            }if(horPos == 3)
            {
                horizontal = 0;
            }if(horPos == 4)
            {
                horizontal = 2;
            }if(horPos == 5)
            {
                horizontal = 4;
            }if(horPos == 6)
            {
                horizontal = 6;
            }

            if(vertPos == 0)
            {
                vertical = -2;
            }if(vertPos == 1)
            {
                vertical = 0;
            }if(vertPos == 2)
            {
                vertical = 2;
            }
            newPosition = new Vector2(horizontal, vertical);
        } while(newPosition == (Vector2)playerLocation.position);
    }

    // void flagCaptured()
    // {
    //     manajerGame.addScore();
    //     Debug.Log("You got the flag.");
    // }
}
