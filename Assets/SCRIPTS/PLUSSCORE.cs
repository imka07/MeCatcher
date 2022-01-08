using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLUSSCORE : MonoBehaviour
{
    [SerializeField] private TextMesh PlusTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlusTime.text = FindObjectOfType<DASKCONTROLLER>().SCOREAd.ToString();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
