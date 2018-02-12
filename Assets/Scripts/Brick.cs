using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Brick : MonoBehaviour
{
    //public AudioClip[] songArray;
    public GameObject brick;
    public GameObject smoke;
    private LevelManager levelManager;
    public Sprite[] hitSprite;
	public int timesHits;
    public static int breakableCount = 0;
    private bool isBreakable;
    //public int somebodyCounter=0;
    void Start ()
		{
        isBreakable = (this.tag == "Break");
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHits = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
		
	void OnCollisionEnter2D(Collision2D coll)
	{
		print ("boing");
        //PlaySomeBody();
        

        //	If the brick is a breakable one, we call the HandleHits() method
        if (isBreakable)
        {
            HandleHits();
        }
    }

    /*void PlaySomeBody()
    {
        for (int i = 0; i <= 16 ; i++)
        {
            if (somebodyCounter==i)
            {
                AudioClip song = songArray[i];
                AudioSource.PlayClipAtPoint(song, brick.transform.position, 0.8f);
                if (i != 14)
                {
                    somebodyCounter++;
                }
                else
                {
                    i = 0;
                }
                
            }
        }
           
    }*/
    void HandleHits()
    {
        timesHits++;
        int maxHits = hitSprite.Length + 1;

        if (timesHits >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        Debug.Log("HOLA");
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        Debug.Log("ADIOS");
        smokePuff.GetComponent<Renderer>().material.color = gameObject.GetComponent<SpriteRenderer>().color;
    }

        void LoadSprites()
    {
        int spriteIndex = timesHits - 1;

        if (hitSprite [spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
    }
}
