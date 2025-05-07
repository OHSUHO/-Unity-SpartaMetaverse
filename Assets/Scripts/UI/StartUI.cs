using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : BaseUI
{
    [SerializeField] Button StartBtn;
    [SerializeField] Button ExitBtn;
    private void Start()
    {
        StartBtn.onClick.AddListener(StartBtnClick);
        ExitBtn.onClick.AddListener(ExitBtnClick);
    }
    public void StartBtnClick()
    {
        GameManager.Instance.GameStart();
        manager.GameUI.ActiveUI();
        manager.GameUI.UpdateScore(0);
        UnActiveUI();
    }

    public void ExitBtnClick()
    {
        GameManager.Instance.LoadScene("SampleScene");
    }
}
