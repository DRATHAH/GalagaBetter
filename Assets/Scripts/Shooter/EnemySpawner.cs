using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timer = 3f;
    public float coolTimer = 5f;
    public GameObject[] enemies;
    public float posMod = 3f;

    float countdown = 0;
    float coolCountdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        coolCountdown += Time.deltaTime;
        if (countdown >= timer)
        {
            countdown = 0;
            SpawnEnemy();
        }
        if (coolCountdown >= coolTimer)
        {
            coolCountdown = 0;
            SpawnCoolEnemy();
        }
    }

    void SpawnEnemy()
    {
        float randPos = Random.Range(-posMod, posMod);
        Vector3 randomPosition = new Vector3(transform.position.x + randPos, transform.position.y, transform.position.z);
        int random = Random.Range(0, enemies.Length);
        Instantiate(enemies[0], randomPosition, transform.rotation);
    }
    void SpawnCoolEnemy()
    {
        float randPos = Random.Range(-posMod, posMod);
        Vector3 randomPosition = new Vector3(transform.position.x + randPos, transform.position.y, transform.position.z);
        Instantiate(enemies[enemies.Length-1], randomPosition, transform.rotation);
    }
}
