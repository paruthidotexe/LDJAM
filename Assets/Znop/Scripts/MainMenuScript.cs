using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	void Start () {
	
	}
	
	void Update ()
	{
		if(Input.GetKeyUp(KeyCode.P))
		{
			Application.LoadLevel(GameMgr.Scene_InGame);
		}
		if(Input.GetKeyUp(KeyCode.S))
		{
			Application.LoadLevel(GameMgr.Scene_Story);
		}
		if(Input.GetKeyUp(KeyCode.C))
		{
			Application.LoadLevel(GameMgr.Scene_Credits);
		}

		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
			{
				if(hit.collider.name.Equals("PlayBtn"))
				{
					AudioMgr.Instance.PlayBtnSfx();
					Application.LoadLevel(GameMgr.Scene_InGame);
				}
				else if(hit.collider.name.Equals("StoryBtn"))
				{
					AudioMgr.Instance.PlayBtnSfx();
					Application.LoadLevel(GameMgr.Scene_Story);
				}
				else if(hit.collider.name.Equals("CreditsBtn"))
				{
					AudioMgr.Instance.PlayBtnSfx();
					Application.LoadLevel(GameMgr.Scene_Credits);
				}
			}
		}


	}
}
