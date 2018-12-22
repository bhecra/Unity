using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    #region Variables
    public float speedEnemy = 2.0f;

    public float amplitudX = 1.0f;
    public float amplitudY = 1.0f;
    public float speedTrigonometric = 0.5f;

    public Sprite[] enemiesGround;
    public Sprite[] enemiesAir;
    public Sprite[] enemiesObstacles;

    public Transform carEnemy, planeEnemy, obstacleEnemy;

    public SpriteRenderer enemiesGroundRender;
    public SpriteRenderer enemiesAirRender;
    public SpriteRenderer enemiesObstaclesRender;

    public Transform enemiesObstaclesParent;

    public GameObject newEnemyGround = null;
    public GameObject newEnemyAir = null;
    public GameObject newEnemyObstacle = null;

    float time = 0;
    private float x;
    private float y;
    private float tiempo;
    private Vector3 posActual;
    #endregion



    #region
    void Start()
    {
        enemiesGroundRender = enemiesGroundRender.transform.GetComponent<SpriteRenderer>();
        enemiesGroundRender.sprite = HandleChoiceEnemy(enemiesGround);

        enemiesAirRender = enemiesAirRender.transform.GetComponent<SpriteRenderer>();
        enemiesAirRender.sprite = HandleChoiceEnemy(enemiesAir);
        
        enemiesObstaclesRender = enemiesObstaclesRender.transform.GetComponent<SpriteRenderer>();
        enemiesObstaclesRender.sprite = HandleChoiceEnemy(enemiesObstacles);

    }



   
   
    // Update is called once per frame
    void Update()
    {

        
        time += Time.deltaTime;

        if(time >= 5)
        {
            HandlerCreateEnemies(carEnemy.gameObject);
            HandlerCreateEnemies(planeEnemy.gameObject);
            HandlerCreateEnemies(obstacleEnemy.gameObject);
            time = 0;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        { 
            HandleMovEnemy(enemy.transform, (int)Random.Range(1, 4));
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Chouque, destruir");
        }
        
    }

    #endregion
    // Use this for initialization



    #region Custom Methods
    void HandleMovEnemy(Transform enemy, float factor)
    {
        enemy.Translate(-Vector3.right * factor * speedEnemy * Time.deltaTime, Space.World);
    }

    void HandleObstacle(Transform obstacle)
    {

        enemiesObstaclesParent.Translate(-Vector3.right  * 0.5f * speedEnemy * Time.deltaTime, Space.World);
        
        tiempo += Time.deltaTime;
        y = (amplitudX * Mathf.Cos(tiempo * speedTrigonometric));
        x =  (amplitudY * Mathf.Sin(tiempo * speedTrigonometric));
        obstacle.localPosition = new Vector3(x, y, 0);
    }

    GameObject  HandlerCreateEnemies(GameObject objectNew)
    {
        GameObject Enemy = Instantiate(objectNew, objectNew.transform.position, objectNew.transform.localRotation);
        return Enemy;
    }

    Sprite HandleChoiceEnemy(Sprite[] enemies)
    {
        int rand = 0;
        rand =  Random.Range(0, enemies.Length);
        return enemies[rand];
    }
    #endregion

}
