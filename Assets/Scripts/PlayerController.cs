using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{     
    public GameObject projectilePrefab;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 12.0f;
    public float xRange = 25.0f;
    public float zRange = 13.0f;

    public Slider lifeSlider;

    // Player stats
    private int lifeCounter;
    private ScoreManager scoreManager;
    private SpawnManager spawnManager;

    private void Start()
    {
        //Storing the reference to our ScoreManager object to update
        // player life.
        scoreManager = GameObject.Find("ScoreManager")
            .GetComponent<ScoreManager>();    
        
        // Storing the reference to the SpawnManger
        spawnManager = GameObject.Find("SpawnManager")
            .GetComponent<SpawnManager>();

        // Set the life bar with the maximum lives of the player
        Debug.Log("Initializing player stats");
        lifeCounter = scoreManager.getLifeCounter();
        Debug.Log(string.Format("Starting with {0} lives", lifeCounter));

        lifeSlider.maxValue = lifeCounter;
        lifeSlider.value = lifeCounter;
        lifeSlider.fillRect.gameObject.SetActive(true);        
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerHorizontally();
        MovePlayerVertically();                
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    void MovePlayerHorizontally()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
    }

    void MovePlayerVertically()
    {
        if (transform.position.z < 0.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);

        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        else
        {
            horizontalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
        }
    }

    public void DecreaseLifeBar(int amount)
    {
        lifeCounter -= amount;
        lifeSlider.fillRect.gameObject.SetActive(true);
        lifeSlider.value = lifeCounter;

        Debug.Log(string.Format("Decreasing slider life, {0} lives", lifeCounter));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {

            if (scoreManager.getLifeCounter() > 1)
            {
                scoreManager.DecreaseLife(1);
                DecreaseLifeBar(1);
                Debug.Log(string.Format("Decreasing slider life, {0} lives", lifeCounter));

                Debug.Log(
                    string.Format("Ouch! remaining life points: {0}"
                    , scoreManager.getLifeCounter())
                    );

                // Destroy the collided animal
                Destroy(other.gameObject);
            }
            else
            {                
                Debug.Log(" **Game Over** ");
                scoreManager.DecreaseLife(1);
                DecreaseLifeBar(1);
                scoreManager.printGameOver();
                
                //Stop animal spawning
                spawnManager.Stop();

                //Destroy player
                Destroy(gameObject);
            }
        }

    }

}
