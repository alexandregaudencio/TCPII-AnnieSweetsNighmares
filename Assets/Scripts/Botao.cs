using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    private GameObject chave;
    private GameObject player;
    public bool ativou;
    public bool gastarChave;

    public KeyCode TeclaPlayer;
    float seg, segAtual;
    // Start is called before the first frame update
    void Start()
    {
        ativou = false;
        gastarChave = false;
    }

    // Update is called once per frame
    void Update()
    {



        // if (gastarChave == true)
        // {
        //     ativou = true;
        // }
        //else GastarChave();

    }

    /* 
        public void GastarChave()
        {
            float waitTime = 2;
            float counter = 0;
            while (counter < waitTime)
            {
                //Increment Timer until counter >= waitTime
                counter += Time.deltaTime;
                if (counter > 2)
                {
                    ativou = false;
                }
            }

        } */

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("player"))
        {
            //chave = collision.gameObject;
            ativou = true;
            player = collision.gameObject;
            gastarChave = player.GetComponent<playerMenina>().comKey;
            TeclaPlayer = player.GetComponent<playerMenina>().TeclaMartelo;
            //player = collision.gameObject;
            //Destroy(collision.gameObject);
            //this.gameObject.SetActive(false);
        }


    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.CompareTag("player"))
        {
            ativou = false;
            player = collision.gameObject;
            gastarChave = player.GetComponent<playerMenina>().comKey;

        }

    }
}