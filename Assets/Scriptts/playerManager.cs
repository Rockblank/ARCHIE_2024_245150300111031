using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public bool isOkToMove = true;
    [SerializeField] gameManager manajerGame;

    bool canUp = true;
    bool canDown = true;
    bool canLeft = true;
    bool canRight = true;

    bool isWalk = false;
    bool walkUp = false;
    bool walkDown = false;
    bool walkLeft = false;
    bool walkRight = false;

    int horPos;
    int verPos;

    int horizontalPosition;
    int verticalPosition;

    Vector2 startPosition;

    void Start()
    {
        randomPosition();
    }

    public void randomPosition()
    {
        randomizePosition();
        setPosition();
        transform.position = new Vector2(horizontalPosition,verticalPosition);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         //handle exception
        exceptionHandling();

        if(isOkToMove)
        {
            //handle movement with exception
            movement();
        }
    }

    void OnTriggerEnter2D(Collider2D  other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit wall");
            manajerGame.PlayHitwallSfx();
            manajerGame.showJumpscare();
            transform.position = startPosition;
            manajerGame.decreaseScore();
            manajerGame.decreaseLife();
        }
    }

    void movement()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && canUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            manajerGame.playWalkSFX();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && canDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            manajerGame.playWalkSFX();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && canRight)
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            manajerGame.playWalkSFX();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && canLeft)
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            manajerGame.playWalkSFX();
        }
    }

    void exceptionHandling()
    {

        if(transform.position.y == 2)
        {
            canUp = false;
        } else { canUp = true; }

        if(transform.position.y == - 2)
        {
            canDown = false;
        } else { canDown = true; }

        if(transform.position.x == -6)
        {
            canLeft = false;
        } else { canLeft = true; }

        if(transform.position.x == 6)
        {
            canRight = false;
        } else { canRight = true; }

    }

    void randomizePosition()
    {
        horPos = Random.Range(0,6);
        verPos = Random.Range(0,2);
    }

    void setPosition()
    { 
        if(horPos == 0)
        {
            horizontalPosition = -6;
        }if(horPos == 1)
        {
            horizontalPosition = -4;
        }if(horPos == 2)
        {
            horizontalPosition = -2;
        }if(horPos == 3)
        {
            horizontalPosition = 0;
        }if(horPos == 4)
        {
            horizontalPosition = 2;
        }if(horPos == 5)
        {
            horizontalPosition = 4;
        }if(horPos == 6)
        {
            horizontalPosition = 6;
        }

        if(verPos == 0)
        {
            verticalPosition = -2;
        } if(verPos == 1)
        {
            verticalPosition = 0;
        } if(verPos == 2)
        {
            verticalPosition = 2;
        }
    }
}
