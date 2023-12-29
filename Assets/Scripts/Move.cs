using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 1f;
    public GameObject objectToMove;
    public int startingDir = 0;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    [Header("Move parameters")]
    public int currentDirection;
    private float h = 0f;
    private float v = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = objectToMove.GetComponent<Rigidbody2D>();
        animator = objectToMove.GetComponent<Animator>();
        ChangeDirTo(startingDir);
        currentDirection = startingDir;
        //Vector2 dir = new Vector2(h, v);


    }

    // Update is called once per frame
    

    public void ChangeDirUp()
    {
        h = 0;
        v = 1;
        animator.SetInteger("MoveDir", 1);
        currentDirection = 1;

    }
    public void ChangeDirDown()
    {
        h = 0;
        v = -1;
        animator.SetInteger("MoveDir", 2);
        currentDirection = 2;
    }
    public void ChangeDirRight()
    {
        h = 1;
        v = 0;
        animator.SetInteger("MoveDir", 0);
        currentDirection = 0;
    }
    public void ChangeDirLeft()
    {
        h = -1;
        v = 0;
        animator.SetInteger("MoveDir", 3);
        currentDirection = 3;
    }

    public void ChangeDirTo(int newDir)
    {
        switch (newDir)
        {
            case 0:
                ChangeDirRight();
                break;
            case 1:
                ChangeDirUp();
                break;
            case 2:
                ChangeDirDown();
                break;
            case 3:
                ChangeDirLeft();
                break;
            default:
                //idk
                ChangeDirRight();
                break;
        }
    }

    public int RandomNearbyDirection()
    {
        Debug.Log("inside randomnearbydirection");
        int newDir;
        int[] nearDirs;
        switch (currentDirection)
        {
            case 0:
                nearDirs = new int[] { 0, 1, 2 };
                Debug.Log("inside case 0");
                break;
            case 1:
                nearDirs = new int[] { 0, 1, 3 };
                break;
            case 2:
                nearDirs = new int[] { 0, 2, 3 };
                break;
            case 3:
                nearDirs = new int[] { 1, 2, 3 };
                break;
            default:
                nearDirs = new int[] { 0 };
                //returns Right as default
                Debug.LogWarning("Unexpected currentDir value: " + currentDirection);
                break;

        }
        int randomIndex = Random.Range(0, nearDirs.Length);
        Debug.Log(randomIndex);
        newDir = nearDirs[randomIndex];
        Debug.Log("newdir is: " + newDir);
        //Debug.Log(newDir);
        return newDir;
        
    }

    public void debugging()
    {
        Debug.Log("it works");
    }

    public void ChangeOppositeDir()
    {
        
        switch (currentDirection)
        {
            case 0:
                ChangeDirLeft();
                break;
            case 1:
                ChangeDirDown();
                break;
            case 2:
                ChangeDirUp();
                break;
            case 3:
                ChangeDirRight();
                break;
            default:
                //idk
                ChangeDirRight();
                Debug.Log("unexpected current dir value");
                break;
        }
    }


    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal"); //horizontal axis input
        //float v = Input.GetAxis("Vertical"); //vertical axis input
        // you are using axis names as defined in Edit > Project Settings > Input Manager
        //Debug.Log(h);

        //creates a 2d vector in unity
        Vector2 dir = new Vector2(h, v);
        rigidbody.velocity = dir.normalized * speed;
        //returns the vector with a mag. of 1

        //0 = right
        //1 = up
        //2 = down
        //3 = left
    }

    
}
