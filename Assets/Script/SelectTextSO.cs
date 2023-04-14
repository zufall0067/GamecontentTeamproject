using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectTextSo")]
public class SelectTextSO : ScriptableObject
{
    [TextArea]
    public string firstText;
    public bool firstTrue;

    [TextArea]
    public string secondText;
    public bool secondTrue;

    [TextArea]
    public string threeText;
    public bool threeTrue;
}
