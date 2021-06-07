using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    private Animator anim;
    public GameObject martelo;
    bool usar;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        usar = martelo.GetComponent<trap>().fechou;

        if (usar == true){
             anim.SetBool("fechou", true);
        }
        else{
            anim.SetBool("fechou", false);
        }
    }
}
