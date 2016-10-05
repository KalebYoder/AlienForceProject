using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AlienForce : MonoBehaviour {

    public GameObject Asteroid;
    private GameObject NewAsteroid;
    //public ArrayList AsteroidList = new ArrayList();
    public List<Object> AsteroidList = new List<Object>();
    int levelNum;
    //public GameObject PlayerShip;
    public GameObject PlayerShip;
    //public ArrayList PlayerList = new ArrayList();
    PlayerShip Player;
    //public PlayerShip Player;
    //public GameObject Player;
    int levelDisplay;
    public GameObject EnemyShip;
    private GameObject NewShip;
    public GameObject PathAnchor; //a sub-object on the enemy that keeps it on the path
    private GameObject NewAnchor;
    //public ArrayList EnemyList = new ArrayList();
    public List<Object> EnemyList = new List<Object>();
    //Text LevelText;
    public List<Object> PathList = new List<Object>();
    public GameObject Path;
    private GameObject NewPath;

    // Use this for initialization
    void Start () {
       //creates asteroid field
        for (float x = 1.5f; x < 21.0f; x+=2.0f)
        {
            for (float y = -1.5f; y > -21.0f; y-=2.0f)
            {
                NewAsteroid = (GameObject)(Instantiate(Asteroid, new Vector3(x, y, 0f), Quaternion.identity));
                NewAsteroid.transform.parent = GameObject.Find("Asteroids").transform; //parents object to an empty at 0,0,0 to make the heirarchy cleaner when debugging.
                AsteroidList.Add(NewAsteroid);
            }
        }

        //instantiates paths which trigger pathfinding logic
        for (float y = -.5f; y > -20.5f; y-= 2.0f)
        {
            NewPath = (GameObject)Instantiate(Path, new Vector3(10.5f, y, 0f), Quaternion.identity);
            NewPath.transform.parent = GameObject.Find("Paths").transform; //parents object to an empty at 0,0,0 to make the heirarchy cleaner when debugging.
            PathList.Add(NewPath);
        }
        for (float x = .5f; x < 21f; x+= 2.0f)
        {
            NewPath = (GameObject)Instantiate(Path, new Vector3(x, -10.5f, 0f), Quaternion.Euler(0, 0, 90));
            NewPath.transform.parent = GameObject.Find("Paths").transform; //parents object to an empty at 0,0,0 to make the heirarchy cleaner when debugging.
            PathList.Add(NewPath);

        }

        //creates the player and places it on the board
        GameObject GameObjPlayer = (GameObject)Instantiate(PlayerShip, new Vector2(20.5f, -20.5f), Quaternion.Euler(0, 0, 90));
        Player = GameObjPlayer.GetComponent<PlayerShip>();
        //define level text outside of this method
        //define lives outside of this method
        //displayLives(3);
        //define LevelNum outside this method
        levelNum = 0;
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyList.Count == 0)
        {
            StartLevel();
        }
        //Need condition for dead player
        if (!(Player.isDead))
        {
            if (Input.GetKeyDown("space") && !(Player.shotExists))
            {
                Player.Fire();
            }
            else if (Input.GetKeyDown("up"))
            {
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKeyDown("left"))
            {
                Player.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKeyDown("down"))
            {
                Player.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (Input.GetKeyDown("right"))
            {
                Player.transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }
        //Player.transform.position += transform.forward * Time.deltaTime * Player.speed;
        else if (Input.GetKeyDown("space"))
        {
            Player.Spawn();
        }      
    }

    private void StartLevel()
    {
        Time.timeScale = 0; //pause game until space is hit
        levelDisplay++;
        Player.transform.position = new Vector2(20.5f, -20.5f);
        Player.transform.rotation = Quaternion.Euler(0, 0, 90);
        for (float x = .5f; x < 21f; x += 2.0f)
        {
            NewShip = (GameObject)Instantiate(EnemyShip, new Vector3(x, -.5f, 0f), Quaternion.Euler(0, 0, 180));
            NewShip.transform.parent = GameObject.Find("Enemies").transform; //parents object to an empty at 0,0,0 to make the heirarchy cleaner when debugging.
            EnemyList.Add(NewShip);
        }
        /*foreach (GameObject EnemyShip in EnemyList)
        {
            GameObject NewAnchor = (GameObject)Instantiate(PathAnchor, EnemyShip.transform.position, Quaternion.identity);
            NewAnchor.transform.parent = EnemyShip.transform;
        }*/
        //put "Press space to start" on screen
        /*while (!Input.GetKeyDown("space"))
        {
            //Waiting for player to hit space before starting the level
        }*/
        Time.timeScale = 1;
    }
    /*public void ShipCollision(BaseEnemy EnemyShip1, BaseEnemy EnemyShip2)
    {
        //if(Raycast(EnemyShip1.transform, EnemyShip1.transform.rotation, 1.0f)
        //ship facing colliding ship reverses direction for at least three units
    }*/
}
