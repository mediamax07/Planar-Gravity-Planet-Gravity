using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlanarGravityScript : MonoBehaviour {
	public Transform planetTarget;
	public float forceAmount = 1000.0f;
	public float gravityRadius = 10.0f;
	public Color gizmosColor = Color.red;

	Vector3 targetDirection;

	// Use this for initialization
	void Start () {
		Physics.gravity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (transform.position, planetTarget.position);

		targetDirection = planetTarget.position - transform.position;
		targetDirection = targetDirection.normalized;

		if (distance < gravityRadius) {
			GetComponent<Rigidbody> ().AddForce (targetDirection * forceAmount * Time.deltaTime);
		}
	}

	void OnDrawGizmos () {
		Gizmos.color = gizmosColor;
		Gizmos.DrawWireSphere (planetTarget.position, gravityRadius);
	}
}
