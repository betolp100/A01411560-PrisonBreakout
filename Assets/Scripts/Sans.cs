using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Sans : MonoBehaviour {
    private int megalo;
    public AudioSource megalomania;
    private AudioSource[] allAudioSources;
    public Text Sanstext;
    public GameObject ball;
    public GameObject sansBrick;
    private bool startMove = false;
    //public AudioClip[] songArray;
    public GameObject smoke;
    private LevelManager levelManager;
    public Sprite[] hitSprite;
    public int timesHits;
    public static int breakableCount = 0;
    private bool isBreakable;
    //public int somebodyCounter=0;
    public float speed = -1;


    void Awake()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    private void Update()
    {
        if (startMove)
        {

            if (transform.position.x < 14f)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(10f * speed, 0f);
                speed = speed * -1;
            }
            if (transform.position.x >2)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(10f * speed, 0f);
                speed = speed * -1;
            }
        }
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        
        if (megalo == 1)
        {
            allAudioSources[0].Stop();
            megalomania = GetComponent<AudioSource>();
            megalomania.Play();
            megalo++;
        }
        startMove = true;
        sansBrick.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(10f * speed, 0f);
        Sanstext.text = "MISSED!";
        yield return new WaitForSeconds(0.5f);
        sansBrick.GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        
        startMove = true;
        Sanstext.text="v";
        if (sansBrick.GetComponent<Renderer>().enabled == true)
        {
            HandleHits();
        }
    }

    IEnumerator Start()
    {
        megalo = 1;
        Sanstext.text = "BOSS: 1HP, 0 DEFENSES.";
        yield return new WaitForSeconds(2f);
        Sanstext.text = ("HAHAHA, THIS WILL BE SOOOO EASY. 1 HIT BRICK. IZPC");
        yield return new WaitForSeconds(2f);
        Sanstext.text = "";
        isBreakable = (this.tag == "Break");
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHits = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    
    void HandleHits()
    {
        timesHits++;
        int maxHits = hitSprite.Length + 1;

        if (timesHits >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Debug.Log("BYEBYE");
            Destroy(gameObject);
        }
        else
        {
            Sanstext.text = "MISSED! ";
        }
    }

    void PuffSmoke()
    {
        Debug.Log("HOLA");
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        Debug.Log("ADIOS");
        smokePuff.GetComponent<Renderer>().material.color = gameObject.GetComponent<SpriteRenderer>().color;
    }
}
