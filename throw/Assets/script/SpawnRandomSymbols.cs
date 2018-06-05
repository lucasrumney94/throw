using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomSymbols : MonoBehaviour {

	public float spawnPeriod = 0.2f;
	public float upForceMagnitude = 1.0f;
	public float outForceMax = 3.0f;
	public List<GameObject> Symbols;
	

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("SpawnSymbols");
	}

	IEnumerator SpawnSymbols()
	{
		for(;;)
		{
			GameObject g = GameObject.Instantiate(Symbols[Random.Range(0, Symbols.Count)], transform.position, transform.rotation);
			g.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-outForceMax, outForceMax), upForceMagnitude, Random.Range(-outForceMax, outForceMax)), ForceMode.Impulse);

			yield return new WaitForSeconds(spawnPeriod);
		}
	}
	
	
}
