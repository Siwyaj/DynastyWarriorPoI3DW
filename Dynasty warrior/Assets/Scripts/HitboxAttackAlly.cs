using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxAttackAlly : MonoBehaviour
{
    int Damage;
    Vector3 attackPosition;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Damage = Random.Range(40, 60);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 0.6f)
        {
            Destroy(gameObject);
        }
        if (time > 0.1f )
        {
            attackPosition = transform.parent.transform.position;
            transform.RotateAround(attackPosition, Vector3.up, -360 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collideenemy");
        if (other.gameObject.tag == "enemy")
        {

            other.gameObject.GetComponent<Stats>().TakeDamage(Damage);
        }
    }
}
