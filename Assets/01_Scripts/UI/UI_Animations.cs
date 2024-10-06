using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Animations : MonoBehaviour
{
    public GameObject intro;
    public RectTransform logo;
    public RectTransform logoShade;
    public RectTransform continueGameMenu;
    public RectTransform exitGameMenu;
    public RectTransform darkBackground;
    bool isContinueMenuOpen = false;
    bool isExitMenuOpen = false;

    void Start()
    {
        LeanTween.alpha(intro.GetComponent<RectTransform>(), 0, 0.5f).setDelay(3f).setOnComplete(InitMainMenu);
    }

    void InitMainMenu()
    {
        intro.GetComponentInChildren<Image>().raycastTarget = false;
        LeanTween.moveX(logo, 350, 3f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveX(logoShade, 380, 3f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveY(logoShade, 430, 3f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.alpha(logo, 1f, 2f);
        LeanTween.alpha(logoShade, 0.5f, 2f);
    }

    public void ContinueGameMenu()
    {
        if (isContinueMenuOpen)
        {
            LeanTween.moveY(continueGameMenu, 600, 0.3f).setEase(LeanTweenType.linear);
            LeanTween.alpha(darkBackground, 0, 0.3f);
            darkBackground.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            LeanTween.moveY(continueGameMenu, -525, 0.3f).setEase(LeanTweenType.linear);
            LeanTween.alpha(darkBackground, 0.7f, 0.3f);
            darkBackground.GetComponent<Image>().raycastTarget = true;
        }
        isContinueMenuOpen = !isContinueMenuOpen;
    }

    public void ExitGameMenu()
    {
        if (isExitMenuOpen)
        {
            LeanTween.scale(exitGameMenu, new Vector3(0, 0, 0), 0.3f).setEase(LeanTweenType.linear);
            LeanTween.alpha(darkBackground, 0, 0.3f);
            darkBackground.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            LeanTween.scale(exitGameMenu, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
            LeanTween.alpha(darkBackground, 0.7f, 0.3f);
            darkBackground.GetComponent<Image>().raycastTarget = true;
        }
        isExitMenuOpen = !isExitMenuOpen;
    }
}
