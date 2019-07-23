using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
	public GameObject[] deathEffects;
	public void Death () 
	{
		int counter = 0;    
		while(counter < deathEffects.Length)
		{
			GameObject.Instantiate (deathEffects[counter], transform.position, transform.rotation);
			counter++;
		}
		Destroy(gameObject);
	}

	public float health = 100;

	public void TakeDamage () 
	{
		health --;
		if(health <= 0)
		{
			Death ();
		}
	}
}