using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 2;
    private float lowerSpawnRangeZ = 5;
    private float upperSpawnRangeZ = 15;
    public GameObject powerUpPrefab;
    private int powerUpInterval = 10;
    private PlayerController playerController;
    public GameObject player;
    private int spawnRateUpdateDelay = 5;
    private int spawnRateUpdateInterval = 5;
    private int spawnPowerUpDelay = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("UpdateSpawnRate", spawnRateUpdateDelay, spawnRateUpdateInterval);
        InvokeRepeating("SpawnPowerUp", spawnPowerUpDelay, powerUpInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomAnimal()
    {
        if (!playerController.gameOver)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(animalPrefabs[animalIndex], spawnPos,
                    animalPrefabs[animalIndex].transform.rotation);
        }
    }
    void UpdateSpawnRate()
    {
        if (!playerController.gameOver)
        {
            spawnInterval = 2 / (1 + (Time.time / 100));
            Debug.Log("Spawn Rate is 1 animal per " + spawnInterval + " seconds.");
        }
    }

    void SpawnPowerUp()
    {
        if (!playerController.gameOver)
        {
            Vector3 spawnDistance = new Vector3(-25, .3f, Random.Range(lowerSpawnRangeZ, upperSpawnRangeZ));
            Instantiate(powerUpPrefab, spawnDistance, powerUpPrefab.transform.rotation);
            powerUpInterval = Random.Range(60, 120);
        }
    }
}
