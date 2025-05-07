using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI restartText;

    [SerializeField] StartUI StartUI;
    public GameUI GameUI;

    // Start is called before the first frame update
    void Start()
    {
        
        GameUI.Init();

        

    }

    


    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        GameUI.UpdateScore(score);
    }
    
}
