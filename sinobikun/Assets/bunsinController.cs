using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunsinController : MonoBehaviour
{
    public int bunsincount=0;

    [SerializeField] private float _velocity = 0.5f;
    private int _direction = 1;

    GameObject player;
    public GameObject syurikenPrefab;

    void Start()
    {
        this.player=GameObject.Find("sinobi");
        if (player != null)
        {
            Vector3 playerPos=this.player.transform.position;
            transform.position=new Vector3(playerPos.x-0.5f,playerPos.y,playerPos.z);
        }
    }

    void Update()
    {

        transform.localScale=new Vector3(1.13f,1.18f,transform.localScale.z);
        Vector3 playerPos=transform.position;
        transform.position=new Vector3(playerPos.x + (_velocity * Time.deltaTime * _direction),playerPos.y,playerPos.z);

        if(Input.GetKey(KeyCode.RightArrow))
        {
            _direction = 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = -1;
        }

        if(_direction !=0)
        {
            transform.localScale=new Vector3(_direction,1,1);
        }
    }
}