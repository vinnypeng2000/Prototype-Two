using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Projectile projectilePrefab;
    public Transform offset;
    public GameManager gm;
    public float interval;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.start)
        {
            timer += Time.deltaTime;
            if(timer >= interval)
            {
                StartCoroutine(fire(1));
                timer -= interval;
            }
        }
    }

    public IEnumerator fire(float delay)
    {
        Instantiate(projectilePrefab, offset.position, transform.rotation);
        yield return new WaitForSeconds(delay);
    }
}
