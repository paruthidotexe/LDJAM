using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

	Vector3 startPos = new Vector3(7.5f, 2, -4);
	Vector3 endPos = new Vector3(-1, 13, -1);
	Vector3 endRotation = new Vector3(0, 270, 0);

	public GameObject CreditsObj;

	float curTime = 0.0f;

	void Start ()
	{
		transform.position = startPos;
	}
	
	void Update ()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			OnMainMenu();
		}
		transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(endRotation), Time.deltaTime);

		curTime += Time.deltaTime;
		if(curTime > 2f)
		{
			transform.position = endPos;
			transform.rotation = Quaternion.Euler(endRotation);
			ShowCredits();
		}
	}

	void ShowCredits()
	{
		CreditsObj.SetActive(true);
	}

	public void OnMainMenu()
	{
		AudioMgr.Instance.PlayBtnSfx();
		Application.LoadLevel(GameMgr.Scene_MainMenu);
	}
}


