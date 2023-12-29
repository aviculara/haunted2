using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    public GameObject moveEnemy;
    public GameObject movePlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Move moveScript = moveEnemy.GetComponent<Move>();
            //int currentDir = moveEnemy.GetComponent<EnemyBehaviour>().currentDir;
            moveScript.ChangeOppositeDir();
        }
        else if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("collision with player");
            PlayerController controllerScript = movePlayer.GetComponent<PlayerController>();
            if (controllerScript == null)
            {
                Debug.Log("null object");
            }
            controllerScript.Fall();

        }
    }
 
}

