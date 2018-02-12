using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    
	static MusicPlayer musicPlayer	=	null;

    public void Start()
    {
       
        
    }

    void Awake()
	{
		if(musicPlayer!=null)
		{Destroy(gameObject);}
		else
		{
			musicPlayer=this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
