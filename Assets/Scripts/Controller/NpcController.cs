using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    BoxCollider2D boxCollider;
    [SerializeField] GameObject PressEObject;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PressEObject.SetActive(true);
           
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PressEObject.SetActive(false);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().isInteracting)
        {
            Time.timeScale = 0f;
            GameManager.Instance.LoadScene("FlappyBird");
        }
    }



}
