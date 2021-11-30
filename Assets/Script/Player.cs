using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float min_X, max_X;
    [SerializeField]
    private GameObject player_Bullet;
    [SerializeField]
    private Transform attack_Point;
    [SerializeField]
    private Transform attack_Point1;
    [SerializeField]
    private Transform attack_Point2;
    public float attack_Timer = 0.35f;
    public float current_Attack_Timer;
    private bool canAttack;
    public bool pcanShoot;
    //private AudioSource shootSound;

    void Awake()
    {
        //shootSound = GetComponent<AudioSource>();

    }
    void Start()
    {
        if(pcanShoot)
        Invoke("Attack", current_Attack_Timer);
    }
    void Update()
    {
        MovePlayer();
        // Attack();
    }
    void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            if (temp.x > max_X)
                temp.x = max_X;
            transform.position = temp;

        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            if (temp.x < min_X)
                temp.x = min_X;
            transform.position = temp;

        }
    }

    void Attack()
    {//Spawn bullets automatically with some delay
        GameObject pbullet = Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
        pbullet.GetComponent<BulletScript>().is_PlayerBullet = true;

        GameObject pbullet1 = Instantiate(player_Bullet, attack_Point1.position, Quaternion.identity);
        pbullet1.GetComponent<BulletScript>().is_PlayerBullet1 = true;

        GameObject pbullet2 = Instantiate(player_Bullet, attack_Point2.position, Quaternion.identity);
        pbullet2.GetComponent<BulletScript>().is_PlayerBullet2 = true;

        // shootSound.Play();

        if (pcanShoot)
            Invoke("Attack", current_Attack_Timer);


        /* attack_Timer += Time.deltaTime;
           if(attack_Timer > current_Attack_Timer)
           {
               canAttack = true;
           }

           if(Input.GetKeyDown(KeyCode.Space))
           {
               if(canAttack)
               {
                   canAttack = false;
                   attack_Timer = 0;
                   Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                   Instantiate(player_Bullet, attack_Point1.position, Quaternion.identity);
                   Instantiate(player_Bullet, attack_Point2.position, Quaternion.identity);
               }
           }*/
    }

}
