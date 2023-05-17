using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : MonoBehaviour
{
    private SpriteRenderer image;
    private CanvasGroup CanvasGroup;

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        

        image.DOFade(1f, 1f);
        Invoke("fadeOut", 2f);
    }

    public void fadeOut()
    {
        image.DOFade(0, 1.7f);
    }

    void Update()
    {
    }
}
