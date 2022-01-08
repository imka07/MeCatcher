using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForFive : MonoBehaviour
{
    [SerializeField] private GameObject FloatingAddTime;
    [SerializeField] private GameObject Spawner;
    public float MinusTime1;
    [SerializeField] private TextMesh MinusTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MinusTime1 = Random.Range(2, 5);
        MinusTimer.text = MinusTime1.ToString();
    }
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
