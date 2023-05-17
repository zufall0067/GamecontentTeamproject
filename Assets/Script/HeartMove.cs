using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMove : MonoBehaviour
{
    private Rigidbody2D rigidbodyy;
    private float timer;

    void Start()
    {
        rigidbodyy = GetComponent<Rigidbody2D>();
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        rigidbodyy.MovePosition(transform.position + new Vector3(0, 1f) * Time.deltaTime);
        
        if(timer > 0.7f)
        {
            Destroy(this.gameObject);
        }
    }
}
