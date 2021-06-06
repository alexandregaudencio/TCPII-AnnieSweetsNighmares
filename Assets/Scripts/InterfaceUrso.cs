using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InterfaceUrso : MonoBehaviour
{
    public static InterfaceUrso instance;
    public int lado;
    int quantidadeAE;
    int quantidadeAD;
    int quantidadeVE;
    int quantidadeVD;
    int quantidadeVMD;
    int quantidadeVME;
    public Text QAEUi;
    public Text QADUi;
    public Text QVDUi;
    public Text QVEUi;
    public Text QVMDUi;
    public Text QVMEUi;


    public Animator animAE, animAD, animVE, animVD, animVME, animVMD;

    [SerializeField] private GameObject azulE;
    [SerializeField] private GameObject azulD;
    [SerializeField] private GameObject vermelhoE;
    [SerializeField] private GameObject vermelhoD;
    [SerializeField] private GameObject verdeE;
    [SerializeField] private GameObject verdeD;


    [SerializeField] private GameObject azulUiE;
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
        animAE = azulE.GetComponent<Animator>();
        animAD = azulD.GetComponent<Animator>();
        animVE = verdeE.GetComponent<Animator>();
        animVD = verdeD.GetComponent<Animator>();
        animVME = vermelhoE.GetComponent<Animator>();
        animVMD = vermelhoD.GetComponent<Animator>();
        instance = this;
        //anim = GetComponent<Animator>();
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (lado == 0)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    quantidadeAE++;
                    azulUiE.SetActive(true);
                    QAEUi.text = quantidadeAE.ToString();
                    //animUE.SetBool("Piscar", true);
                }
                if (collision.gameObject.layer == 9)
                {
                    vermelhoUiE.SetActive(true);
                    quantidadeVME++;
                    QVMEUi.text = quantidadeVME.ToString();
                }
                if (collision.gameObject.layer == 10)
                {
                    verdeUiE.SetActive(true);
                    quantidadeVE++;
                    QVEUi.text = quantidadeVE.ToString();
                }

            }
        }
        if (lado == 1)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    quantidadeAD++;
                    azulUiD.SetActive(true);
                    QADUi.text = quantidadeAD.ToString();
                    
                }
                if (collision.gameObject.layer == 9)
                {
                    vermelhoUiD.SetActive(true);
                    quantidadeVMD++;
                    QVMDUi.text = quantidadeVMD.ToString();
                    
                }
                if (collision.gameObject.layer == 10)
                {
                    verdeUiD.SetActive(true);
                    quantidadeVD++;
                    QVDUi.text = quantidadeVD.ToString();
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
                    quantidadeAE--;
                    if (quantidadeAE<1) azulUiE.SetActive(false);
                    QAEUi.text = quantidadeAE.ToString();
                }
                if (collision.gameObject.layer == 9)
                {
                    quantidadeVME--;
                    if (quantidadeVME<1) vermelhoUiE.SetActive(false);
                   QVMEUi.text = quantidadeVME.ToString();
                }
                if (collision.gameObject.layer == 10)
                {

                    quantidadeVE--;
                    if (quantidadeVE<1)verdeUiE.SetActive(false);
                    QVEUi.text = quantidadeVE.ToString();
                }

            }
        }
        if (lado == 1)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    quantidadeAD--;
                    if (quantidadeAD < 1) azulUiD.SetActive(false);
                    QADUi.text = quantidadeAD.ToString();
                    
                }
                if (collision.gameObject.layer == 9)
                {
                    quantidadeVMD--;
                    if (quantidadeVMD < 1) vermelhoUiD.SetActive(false);
                    QVMDUi.text = quantidadeVMD.ToString();
                }
                if (collision.gameObject.layer == 10)
                {
                    quantidadeVD--;
                    if (quantidadeVD < 1) verdeUiD.SetActive(false);
                    QVDUi.text = quantidadeVD.ToString();
                }

            }
        }

    }
}
