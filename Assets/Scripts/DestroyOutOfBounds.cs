using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound && gameObject.tag == "Farm")
        {
            Destroy(gameObject);
        }        
        else if (transform.position.z < lowerBound && gameObject.tag == "Dog")
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
