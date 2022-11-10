using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxAttackEnemy : MonoBehaviour
{
    int Damage;
    Vector3 attackPosition;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Damage = Random.Range(5, 15);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 1f)
        {
            Destroy(gameObject);
        }
        if (time > 0.5f )
        {
            attackPosition = transform.parent.transform.position;
            transform.RotateAround(attackPosition, transform.right, 180 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collideenemy");
        if (other.gameObject.tag == "good")
        {
            other.gameObject.GetComponent<Stats>().TakeDamage(Damage);
        }
    }
}
