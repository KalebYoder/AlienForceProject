using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    int speed; //despite only ever being set to 2, I'm keeping this as a variable in case I want to add different types of shots for different enemies
//    Ship ParentShip;

    void Start()
    {
 //       ParentShip = transform.parent.GetComponent<Ship>();
        speed = 2;
    }

    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    public void SetParent(Ship NewParent)
    {
        //ParentShip = NewParent;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.Equals(transform.parent.gameObject))
        {
//            ParentShip.shotExists = false;
            Destroy(this.gameObject);
        }
    }
}
