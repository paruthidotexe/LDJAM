using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamePlayScript : MonoBehaviour {

	float gamePlayed = 0;
	public Text gameTimeText;
	public Text enemyCountText;

	public GameObject Player_01;
	public GameObject Enemy_01;
	public GameObject Enemy_02;
	public GameObject Missile_01;

	public GameObject MissilePoolObj;
	List<GameObject> MissilePool;
	int currentMissileIndex = 0;

	public GameObject GameOverScr;
	public Text GOMsgText;

	long curTimeSec = 0;
	float curTime = 0;

	bool isMissleLaunched = false;

	void Start () {
		MissilePool = new List<GameObject>();
		for(int i = 0; i < 25; i++)
		{
			GameObject curMissile = GameObject.Instantiate(Missile_01) as GameObject; 
			curMissile.transform.position = new Vector3(-1000, 0, 0);
			curMissile.transform.parent = MissilePoolObj.transform;
			MissilePool.Add(curMissile);
		}
		GameOverScr.SetActive(false);
	}
	
	void Update () {
		if(GameMgr.Instance.GameState == 1)
			return;

		if(GameMgr.Instance.GameState == 2)
		{
			GameOverScr.SetActive(true);
			GOMsgText.text = "Survived for " + curTimeSec  + " Sec \nEnemies Killed " + 
					GameMgr.Instance.enemiesKilled + "\nEscaped from " + 
					GameMgr.Instance.missleLaunched + " Missiles\n\n Hope enjoyed the game";
			return;
		}

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
			GameObject missile = GetMissile(); 
			MissileScript ms = missile.GetComponent<MissileScript>() as MissileScript;
			missile.transform.position = Enemy_02.transform.position + Enemy_02.transform.forward;
			missile.transform.LookAt(Player_01.transform.position);
			missile.transform.Rotate(new Vector3(0, 270, 0));
			ms.Activate(Enemy_02.transform.forward, 0);
			GameMgr.Instance.missleLaunched++;
		}
		/*
		if(curTimeSec % 3 == 0 && !isMissleLaunched)
		{
			isMissleLaunched = true;
			GameObject missile = GetMissile(); 
			MissileScript ms = missile.GetComponent<MissileScript>() as MissileScript;
			missile.transform.position = Enemy_01.transform.position;
			missile.transform.LookAt(Player_01.transform.position);
			missile.transform.Rotate(new Vector3(0, 270, 0));
			ms.Activate(Enemy_01.transform.forward, 0);
			missleLaunched++;
		}
		*/
		transform.position = new Vector3(Player_01.transform.position.x, transform.position.y, Player_01.transform.position.z);
	}

	public void OnMainMenu()
	{
		AudioMgr.Instance.PlayBtnSfx();
		Application.LoadLevel(GameMgr.Scene_MainMenu);
	}

	void UpdateUI()
	{
		enemyCountText.text = "Enemies " + GameMgr.Instance.enemiesKilled.ToString();
		gameTimeText.text = curTimeSec.ToString() + " Sec";
	}

	GameObject GetMissile()
	{
		if(currentMissileIndex + 1 >= 0 && currentMissileIndex + 1 < MissilePool.Count )
		{
			currentMissileIndex++;
		}
		else
		{
			currentMissileIndex = 0;
		}
		return MissilePool[currentMissileIndex];
	}

	public void OnReplay()
	{
		GameMgr.Instance.GameState = 0;
		AudioMgr.Instance.PlayBtnSfx();
		Application.LoadLevel(GameMgr.Scene_InGame);
	}

	public void OnHomne()
	{
		GameMgr.Instance.GameState = 0;
		AudioMgr.Instance.PlayBtnSfx();
		Application.LoadLevel(GameMgr.Scene_MainMenu);
	}

	public void OnStory()
	{
		GameMgr.Instance.GameState = 0;
		AudioMgr.Instance.PlayBtnSfx();
		Application.LoadLevel(GameMgr.Scene_Story);
	}
}
