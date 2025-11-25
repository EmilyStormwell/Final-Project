using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -5;
    private PlayerController playerController;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
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
            playerController.gameOver = true;
        }
    }
}
