using UnityEngine;
using System.Collections.Generic;

public class EnemyBoat : MonoBehaviour {

	float nextMissileTime = 0.5f;

	public GameObject MissilePoolObj;
	List<GameObject> MissilePool;
	int currentMissileIndex = 0;

	public GameObject Missile_01;
	public GameObject Player_01;
	bool inRange = false;

	void Start () {
		MissilePool = new List<GameObject>();
		for(int i = 0; i < 25; i++)
		{
			GameObject curMissile = GameObject.Instantiate(Missile_01) as GameObject; 
			curMissile.transform.position = new Vector3(-1000, 0, 0);
			curMissile.transform.parent = MissilePoolObj.transform;
			MissilePool.Add(curMissile);
		}

	}

	void Update () {
		if(inRange && GameMgr.Instance.GameState == 0)
		{
			nextMissileTime -= Time.deltaTime;
			if(nextMissileTime < 0)
			{
				nextMissileTime = 0.5f;
				GameObject missile = GetMissile(); 
				MissileScript ms = missile.GetComponent<MissileScript>() as MissileScript;
				missile.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
				missile.transform.LookAt(Player_01.transform.position);
				missile.transform.Rotate(new Vector3(0, 270, 0));
				ms.Activate(transform.forward, 1);
				GameMgr.Instance.missleLaunched++;
				Debug.Log("missile Launch" + missile.transform.position);
			}
		}
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

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("Hero"))
		{
			AudioMgr.Instance.PlayShipAlert();
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.CompareTag("Hero"))
		{
			inRange = true;
		}
	}

	void OnTriggerExit(Collider col) {
		inRange = false;
	}

}
