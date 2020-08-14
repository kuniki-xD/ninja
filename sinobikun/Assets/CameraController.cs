﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        this.player=GameObject.Find("idle01");
    }

    void Update()
    {
        Vector3 playerPos=this.player.transform.position;
        transform.position=new Vector3(playerPos.x,playerPos.y+2,transform.position.z);
    }
}
