using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 25;
    public GameObject[] projectilePrefab;
    public int feed = 0;
    public float feedDelay = 1;
    public float feedInterval = 1;
    public TextMeshProUGUI feedText;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private int chosenFeed;
    public GameObject[] dogTreatPrefab;
    public int dogTreats;
    public  float dogTreatsDelay = 4;
    public float dogTreatsInterval = 4;
    public TextMeshProUGUI dogTreatsText;
    private int chosenTreat;
    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("IncreaseAmmo", feedDelay, feedInterval);
        InvokeRepeating("IncreaseDogTreats", dogTreatsDelay, dogTreatsInterval);
        feedText.text = "Feed: " + feed;
        scoreText.text = "Score: " + score;
        dogTreatsText.text = "Dog Treats: " + dogTreats;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (!gameOver)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3 (-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && feed > 0 && !gameOver)
        {
            chosenFeed = Random.Range(0, projectilePrefab.Length);
            Instantiate(projectilePrefab[chosenFeed], transform.position, projectilePrefab[chosenFeed].transform.rotation);
            feed--;
            feedText.text = "Feed: " + feed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dogTreats > 0 && !gameOver)
        {
            chosenTreat = Random.Range(0, dogTreatPrefab.Length);
            Instantiate(dogTreatPrefab[0], transform.position, dogTreatPrefab[0].transform.rotation);
            dogTreats--;
            dogTreatsText.text = "Dog Treats: " + dogTreats;
        }
    }
    void IncreaseAmmo()
    {
        feed++;
        feedText.text = "Feed: " + feed;
    }

    void IncreaseDogTreats()
    {
        dogTreats++;
        dogTreatsText.text = "Dog Treats: " + dogTreats;
    }
}
