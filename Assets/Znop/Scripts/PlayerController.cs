using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float speed = 0;
	float fwdSpeed = 0.5f;
	float rotAngle = 5;
	float rotSpeed = 10;
	public static Vector3 PlayerPos = Vector3.zero;

	void Start () {	
	}

	void Update () 
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(transform.up, Time.deltaTime * -rotAngle * rotSpeed);			
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(transform.up, Time.deltaTime * rotAngle * rotSpeed);			
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			speed += fwdSpeed;
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			speed -= fwdSpeed;
		}
		if(speed < 1)
			speed = 1;
		if(speed > 20)
			speed = 20;

		transform.position += transform.forward * Time.deltaTime * speed;

		PlayerPos = transform.position;
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag("Missile1") || collision.gameObject.CompareTag("Missile2"))
		{
			AudioMgr.Instance.PlayExplosion();
			GameMgr.Instance.GameState = 2;
		}
	}
}
