using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour 
{
	public const string Scene_Loading = "LoadingScene";
	public const string Scene_MainMenu = "MainMenu";
	public const string Scene_Story = "Story";
	public const string Scene_InGame = "InGame";
	public const string Scene_Credits = "Credits";


	public int GameState = 0; //0 = normal, 1= pause, 2 = over
	public long enemiesKilled = 0;
	public long missleLaunched = 0;

	private static GameMgr instance = null;
	public static GameMgr Instance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<GameMgr>() as GameMgr;
				
				if(instance != null)
				{
					DontDestroyOnLoad(instance.gameObject);
				}
			}
			return instance;
		}
	}

	void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
	}

	void Start () {
	
	}

	void Update () {
	
	}
}
