using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        //Storing the reference to our ScoreManager object to update
        // points when feeding animals.
        scoreManager = GameObject.Find("ScoreManager")
            .GetComponent<ScoreManager>();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detect collision other tag: " + other.tag);
        if (gameObject.CompareTag("Food") && other.CompareTag("Animal"))
        {
            //scoreManager.IncreaseFeedAnimal();
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
        
        
    }
}
