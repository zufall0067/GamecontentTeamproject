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

    public Transform target; // ���� Ÿ���� Ʈ���� ��

    private float relativeHeigth = 1.0f; // ���� �� y��
    private float zDistance = -1.0f;// z�� ���� ��� �ʿ� ������.
    private float xDistance = 1.0f; // x��
    public float dampSpeed = 2;  // ���󰡴� �ӵ� ª���� Ÿ�ٰ� ���� �����δ�.
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
            Debug.Log("����");
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
