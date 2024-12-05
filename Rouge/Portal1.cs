using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
{
    private static Portal1 instance; //portal1의 스크립트를 선언 하지만 값을 안넣어줬기에 null값
    private void Start()
    {
        //instance = GetComponent<Portal1>();
        if (null == instance) //instance가 null값이면 실행
        {
            instance = this; //instance에 자기자신의 portal1을 넣어줌 == instance = getcomponet랑 같은역할
            DontDestroyOnLoad(this.gameObject);  //씬이동을해도 파괴되지 않게해줌
        }
        else
        {
            DestroyObject(this.gameObject); //instance가 null이 아니라면 해당 오브젝트를 파괴(경고 떠도 무시해)
        }
    }

    public bool trig = false;
    int i;
    string portalname;
    public void PortalExcute()
    {
        if (portalname == "Portal" && trig == true)
        {
            i++;
            print(i);
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D COL) // col지역변수
    {
        print(portalname);
        if (COL.gameObject.layer == 6)
        {
            portalname = COL.gameObject.name;
            trig = true;
        }
        print(portalname);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            trig = false;
            portalname = null;
        }
    }
}
