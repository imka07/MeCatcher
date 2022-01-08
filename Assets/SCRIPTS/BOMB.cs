using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMB : MonoBehaviour
{
    private Rigidbody2D rb;
    public ParticleSystem[] explod;
    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject FloatingAddTime;
    public bool bomb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(FloatingAddTime, Spawner.transform.position, Quaternion.identity);
            
            var d = FindObjectOfType<DASKCONTROLLER>();
            if(bomb == true)
                Instantiate(explod[0], transform.position, Quaternion.identity);
            else
                Instantiate(explod[1], transform.position, Quaternion.identity);
            d.timer -= 5;
            Destroy(gameObject);
        }
    }
   
}
