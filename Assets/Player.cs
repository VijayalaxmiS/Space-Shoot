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
    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    void Update()
    {
        MovePlayer();
        Attack();
        }
    void MovePlayer()
    {
        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            if(temp.x > max_X)
            temp.x = max_X;
            transform.position = temp;

        } else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            if (temp.x < min_X)
                temp.x = min_X;
            transform.position = temp;

        }
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            if(canAttack)
            {
                canAttack = false;
                attack_Timer = 0;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
            }
        }
    }
    
}
