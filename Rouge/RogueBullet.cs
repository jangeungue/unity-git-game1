using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBullet : MonoBehaviour
{
    public float speed = 0.5f;
    public float distance;
    public LayerMask isLayer;
    public Vector2 bulletSize;
    public GameObject bulletClonePrefab; // 복제본 프리팹




    void Start()
    {
        //gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, distance, isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "Enemy")
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position, bulletSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    Debug.Log("명중!!!");
                    collider.GetComponent<Monster>().TakeDamage(1);
                }
            }
            Destroy(gameObject); // 본체 파괴            
        }

        if (transform.rotation.y == 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * -1 * speed * Time.deltaTime);
        }
    }
}
