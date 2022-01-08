using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FORPLUSTIME : MonoBehaviour
{

    [SerializeField] private TextMesh PlusTime;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
        PlusTime.text = FindObjectOfType<DASKCONTROLLER>().TimerAd.ToString();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
