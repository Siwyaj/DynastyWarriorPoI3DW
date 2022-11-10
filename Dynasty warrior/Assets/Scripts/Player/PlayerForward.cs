using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float rotation = Input.mousePosition.x;
        transform.rotation = Quaternion.AngleAxis(rotation * Settings.sensitivity, Vector3.up);
    }
}
