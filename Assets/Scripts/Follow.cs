using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
   [SerializeField] private Vector3 offset;

   [SerializeField] private Transform target;

    private Vector3 velocity = Vector3.zero;

    private float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(this.transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
