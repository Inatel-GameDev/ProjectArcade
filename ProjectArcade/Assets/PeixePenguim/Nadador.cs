using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nadador : MonoBehaviour
{
    [SerializeField] private float maxSpeedH;
    [SerializeField] private float maxSpeedV;
    [SerializeField] private float minSpeedH;
    [SerializeField] private float minSpeedV;
    [SerializeField] public float speedH;
    [SerializeField] private float speedV;
    [SerializeField] private int direction;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float deltaHeigth;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private bool subindo;

    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHeight = rb.transform.position.y + deltaHeigth;
        minHeight = rb.transform.position.y - deltaHeigth;
        subindo = true;

        speedH = Random.Range(minSpeedH,maxSpeedH);
        speedV = Random.Range(minSpeedV, maxSpeedV);
        if(transform.position.x > 10)
        {
            speedH = speedH * -1;
        }
    }

    void Update()
    {   
        if(subindo)
        {
            rb.velocity = new Vector2(speedH, speedV);
        } else
        {
            rb.velocity = new Vector2(speedH, -speedV);
        }

        if(subindo && rb.transform.position.y > maxHeight)
        {
            subindo = false;
        }

        if (!subindo && rb.transform.position.y < minHeight)
        {
            subindo = true;
        }


        if(rb.transform.position.x > maxX || rb.transform.position.x < minX)
        {
            Destroy(gameObject);
        }

    }
}
