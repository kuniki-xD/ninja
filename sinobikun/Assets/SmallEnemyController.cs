using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyController : MonoBehaviour
{
    private Vector3 targetpos;
    void Start()
    {
        targetpos=transform.position;
    }

    void Update()
    {
        transform.position=new Vector3((Time.time)*0.01f+targetpos.x,targetpos.y,targetpos.z);
    }
}
