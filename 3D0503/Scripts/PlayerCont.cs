using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;
    Vector3 movevec;
    Vector3 doDodgevec;

    Animator anim;
    Rigidbody rigid;

    bool isJump;
    bool isDodge;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Dodge();
    }
    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        
    }
    void Move()
    {
        movevec = new Vector3(hAxis, 0, vAxis).normalized;
        if (isDodge)
        {
            movevec = doDodgevec;
        }
        transform.position += movevec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime; //���׿����� ����Ʈ ������ ������

        anim.SetBool("isRun", movevec != Vector3.zero); //������ ��
        anim.SetBool("isWalk", wDown);

        
    }
    void Turn()
    {
        transform.LookAt(transform.position + movevec); //LookAt ������ ���͸� ���ؼ� ȸ�������ִ� �Լ�
    }

    void Jump()
    {
        if (jDown && movevec == Vector3.zero && !isJump && !isDodge) //�������� ���� ��(�׼�X) ���� 
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse); //Impulse �ﰢ���� �� �ֱ�
            anim.SetBool("isJump", true);
            anim.SetTrigger("DoJump");
            isJump = true;
        }
    }
    void Dodge()
    {
        if (jDown && movevec != Vector3.zero && !isJump && !isDodge) //�����̰� ���� �� ȸ��
        {
            doDodgevec = movevec; // ȸ���� �� ���⺤�ͷ� �ٲٱ�
            speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.5f); //Invoke�� �ð��� �Լ� ȣ��
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }
    
}
