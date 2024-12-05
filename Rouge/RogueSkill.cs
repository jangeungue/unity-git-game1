using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueSkill : MonoBehaviour
{
    [SerializeField]
    RogueShoot ros;
    [SerializeField]
    RoguePlayerCont rpc;
    public int WindKnifeNum = -1;
 
    public void WindKnife()
    {
        if (WindKnifeNum > 0) //윈드나이프 0보다 클 떄   
        {
            WindKnifeNum--;

            ros.WindKnifeSkill();
            rpc.WindKnifeCol = 0.5f;
            
        }
        else if(WindKnifeNum == 0) //윈드나이프 0일 떄 10초 쿨타임 
        {
            rpc.WindKnifeCol = 10f;
            WindKnifeNum--;
        }
        else // 윈드나이프 0보다 작을 때 (재충전)
        {
            WindKnifeNum = 5;
        }
    }
}
