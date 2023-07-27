using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase2 : MonoBehaviour
{
    private float distance;
    public float distanceBTW;
    private Rigidbody2D rb;
    private Player player;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;

    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(Player)) as Player;
        moveSpeed = 2f;
        localScale =  transform.localScale;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        distance = Vector2.Distance(transform.position , player.transform.position);
        if(distance <= distanceBTW)
        {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y)*moveSpeed;
        }
    }

    private void LateUpdate()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale =  new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }
}