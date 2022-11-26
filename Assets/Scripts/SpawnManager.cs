using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] animalPrefabs;
    private float spawnPosX = 20;
    private float spawnPosZ = 25;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnPosZ);

            Instantiate(
                animalPrefabs[animalIndex], 
                spawnPosition, 
                animalPrefabs[animalIndex].transform.rotation
            );
        }

    }
}
