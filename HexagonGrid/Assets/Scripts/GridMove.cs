using UnityEngine;
using System.Collections;

public class GridMove : MonoBehaviour {

	public Vector2 dest;
	Vector2 dir;
	Vector2 velocity;
	public float maxMove = 1f;
	public float speed = 2f;


	// Use this for initialization
	void Start () {
		dest = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		dir = dest - (Vector2)transform.position;

		if(dir.magnitude <= maxMove)
		{
			velocity = dir.normalized * speed * Time.deltaTime;
			velocity = Vector2.ClampMagnitude (velocity, dir.magnitude);
		}
		transform.Translate (velocity);
	}
}
