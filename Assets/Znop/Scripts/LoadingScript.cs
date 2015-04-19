using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour 
{
	float curTime = 3.0f;

	void Start ()
	{
	}
	
	void Update ()
	{
		curTime -= Time.deltaTime;
		if(curTime < 0)
		{
			Application.LoadLevel(GameMgr.Scene_MainMenu);
		}
	}
}
