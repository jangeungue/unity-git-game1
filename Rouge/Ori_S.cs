using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ori_S : MonoBehaviour
{
    private float rotSpeed = 300f;
    private float speed = 30f;
    public RoguePlayerCont Rog;
    public void Update()
    {
        
        if (Input.GetKey(KeyCode.S) && !(this.transform.rotation.eulerAngles.z == -1f))
        {
            Rog.rb.velocity = Vector2.zero;
            this.transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.M))
        {
            Rog.rb.velocity = Vector3.zero;
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        
        

    }
}
