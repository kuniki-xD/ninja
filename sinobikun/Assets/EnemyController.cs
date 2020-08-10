using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;

    void OnTriggerEnter2D(Collider2D collider)
    {
        health--;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
