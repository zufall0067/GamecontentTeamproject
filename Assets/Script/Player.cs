using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaitForEndOfFrame waitForEndOfFrame;
    public LayerMask whatIsLayer;

    private float speed;
    private Vector3 moveHorizontal;
    private Vector3 moveVertical;
    private float moveDirx;
    private float moveDiry;
    private Vector3 velocity;

    private new Rigidbody2D rigidbody;
    private Collider2D hit;
    private Character character;
    private TextManager textManager;

    private bool isAroundCha;
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
        textManager = FindObjectOfType<TextManager>();
        StartCoroutine(CharacterCheck());
    }

    private void Update()
    {
        if (isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
