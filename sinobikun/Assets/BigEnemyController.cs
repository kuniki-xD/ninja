using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float interval;
    private float time=0f;
    public int health;

    void Start()
    {
        interval=5f;
    }

    void Update()
    {
        transform.localScale=new Vector3(-8.3f,transform.localScale.y,transform.localScale.z);
        //time+=Time.deltaTime;

        //if(time>interval)
        //{
        //    GameObject enemy=Instantiate(enemyPrefab);
        //    enemy.transform.position=new Vector3(5,0,0);
        //    time=0f;
        //}
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        health--;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
