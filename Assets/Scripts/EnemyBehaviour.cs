using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public int behaviourLevel = 1;
    //public int currentDir = 0;
    public GameObject playerObject;

    public int counterTarget = 10;

    private Move moveScript;
    //private int nextDir = 0;
    private Rigidbody2D playerRB;
    private Vector2 prevDist;
    private Vector2 currentDist;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        
        moveScript = GetComponent<Move>();
        if(moveScript == null)
        {
            Debug.Log("null");
        }

        playerRB = playerObject.GetComponent<Rigidbody2D>();
        prevDist = findDistance(playerRB);
        counter = 0;
    }

    void FixedUpdate()
    {
        switch (behaviourLevel)
        {
            case 0:
                moveScript.speed = 0.5f;
                currentDist = findDistance(playerRB);
                counter = counter + 1;
                int rand = Random.Range(0, 100);
                if (counter > counterTarget && rand < 50)
                {
                    //horizontal choice
                    if (currentDist.x > 0)
                    {
                        moveScript.ChangeDirRight();
                    }
                    else if(currentDist.x < 0)
                    {
                        moveScript.ChangeDirLeft();
                    }
                    
                    counter = 0;
                }
                else if(counter > counterTarget)
                {
                    //vertical choice
                    if(currentDist.y > 0)
                    {
                        moveScript.ChangeDirUp();
                    }
                    else if(currentDist.y < 0)
                    {
                        moveScript.ChangeDirDown();
                    }
                    
                    counter = 0;
                }
                break;
            case 1:
                //difficulty level 1
                //if distance increased
                /*
                currentDist = findDistance(playerRB);
                counter = counter + 1;
                if( counter > counterTarget && currentDist.magnitude > prevDist.magnitude)
                {
                    //change direction
                    nextDir = moveScript.RandomNearbyDirection(currentDir);
                    moveScript.ChangeDirTo(nextDir);
                    currentDir = nextDir;
                    counter = 0;
                }
                prevDist = currentDist;
                */
                break;
            default:
                //idk yet
                break;
        }
    }

    private Vector2 findDistance(Rigidbody2D targetRB)
    {
        Vector2 distance;
        Vector2 targetPos = targetRB.transform.position;
        Vector2 selfPos = moveScript.objectToMove.transform.position;
        distance = targetPos - selfPos;
        return distance;
    }

}
