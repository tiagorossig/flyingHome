using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpiderPathing : MonoBehaviour
{
    public float speed;
    public bool MoveUp;

    private void Update()
    {
        if (speed == 0)
        {
            speed = .2f;
        }
        // if true, moves to right
        if (MoveUp)
        {
            transform.Translate(0, 2 * Time.deltaTime * speed, 0);
        }
        else
        {
            transform.Translate(0, -2 * Time.deltaTime * speed, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("turn"))
        {
            if (MoveUp)
            {
                MoveUp = false;
            }
            else
            {
                MoveUp = true;
            }
        }
    }

}
