using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armadilha3 : MonoBehaviour
{
    public int la;
    // Start is called before the first frame update

    void Start()
    {
        //playerMenina playerScript = GameObject.FindWithTag("player").GetComponent<playerMenina>(); //GameObject.Find("playerMenina").GetComponent<playerMenina>();
        la = playerMenina.instance.aonde;
       // la2 = playerMenina2.instance.aonde;
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {

    }
    void OnDestroy()
    {
        //playerMenina playerScript = GameObject.FindWithTag("player").GetComponent<playerMenina>();
        if (la == 1 ) MesaEsquerda.instance.jaTem = false;
            
        
        if (la == 2) MesaEsquerda.instance.jaTem2 = false;
          
        
        if (la == 3 ) MesaEsquerda.instance.jaTem3 = false;
           
        
        if (la == 4 ) MesaEsquerda.instance.jaTem4 = false;
           
        

    }
}


