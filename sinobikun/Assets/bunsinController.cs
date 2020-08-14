using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunsinController : MonoBehaviour
{
    public int bunsincount=0;

    GameObject player;
    public GameObject syurikenPrefab;

    void Start()
    {
        this.player=GameObject.Find("sinobi");
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 playerPos=this.player.transform.position;
            transform.position=new Vector3(playerPos.x-0.5f,playerPos.y,playerPos.z);
            if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject obj;
                obj=Instantiate(syurikenPrefab);
                obj.transform.position=transform.position;
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
}
