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
    public float bound_Y = -11f;
    public Transform attack_Point;
   // private AudioSource explosionSound;

    void Awake()
    {
     // explosionSound = GetComponent<AudioSource>();
    }
    void Start()
    {
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
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < bound_Y)
                gameObject.SetActive(false);
        }
    }
    void StartShooting()
    {
        GameObject bullet = Instantiate(bullet_Prefab, attack_Point.position,Quaternion.identity);
        
        bullet.GetComponent<BulletScript>().is_EnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", bulletspawn_Timer);
    }

   

   

    }

