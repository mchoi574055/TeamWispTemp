using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public bool chase = false;
    private Vector3 startingPoint;
    private GameObject player;
    public float chaseRadius = 5.0f;
    public float attackRadius = 2.5f;
    private float _angle;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        _angle = rotateSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
            return;
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist <= chaseRadius && dist >= attackRadius)
        {
            Chase();
        }
        else if (dist < attackRadius)
        {
            Encircle();
        }
        else
            ReturnStartPoint();
        //Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Encircle()
    {

        //var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * attackRadius;
        //transform.position = player.transform.position + offset;
        transform.RotateAround(player.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        transform.Rotate(0.0f, 0.0f, -1 * rotateSpeed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint, speed * Time.deltaTime);
    }

}