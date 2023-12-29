using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    private Spawner spawner;
    private GameManager myGM;
    public int points = 1;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        myGM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spawner.SpawnObject();
            myGM.IncreaseScore(points);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            spawner.SpawnObject();
            Destroy(gameObject);
        }
    }

}
