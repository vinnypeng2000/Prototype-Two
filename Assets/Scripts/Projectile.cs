using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Here");
        // Destroy(gameObject);
        if (!collision.gameObject.CompareTag("Evil Wizard")) 
        {
            Destroy(gameObject);
        }
    }
}
