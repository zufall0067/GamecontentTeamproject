using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public CharacterSO characterSO;
    [SerializeField]
    public GameObject[] characterImage;
    [SerializeField]
    public string characterName;

    [SerializeField]
    private GameObject dialogue;

    [SerializeField]
    private GameObject characterText;

    private WaitForEndOfFrame endFrame;

    public int likePoint;

    public Transform target;

    private float relativeHeigth = -0.1f; // 높이 즉 y값
    private float zDistance = -1f;// z값 나는 사실 필요 없었다.
    private float xDistance = 0.3f; // x값
    public float dampSpeed = 2;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.

    private TextManager textManager;

    public GameObject heart;

    private void Awake()
    {
        textManager = FindObjectOfType<TextManager>();
    }

    void Start()
    {
        likePoint = 0;
    }

    public void trueAnswerInput()
    {
        likePoint++;

        Instantiate(heart, transform.position, Quaternion.identity);

        if (likePoint >= 5)
        {
            textManager.Endingchecker += 1;
            StartCoroutine(FollowPlayer());
            this.gameObject.layer = 8;
            Debug.Log(textManager.Endingchecker);
        }
    }

    public IEnumerator FollowPlayer()
    {
        Player player = FindObjectOfType<Player>();
        this.transform.parent = player.gameObject.transform;
        int childCount = player.gameObject.transform.childCount;

        if (childCount == 1)
        {
            target = player.gameObject.transform;
        }
        else
        {
            target = player.transform.GetChild(childCount -2);
        }

        while (true)
        {
            Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //그 둘 사이의 값을 더해 보정한다. 이렇게 되면 멀어지면 따라간다.
            yield return endFrame;
        }
    }
}
