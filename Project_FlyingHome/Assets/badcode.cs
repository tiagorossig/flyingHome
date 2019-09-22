using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badcode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // disables branch collision when comes in contact with beetle
    void OnTriggerEnter2D(Collider2D other)
    {
        // find all GameObjects tagged as Branch
        // ANYTHING TAGGED AS "Branch" MUST HAVE A BOXCOLLIDER2D COMPONENT
        GameObject[] branches = GameObject.FindGameObjectsWithTag("Branch");
        // edit tags as necessary
        if (other.tag == "Beetle" || other.tag == "Acorn" || other.tag == "Spider")
        {
            // disables branch collision
            foreach (GameObject branch in branches)
                branch.GetComponent<BoxCollider2D>().enabled = false;
            // begins waiting routine, should adjust time as necessary
            StartCoroutine(EnableBox(1F));
        }

        IEnumerator EnableBox(float waitTime)
        {
            // waits for set amount of time
            yield return new WaitForSeconds(waitTime);
            // turns on branch collision
            foreach (GameObject branch in branches)
                branch.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
