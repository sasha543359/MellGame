using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 2.0f; 

    void Start()
    {
        StartCoroutine(SpawnRoutine()); 
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); 
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
