using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform launchPoint;
    private Transform player;
    private Rigidbody2D rb;
    public Vector2 target;
    public GameObject hitVFX;
    // Start is called before the first frame update
    void Start()
    {

        /*  rb = GetComponent<Rigidbody2D>();
          Vector2 direction =  player.position - launchPoint.position ;
          direction = direction.normalized;
          rb.velocity = direction * speed;*/
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position,target,speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController.numberOfHits++;
            Instantiate(hitVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
