using UnityEngine;
using System.Collections.Generic;

public class StoryScript : MonoBehaviour {

	public  List<GameObject> Pages;

	int curPage = 0;
	float doubleClickTimer = 0.5f;
	bool clickBlocked = false;

	void Start () {
		UpdateUI();	
	}

	void Update () {
		if(clickBlocked)
		{
			doubleClickTimer -= Time.deltaTime;
			if(doubleClickTimer < 0)
			{
				clickBlocked = false;
				doubleClickTimer = 0.5f;
			}
		}
	
	}

	void UpdateUI()
	{
		for(int i = 0; i < Pages.Count; i++)
		{
			Pages[i].SetActive(false);
		}
		Pages[curPage].SetActive(true);
	}

	public void OnNextPage()
	{
		if(clickBlocked)
		{

		}
		else
		{
			AudioMgr.Instance.PlayBtnSfx();

			if(curPage + 1 >= Pages.Count)
			{
				Application.LoadLevel(GameMgr.Scene_MainMenu);
			}
			else
			{
				curPage++;
				UpdateUI();
			}
		}
	}

}
