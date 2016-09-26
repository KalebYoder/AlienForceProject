using UnityEngine;
using System.Collections;

public abstract class Ship : MonoBehaviour {

    public int health { get; set; }
    public bool shotExists;
    public GameObject Shot;
    protected float speed = 1;
    protected int pointValue;

    public void Fire()
    {
        Instantiate(Shot, transform.position, transform.rotation);
        shotExists = true;
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
