using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : ObjectM
{
    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    // Use this for initializationwait
    void Start()
    {
        StartCoroutine(Move(bottomPosition));
        
    }
    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 1.0f){

            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime;

            yield return null;
        }
        print("hit");

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }

}

//notes
//ctrl+k -> ctrl+c == comment
//ctrl+k -> ctrl+u == uncomment
//ctrl+k -> ctrl+d == autoformat

//git notes
//git add .
//git commit -m "comments"
//git push
//git log  <---- check history
//git diff <---- check changes
//git reset --hard head <------ go back to previous version.