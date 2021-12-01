using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   
    public float speed = 5f;
    public float deactivate_Timer = 3f;
    [HideInInspector]
    public bool is_EnemyBullet = false;
    public bool is_PlayerBullet = false;
    public bool is_PlayerBullet1 = false;
    public bool is_PlayerBullet2 = false;
// private AudioSource explosionSound;

    void Awake()
    {
       //explosionSound = GetComponent<AudioSource>();
    }
    void Start()
    {
        if (is_EnemyBullet)
            speed *= -1f;

        if (is_PlayerBullet)
            speed *= 1f;
        if (is_PlayerBullet1)
            speed *= 1f;
        if (is_PlayerBullet2)
            speed *= 1f;
        Invoke("DeactivateGameObject", deactivate_Timer);
     //   Invoke("SpawnBullets", bulletspawn_Timer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;

       
    }
    void DeactivateGameObject()
    {
        
        //
        gameObject.SetActive(false);
       
    }

    void OnTriggerEnter2D (Collider2D target)
    {
        if(target.gameObject.tag == "Bullet" || target.gameObject.tag == "Enemy")
        {

            gameObject.SetActive(false);
            Destroy(target.gameObject);
        //    ScoreText.scoreValue += 1;
        }

        if (target.gameObject.tag == "Enemy")
        {

           ScoreText.scoreValue += 1;
        }




    }
}
    
