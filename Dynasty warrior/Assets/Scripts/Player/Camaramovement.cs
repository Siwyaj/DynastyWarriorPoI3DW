using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaramovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 camaraOffset;
    float currentCamaraPosision;
    float rotationEnd;
    void Start()
    {
        currentCamaraPosision = transform.position.x;
        camaraOffset = player.transform.position + new Vector3(0.25f, 0.65f, 0)+(-Vector3.forward*1.25f);
    }

    void Update()
    {
        rotationEnd = Input.mousePosition.x ;
        CamaraPosition(rotationEnd);
        CamaraRotation(rotationEnd);
    }
    private void FixedUpdate()
    {

    }
    void CamaraPosition(float rotationEnd)//Works
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = playerPosition+Quaternion.AngleAxis(rotationEnd * Settings.sensitivity, new Vector3(0, playerPosition.y,0))*camaraOffset;
    }
    void CamaraRotation(float rotationEnd)
    {
        transform.rotation = Quaternion.AngleAxis(rotationEnd * Settings.sensitivity, Vector3.up);
        transform.Rotate(20,0, 0);
    }
}
