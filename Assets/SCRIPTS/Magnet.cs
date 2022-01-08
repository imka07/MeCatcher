using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Transform player;
    private float speed;
  
    public float MinusTime1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 6f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (DASKCONTROLLER.isActive == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
       
    }
    private void MinusTime()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


    }

}
