using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject[] enemyObjects;
    private float interval;
    private float time=0f;
    public int health;

    void Start()
    {
        interval=10f;
    }

    void Update()
    {
        transform.localScale=new Vector3(-8.3f,transform.localScale.y,transform.localScale.z);
        time+=Time.deltaTime;
        enemyObjects=GameObject.FindGameObjectsWithTag("enemy");

        if(enemyObjects.Length==0)
        {
            if(time>interval)
            {
                GameObject enemy=Instantiate(enemyPrefab);
                enemy.transform.position=new Vector3(transform.position.x-10,transform.position.y-3,0);
                time=0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        health--;
        if(health<=0)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene("Result");
        }
    }
}
