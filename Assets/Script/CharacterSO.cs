using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public SelectTextSO[] arraySelectTextSO = new SelectTextSO[5];
    public TextSO[] arrayTextSO = new TextSO[5];


    public SelectTextSO arraySelectTextSOIndex(int index)
    {
        return arraySelectTextSO[index];
    }

    public TextSO arrayTextSOIndex(int index)
    {
        return arrayTextSO[index];
    }
}
