using UnityEngine;

public class SpeedBoosterSpawner : MonoBehaviour
{
    public GameObject speedBoosterPrefab; 
    public float spawnInterval = 60f; 

    void Start()
    {
        InvokeRepeating("SpawnSpeedBooster", 0f, spawnInterval);
    }

    void SpawnSpeedBooster()
    {
        
        Vector3 randomPosition = new Vector3(Random.Range(-55f, 55f), 0f, Random.Range(-55f, 55f));
        
        Instantiate(speedBoosterPrefab, randomPosition, Quaternion.identity);
    }
}
