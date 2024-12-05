using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearyMonster : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Vector2 tran;
    bool skillX = false;
    public void Skill4()
    {
        if (skillX)
        {
            Debug.Log("skillX");
            player.transform.position = tran; //player위치를 tran으로
        }
    }
    public void OnTriggerStay(Collider target)
    {
        if (target.CompareTag("Monster"))
        {
            if (skillX)
            {
                tran = target.transform.position;
                print("?");
                skillX = true;
                tran -= Vector2.left * 2;
            }
        }
        else
        {
            tran = gameObject.transform.position;
            skillX = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            skillX = false;
        }
    }
}
