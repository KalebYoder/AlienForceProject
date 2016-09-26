using UnityEngine;
using System.Collections;

public class PlayerShip : Ship {

    public bool isDead;
    
    Vector2 SpawnLoc; //The random grid square where the player will be respawned upon death.

	// Use this for initialization
	void Start () {
        isDead = false;
        pointValue = 0;
        health = 1;
        SpawnLoc = new Vector2();
    }

    public void Spawn()
    {
        SpawnLoc.x = Random.Range(0, 21);
        SpawnLoc.y = Random.Range(0, -21);
    }

    /*void OnCollisionEnter2D(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("EnemyShot"))
        {
            health--;
        }
    }*/
}
