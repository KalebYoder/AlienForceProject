using UnityEngine;
using System.Collections;

public class BaseEnemy : Ship {

	// Use this for initialization
	void Start () {
        Direction = new Vector2();
        Direction = Vector2.down;
        pointValue = 100;
        health = 1;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerShip Player = collision.collider.GetComponent<PlayerShip>();
            Player.health--;
        }
        else if(collision.collider.CompareTag("Enemy") && Physics2D.Raycast(this.transform.position, this.transform.forward, 1.0f))
        {
            this.transform.localRotation = Quaternion.Inverse(this.transform.localRotation);
        }
        else if(Physics2D.Raycast(this.transform.position, this.transform.forward, 1.0f))
        {
            if(Random.Range(0,1) == 1)
            {
                this.transform.Rotate(new Vector2(0f, 90f));
            }
            else
            {
                this.transform.Rotate(new Vector2(0f, -90f));
            }
        }
    }
}
