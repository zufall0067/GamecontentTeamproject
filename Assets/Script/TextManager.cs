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

    public GameObject TextPanle;
    public Text characterName;
    public Text textDial;

    public CharacterSO characterSO;
    public TextSO textSO;
    public SelectTextSO selectTextSO;

    private Text firstText;
    private Text secondText;
    private Text threeText;

    private GameObject characterImagePrefab;

    private int index;

    private string insCharacterName;
    private GameObject insCharacterImage;
    private Character insCharacter;

    private void Awake()
    {
        firstText = firstButton.transform.Find("Text").gameObject.GetComponent<Text>();
        secondText = secondButton.transform.Find("Text").gameObject.GetComponent<Text>();
        threeText = threeButton.transform.Find("Text").gameObject.GetComponent<Text>();
    }

    void Start()
    {
        HideSelectPanel();
        HideTextPanel();
    }

    public void InstantiateCharacter(GameObject characterObject)
    {
        insCharacter = characterObject.GetComponent<Character>();
        insCharacterImage = insCharacter.characterImage;
        insCharacterName = insCharacter.characterName;
    }

    public void ChangeSO(CharacterSO SO)
    {
        characterSO = SO;
    }

    public void ChangeTextSO(int index)
    {
        textSO = characterSO.arrayTextSO[index];
        selectTextSO = characterSO.arraySelectTextSO[index];
    }

    public void buttonInputText()
    {
        firstButton.GetComponent<Button>().onClick.RemoveAllListeners();
        secondButton.GetComponent<Button>().onClick.RemoveAllListeners();
        threeButton.GetComponent<Button>().onClick.RemoveAllListeners();

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

    public void ShowTextPanel(TextSO SO, GameObject characterObject)
    {
        if(TextPanle.activeSelf == false)
        { TextPanle.SetActive(true); }
        InstantiateCharacter(characterObject);

        characterImagePrefab = Instantiate(insCharacterImage);
        characterImagePrefab.transform.position += new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);
        characterName.text = insCharacterName;
        textDial.text = SO.text[0];
        index = 0;
    }

    public void NextTextPanel(TextSO SO)
    {
        index += 1;

        if (SO.text[index] == "end")
        {
            index -= 1;
            return;
        }

        if (string.IsNullOrEmpty(SO.text[index]))
        {
            HideTextPanel();
            ShowSelectPanel();
        }

        textDial.text = SO.text[index];
    }

    public void HideTextPanel()
    {
        if (TextPanle.activeSelf == true)
        { TextPanle.SetActive(false); }

        if(characterImagePrefab != null) 
        { Destroy(characterImagePrefab.gameObject); }
        
    }

    public void trueAnser()
    {
        HideSelectPanel();
        Player.isTalking = false;
        insCharacter.GetComponent<Character>().trueAnswerInput();
        Debug.Log("Æ®·ç");
    }

    public void falseAnser()
    {
        HideSelectPanel();
        Player.isTalking = false;
        
        Debug.Log("»¹½º");
    }
}
