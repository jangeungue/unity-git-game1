using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;

    Vector3 movevec;

    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");

        movevec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += movevec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime; //���׿����� ����Ʈ ������ ������

        anim.SetBool("isRun", movevec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        transform.LookAt(transform.position + movevec); //LookAt ������ ���͸� ���ؼ� ȸ�������ִ� �Լ�
    }
}
