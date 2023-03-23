using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Canvas game stats counters
    public TextMeshProUGUI txtPlayerLives;
    public TextMeshProUGUI txtFeedCounter;
    public GameObject txtGameOver;

    private int feedAnimalCounter = 0;
    public int playerLifeCounter = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Call and print the counters
        Debug.Log("Starting the ScoreManager");
        Debug.Log(string.Format("Life points: {0}", playerLifeCounter));
        Debug.Log(string.Format("Fed animals: {0}", feedAnimalCounter));

        // Hide Game Over message
        txtGameOver.SetActive(false);
        // Printing counters on screen
        PrintLives();
        PrintFeedCounter();

    }

    // Update is called once per frame
    public void DecreaseLife(int amount)
    {
        playerLifeCounter -= amount;
        Debug.Log(string.Format("Ouch! remaining life points: {0}", playerLifeCounter));
        PrintLives();
    }

    public int getLifeCounter()
    {
        return playerLifeCounter;
    }

    public void IncreaseFeedAnimal()
    {
        feedAnimalCounter += 1;
        Debug.Log(string.Format("Fed animals: {0}", feedAnimalCounter));

        PrintFeedCounter();
    } 

    public int getFeedAnimalsCounter()
    {
        return feedAnimalCounter;
    }

    void PrintLives()
    {
        txtPlayerLives.text = string.Format("Lives: {0}", playerLifeCounter);
    }

    void PrintFeedCounter()
    {
        txtFeedCounter.text = string.Format("Feed: {0}", feedAnimalCounter);
    }

    public void printGameOver()
    {
        txtGameOver.SetActive(true);
    }
}
