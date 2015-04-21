using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	float speed = 1f;

	void Start () {
		
	}
	
	void Update () {

		transform.position = Vector3.Lerp(transform.position, PlayerController.PlayerPos, Time.deltaTime * speed);
		transform.LookAt(PlayerController.PlayerPos);			
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag("Missile2"))
		{
			GameMgr.Instance.enemiesKilled += 1; 
			transform.position = new Vector3(50, 6, 0);
			AudioMgr.Instance.PlayExplosion();
		}
	}
	
}
