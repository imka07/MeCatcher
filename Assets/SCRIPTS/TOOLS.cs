using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TOOLS : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject FloatingAddTime;
    public bool isChest;
    public bool issSaw;
    GameObject bascket;
    private float speed;
    public float MinusTime1;
    [SerializeField] private TextMesh MinusTimer;
    public bool isTrue;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 4;
        rb = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(DASKCONTROLLER.isActive == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
       
        
        MinusTime1 = Random.Range(4, 5);
        MinusTimer.text = MinusTime1.ToString();
    }
    //public void MoveToBascket()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, bascket.transform.position, speed * Time.deltaTime);
    //}
   
    
    
    private void MinusTime()
    {
        Instantiate(FloatingAddTime, Spawner.transform.position, Quaternion.identity);
        var d = FindObjectOfType<DASKCONTROLLER>();
        d.PlusMinusTimeSound();
        d.timer -= MinusTime1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Finish")
        {
            MinusTime();
            Destroy(this.gameObject);
        }
        
    }
}
