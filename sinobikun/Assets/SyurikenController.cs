using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyurikenController : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    GameObject syuriken;
    private float speed=10.0f;
    private float time=0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos=transform.position;
        pos.x+=speed*Time.deltaTime;
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