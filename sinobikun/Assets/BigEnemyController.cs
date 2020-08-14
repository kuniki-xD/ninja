using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float interval;
    private float time=0f;

    void Start()
    {
        interval=5f;
    }

    void Update()
    {
        //time+=Time.deltaTime;

        //if(time>interval)
        //{
        //    GameObject enemy=Instantiate(enemyPrefab);
        //    enemy.transform.position=new Vector3(5,0,0);
        //    time=0f;
        //}
    }
}
