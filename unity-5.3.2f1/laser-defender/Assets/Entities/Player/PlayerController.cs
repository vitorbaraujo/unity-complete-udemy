using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float padding = 1f;
	public GameObject laserPrefab;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 250f;
	public AudioClip fireSound;

	float xmin, xmax;

	void Start() {
		float distance = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));

		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		// restricts the player to the game space
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
	}

	void Fire() {
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
		GameObject beam = Instantiate (laserPrefab, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			
			if (health <= 0) {
				Die ();
			}
		}
	}

	void Die() {
		LevelManager levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Win Screen");
		Destroy (gameObject);
	}
}
