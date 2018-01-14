﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 14f;
	public float height = 7f;
	public float speed = 5f;

	private float xmin;
	private float xmax;
	private bool movingRight;
	
	void Start(){
		float distance = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));
		
		xmin = leftMost.x;
		xmax = rightMost.x;

		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	void Update(){
		float leftEdgeOfFormation = transform.position.x - width / 2;
		float rightEdgeOfFormation = transform.position.x + width / 2;
		if (leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax) {
			movingRight = !movingRight;
		}

		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}
}