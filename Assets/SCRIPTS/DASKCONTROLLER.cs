using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DASKCONTROLLER : MonoBehaviour
{
    public float speed;
    public float score;
    [SerializeField] private Text scoreText;
    public float timer;
    [SerializeField] private Text[] TimerText;
    [SerializeField] private AudioSource PlusScore;
    [SerializeField] private AudioSource magnet;
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject StartPannel;
    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject[] FloatingAddTime;
    [SerializeField] private GameObject[] spawn;
    [SerializeField] private GameObject FINISHPANEL;
    [SerializeField] private AudioSource MinusTimer;
    [SerializeField] private AudioSource Frreeze;
    [SerializeField] private AudioSource PlusTimer;
    [SerializeField] private ParticleSystem[] Particles;
    [SerializeField] private AudioSource PressToStart;
    [SerializeField] private GameObject[] baffs;
    
    public SpriteRenderer[] skins;
    public Image freeze;
    private int tryCount;
    public static bool isActive;
    public bool isActive2 = false;
    public bool isActive3 = false;
    public bool isActive4 = false;
    public BoxCollider2D bx;
    public BAFF bf;
    public int TimerAd;
    public int SCOREAd;
    void Start()
    {
       
        isActive = false;
        isActive3 = false;
        skins[2].enabled = false;
        MinMen(false);
        skins[0].enabled = true;
        skins[1].enabled = false;
        freeze.enabled = false;
        FINISHPANEL.SetActive(false);
        MagMen(false);
        BigMen(false);
        StartPannel.SetActive(true);
        Time.timeScale = 0;
        Spawner.SetActive(false);
        StartButton.SetActive(true);
        timer = 30;
        speed = 5;
       
    }
    private void Awake()
    {
        
    }
    public void FreezeTimer(bool active)
    {
        freeze.enabled = active;
    }
   

    public void ChangeSkin(bool active)
    {
        skins[2].enabled = active;
        skins[0].enabled = false;
        skins[1].enabled = active;
    }
    public void StartToPlay()
    {
        PressToStart.Play();
        StartPannel.SetActive(false);
        Spawner.SetActive(true);
        Time.timeScale = 1;
        StartButton.SetActive(false);
    }
    public void MagMen(bool active)
    {
        baffs[2].SetActive(active);
    }
    public void MinMen(bool active)
    {
        baffs[0].SetActive(active);
    }
    public void BigMen(bool active)
    {
        baffs[1].SetActive(active);
    }
    public void StopMag()
    {
        isActive = false;
    }
    public void StopFreeze()
    {
        isActive3 = false;
    }
    public void StopMin()
    {
        isActive4 = false;
    }
    public void StopBig()
    {
        isActive2 = false;
    }
    public void PlusScoreSound()
    {
        PlusScore.Play();
    }
    public void PlusMinusTimeSound()
    {
        MinusTimer.Play();
    }
    public void Timer()
    {
        if (timer > 0 && !isActive3)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Respawn()
    {
        timer = 30;
        FINISHPANEL.SetActive(false);
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        Timer();
        if (timer < 0)
        {
           
            int lastScore = int.Parse(scoreText.text.ToString());
            PlayerPrefs.SetFloat("score", lastScore);
            SetFinishPanel();

        }
        TimerText[0].text = timer.ToString("0");
        scoreText.text = score.ToString();

        if (timer < 5)
        {

            TimerText[0].color = new Color(255, 0, 0);
        }
        else if (timer > 5)
        {
            TimerText[0].color = new Color(255, 255, 255);
        }
        if (timer < 0)
        {
            timer = 0;
        }
        
    }
   
    
    private void SetFinishPanel()
    {
        FINISHPANEL.SetActive(true);
        Time.timeScale = 0;
        
    }
    private void PLTime()
    {
        TimerAd = Random.Range(2, 4);
        timer += TimerAd;
    }
    private void InstTools()
    {
        Instantiate(FloatingAddTime[1], spawn[1].transform.position, Quaternion.identity);
        Instantiate(Particles[1], spawn[0].transform.position, Quaternion.identity);
       
        
    }
    public void DaskSetting()
    {
        SCOREAd = Random.Range(1, 3);
        score += SCOREAd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "plustime")
        {
            PlusScoreSound();
            
            Instantiate(Particles[1], spawn[0].transform.position, Quaternion.identity);
            PLTime();
            Destroy(collision.gameObject);
           
        }
        if (collision.gameObject.tag == "tools")
        {
            PlusScoreSound();
            InstTools();
            DaskSetting();
            Instantiate(Particles[0], collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            PLTime();
        }
        if (collision.gameObject.tag == "Coin")
        {
            Instantiate(FloatingAddTime[1], spawn[1].transform.position, Quaternion.identity);
            Instantiate(Particles[2], collision.transform.position, Quaternion.identity);
            Coin();
            Destroy(collision.gameObject);

        }
        if(collision.gameObject.tag == "Mag")
        {
            magnet.Play();
            bf.StartMag();     
            isActive = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "BIG")
        {
            PlusScoreSound();
            DaskSetting();
            bf.StartBig();
            isActive2 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Freeze")
        {
            
            Frreeze.Play();
            bf.StartFreeze();
            isActive3 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Min")
        {
            PlusScoreSound();
            DaskSetting();
            bf.StartMini();
            isActive4 = true;
            Destroy(collision.gameObject);
        }
    }
    public void Biger()
    {
        bx.size = new Vector2(2.86f, 0.9f);
    }
    public void Smaller()
    {
        bx.size = new Vector2(1.4f, 0.9f);
    }
    public void Coin()
    {
        PlusTimer.Play();
        SCOREAd = Random.Range(5, 15);
        score += SCOREAd;
    }
   
   
    
   
    public void LEFT()
    {
        if (transform.position.x > -2)
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        
          
    }
    public void RIGHT()
    {
        if (transform.position.x < 2)
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
