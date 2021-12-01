using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float min_X = -6f, max_X = 6f;
    public GameObject enemyPrefab;
   public GameObject enemyPrefab1;

    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    // Update is called once per frame
    void SpawnEnemies()
    {
        float pos_X = Random.Range(min_X, max_X);
        Vector3 temp = transform.position;
        temp.x = pos_X;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f ));
        }
        else
        {
            Instantiate(enemyPrefab1, temp, Quaternion.Euler(0f, 0f, -90f));
        }
        Invoke("SpawnEnemies", timer);
    }
}
