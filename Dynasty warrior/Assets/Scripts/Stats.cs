using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    int health;
    public GameObject castle1;
    public GameObject castle2;
    public GameObject castle3;
    public GameObject castle4;
    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(50, 100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            transform.position = new Vector3(100, 100, 100);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
