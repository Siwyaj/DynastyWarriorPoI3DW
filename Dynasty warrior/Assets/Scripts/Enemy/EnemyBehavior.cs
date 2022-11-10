using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    Animator enemyAnimator;
    public GameObject ClosestGood;
    public GameObject[] goodPeople;
    public bool inrange;
    public float time=3;
    public float lastAttack;
    public GameObject EnemyHitboxGameObject;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {   
        GameObject Model = transform.Find("Ready Idle").gameObject;
        enemyAnimator = Model.GetComponent<Animator>();
        agent.speed = Random.Range(9f, 15f) / 10f;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        ClosestGood =FindClosestGood();
        transform.LookAt(ClosestGood.transform.position, Vector3.up);
        if ((ClosestGood.transform.position - transform.position).sqrMagnitude > 2)
        {
            inrange = false;
            enemyAnimator.SetBool("isAttack", false);
            enemyAnimator.SetBool("isRunning", true);
            enemyAnimator.SetBool("isIdle", false);
            agent.SetDestination(ClosestGood.transform.position);
        }
        else
        {
            enemyAnimator.SetBool("isAttack", false);
            enemyAnimator.SetBool("isRunning", false);
            enemyAnimator.SetBool("isIdle", true);
            agent.SetDestination(transform.position);
            inrange = true;
        }
        if (inrange && Mathf.Abs(time-lastAttack)>2f)
        {
            enemyAnimator.SetBool("isRunning", false);
            enemyAnimator.SetBool("isIdle", false);
            enemyAnimator.SetBool("isAttack", true);
            lastAttack = time;
            Debug.Log("InRange");
            EnemyAttack();
        }
    }

    GameObject FindClosestGood()
    {
        goodPeople = GameObject.FindGameObjectsWithTag("Good");
        GameObject closestGood = null;
        float distance = Mathf.Infinity;
        float currentDistance=0f;
        foreach (GameObject good in goodPeople)
        {
            Vector3 diff = good.transform.position - transform.position;
            currentDistance = diff.sqrMagnitude;
            if (currentDistance < distance)
            {
                closestGood = good;
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

        GameObject spawnedHitbox = Instantiate(EnemyHitboxGameObject, transform.position + transform.up, transform.rotation) as GameObject;
        spawnedHitbox.transform.parent = transform;
    }

}
