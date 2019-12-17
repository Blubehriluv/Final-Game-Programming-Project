using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2 : MonoBehaviour
{
    public float rotationSpeed;
    public float distance;
    public LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;
    public Gradient yellowColor;

    public Enemy other;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = yellowColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                lineOfSight.colorGradient = redColor;
                Debug.Log("hit player");
            }
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = greenColor;
        }

        lineOfSight.SetPosition(0, transform.position);
    }

}
