using UnityEngine;
using System.Collections;

public abstract class Ship : MonoBehaviour {

    public int health { get; set; }
    public bool shotExists;
    protected Projectile Shot;
    public Vector2 Direction { get; set; }
    protected float speed;
    protected int pointValue;

    public void Rock()
    {
        //plays rocking animation if ship with more than 1 health left gets hit.
    }

    public void Fire()
    {
        Instantiate(Shot);
        shotExists = true;
    }
}
