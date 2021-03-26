using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLaser : MonoBehaviour
{
    public Transform firePoint;
    public Transform endPoint;
    public LineRenderer lineRenderer;

    public GameObject endVFX;

    private List<ParticleSystem> particles = new List<ParticleSystem>();

    public ParticleSystem particle;

    private float timeUntilDying = 0f;
    public bool killPlayer;

    public float timeBtwSwitching;

    private float startTimeBtwSwitching;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        //FillList();
        killPlayer = false;
        startTimeBtwSwitching = timeBtwSwitching;
   
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        
        
          
        {
            lineRenderer.enabled = true;
            particle.enableEmission = true;
            UpdateLaser();
        }

        else {
                lineRenderer.enabled = false;
            particle.enableEmission = false;
        }

        if(timeBtwSwitching<=0)
        {
            isOn = !isOn;
            timeBtwSwitching = startTimeBtwSwitching;
        }
        else
        {
            timeBtwSwitching -= Time.deltaTime;
        }

        
       




    }

    void UpdateLaser()
    {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
        Vector2 direction = endPoint.position - firePoint.position;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction.normalized, direction.magnitude);
        if (hit)
        {

            //endPoint.position = hit.point;
            lineRenderer.SetPosition(1, hit.point);
            //Instantiate(particle, endVFX.transform.position, Quaternion.identity);

            // Check what object the ray hit
            if (hit.collider.CompareTag("Player"))
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(KillPlayer(hit));



                //Destroy(hit.collider.gameObject);
            }

            //endVFX.transform.position = hit.point;
            //Vector3 direction = hit.point - firePoint.position;

        }

        // endVFX.transform.position = lineRenderer.GetPosition(1);

        /* if (hit.point.y != firePoint.transform.position.y)
         {
             /* if (hit.point.y > 0f)
              {
                  Vector3 offset = new Vector3(0f, 0.2f, 0f);
                  endVFX.transform.position = lineRenderer.GetPosition(1) + offset;
              }
              else
              {
                  Vector3 offset = new Vector3(0f, -0.2f, 0f);
                  endVFX.transform.position = lineRenderer.GetPosition(1) + offset;
              }*/
        /*Vector3 offset = new Vector3(0f, 0.2f, 0f);
        endVFX.transform.position = lineRenderer.GetPosition(1) + offset;
    }
    else
    {


        Vector3 offset = new Vector3(0.2f, 0f, 0f);
        endVFX.transform.position = lineRenderer.GetPosition(1) + offset;

    }*/
        /*Vector3 offset = new Vector3(0.2f, 0f, 0f);
        endVFX.transform.position = lineRenderer.GetPosition(1) + offset;*/
        /*if (hit.point.y != firePoint.transform.position.y)
        {
            if (hit.point.y - firePoint.transform.position.y > 0f)
            {
                Vector2 offset = new Vector2(0f, 0.3f);
                endVFX.transform.position = hit.point + offset;
            }
            else
            {
                Vector2 offset = new Vector2(0f, -0.3f);
                endVFX.transform.position = hit.point + offset;
            }
        }
        else
        {
            if (hit.point.x - firePoint.transform.position.x > 0f)
            {
                Vector2 offset = new Vector2(0.3f,0f);
                endVFX.transform.position = hit.point + offset;
            }
            else
            {
                Vector2 offset = new Vector2(-0.3f,0f);
                endVFX.transform.position = hit.point + offset;
            }
        }*/
        /* Vector2 localPoint = hit.transform.InverseTransformPoint(hit.point);
         Vector2 localDir = localPoint.normalized;*/
        /* Vector3 aux = new Vector3(hit.point.x, hit.point.y, 0f);
         Vector2 dir = aux - firePoint.transform.position;
         dir = dir.normalized;
         endVFX.transform.position = dir + hit.point;*/
        endVFX.transform.position = hit.point;
    }

    private IEnumerator KillPlayer(RaycastHit2D hit)
    {
        hit.collider.gameObject.GetComponent<PlayerController>().moveSpeed = 0f;
        GameObject playerDeathVFX = hit.collider.gameObject.GetComponent<PlayerController>().deathVFX;
        Transform playerTransform = hit.collider.gameObject.GetComponent<Transform>();
        yield return new WaitForSeconds(0.2f);

        Destroy(hit.collider.gameObject);
        Instantiate(playerDeathVFX, playerTransform.position, Quaternion.identity);

    }

}
