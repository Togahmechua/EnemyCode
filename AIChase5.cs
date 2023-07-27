using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase5 : MonoBehaviour
{
    public GameObject effectShoot;
    public GameObject effectshoot2;
    public float timeBtwFire;
    private float time;
    public Transform firePos;
    public float ShootingRange;
    public GameObject bullet;
    private Transform playerPos;
    public float speed;
    private Vector3 startingRotation;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        startingRotation = transform.eulerAngles;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        Rotate();
        Shoot();
        if (Vector2.Distance(transform.position, playerPos.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    private void Rotate()
    {
        Vector2 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(startingRotation.x, startingRotation.y, angle-90);
    }

    private void Shoot()
    {
        time -= Time.deltaTime;
        float distanceFromPlayer = Vector2.Distance(playerPos.position, transform.position);    
        if (distanceFromPlayer <= ShootingRange && time < 0)
        {
            GameObject effect3 = Instantiate(effectShoot, firePos.position, firePos.rotation);
            GameObject effect4 = Instantiate(effectshoot2, firePos.position, firePos.rotation);
            GameObject bullet1 = Instantiate(bullet, firePos.position, Quaternion.identity);
            time = timeBtwFire;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
