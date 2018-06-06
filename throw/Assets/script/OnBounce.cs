using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBounce : MonoBehaviour {

	public float lightFadeTime = 1.0f;
	public float lightRangeMultiplier = 1.2f;
	public List<AudioClip> dingClips;
	public AudioClip bounceClip;

	private AudioSource myAudioSource;
	private Light myLight;


	void Start () 
	{
		myAudioSource = gameObject.GetComponent<AudioSource>();
		myLight = gameObject.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!GetComponent<Rigidbody>().useGravity)
		{
			//if (!myAudioSource.isPlaying)
			//{
			myAudioSource.clip = dingClips[Random.Range(0, dingClips.Count)];
			myAudioSource.Play();
			//}
			//else
			//{
			//	myOtherAudioSource = gameObject.AddComponent<AudioSource>();
			//}
			//myLight.range *= lightRangeMultiplier;
			//StartCoroutine(dimLight());
		}
		else
		{
			myAudioSource.clip = bounceClip;
       		myAudioSource.Play();
			//myLight.range *= lightRangeMultiplier;
			//StartCoroutine(dimLight());
		}
	}

	IEnumerator dimLight()
	{
		yield return new WaitForSeconds(lightFadeTime);
		//myLight.range /= lightRangeMultiplier;

	}


}
