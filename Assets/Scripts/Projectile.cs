using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    float speed; //despite only ever being set to 3.5, I'm keeping this as a variable in case I want to add different types of shots for different enemies
    public Ship ParentShip { get; set;}

    void Start()
    {
        speed = 3.5f;
    }

    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.Equals(ParentShip))
        {
            Destroy(gameObject);
            ParentShip.shotExists = false;
        }
    }
}
