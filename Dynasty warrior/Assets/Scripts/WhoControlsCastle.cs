using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoControlsCastle : MonoBehaviour
{
    public Material goodMaterial;
    public Material EnemyMaterial;
    public int good;
    public int enemy;
    public GameObject enemySpawner;
    public GameObject CastleCotroller;
    float controlleringSide=0;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Renderer>().material = EnemyMaterial;
    }

    private void FixedUpdate()
    {
        if (good > enemy)
        {
            if (controlleringSide <= 100)
            {
                controlleringSide += Time.deltaTime * Mathf.Abs(good - enemy)*10;
                Debug.Log("good Taking");
                enemySpawner.SetActive(false);
            }
            else
            {
                Debug.Log("allies took castle");
                enemySpawner.SetActive(true);
                enemySpawner.GetComponent<SpawnEnemy>().enemyControlled = false;
                transform.GetComponent<Renderer>().material = goodMaterial;
                CastleCotroller.transform.tag = "Good";
            }
        }
        else if (good < enemy)
        {
            if (controlleringSide >=0)
            {
                enemySpawner.SetActive(false);
                Debug.Log("enemy taking Taking");
                controlleringSide -= Time.deltaTime * Mathf.Abs(good - enemy);
            }
            else
            {
                enemySpawner.SetActive(true);
                transform.GetComponent<Renderer>().material = EnemyMaterial;
                Debug.Log("enemy took castle");
                enemySpawner.GetComponent<SpawnEnemy>().enemyControlled = true;
                CastleCotroller.transform.tag = "enemy";
            }
        }
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Good")
        {
            good++;
            Debug.Log("good entered");
        }
        if (collision.transform.tag == "enemy")
        {
            Debug.Log("enemy entered");
            enemy++;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Good")
        {
            Debug.Log("ally exit");
            good--;
        }
        if (collision.transform.tag == "enemy")
        {
            Debug.Log("enemy exit");
            enemy--;
        }
    }
}
