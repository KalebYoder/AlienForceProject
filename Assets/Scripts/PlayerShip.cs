using UnityEngine;
using System.Collections;

public class PlayerShip : Ship {

    public bool isDead;
    Vector2 SpawnLoc; //The random grid square where the player will be respawned upon death.

	// Use this for initialization
	void Start () {
        isDead = false;
        Direction = new Vector2();
        Direction = Vector2.left;
        pointValue = 0;
        SpawnLoc = new Vector2();
	}

    public void Spawn()
    {
        SpawnLoc.x = Random.Range(0, 21);
        SpawnLoc.y = Random.Range(0, -21);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("EnemyShot"))
        {
            health--;
        }
    }
}
