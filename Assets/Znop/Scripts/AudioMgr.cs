using UnityEngine;
using System.Collections;

public class AudioMgr : MonoBehaviour {

	public AudioClip ButtonSelect;
	public AudioClip ShipAlert;
	public AudioClip Explosion;

	private static AudioMgr instance = null;
	public static AudioMgr Instance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<AudioMgr>() as AudioMgr;
				
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

	public void PlayBtnSfx()
	{
		AudioSource audioSrc = gameObject.GetComponent<AudioSource>() as AudioSource;
		audioSrc.clip = ButtonSelect;
		audioSrc.Play();
	}

	public void PlayShipAlert()
	{
		AudioSource audioSrc = gameObject.GetComponent<AudioSource>() as AudioSource;
		audioSrc.clip = ShipAlert;
		audioSrc.Play();
	}

	public void PlayExplosion()
	{
		AudioSource audioSrc = gameObject.GetComponent<AudioSource>() as AudioSource;
		audioSrc.clip = Explosion;
		audioSrc.Play();
	}
}
