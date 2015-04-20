using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlayScript : MonoBehaviour {

	float gamePlayed = 0;
	public Text gameTimeText;
	public Text enemyCountText;

	public GameObject Enemy_01;
	public GameObject Enemy_02;
	public GameObject Missile_01;



	long curTimeSec = 0;
	float curTime = 0;

	bool isMissleLaunched = false;

	void Start () {
	}
	
	void Update () {
		curTime += Time.deltaTime;
		if(curTime >= 1.0f)
		{
			curTimeSec++;
			curTime = 0;
			UpdateUI();
			isMissleLaunched = false;
		}

		if(curTimeSec % 2 == 0 && !isMissleLaunched)
		{
			isMissleLaunched = true;
			GameObject missile = GameObject.Instantiate(Missile_01) as GameObject; 
			MissileScript ms = missile.GetComponent<MissileScript>() as MissileScript;
			missile.transform.position = Enemy_02.transform.position;
			ms.Activate();
		}

	}

	public void OnMainMenu()
	{
		AudioMgr.Instance.PlayBtnSfx();
		Application.LoadLevel(GameMgr.Scene_MainMenu);
	}

	void UpdateUI()
	{
		gameTimeText.text = curTimeSec.ToString() + "Sec";
	}
}
