using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIchase3 : MonoBehaviour
{   
    public GameObject Explosion;
    private Transform player;
    private float distance;
    public float speed;
    public float distanceBTW;
    private Rigidbody2D rb;
    private Vector3 localScale;
 
    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position , player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance <= distanceBTW)
        {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        rb.velocity = new Vector2(direction.x, direction.y);
        }
        LateUpdate();
        ExplosionEffect();
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceBTW);
    }

    private void ExplosionEffect()
    {
        if (Vector2.Distance(transform.position , player.transform.position) <= 0.5f)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
