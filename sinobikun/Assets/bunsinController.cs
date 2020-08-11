using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunsinController : MonoBehaviour
{
    public PlayerController playerController;

    GameObject player;

    private float b_speed=5.0f;
    private float b_attenuation=5.0f;

    private Vector3 b_velocity;
    void Start()
    {
        this.player=GameObject.Find("sinobi");
    }

    void Update()
    {
        b_velocity+=(this.player.transform.position-transform.position)*b_speed;
        b_velocity*=b_attenuation;
        transform.position+=b_velocity*=Time.deltaTime;

        int key=0;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key=1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key=-1;
        }

        if(key!=0)
        {
            transform.localScale=new Vector3(-key,1,1);
        }
    }
}
