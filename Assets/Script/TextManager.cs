using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;
    [SerializeField]
    private GameObject secondButton;
    [SerializeField]
    private GameObject threeButton;

    public TextSO textSO;

    private Text firstText;
    private Text secondText;
    private Text threeText;

    private void Awake()
    {
        firstText = firstButton.transform.Find("Text").gameObject.GetComponent<Text>();
        secondText = secondButton.transform.Find("Text").gameObject.GetComponent<Text>();
        threeText = threeButton.transform.Find("Text").gameObject.GetComponent<Text>();
    }

    void Start()
    {
        buttonInputText();
    }

    void Update()
    {
        
    }

    public void buttonInputText()
    {
        firstText.text = textSO.firstText;
        secondText.text = textSO.secondText;
        threeText.text = textSO.threeText;


    }
}
