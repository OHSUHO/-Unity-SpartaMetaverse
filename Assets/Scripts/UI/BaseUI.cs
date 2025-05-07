using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    [SerializeField] protected UIManager manager;

    

    public void ActiveUI()
    {
        this.gameObject.SetActive(true);
    }

    public void UnActiveUI()
    {
        this.gameObject.SetActive(false);
    }

}
