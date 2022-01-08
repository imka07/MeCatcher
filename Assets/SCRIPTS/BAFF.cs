using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAFF : MonoBehaviour
{
    [SerializeField] Image mag;
    Coroutine Mag;
    GameObject player;
    [SerializeField] Image big;
    [SerializeField] Image Min;
    Coroutine min;
    Coroutine Big;
    Coroutine Freeze;
  
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
       
    }
    public void StartMag()
    {
        if (Mag != null) StopCoroutine(Mag);
        Mag = StartCoroutine(Magnite());
    }
    public void StartBig()
    {
        if (Big != null) StopCoroutine(Big);
        Big = StartCoroutine(BIG());
    }
    public void StartFreeze()
    {
        if (Freeze != null) StopCoroutine(Freeze);
        Freeze = StartCoroutine(Freez());
    }
    public void StartMini()
    {
        if (min != null) StopCoroutine(min);
        min = StartCoroutine(Mini());
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private IEnumerator Mini()
    {
        var d = player.GetComponent<DASKCONTROLLER>();
        d.ChangeSkin(true);
        d.MinMen(true);
        d.Smaller();
        d.speed = 7;
        d.skins[1].enabled = false;
        Min.fillAmount = 1;
        float timer = 6;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            Min.fillAmount = timer / 6;
            yield return null;
        }
        d.ChangeSkin(false);
        d.StopMin();
        d.MinMen(false);
        d.speed = 5;
        d.skins[0].enabled = true;
        Min.fillAmount = 0;
        min = null;
    }
    private IEnumerator Freez()
    {
        var d = player.GetComponent<DASKCONTROLLER>();
        d.DaskSetting();
      
        float timer = 6;
        d.FreezeTimer(true);
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
      
        d.DaskSetting();
        d.FreezeTimer(false);
        d.StopFreeze();
        Freeze = null;
    }
    private IEnumerator BIG()
    {
        var d = player.GetComponent<DASKCONTROLLER>();
        big.fillAmount = 1;
        d.Biger();
        d.speed = 3;
        d.BigMen(true);
        d.ChangeSkin(true);
        d.skins[2].enabled = false;
        float timer = 6;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            big.fillAmount = timer / 6;
            yield return null;
        }
        big.fillAmount = 0;
        d.BigMen(false);
        d.speed = 5;
        d.Smaller();
        d.ChangeSkin(false);
        d.skins[0].enabled = true;
        d.StopBig();
        Big = null;
    }
    private IEnumerator Magnite()
    {
        var d = player.GetComponent<DASKCONTROLLER>();


     
        d.MagMen(true);
        mag.fillAmount = 1;
        float timer = 6;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            mag.fillAmount = timer / 6;
            yield return null;
        }
        d.MagMen(false);
      
        d.StopMag();
        mag.fillAmount = 0;
      
        Mag = null;
    }
}
