using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintBall : MonoBehaviour {

	private Color myColor;
	public GameObject paintBowl;

	private AudioSource MyAudioSource;

	// Use this for initialization
	void Start () 
	{
		myColor = gameObject.GetComponent<Renderer>().material.color;
		MyAudioSource = gameObject.GetComponent<AudioSource>();
		

	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Paintable"))
		{
			MyAudioSource.Play();

			other.GetComponent<Renderer>().material.color = myColor;


			//other.GetComponent<Renderer>().material.EnableKeyword("Emmission")
			
			other.GetComponent<Renderer>().material.SetColor("_EmissionColor", myColor);

			//DynamicGI.SetEmissive(other.GetComponent<Renderer>(), myColor);
			

			GetComponent<Rigidbody>().velocity = Vector3.zero;
			transform.position = Vector3.up;


		}
	}
}
