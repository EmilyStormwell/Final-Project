using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DetectCollisions : MonoBehaviour
{
    private  PlayerController playerController;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        Debug.Log("got controller " + playerController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.tag == "Farm")
        {
            Debug.Log("Increase score");
            playerController.score++;
            playerController.scoreText.text = "Score: " + playerController.score;
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
