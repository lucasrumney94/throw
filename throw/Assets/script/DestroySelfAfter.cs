using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfter : MonoBehaviour {


	public float lifeTime = 2.0f; 

	private float initialTime;
	// Use this for initialization
	void Start () 
	{
		initialTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time - initialTime > lifeTime)
		{
			Destroy(gameObject);
		}
	}
}
