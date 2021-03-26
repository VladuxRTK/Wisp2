using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
   
    private Vector2 firstPoint;
    private Vector2 secondPoint;

    public float speed;

    public int dir;

    private bool moveToFirstPoint;
    // Start is called before the first frame update
    void Start()
    {
        if(dir<0)
        {
            firstPoint = new Vector2(this.transform.position.x + 5, this.transform.position.y);
            secondPoint = new Vector2(this.transform.position.x - 5, this.transform.position.y);
        }
        else
        {
            firstPoint = new Vector2(this.transform.position.x, this.transform.position.y + 5);
            secondPoint = new Vector2(this.transform.position.x, this.transform.position.y - 5  );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(moveToFirstPoint)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, firstPoint, speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, secondPoint, speed * Time.deltaTime);
        }
        if(this.transform.position.x == firstPoint.x && this.transform.position.y == firstPoint.y)
        {
            moveToFirstPoint = !moveToFirstPoint;
        }
        if (this.transform.position.x == secondPoint.x && this.transform.position.y == secondPoint.y)
        {
            moveToFirstPoint = !moveToFirstPoint;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            Instantiate(player.deathVFX, player.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
