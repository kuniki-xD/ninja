﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce=680.0f;
    float walkForce=30.0f;
    float maxWalkSpeed=6.0f;

    public GameObject syurikenPrefab;
    public GameObject bunsinPrefab;

    public int bunsincount=0;

    void Start()
    {
        this.rigid2D=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //ジャンプ
        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y==0)
        {
            this.rigid2D.AddForce(transform.up*this.jumpForce);
        }

        //左右移動
        int key=0;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key=1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key=-1;
        }

        //プレイヤの速度
        float speedx=Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if(speedx<this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right*key*this.walkForce);
        }

        //動く方向に応じて反転
        if(key!=0)
        {
            transform.localScale=new Vector3(-key,1,1);
        }

        //手裏剣発射処理
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj;
            obj=Instantiate(syurikenPrefab);
            obj.transform.position=transform.position;
            Spawn();
            Debug.Log(bunsincount);
        }
    }
    public void Spawn()
    {
        Instantiate(bunsinPrefab,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        bunsincount++;
    } 

    public int GetBunsinCount()
    {
        return bunsincount;
    }
}
