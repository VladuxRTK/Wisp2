using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour

{
    private Transform initialPos;
    public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(bullet.target,this.transform.position)==0)
        {
            Destroy(gameObject);
        }
    }
}
