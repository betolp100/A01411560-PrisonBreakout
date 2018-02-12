using UnityEngine;
using System.Collections;

public class ColDown : MonoBehaviour 
{
	private LevelManager levelManager;
	
	void OnTriggerEnter2D(Collider2D trigger)
	{
		levelManager= GameObject.FindObjectOfType<LevelManager>();
		print("Trigger ON, LOSE SCREEN");
		levelManager.LoadLevel("Lose");
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		print ("Collision ON");
	}
}