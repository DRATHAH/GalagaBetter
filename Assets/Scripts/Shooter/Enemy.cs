using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageableCharacter
{
    public enum EnemyType
    {
        basic,
        cool,
    }
    public EnemyType enemyType;

    public float speed = 5;
    public int damage = 1;

    CharacterController controller;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyType == EnemyType.basic)
        {
            Vector3 movement = transform.forward * speed * Time.deltaTime;
            controller.Move(movement);
        }
        else if (enemyType == EnemyType.cool)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Vector3 movement = direction * speed * Time.deltaTime;
            controller.Move(movement);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();

        if (player)
        {
            player.OnHit(damage);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward);
    }
}
