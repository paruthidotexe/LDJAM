using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float speed = 0;
	public static Vector3 PlayerPos = Vector3.zero;

	void Start () {	
	}

	void Update () 
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(transform.up, -10);			
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(transform.up, 10);			
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			speed += 1;
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			speed -= 5;
		}
		if(speed < 1)
			speed = 1;
		if(speed > 20)
			speed = 20;

		transform.position += transform.forward * Time.deltaTime * speed;

		PlayerPos = transform.position;
	}
}
