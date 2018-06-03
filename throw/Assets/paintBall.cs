using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintBall : MonoBehaviour {

	private Color myColor;
	public GameObject paintBowl;

	// Use this for initialization
	void Start () 
	{
		myColor = gameObject.GetComponent<Renderer>().material.color;
		

	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Paintable"))
		{
			other.GetComponent<Renderer>().material.color = myColor;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			transform.position = Vector3.up;
		}
	}
}
