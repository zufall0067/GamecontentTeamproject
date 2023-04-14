using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;
    [SerializeField]
    private GameObject secondButton;
    [SerializeField]
    private GameObject threeButton;

    public SelectTextSO selectTextSO;

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
        HideSelectPanel();
    }

    public void ChangeSO(SelectTextSO SO)
    {
        selectTextSO = SO;
    }

    public void buttonInputText()
    {
        firstText.text = selectTextSO.firstText;
        secondText.text = selectTextSO.secondText;
        threeText.text = selectTextSO.threeText;

        if (selectTextSO.firstTrue == true)
        {
            firstButton.GetComponent<Button>().onClick.AddListener(trueAnser);
        }
        else
        {
            firstButton.GetComponent<Button>().onClick.AddListener(falseAnser);
        }

        if (selectTextSO.secondTrue == true)
        {
            secondButton.GetComponent<Button>().onClick.AddListener(trueAnser);
        }
        else
        {
            secondButton.GetComponent<Button>().onClick.AddListener(falseAnser);
        }

        if (selectTextSO.threeTrue == true)
        {
            threeButton.GetComponent<Button>().onClick.AddListener(trueAnser);
        }
        else
        {
            threeButton.GetComponent<Button>().onClick.AddListener(falseAnser);
        }
    }

    public void ShowSelectPanel()
    {
        if (firstButton.activeSelf == false)
        {
            firstButton.SetActive(true);
        }
        if (secondButton.activeSelf == false)
        {
            secondButton.SetActive(true);
        }
        if (threeButton.activeSelf == false)
        {
            threeButton.SetActive(true);
        }

        buttonInputText();
    }
    public void HideSelectPanel()
    {
        if(firstButton.activeSelf == true)
        {
            firstButton.SetActive(false);
        }
        if(secondButton.activeSelf == true) 
        {
            secondButton.SetActive(false);
        }
        if(threeButton.activeSelf == true) 
        {
            threeButton.SetActive(false);
        }
    }

    public void trueAnser()
    {
        Debug.Log("Æ®·ç");
    }

    public void falseAnser()
    {
        Debug.Log("»¹½º");
    }
}
