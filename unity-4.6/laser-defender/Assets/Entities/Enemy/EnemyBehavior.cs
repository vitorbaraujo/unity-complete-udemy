using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float health = 150f;
	public GameObject laserPrefab;
	public float projectileSpeed;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;

	public AudioClip fireSound;
	public AudioClip destroyedSound;

	private ScoreController scoreController;

	void Start() {
		scoreController = GameObject.Find ("Score").GetComponent<ScoreController>();
	}

	void Update() {
		float probability = shotsPerSecond * Time.deltaTime;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();

			if (health <= 0) {
				Die();
			}
		}
	}

	void Fire() {
		GameObject beam = Instantiate (laserPrefab, transform.position, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void Die() {
		AudioSource.PlayClipAtPoint(destroyedSound, transform.position);
		scoreController.Score(scoreValue);
		Destroy (gameObject);
	}
}
