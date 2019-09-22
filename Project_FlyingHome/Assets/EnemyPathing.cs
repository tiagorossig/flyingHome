using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    private void Update()
    {
        if (speed == 0)
        {
            speed = 2f;
        }
        // if true, moves to right
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(5, 5);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-5, 5);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "turn")
        {
            if(MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

}
