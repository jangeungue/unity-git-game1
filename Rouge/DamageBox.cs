using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DamageBox : MonoBehaviour
{
    [SerializeField]
    RoguePlayerCont rpc;
    public Transform pos;
    public Vector2 boxSize;

    public float ATKcurTime; //쿨타임을 대입할 임시값
    public float ATKcooltime = 0.5f; //쿨타임 기본값 
    public float skill1curTime; //스킬1쿨타임을 대입할 임시값
    public float skill1cooltime = 0.6f; //스킬1쿨타임 기본값 


    public void Update()
    {
        ATKcurTime -= 1 * Time.deltaTime;
        skill1curTime -= 1 * Time.deltaTime;
    }
    public void ATK()
    {
        if (ATKcurTime <= 0)
        {
            
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Monster")
                {
                    
                    collider.GetComponent<Monster>().TakeDamage(1);

                }
            }
        }
        ATKcurTime = ATKcooltime;
    }
    public void Skill1()
    {
        if (skill1curTime <= 0)
        {

            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Monster")
                {

                    collider.GetComponent<Monster>().TakeDamage(1);

                }
            }
        }
        skill1curTime = skill1cooltime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}

