using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ship : MonoBehaviour {

    public int health { get; set; }
    public bool shotExists;
    //GameObject GameObjShot;
    //protected Projectile Shot;
    public GameObject Shot;
    protected float speed = 1;
    protected int pointValue;

    public void Fire()
    {
        //GameObjShot = (GameObject)Instantiate(GameObjShot, (transform.position + (transform.up * 0.5f)) , transform.rotation);
        //Shot = GameObjShot.GetComponent<Projectile>();
        var ShotInstance = (GameObject)Instantiate(Shot, (transform.position + (transform.up * 0.6f)), transform.rotation);
        var NewProjectile = ShotInstance.GetComponent<Projectile>();
        NewProjectile.ParentShip = this;
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
