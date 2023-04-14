using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterSO characterSO;
    [SerializeField]
    private GameObject characterImage;
    [SerializeField]
    private string characterName;

    [SerializeField]
    private GameObject dialogue;

    public int likePoint;

    void Start()
    {
         
    }

    void Update()
    {
        
    }

    private void ShowDialogue(int count)
    {

    }

    private void HideDialogue()
    {

    }

    public void trueAnswerInput()
    {
        likePoint++;

    }
}
