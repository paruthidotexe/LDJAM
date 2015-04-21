using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

	float speed = 0.5f;
	bool isActivated = false;
	int missileType = 0;
	Vector3 dir = Vector3.forward;
	float MissileTime = 5.0f;

	void Start () {
	
	}
	
	void Update () {
		if(isActivated)
		{ 
			if(missileType == 0)
			{
				transform.position += dir * Time.deltaTime * 10;
			}
			else if(missileType == 1)
			{
				MissileTime -= Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position,
				                                         PlayerController.PlayerPos,
				                                         Time.deltaTime * 10);
				//transform.position = Vector3.Lerp(transform.position, PlayerController.PlayerPos, Time.deltaTime * speed);
				transform.LookAt(PlayerController.PlayerPos);
				transform.Rotate(new Vector3(0, 270, 0));

				if(MissileTime < 0)
				{
					MissileTime = 5.0f;
					transform.position = new Vector3(-1000, 0, 0);
					isActivated = false;
					//AudioMgr.Instance.PlayExplosion();
				}
			}
		}
	}

	public void Activate(Vector3 newDir, int curType)
	{
		isActivated = true;
		gameObject.SetActive(true);
		dir = newDir;
		missileType = curType;
	}
}
