using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPisca : MonoBehaviour
{
    public int lado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                    InterfaceUrso.instance.animAE.SetBool("Piscar", true);
                }
                if (collision.gameObject.layer == 9)
                {
                    InterfaceUrso.instance.animVME.SetBool("Piscar", true);
                }
                if (collision.gameObject.layer == 10)
                {
                    InterfaceUrso.instance.animVE.SetBool("Piscar", true);
                }

            }
        }
        if (lado == 1)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    InterfaceUrso.instance.animAD.SetBool("Piscar", true);

                }
                if (collision.gameObject.layer == 9)
                {
                    InterfaceUrso.instance.animVMD.SetBool("Piscar", true);

                }
                if (collision.gameObject.layer == 10)
                {
                    InterfaceUrso.instance.animVD.SetBool("Piscar", true);
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
                    InterfaceUrso.instance.animAE.SetBool("Piscar", false);
                }
                if (collision.gameObject.layer == 9)
                {
                    InterfaceUrso.instance.animVME.SetBool("Piscar", false);
                }
                if (collision.gameObject.layer == 10)
                {
                    InterfaceUrso.instance.animVE.SetBool("Piscar", false);

                }

            }
        }
        if (lado == 1)
        {
            if (collision.gameObject.CompareTag("urso"))
            {
                if (collision.gameObject.layer == 8)
                {
                    InterfaceUrso.instance.animAD.SetBool("Piscar", false);

                }
                if (collision.gameObject.layer == 9)
                {
                    InterfaceUrso.instance.animVMD.SetBool("Piscar", false);
                }
                if (collision.gameObject.layer == 10)
                {
                    InterfaceUrso.instance.animVD.SetBool("Piscar", false);
                }

            }
        }
    }
    }
