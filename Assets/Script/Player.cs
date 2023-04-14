using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaitForEndOfFrame waitForEndOfFrame;
    public Vector2 size;
    public LayerMask whatIsLayer;

    private float speed;
    private Vector3 moveHorizontal;
    private Vector3 moveVertical;
    private float moveDirx;
    private float moveDiry;
    private Vector3 velocity;

    private new Rigidbody2D rigidbody;

    private bool isTalking;

    private void Awake()
    {

    }

    private void Start()
    {
        whatIsLayer = LayerMask.GetMask("Character");
        speed = 10f;
        isTalking= false;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(isTalking == false) 
        {
            moveDirx = Input.GetAxisRaw("Horizontal");
            moveDiry = Input.GetAxisRaw("Vertical");

            moveHorizontal = transform.right * moveDirx;
            moveVertical = transform.up * moveDiry;

            velocity = (moveHorizontal + moveVertical).normalized * speed;

            rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
        }
    }

    private IEnumerator CharacterCheck()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, whatIsLayer);

        if(hit != null) 
        {

        }

        yield return waitForEndOfFrame;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
