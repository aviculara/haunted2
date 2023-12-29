using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public int coinChance;
    public int moneyBagChance = 20;
    public int scrollChance = 10;

    public GameObject coinPrefab;
    public GameObject moneyBagPrefab;
    public GameObject scrollPrefab;
    
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
        //start with a coin
        //StartCoroutine(SpawnObjects());
    }


    public void SpawnObject()
    {
        //spawn object at a random pos on screen
        int percent = Random.Range(0, 100);
        if(percent < scrollChance)
        {
            float randx = Random.Range(-2.4f, 2.4f);
            float randy = Random.Range(-1.2f, 4.37f);
            Vector3 randPos = new Vector3(randx, randy);

            GameObject spawnedObject = Instantiate(scrollPrefab, randPos, Quaternion.identity);
            //Quaternion.identity. This is a predefined Quaternion that represents no rotation.
            //spawn scroll
        }
        else if(percent < scrollChance + moneyBagChance)
        {
            float randx = Random.Range(-2.42f, 2.42f);
            float randy = Random.Range(-1.2f, 4.37f);
            Vector3 randPos = new Vector3(randx, randy);

            GameObject spawnedObject = Instantiate(moneyBagPrefab, randPos, Quaternion.identity);
            //spawn moneybag
        }

        else
        {
            float randx = Random.Range(-2.44f, 2.41f);
            float randy = Random.Range(-1.22f, 4.42f);
            Vector3 randPos = new Vector3(randx, randy);

            GameObject spawnedObject = Instantiate(coinPrefab, randPos, Quaternion.identity);
            //spawn coin
        }
    }
}
