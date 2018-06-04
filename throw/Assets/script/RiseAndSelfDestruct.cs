using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseAndSelfDestruct : MonoBehaviour {

	public float speed;
	public float lifetime;

	private float InitialTime;

	// Use this for initialization
	void Start () 
	{
		InitialTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += speed*Vector3.up*Time.deltaTime;
		if (Time.time - InitialTime > lifetime)
		{
			Destroy(gameObject);
		}
	}
}
