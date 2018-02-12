using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

	private Platform platform;
	private Vector3 platformToBallVector;
	private bool hasStarted = false;
	void Start ()
	{
		platform = GameObject.FindObjectOfType<Platform>();
		platformToBallVector=this.transform.position - platform.transform.position;
	}
	
	void Update ()
	{
		if(!hasStarted)
		{
			this.transform.position=platform.transform.position + platformToBallVector;
			
			if (Input.GetMouseButton(0))
				{
                CallTime();
				print ("Mouse clicked launching ball");
				hasStarted=true;
				this.GetComponent<Rigidbody2D>().velocity=new Vector2(2f,10f);
				}
		}
	}

    IEnumerator CallTime()
    {
        yield return new WaitForSeconds(4f);
    }
    void OnCollisionEnter(Collision collision)
    {
        //	We create a new Vector2 object , called tweak, with random generated values for the
        //	x and y parameters (forces).  The float values will range from 0 to 0.2.
        Vector3 tweak = new Vector3(Random.Range(0f, 0.10f), Random.Range(0f, 0.10f), 0f);

        //	If the game has already started, then we sound the audioclip attached to the ball
        //	and then we tweak the ball's velocity
        if (hasStarted)
        {
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody>().velocity += tweak;
        }
    }

}
