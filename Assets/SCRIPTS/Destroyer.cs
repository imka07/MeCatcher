using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lifeTime);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
