using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedEnemy : MonoBehaviour
{
    // patrol
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float margin = 0.2f;
    public float speed;

    // chase
    public float rotateSpeed;
    public bool chase = false;
    private Vector3 startingPoint;
    private GameObject hero;
    public float chaseRadius = 5.0f;
    public float attackRadius = 2.5f;

    void Start()
    {
        startingPoint = gameObject.transform.position;
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hero == null)
            return;
        float dist = Vector3.Distance(transform.position, hero.transform.position);
        if (dist <= chaseRadius && dist >= attackRadius)
        {
            Chase();
        }
        else if (dist < attackRadius)
        {
            Encircle();
        }
        else
            patrol();

    }

    private void patrol()
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

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, hero.transform.position, speed * Time.deltaTime);
    }

    private void Encircle()
    {

        transform.RotateAround(hero.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        transform.Rotate(0.0f, 0.0f, -1 * rotateSpeed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint, speed * Time.deltaTime);
    }
}
