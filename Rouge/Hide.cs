using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Hide : MonoBehaviour
{
    //[SerializeField]
    //SpriteRenderer SR;
    ////private bool isHiding = false;
    [SerializeField]
    RoguePlayerCont Rog;
    [SerializeField]
    BoxCollider2D box;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Rog.jumpCount = 0;
        }
        
        if (Rog.Hide == true)
        { 
            box.isTrigger = true;
        }
        
         
    }

    
    //public void Start()
    //{
    //    Rog = GetComponent<RoguePlayerCont>();
    //}
    //public void HIDE()
    //{
    //    //isHiding = true;
    //    Rog.speed = 5.0f;
    //    StartCoroutine(HideSkill());
    //}

    //private IEnumerator HideSkill()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f); // 적 인식 반경 은신

    //    foreach (Collider2D col in colliders)
    //    {
    //        if (col.CompareTag("Monster"))
    //        {

    //            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
    //            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col, true);

    //        }

    //    }

    //    yield return new WaitForSeconds(3.0f);

    //    foreach (Collider2D col in colliders)
    //    {
    //        if (col.CompareTag("Monster"))
    //        {

    //            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
    //            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col, false);

    //        }
    //    }

    //    //isHiding = false;
    //    Rog.speed = 3.0f;
    //}
}
