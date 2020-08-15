using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;

    Animator animator;

    float jumpForce=680.0f;
    float walkForce=30.0f;
    float maxWalkSpeed=6.0f;

    public GameObject syurikenPrefab;
    public GameObject bunsinPrefab;
    public GameObject dodaiPrefab;

    public AudioClip jumpSE;
    public AudioClip syurikenSE;
    public AudioClip damageSE;
    public AudioClip doronSE;
    public AudioClip gekihaSE;
    AudioSource aud;

    public int sinobicount=0;
    public int health;
    public int syurikenhoukou;

    private List<GameObject> bunsinObjectList;

    void Start()
    {
        this.rigid2D=GetComponent<Rigidbody2D>();
        this.aud=GetComponent<AudioSource>();
        this.animator=GetComponent<Animator>();
        bunsinObjectList = new List<GameObject>();
    }

    void Update()
    {
        if(this.rigid2D.velocity.x>=0)
        {
            syurikenhoukou=1;
        }
        if(this.rigid2D.velocity.x<=0)
        {
            syurikenhoukou=-1;
        }

        //ジャンプ
        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y==0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up*this.jumpForce);
            this.aud.PlayOneShot(this.jumpSE);
        }

        //左右移動
        float key=0;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key=1.13f;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key=-1.13f;
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
            transform.localScale=new Vector3(key,transform.localScale.y,transform.localScale.z);
        }

        //手裏剣発射処理
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj;
            obj=Instantiate(syurikenPrefab);
            obj.transform.position=transform.position;
            this.aud.PlayOneShot(this.syurikenSE);
            this.animator.SetTrigger("AttackTrigger");
        }
        if(Input.GetKeyDown(KeyCode.R)&& this.rigid2D.velocity.y==0)
        {
            Dodai();
        }

        if(transform.position.y<-10)
        {
            // DestroyImmediate(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag=="enemy")
        {
            this.aud.PlayOneShot(this.damageSE);
            this.animator.SetTrigger("HurtTrigger");
            health--;
        }
        if(health<=0)
        {
            // DestroyImmediate(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Spawn()
    {
        this.aud.PlayOneShot(this.gekihaSE);
        if(sinobicount==0)
        {
            bunsinObjectList.Add(Instantiate(bunsinPrefab,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity) as GameObject);
            sinobicount++;
        }
        else if(sinobicount>0&&sinobicount<4)
        {
            bunsinObjectList.Add(Instantiate(bunsinPrefab,new Vector3(transform.position.x-sinobicount,transform.position.y,transform.position.z),Quaternion.identity) as GameObject);
            sinobicount++;
        }
    }
    public void Dodai()
    {
        if (bunsinObjectList.Count > 0)
        {
            Instantiate(dodaiPrefab,new Vector3(transform.position.x+1,transform.position.y+0.5f,transform.position.z),Quaternion.identity);
            this.animator.SetTrigger("DodaiTrigger");
            // Destroy(bunsinObjectList(bunsinObjectList.Count - 1));
            bunsinObjectList.RemoveAt(bunsinObjectList.Count - 1);
            this.aud.PlayOneShot(this.doronSE);
        }
    }
}