using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunsinController : MonoBehaviour
{
    public int bunsincount=0;

    GameObject player;
    public GameObject syurikenPrefab;

    private float b_speed=5.0f;
    private float b_attenuation=7.0f;
    
    private Vector3 b_velocity;

    void Start()
    {
        this.player=GameObject.Find("sinobi");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj;
            obj=Instantiate(syurikenPrefab);
            obj.transform.position=transform.position;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            bunsincount++;
        }
        if(bunsincount==0)
        {
            b_velocity+=(this.player.transform.position-transform.position)*b_speed;
            b_velocity*=b_attenuation;
            transform.position+=b_velocity*=Time.deltaTime;
            
        }
        else if(bunsincount>0&&bunsincount<4)
        {
            b_velocity+=(this.player.transform.position-transform.position)*b_speed;
            b_velocity*=b_attenuation-bunsincount*1.5f;
            transform.position+=b_velocity*=Time.deltaTime;
        }
        else if(bunsincount>=4)
        {
            bunsincount--;
        }
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
