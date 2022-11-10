using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateScontroller : MonoBehaviour
{
    public GameObject hitBox;
    Animator animator;
    public float timePassed = 3;
    public float attackStartTme = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (Mathf.Abs(timePassed - attackStartTme) > 1.5f)
            {
                animator.SetBool("isIdle", false);
                animator.SetBool("isBack", false);
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);
                animator.SetBool("isRunningForward", false);
                animator.SetBool("isAttacking", true);
                attackStartTme = timePassed;
                attackAction();
            } 
        }
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", true);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", true);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunningForward", true);
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRight", true);
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeft", true);
            animator.SetBool("isBack", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isBack", true);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isBackRight", false);
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isBack", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isRunningForward", false);
            animator.SetBool("isAttacking", false);
        }

    }


    void attackAction()
    {
        Debug.Log("attacked");
        GameObject spawnedHitbox = Instantiate(hitBox, transform.position + transform.right/1.5f, transform.rotation) as GameObject;
        spawnedHitbox.transform.parent = transform;
    }

}
