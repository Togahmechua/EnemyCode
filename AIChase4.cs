using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase4 : MonoBehaviour
{
    private Transform playerPos;
    private Rigidbody2D rb;
    private Vector3 localScale;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed*Time.deltaTime);
        LateUpdate();
        if (Vector2.Distance(transform.position, playerPos.position)<0.5f)
        {
            Destroy(gameObject);
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
