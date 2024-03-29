using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    float topBound = 30;
    float lowerBound = -15;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the object if it goes beyond the player's view
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);            
        }
    }
}
