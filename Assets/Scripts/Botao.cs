using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    private GameObject chave;
    private GameObject player;
    public bool ativou;
    public bool gastarChave;
    private Animator anim;
    public KeyCode TeclaPlayer;
    float seg, segAtual;
    // Start is called before the first frame update
    void Start()
    {
        seg = 0.0f;
        ativou = false;
        gastarChave = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

      seg += Time.deltaTime;

    if(Input.GetKey(TeclaPlayer) && gastarChave == true){
         segAtual = seg;   
        
         
        
        if(seg < segAtual + 5.0f)  {
          anim.SetBool("ativacao", true);
 this.transform.GetChild(3).gameObject.SetActive(true); 
        
        }else
            anim.SetBool("ativacao", false);
            this.transform.GetChild(3).gameObject.SetActive(false);
        
        

    } 

    
        }


public void Animation(){
 
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

    private void OnTriggerStay(Collider collision)
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