using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 1.0f;
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
       if (gameObject.tag == "Energy Drink" && !playerController.gameOver)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        } else if (!playerController.gameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
