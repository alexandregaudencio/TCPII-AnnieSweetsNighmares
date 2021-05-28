using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InterfaceUrso : MonoBehaviour
{
    public int lado;
    [SerializeField]    private GameObject azulUiE;
    [SerializeField] private GameObject verdeUiE;
     [SerializeField] private GameObject  vermelhoUiE;
    [SerializeField] private GameObject azulUiD;
    [SerializeField] private GameObject verdeUiD;
    [SerializeField] private GameObject vermelhoUiD;
    // Start is called before the first frame update
    void Start()
    {
       // azulUi = GameObject.Find("Canvas").transform.Find("ursoAzul").gameObject;
       // verdeUi = GameObject.Find("Canvas").transform.Find("ursoVerde").gameObject;
        //vermelhoUi = GameObject.Find("Canvas").transform.Find("ursoVermelho").gameObject;
    }


    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if (lado == 0)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    azulUiE.SetActive(true);
                }
                if (collision.gameObject.layer == 9)
                {
                    vermelhoUiE.SetActive(true);
                }
                if (collision.gameObject.layer == 10)
                {
                    verdeUiE.SetActive(true);
                }

            }
        }
        if (lado == 1)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    azulUiD.SetActive(true);
                }
                if (collision.gameObject.layer == 9)
                {
                    vermelhoUiD.SetActive(true);
                }
                if (collision.gameObject.layer == 10)
                {
                    verdeUiD.SetActive(true);
                }

            }
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (lado == 0)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    azulUiE.SetActive(false);
                }
                if (collision.gameObject.layer == 9)
                {
                    vermelhoUiE.SetActive(false);
                }
                if (collision.gameObject.layer == 10)
                {
                    verdeUiE.SetActive(false);
                }

            }
        }
        if (lado == 1)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    azulUiD.SetActive(false);
                }
                if (collision.gameObject.layer == 9)
                {
                    vermelhoUiD.SetActive(false);
                }
                if (collision.gameObject.layer == 10)
                {
                    verdeUiD.SetActive(false);
                }

            }
        }

    }
}
