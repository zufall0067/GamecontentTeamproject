using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextSo")]
public class TextSO : ScriptableObject
{
    [TextArea]
    public List<string> text = new List<string>();
}
