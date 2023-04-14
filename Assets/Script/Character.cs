using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public CharacterSO characterSO;
    [SerializeField]
    private GameObject characterImage;
    [SerializeField]
    private string characterName;

    [SerializeField]
    private GameObject dialogue;

    public int likePoint;

    void Start()
    {
         likePoint = 0;
    }

    void Update()
    {
        
    }

    public void trueAnswerInput()
    {
        likePoint++;

    }
}
