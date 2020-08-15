using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] PlayerController pc;
    [SerializeField] bunsinController bc;
    public int health;

    private Vector3 targetpos;

    void Start()
    {
        targetpos=transform.position;
    }

    void Update()
    {
        transform.position=new Vector3(Mathf.Sin(Time.time)*1.0f+targetpos.x,targetpos.y,targetpos.z);
        if(Mathf.Sin(Time.time)<=0)
        {
            transform.localScale=new Vector3(4.7f,transform.localScale.y,transform.localScale.z);
        }
        if(Mathf.Sin(Time.time)>=0)
        {
            transform.localScale=new Vector3(-4.7f,transform.localScale.y,transform.localScale.z);
        }
    }   

    void OnTriggerEnter2D(Collider2D collider)
    {
        health--;
        if(health<=0)
        {
            Destroy(gameObject);
            pc.Spawn();
            bc.bunsincount++;
        }
    }
}
