using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Hp = 10;
    public void TakeDamage(int damage)
    {
        Hp = Hp - damage;

    }
}
