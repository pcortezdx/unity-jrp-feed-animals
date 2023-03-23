using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] animalPrefabs;
    // Range to spawn animals from the top of the screen
    private float spawnPosX = 15f;
    private float spawnPosZ = 25f;

    // Positions to spawn animals
    // from the left or right side of the screen
    private int maxScreenZ = 15;
    private int minScreenZ = 0;
    private float SideSpawnPoint = 25f;
    private float SideRotation = 90f;

    // Intervals settings to spawn animals
    private float startDelay = 1.2f;
    private float spawnInterval = 1.5f;
    
    void Start()
    {
        // Spanwing animals in time = startDelay, then reapeat every spawnInterval
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalFromLeft", startDelay + 0.5f, spawnInterval + 0.5f);
        InvokeRepeating("SpawnRandomAnimalFromRight", startDelay + 0.6f, spawnInterval + 0.6f);

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnPosZ);

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPosition,
            animalPrefabs[animalIndex].transform.rotation
        );
    }

    void SpawnRandomAnimalFromLeft()
    {
        SpawnRandomAnimalSides(SideRotation, SideSpawnPoint);
    }

    void SpawnRandomAnimalFromRight()
    {
        SpawnRandomAnimalSides(-SideRotation, -SideSpawnPoint);
    }

    void SpawnRandomAnimalSides(float rotation, float sideSpawnPoint)
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(sideSpawnPoint, 0, Random.Range(minScreenZ, maxScreenZ));

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPosition,
            animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0f, rotation, 0f)
        );
    }

    public void Stop()
    {
        Destroy(gameObject);
    }

}
