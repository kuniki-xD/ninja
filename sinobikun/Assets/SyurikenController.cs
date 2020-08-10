using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyurikenController : MonoBehaviour
{
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
        time+=Time.deltaTime;
        if(time>5.0f)
        {
            Destroy(gameObject);
        }
    }
}