using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneCameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform transform1;
    [SerializeField]
    private Transform transform2;

    private bool moveTransform1;

    void Start()
    {
        moveTransform1 = false;
    }

    void Update()
    {
        if(moveTransform1 == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform2.position, 0.003f);
            if (transform2.position == this.transform.position)
            {
                moveTransform1 = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform1.position, 0.003f);
            if (transform1.position == this.transform.position)
            {
                moveTransform1 = false;
            }
        }
        
    }
}
