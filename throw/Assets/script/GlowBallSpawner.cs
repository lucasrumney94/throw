using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBallSpawner : MonoBehaviour {

	private List<GameObject> GlowBalls;

	public GameObject GlowBall;
	public int numberOfBalls = 10;
	public float spawnRadius = 5.0f;
	public float spawnHeightMin = 5.0f;

	void Start ()
	{
		GlowBalls = new List<GameObject>();

		for (int i = 0; i < numberOfBalls; i++)
		{
			GameObject g = Instantiate(GlowBall, spawnRadius*Random.insideUnitSphere+spawnHeightMin*Vector3.up, Quaternion.identity) as GameObject;
			GlowBalls.Add(g);

			// Generate a random color
			Color myRandomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); //new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f));

			//Fetch the Renderer from the GameObject
			Renderer rend = g.GetComponent<Renderer>();

			//Set the main Color of the Material to myRandomColor
			rend.material.color = myRandomColor;
			//rend.material.EnableKeyword("_EMISSION");
			rend.material.SetColor("_EmissionColor", myRandomColor);

			//Set the Light Color to the same random Color
			g.GetComponentInChildren<Light>().color = myRandomColor;

		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void GravityOn()
	{
		foreach (GameObject ball in GlowBalls)
		{
			ball.GetComponent<Rigidbody>().useGravity = true;
		}
	}

	public void GravityOff()
	{
		foreach (GameObject ball in GlowBalls)
		{
			ball.GetComponent<Rigidbody>().useGravity = false;
		}
	}
}
