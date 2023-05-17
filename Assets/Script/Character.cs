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

    private float relativeHeigth = -0.1f; // ���� �� y��
    private float zDistance = -1f;// z�� ���� ��� �ʿ� ������.
    private float xDistance = 0.3f; // x��
    public float dampSpeed = 2;  // ���󰡴� �ӵ� ª���� Ÿ�ٰ� ���� �����δ�.

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
            Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // Ÿ�� �������� �ش� ��ġ�� ����.. �� Ÿ�� �ֺ��� ��ġ�� ��ġ�� ��´�.. ������ �Ÿ��� ���ϴ� ���
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //�� �� ������ ���� ���� �����Ѵ�. �̷��� �Ǹ� �־����� ���󰣴�.
            yield return endFrame;
        }
    }
}
