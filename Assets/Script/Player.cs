using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaitForEndOfFrame waitForEndOfFrame;
    public LayerMask whatIsLayer;
    public LayerMask doorLayer;

    private float speed;
    private Vector3 moveHorizontal;
    private Vector3 moveVertical;
    private float moveDirx;
    private float moveDiry;
    private Vector3 velocity;

    private new Rigidbody2D rigidbody;
    private Collider2D hit;
    private Collider2D doorHit;
    private Character character;
    private TextManager textManager;

    private bool isAroundCha;
    public static bool isTalking;

    public int followPet;

    private void Start()
    {
        whatIsLayer = LayerMask.GetMask("Character");
        doorLayer = LayerMask.GetMask("Door");
        speed = 10f;
        followPet = 0;
        isTalking= false;
        rigidbody = GetComponent<Rigidbody2D>();
        textManager = FindObjectOfType<TextManager>();
        StartCoroutine(CharacterCheck());
    }

    private void Update()
    {
        if (isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space) && character.likePoint < 5)
            {
                textManager.NextTextPanel(character.characterSO.arrayTextSOIndex(character.likePoint));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isAroundCha && !isTalking)
        {
            textManager.ChangeSO(character.characterSO);
            textManager.ChangeTextSO(character.likePoint);
            textManager.ShowTextPanel(character.characterSO.arrayTextSOIndex(character.likePoint), character.gameObject);
            isTalking= true;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            doorHit = Physics2D.OverlapCircle(transform.position, 0.8f, doorLayer);

            if(doorHit != null) { Debug.Log(doorHit.name); doorHit.GetComponent<Door>().Move(this.transform); }
            
        }
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
        }
        else
        {
            speed = 8f;
        }

        if (isTalking == false) 
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
        while(true)
        {
            hit = Physics2D.OverlapCircle(transform.position, 0.8f, whatIsLayer);

            if (hit != null)
            {
                character = hit.gameObject.GetComponent<Character>();
                isAroundCha = true;
            }
            else
            {
                character = null;
                isAroundCha = false;
            }

            yield return waitForEndOfFrame;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawSphere(transform.position, 0.8f);
    }
}
