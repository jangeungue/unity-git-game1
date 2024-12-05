using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RogueShoot : MonoBehaviour
{
   

    public GameObject bullet;
    public Transform pos;



    public void WindKnifeSkill()
    {
        Instantiate(bullet, pos.position, transform.rotation); //bullet 동적 생성
    }

}
