using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float margin = 0.2f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, currentGoal.position) <= margin)
        {
            changeGoal();
        }
        else
        {
            Vector3 temp = Vector3.MoveTowards(transform.position,
                                                currentGoal.position,
                                                speed * Time.deltaTime);

            transform.position = temp;
        }

    }

    private void changeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}