using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public bool canShoot;
    public GameObject bullet_Prefab;
    public float bulletspawn_Timer;
    private bool canMove = true;
    public float bound_Y = -10f;
    public Transform attack_Point;
    private Animator anim;

  //  public GameObject enemyExplosion;
  
    void Awake()
    {
     
    }
    void Start()
    {
       // this.GetComponent<EnemyScript>().enemyExplosion = (GameObject)GameObject.Find("Explosion");

        if (canShoot)
            Invoke("StartShooting", bulletspawn_Timer);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position; //Moving enemies in -ve y direction   
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < bound_Y)      //disabling enemy objects once it is out of the screen
                gameObject.SetActive(false);
        }
    }
    void StartShooting()
    { //Enemy Bullet Instantiation
        GameObject bullet = Instantiate(bullet_Prefab, attack_Point.position,Quaternion.identity);
        
        bullet.GetComponent<BulletScript>().is_EnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", bulletspawn_Timer);
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Bullet" || target.gameObject.tag == "Enemy")

        {
            
           // explosionSound.Play();
            canMove = false;

            if(canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }
            Invoke("TurnOffGameObject", 3f);
           // enemyExplosion.transform.position = target.transform.position;
           // enemyExplosion.GetComponent<ParticleSystem>().Play();
           // anim.Play("Destroy");
        }
    }
    }

