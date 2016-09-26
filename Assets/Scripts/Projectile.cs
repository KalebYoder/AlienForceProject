using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    int speed; //despite only ever being set to 2, I'm keeping this as a variable in case I want to add different types of shots for different enemies

    public void Start()
    {
        int speed = 2;
    }

    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
