using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnEnemy() 
    {
        int randomIndex = Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemyPrefab, enemySpawnPoints[randomIndex].position, Quaternion.identity);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(spawnEnemy());
    }
}
