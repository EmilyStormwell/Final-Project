using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 25;
    public GameObject projectilePrefab;
    public int ammo = 0;
    public float ammoDelay = 1;
    public float ammoInterval = 1;
    public TextMeshProUGUI ammoText;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("IncreaseAmmo", ammoDelay, ammoInterval);
        ammoText.text = "Ammo: " + ammo;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3 (-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            ammo--;
            ammoText.text = "Ammo: " + ammo;
        }
    }
    void IncreaseAmmo()
    {
        ammo++;
        ammoText.text = "Ammo: " + ammo;
    }
}
