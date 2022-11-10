using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyBehavior : MonoBehaviour
{
    Animator AllyAnimator;
    public GameObject Closestenemy;
    public GameObject[] enemyPeople;
    public bool inrange;
    public float time=3;
    public float lastAttack;
    public GameObject goodHitboxGameObject;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {   
        GameObject Model = transform.Find("Ally_model").gameObject;
        AllyAnimator = Model.GetComponent<Animator>();
        agent.speed = Random.Range(9f, 15f) / 10f;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        Closestenemy = FindClosestGood();
        transform.LookAt(Closestenemy.transform.position, Vector3.up);
        if ((Closestenemy.transform.position - transform.position).sqrMagnitude > 2)
        {
            inrange = false;
            AllyAnimator.SetBool("isAttack", false);
            AllyAnimator.SetBool("isRunning", true);
            AllyAnimator.SetBool("isIdle", false);
            agent.SetDestination(Closestenemy.transform.position);
        }
        else
        {
            AllyAnimator.SetBool("isAttack", false);
            AllyAnimator.SetBool("isRunning", false);
            AllyAnimator.SetBool("isIdle", true);
            agent.SetDestination(transform.position);
            inrange = true;
        }
        if (inrange && Mathf.Abs(time-lastAttack)>2f)
        {
            AllyAnimator.SetBool("isRunning", false);
            AllyAnimator.SetBool("isIdle", false);
            AllyAnimator.SetBool("isAttack", true);
            lastAttack = time;
            Debug.Log("InRange");
            EnemyAttack();
        }
    }

    GameObject FindClosestGood()
    {
        enemyPeople = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closestGood = null;
        float distance = Mathf.Infinity;
        float currentDistance=0f;
        foreach (GameObject enemy in enemyPeople)
        {
            Vector3 diff = enemy.transform.position - transform.position;
            currentDistance = diff.sqrMagnitude;
            if (currentDistance < distance)
            {
                closestGood = enemy;
                distance = currentDistance;
            }
        }

        return closestGood;
    }

    /*
     * Was used for movement before navmesh
    void MoveTowards(GameObject closest)
    {
        Vector3 closestPosition = closest.transform.position;
        transform.LookAt(closestPosition, Vector3.up);
        if ((closestPosition - transform.position).sqrMagnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
            enemyAnimator.SetBool("isIdle", false);
            inrange = false;
            transform.position = Vector3.MoveTowards(transform.position, closestPosition, Settings.enemySpeed * Time.deltaTime);
            
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
            enemyAnimator.SetBool("isIdle", true);
            inrange = true;
        }
    }*/
    void EnemyAttack()
    {
        Debug.Log("enemyAttack");

        GameObject spawnedHitbox = Instantiate(goodHitboxGameObject, transform.position + transform.up, transform.rotation) as GameObject;
        spawnedHitbox.transform.parent = transform;
    }

}
