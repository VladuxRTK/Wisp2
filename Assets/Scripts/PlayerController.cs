using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 targetPos;
    private Rigidbody2D rb;
    private bool isMoving;
    private Vector2 direction;
    public float changeDirCooldown;
    public GameObject deathVFX;

    public List<Color> healthColors;

    public float timeHit;

    public static int numberOfHits;

    private Vector2 movement;

    private GameManager gm;
    private float changeCool;
    private bool canChangeDir;
    private bool isPaused;

    private Material material;

    private int numberOfTimePaused;

    private int numberOfLastHit;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // material = GetComponent<Renderer>().material;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sr = GetComponent<SpriteRenderer>();


        changeCool = changeDirCooldown;
        canChangeDir = true;
        isPaused = false;
        numberOfHits = 0;
        numberOfLastHit = 0;
    }


    void Update()
    {
        Debug.Log(numberOfHits);

        if (numberOfHits != 0 && timeHit <=0)
        {
            timeHit = 6f;

            numberOfHits = 0;
            //numberOfInitialHits = 0;
            numberOfLastHit = 0;
            sr.material.color = Color.white;
        }
        if (timeHit >= 0 && numberOfHits != 0)
        {

            if (numberOfLastHit < numberOfHits)
            {
                timeHit = 6f;
                numberOfLastHit = numberOfHits;
            }
            else { timeHit -= Time.deltaTime; if (timeHit <= 2f)
                {
                    StartCoroutine(Blink());
                }
            }
           
          
        }
        
       
        if (numberOfHits == 1 && numberOfLastHit==0)
        {
            // this.material.color =(new Color(168, 71, 71));
            sr.material.color = new Color(0.8207547f, 0.360048f, 0.360048f);
            numberOfLastHit = numberOfHits;
        }
        if (numberOfHits == 2 && numberOfLastHit==0)
        {
            //   this.material.color = new Color(183, 77, 77);
            //sr.material.color = new Color(183, 77, 77);
            //   Color color = new Color(183, 77, 77);

            sr.material.color = new Color(0.9150943f, 0.1769758f, 0.1769758f);
            numberOfLastHit = numberOfHits;
        }
        if (numberOfHits == 3 && numberOfLastHit ==0)
        {
            //  this.material.color = new Color(214, 60, 60);
            sr.material.color = Color.red;
            numberOfLastHit = numberOfHits;
        }
        if (numberOfHits == 1)
        {
            // this.material.color =(new Color(168, 71, 71));
            sr.material.color = new Color(0.8207547f, 0.360048f, 0.360048f);
            
        }
        if (numberOfHits == 2)
        {
            //   this.material.color = new Color(183, 77, 77);
            //sr.material.color = new Color(183, 77, 77);
            //   Color color = new Color(183, 77, 77);

            sr.material.color = new Color(0.9150943f, 0.1769758f, 0.1769758f);
        }
        if (numberOfHits == 3 )
        {
            //  this.material.color = new Color(214, 60, 60);
            sr.material.color = Color.red;

        }

        if (numberOfHits == 4)
        {
            Destroy(gameObject);
        }
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (changeDirCooldown <= 0)
        {
            canChangeDir = true;


        }

        else
        {
            changeDirCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !(numberOfTimePaused == gm.pausesPerLevel))
        {
            isPaused = !isPaused;
            numberOfTimePaused += 1;
        }

        // rb.isKinematic = true; 
        Pause();


    }
    private void FixedUpdate()
    {


        Move();



    }

    private void SetTargetPosition()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        direction = targetPos - this.transform.position;
        direction = direction.normalized;

        isMoving = true;
    }
    private void Move()
    {
        rb.velocity = movement * moveSpeed;




        //  transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
        canChangeDir = false;

        /*  if (Mathf.Abs(this.transform.position.x - this.targetPos.x) < float.Epsilon && Mathf.Abs(this.transform.position.y - this.targetPos.y) < float.Epsilon)
          {
              Debug.Log("Aici");
              isMoving = false;
              // rb.velocity = Vector2.zero;

          }*/


    }

    private void StopMoving()
    {
        if (Mathf.Abs(this.transform.position.x - this.targetPos.x) < float.Epsilon && Mathf.Abs(this.transform.position.y - this.targetPos.y) < float.Epsilon)
        {
            Debug.Log("Aici");
            isMoving = false;
            // rb.velocity = Vector2.zero;

        }
    }

    private void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }

    //Make the player blink when close to resetting number of hits
    private IEnumerator Blink()
    {
        Color currentColor;
        currentColor = sr.material.color;
        /*while(timeHit!=0)
        {
            yield return new WaitForSeconds(0.2f);
            sr.material.color = currentColor;
            yield return new WaitForSeconds(0.2f);
            sr.material.color = Color.white;
        }*/
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = Color.white;
      /*  yield return new WaitForSeconds(0.2f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.2f);
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.2f);
        sr.material.color = Color.white;*/


    }
}
