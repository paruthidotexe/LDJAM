using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

	float speed = 0.5f;
	bool isActivated = false;

	void Start () {
	
	}
	
	void Update () {
		if(isActivated)
		{
			transform.position = Vector3.Slerp(transform.position, PlayerController.PlayerPos, Time.deltaTime * speed);
			transform.LookAt(PlayerController.PlayerPos);
			transform.Rotate(new Vector3(0, 270, 0));
		}
	}

	public void Activate()
	{
		isActivated = true;
		gameObject.SetActive(true);
	}
}
