using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public CharacterSO characterSO;
    [SerializeField]
    public GameObject characterImage;
    [SerializeField]
    public GameObject characterCutScene;
    [SerializeField]
    public string characterName;

    [SerializeField]
    private GameObject dialogue;

    private WaitForEndOfFrame endFrame;

    public int likePoint;

    public Transform target; // 따라갈 타겟의 트랜스 폼

    private float relativeHeigth = 1.0f; // 높이 즉 y값
    private float zDistance = -1.0f;// z값 나는 사실 필요 없었다.
    private float xDistance = 1.0f; // x값
    public float dampSpeed = 2;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.
    public int petIndex;

    void Start()
    {
         likePoint = 0;
        petIndex= 0;
    }

    public void trueAnswerInput()
    {
        likePoint++;

        if(likePoint >= 5)
        {
            StartCoroutine(FollowPlayer());
            Debug.Log("끄읏");
        }
    }

    public IEnumerator FollowPlayer()
    {
        target = FindObjectOfType<Player>().gameObject.transform;
        target.GetComponent<Player>().followPet++;
        petIndex = target.GetComponent<Player>().followPet;
        while (true)
        {
            Vector3 newPos = target.position * petIndex + new Vector3(xDistance , relativeHeigth, -zDistance) ;
            transform.position = Vector3.Lerp(transform.position, newPos , Time.deltaTime * dampSpeed);
            yield return endFrame;
        }
    }
}
