using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyController : MonoBehaviour
{
    public int health;
    public int move;
    private Vector3 targetpos;
    private PlayerController pc;

    void Start()
    {
        pc = GameObject.Find("idle01").GetComponent<PlayerController>();   
    }

    void Update()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();
        rb.velocity= new Vector3(move,0,0);
        transform.localScale=new Vector3(-4.7f,transform.localScale.y,transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        health--;
        if(health<=0)
        {
            pc.Spawn();
            Destroy(gameObject);
        }
    }
}
