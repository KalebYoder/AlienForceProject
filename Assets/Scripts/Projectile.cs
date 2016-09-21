using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    int speed; //despite only ever being set to 2, I'm keeping this as a variable in case I want to add different types of shots for different enemies

    public void Start()
    {
        int speed = 2;
        GetComponent<Rigidbody2D>().velocity = transform.forward;
        GetComponent<Rigidbody2D>().velocity.Set(0, speed);
    }
}
