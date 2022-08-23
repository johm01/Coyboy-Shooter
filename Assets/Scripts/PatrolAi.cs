using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAi : MonoBehaviour
{
    public float speed;
    public Transform[] patrol;
    int nodepos;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position != patrol[nodepos].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrol[nodepos].position, speed * Time.deltaTime);
        }
        else
        {
            if(once == false)
            {
                StartCoroutine(UpdateNode());
                once = true;
            }      
        }
        
       
    }
    IEnumerator UpdateNode()
    {
       
        yield return new WaitForSeconds(1);
        if (nodepos + 1 < patrol.Length)
        {
            nodepos++;
        }
        else
        {
            nodepos = 0;
        }
        once = false;
    }
}
