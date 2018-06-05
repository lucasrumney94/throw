using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerNextLevel : MonoBehaviour {

	private SteamVR_TrackedObject trackedObject;
	
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObject.index); }
	}
	
	
	private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

	void Awake()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Controller.GetPressDown(menuButton))
		{
			Debug.Log(gameObject.name + "Menu Press!");
			Debug.Log(SceneManager.sceneCountInBuildSettings);

			SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%(SceneManager.sceneCountInBuildSettings));

		}
	}
}
