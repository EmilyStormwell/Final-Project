using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 2;
    private float lowerSpawnRangeZ = 50;
    private float upperSpawnRangeZ = 250;
    public GameObject powerUpPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("UpdateSpawnRate", 0, 5);
        InvokeRepeating("SpawnPowerUp", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomAnimal()
    {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
                animalPrefabs[animalIndex].transform.rotation);
    }
    void UpdateSpawnRate()
    {
        spawnInterval = 2 / (1 + (Time.time / 100));
    }

    void SpawnPowerUp()
    {
        Vector3 spawnDistance = new Vector3(-550, .3f, Random.Range(lowerSpawnRangeZ, upperSpawnRangeZ));
        Instantiate(powerUpPrefab, spawnDistance, powerUpPrefab.transform.rotation);
    }
}
