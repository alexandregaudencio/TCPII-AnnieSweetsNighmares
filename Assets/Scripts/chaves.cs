using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaves : MonoBehaviour
{
    private Vector3 chaveBody;
    private GameObject mao;
    public float distanciaAtivacao;
    private GameObject player;
    void Start()
    {
        this.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        this.transform.eulerAngles += new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //mao = this.GameObject;
        //ComPlayer();
        this.transform.eulerAngles += new Vector3(0.0f, 3.8f, 0.0f);

    }

    public void ComPlayer()
    {

        //chaveBody = this.transform.position;
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("player") && Input.GetKey(KeyCode.J) ||
         collision.gameObject.CompareTag("player") && Input.GetKey(KeyCode.V))
        {
            //player = collision.gameObject;
            //Destroy(gameObject);
            //this.gameObject.SetActive(false);

        }

    }
}
