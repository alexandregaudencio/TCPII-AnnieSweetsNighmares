using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    private Animator anim;
    BoxCollider boxCollider;
    public GameObject martelo;
    bool usar;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        usar = martelo.GetComponent<trap>().fechou;

        if (usar == true){
             anim.SetBool("fechou", true);
            boxCollider.enabled = true;
        }
        else{
            anim.SetBool("fechou", false);
            boxCollider.enabled = false ;
        }
    }
}
