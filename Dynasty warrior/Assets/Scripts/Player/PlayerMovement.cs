using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //I know this is a bad implementation of movement and should instead use input horizontal and vertical, but at the time i could not remember how and could not find a tutorial on how to and this worked.
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = transform.position + (transform.forward* Mathf.Sqrt(2f)+ -transform.right* Mathf.Sqrt(2f)) * Settings.playerSpeed * (1 / Mathf.Sqrt(2)) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = transform.position + (transform.forward * Mathf.Sqrt(2f) + transform.right * Mathf.Sqrt(2f)) * Settings.playerSpeed * (1 / Mathf.Sqrt(2)) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = transform.position + (-transform.forward * Mathf.Sqrt(2f) + -transform.right * Mathf.Sqrt(2f)) * Settings.playerSpeed * (1 / Mathf.Sqrt(2)) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = transform.position + (-transform.forward * Mathf.Sqrt(2f) + transform.right * Mathf.Sqrt(2f)) * Settings.playerSpeed * (1 / Mathf.Sqrt(2)) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = transform.position + transform.forward * Settings.playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = transform.position + transform.right * Settings.playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = transform.position + -transform.right * Settings.playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = transform.position + -transform.forward * Settings.playerSpeed * Time.deltaTime;
        }
        
    }
}
