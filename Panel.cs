using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    //0: Home, 1: Settings, 2: YesNoPopup
    [SerializeField] protected PanelElement[] panelElements;
    public UISound uISound;
    public GameObject gameplayCanvas;

    private void Awake()
    {
        InitializePanelElements();
    }

    public void Enable()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }
    protected void Disable()
    { 
        gameObject.SetActive(false);
    }

    public void Close()
    {
        if (gameObject.activeSelf)
        {
            LeanTween.moveLocalX(gameObject, -2000f, .25f).setEaseOutCubic().setOnComplete(Disable);
            CloseAllActivePanelElements();
        }     
    }

    private void OnDisable()
    {
        gameplayCanvas.SetActive(true);
    }

    private void OnEnable()
    {
        gameplayCanvas.SetActive(false);
        LeanTween.moveLocalX(gameObject, 0f, .25f).setEaseInCubic().setOnComplete(panelElements[0].Enable);
    }
    public void CloseAllActivePanelElements()
    {
        for (int i = 0; i < panelElements.Length; i++)
        {
            panelElements[i].Close();
        }
        uISound.PlayAudio(uISound.closePage);
    }
    protected void InitializePanelElements()
    {
        for (int i = 0; i < panelElements.Length; i++)
        {
            panelElements[i].Initialize();
        }
    }
}
