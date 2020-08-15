using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunsinController : MonoBehaviour
{
    Animator animator;
    
    public int bunsincount=0;

    [SerializeField] private float _velocity = 0.5f;
    private int _direction = 1;

    private GameObject player;
    public GameObject syurikenPrefab;

    void Start()
    {
        this.animator=GetComponent<Animator>();
        this.player=GameObject.Find("idle01");
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
        if (player != null)
        {
            transform.position=new Vector3(playerPos.x + (_velocity * Time.deltaTime * _direction),player.transform.position.y,playerPos.z);
        }
        else
        {
            Debug.Log("Playerがnull");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj;
            obj=Instantiate(syurikenPrefab);
            obj.transform.position=transform.position;
            this.animator.SetTrigger("AttackTrigger");
        }

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