using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public float vida;
    public GameObject tesouros;
    
    public Text vidaUi;
    //public GameObject areaTesouro;
    GameObject objTesouro;
     GameObject objTesouro1;
     GameObject objTesouro2;
     GameObject objTesouro3;
     GameObject objTesouro4;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        vida = 5;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        vidaUi.text = vida.ToString();
       

        if (vida <= 0)
        {
            gameManager.instance.gameOver();
        }
    }
   /* private void OnTriggerEnter(Collider collision)
    {


        if (collision.gameObject.CompareTag("urso"))
        {

            vida=vida+0.5f;
           //Destroy(collision.gameObject);

        }
    }*/
}
