using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

   
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Animator>().enabled = true;
            StartCoroutine(Explosion(.75F));
            Destroy(gameObject);
        }
    }

    IEnumerator Explosion(float waitTime)
    {
        // waits for set amount of time
        yield return new WaitForSeconds(waitTime);
    }
}
