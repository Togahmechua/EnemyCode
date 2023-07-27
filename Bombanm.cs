using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombanm : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public float distanceBTW;
    private Animator anm;
    public AIchase3 ai;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        distance = Vector2.Distance(ai.transform.position , player.transform.position);
        if (distance <= distanceBTW)
        {
            anm.SetBool("InRangge", true);
        }
        else anm.SetBool("InRangge", false);
    }
}
