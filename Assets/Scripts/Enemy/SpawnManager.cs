using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float startDelay = 2.0f;
    public float spawnInterval = 10.0f;

    private GameObject minimap;
    public GameObject minimapEnemy;

    private float enemySpawnX;
    private float enemySpawnY;
    private Vector3 enemySpawnPos;
    public float xBoundary = 20.0f;
    public float yBoundary = 20.0f;


    private float playerPositionX;
    private float playerPositionY;
    public float screenSizeX = 5f;
    public float screenSizeY = 4f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
        player = GameObject.Find("Player");
        minimap = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        enemySpawnX = Random.Range(-xBoundary, xBoundary);
        enemySpawnY = Random.Range(-yBoundary, yBoundary);
        enemySpawnPos = new Vector3(enemySpawnX, 0, enemySpawnY);

        playerPositionX = player.transform.position.x;
        playerPositionY = player.transform.position.z;

        if ((enemySpawnX > playerPositionX - screenSizeX && enemySpawnX < playerPositionX + screenSizeX)
        || (enemySpawnY > playerPositionY - screenSizeY && enemySpawnY < playerPositionY + screenSizeY))
        {
            SpawnEnemy();
        }
        else
        {
            Instantiate(enemy, enemySpawnPos, transform.rotation);
            // InstantiateMinimapImage(enemySpawnPos);
        }
    }

    private void InstantiateMinimapImage(Vector3 enemySpawnPos) {
        var tick = Instantiate(minimapEnemy, enemySpawnPos, transform.rotation);
        tick.transform.SetParent(minimap.transform.GetChild(0));
        tick.transform.localScale = new Vector3(1, 1, 1);
    }
}
