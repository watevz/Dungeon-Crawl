using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	
	public Transform exit;

	void OnTriggerEnter (Collider col) 
	{
		if(col.transform.CompareTag("Player")){
			col.transform.position = exit.position;
			Rigidbody colRig = col.GetComponent<Rigidbody>();
			if(colRig){
				colRig.velocity = Vector3.zero;
			}			
		}
	}
}