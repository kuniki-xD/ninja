using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyurikenController : MonoBehaviour
{
    GameObject syuriken;
    private float speed=10.0f;
    private float time=0.0f;
    private int _direction;

    private PlayerController pc;

    void Start()
    {
        pc = GameObject.Find("idle01").GetComponent<PlayerController>();
        _direction = pc._direction;
    }

    void Update()
    {
        Vector3 pos=transform.position;
        pos.x+= _direction*speed*Time.deltaTime;
        transform.position=pos;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="enemy")
        {
            Destroy(gameObject);
        }
        if(collider.gameObject.tag=="bigenemy")
        {
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }
}