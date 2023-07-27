using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySquare : MonoBehaviour
{
    public GameObject Points;
    public GameObject ExplosionEffect;
    public int health;
    private Point point;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.Find("PointManager").GetComponent<Point>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Instantiate(Points, transform.position, Quaternion.identity);
            point.UpdateScore(score);
            //Enemy die
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
