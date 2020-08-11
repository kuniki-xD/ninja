using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.position-=new Vector3(Time.deltaTime*speed,0);
        if(transform.position.x<=-8.9f)
        {
            transform.position=new Vector3(8.9f,0);
        }
        
    }
}
