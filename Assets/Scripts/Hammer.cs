using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Rigidbody2D rb;

    public float timeBtwFalls;
    public float timeBtwRises;

    private Vector2 initialPoint;
    public HasFallen nextPoint;
    public float speed;

    private bool fall;
    public bool hasFallenX;
    private bool isRising;
    private float startTimeBtwFalls;
    private bool rise;
    private float startTimeBtwRises;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fall = false;
        rise = false;
        startTimeBtwFalls = timeBtwFalls;
        startTimeBtwRises = timeBtwRises;
        hasFallenX = false;
        initialPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fall)
        {
            if (timeBtwFalls <= 0)
            {
                timeBtwFalls = startTimeBtwFalls;
                fall = true;
                rise = false;
            }
            else if(timeBtwFalls>0 && !fall)
            {
                timeBtwFalls -= Time.deltaTime;
            }
        }
        if(fall)
        {
            if (timeBtwRises <= 0)
            {
                timeBtwRises = startTimeBtwRises;
                fall = false ;
                rise = true;
                isRising = true;
            }
            else if(timeBtwRises>0 && !rise)
            {
                timeBtwRises-= Time.deltaTime;
            }
        }
        //Verify if the platform got back to intial point
        //if(this.transform.position == initialPoint.position)
       // {
            hasFallenX = false;
        //}

        //If it didn't reach the initial point, check if the platformer started rising towards it initial point
       // else 
       // {
           this.hasFallenX = nextPoint.hasFallen;
       // }
        
        
    }

    private void FixedUpdate()
    {
        if(fall)
        {
            rb.isKinematic = false;
        }
        if(rise)
        {
            rb.isKinematic = true;
           
            this.transform.position = Vector2.MoveTowards(this.transform.position, initialPoint, speed * Time.deltaTime);
           
        }

      
    }

}
