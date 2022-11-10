using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyGameObject;
    public GameObject AllyGameObject;
    float timePast = 30;
    float LastSpawn;
    public bool enemyControlled=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timePast += Time.deltaTime;
        if (Mathf.Abs(timePast - LastSpawn)>10)
        {
            if (enemyControlled)
            {
                LastSpawn = timePast;
                SpawnEnemyMethod();
            }
            else
            {
                LastSpawn = timePast;
                SpawnAllyMethod();
            }
            
        }
    }


    void SpawnEnemyMethod()
    {
        int amount = Random.Range(2,5);

        for (int i = 0; i <= amount; i++)
        {
            float z = Random.Range(-2, 2);
            float x = Random.Range(-2,2);
            Instantiate(EnemyGameObject, transform.position + new Vector3(x, 0.5f, z), transform.rotation);
        }
    }
    void SpawnAllyMethod()
    {
        Debug.Log("spawn ally method");
        int amount = Random.Range(5, 10);

        for (int i = 0; i <= amount; i++)
        {
            Debug.Log("spawn ally");
            float z = Random.Range(-4, 4);
            float x = Random.Range(-4, 4);
            Instantiate(AllyGameObject, transform.position + new Vector3(x, 0.5f, z), transform.rotation);
        }
    }
}
