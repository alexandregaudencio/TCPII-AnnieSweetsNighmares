using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armadilha1 : MonoBehaviour
{
    public int la, la2;

   
    // Start is called before the first frame update
    void Start()
    {
        //playerMenina playerScript = GameObject.FindWithTag("player").GetComponent<playerMenina>();
        la = playerMenina.instance.aonde;
        la2 = playerMenina2.instance.aonde;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("urso"))
        {
          
                 if (collision.gameObject.layer == 8)
                    {

                        Destroy(gameObject);
                        Destroy(collision.gameObject);

                      }
        }
    }
      void OnDestroy()
    {
        playerMenina playerScript = GameObject.FindWithTag("player").GetComponent<playerMenina>();
        if (la == 1 || la2 == 1)
        {
            playerMenina.instance.jaTem = false;
            playerMenina2.instance.jaTem = false;
        }
        if (la == 2 || la2 == 2)
        {
            playerMenina.instance.jaTem2 = false;
            playerMenina2.instance.jaTem2 = false;
        }
        if (la == 3 || la2 == 3)
        {
            playerMenina.instance.jaTem3 = false;
            playerMenina2.instance.jaTem3 = false;
        }
        if (la == 4 || la2 == 4)
        {
            playerMenina.instance.jaTem4 = false;
            playerMenina2.instance.jaTem4 = false;
        }
    }
}


