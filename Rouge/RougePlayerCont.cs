using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEditorInternal;
using UnityEngine;

public class RoguePlayerCont : MonoBehaviour
{
    public float jumpPower;
    public int jumpCount;
    public bool isPlatform = false;

    [SerializeField]
    SpriteRenderer SR;
    public Rigidbody2D rb;
    Portal1 pol;

    public bool Hide = false;
    //RougeJump rj;
    public bool isATK = false;
    public bool isSkill2 = false;
    public float Maxspeed = 6;
    public float speed = 0f;
    [SerializeField]
    RogueSkill rs;
    [SerializeField]
    NearyMonster neary;
    [SerializeField]
    DamageBox db;

    public float WindKnifeCol = 0;
    public float Skill1Col = 0;
    void Start()
    {
        pol = GetComponent<Portal1>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if(speed < 2) //오른쪽 시작스피드 2부터
            {
                speed = 2;
            }
            transform.rotation = Quaternion.Euler(0, 0, 0); //오른쪽방향
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (speed < 2) //왼쪽 시작스피드 2부터
            {
                speed = 2;
            }
            transform.rotation = Quaternion.Euler(0, 180, 0); //왼쪽방향
        }
        if (speed > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); //transform 기본 움직임 스피드
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) //D키 or A키
        {
            if(speed < Maxspeed)
            {
                speed += Time.deltaTime;
            }
        }
        else if(speed > 0) //키 안 누르면 스피드 빠르게 줄어들기
        {
            speed -= 3 * Time.deltaTime;
        }
        // 포탈
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            pol.PortalExcute();
        }
        //기본공격
        if (Input.GetKey(KeyCode.J) && db.ATKcurTime <= 0) 
        {
            db.ATK();
            Debug.Log("J");
        }
        //스킬1 은신 + 이속증가
        if (Input.GetKeyDown(KeyCode.U)) //isPlatform 옵젝에 Hide 스크립트가 껴져있어 트리거 발동
        {
            Hide = true;
            print(rb.velocity);
            rb.gravityScale = 0;
        }
        //스킬2 난도질[물리]
        if (Input.GetKey(KeyCode.I) && db.skill1curTime <= 0)
        {
            db.Skill1();
            Debug.Log("Skill1");
        }
        //스킬3 윈드나이프[마법]
        if (Input.GetKey(KeyCode.O) && WindKnifeCol <= 0)
        {
            rs.WindKnife();
        }
        //스킬4 습격[물리/마법]
        if (Input.GetKeyDown(KeyCode.P))
        {
           neary.Skill4();
        }
        WindKnifeCol -= Time.deltaTime; // O bullet발사 쿨타임 
    }
    private void FixedUpdate()
    {

        //jump
        if (Input.GetKeyDown(KeyCode.K) && jumpCount < 2) //K키 and 점프카운트 < 2
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //점프 addForce 기본형
            jumpCount++; //점프카운트 +1
            //anim.SetBool("isJumping", true);
        }
        
    }
}

