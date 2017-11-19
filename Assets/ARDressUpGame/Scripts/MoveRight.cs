using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {

	public float Speed=1.0f;
	public GameObject MovedObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.right*Speed*1.0f);

		if (transform.position.x >= 1000)
			//transform.position = new Vector3(-1500, transform.position.y, transform.position.z);
			transform.Translate(Vector3.left*1100);
	}
}
