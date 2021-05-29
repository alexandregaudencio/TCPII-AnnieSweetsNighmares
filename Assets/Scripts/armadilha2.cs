using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armadilha2 : MonoBehaviour
{
    public int la;

    // Start is called before the first frame update
    void Start()
    {
        //playerMenina playerScript = GameObject.FindWithTag("player").GetComponent<playerMenina>();
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
        if (la == 1) playerMenina.instance.jaTem = false;


        if (la == 2) playerMenina.instance.jaTem2 = false;


        if (la == 3) playerMenina.instance.jaTem3 = false;


        if (la == 4) playerMenina.instance.jaTem4 = false;

    }
}

