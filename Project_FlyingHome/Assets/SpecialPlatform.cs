using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    
    public void PhaseDown()
    {
        StartCoroutine(PhaseTimer());
    }

    IEnumerator PhaseTimer()
    {
        effector.rotationalOffset = 0;
        yield return new WaitForSeconds(5);
        effector.rotationalOffset = 180f;
    }


    // Update is called once per frame
    void Update()
    {
         
    }
}
