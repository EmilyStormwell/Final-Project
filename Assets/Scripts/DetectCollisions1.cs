using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DetectCollisions : MonoBehaviour
{
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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter Activated");
        if (gameObject.tag == "Farm" && other.gameObject.tag == "Feed")
        {
            playerController.score++;
            playerController.scoreText.text = "Score: " + playerController.score;
            Destroy(gameObject);
            Destroy(other.gameObject);
        } else if (gameObject.tag == "Dog" && other.gameObject.tag == "Dog Treat")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        } else if (gameObject.tag == "Energy Drink" && other.gameObject.tag == "Feed" || other.gameObject.tag == "Dog Treat")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerController.feedInterval = playerController.feedInterval / 1.15f;
            playerController.dogTreatsInterval = playerController.dogTreatsInterval / 1.15f;
            Debug.Log("Feed rate is: " + playerController.feedInterval + " Treats rate is: " + playerController.dogTreatsInterval);
        }

    }
}
