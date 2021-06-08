using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMenina : MonoBehaviour
{
    public static playerMenina instance;

    [SerializeField] private float Speed;
    [SerializeField] private Transform targetVision;
    private Rigidbody rig;
    //Vector3 movement;
    // float contador = 5;

    //Player Move
    public string horizontal, vertical;


    //Martelo
    //public GameObject botao;
    public GameObject chave;
    public bool comKey = false;
    private GameObject newchave;
    public KeyCode TeclaMartelo = KeyCode.J;

    public AudioSource myFx;
    public AudioClip JogarNoLixo, PegarCola, PegarLego, PegarOuro, JogarCola, JogarLego, JogarOuro, CraftCola, CraftLego, CraftOuro, CraftErro, NaMesa, Passos, PegarChave;

    string ArmSom;




    public GameObject[] LA;
    // public GameObject LA2;
    public GameObject[] armArray;//(arm,arm1,arm3)
                                 //public GameObject arm;
                                 //public GameObject arm2;
                                 //public GameObject arm3;

    //16/04

    public GameObject[] mesaArray;//instanciar os objetos na mesa(mesadir e msaesq)
    public GameObject[] materiaisArray;//materiais(metal, lego, cola) (objetos)
    public GameObject[] armMesaArray;//armadilhas formadas na mesa-(armadilhas)
    public GameObject mao;//aonde instancia o objeto segurado

    GameObject obj1;// armadilha chao1
    GameObject obj2;// armadilha chao2
    public GameObject obj3;//materiais
    GameObject obj4;//material na mesa esquerda
    GameObject obj5;//material na mesa direita
    GameObject obj6;//armadilha na mesa
    GameObject obj7;//armadilha na mao


    int obj3Id;//id dos materiais na mao  (i)
    public int obj4Id;//id dos materiais na mesa
    public int obj5Id;//id dos materiais na mesa
    public int obj6Id;//id das armadilhas prontas ()
    int obj7Id;//id das armadilhas na mao (armId)



    float tempoPoçaCola = 1;//tempo PoçaCola
    float tempoBarreiraLego = 2;//BarreiraLego
    float tempoEstrepeLego = 3;//EstrepeLego


    public bool segurando;//obj3 ou obj7 instanciados na mao ou n
    public bool colocadoE;//colocou material na mesa esquerda
    public bool colocadoD;//colocou material na mesa direita
    bool criando;//está no processo de criação(colocando os materiais)
    public bool armMao;//se o obj7 está na mão(armadilha na mão)

    public bool jaTem;
    public bool jaTem2;
    public bool jaTem3;
    public bool jaTem4;
    public int aonde;

    // public KeyCode TeclaPegar = KeyCode.E;
    // public KeyCode TeclaJuntar = KeyCode.R;
    // public KeyCode TeclaJogar = KeyCode.T;

    private float movement;
    private float movement2;
    private Animator anim;

    //int RotX2, RotY2, RotZ2;
    //int RotX3, RotY3, RotZ3;

    private int RotX, RotY, RotZ = 0;
    public int RotX1 { get => RotX; set => RotX = value; }
    public int RotY1 { get => RotY; set => RotY = value; }
    public int RotZ1 { get => RotZ; set => RotZ = value; }
    public int RotX2 { get => RotX; set => RotX = value; }
    public int RotY2 { get => RotY; set => RotY = value; }
    public int RotZ2 { get => RotZ; set => RotZ = value; }




    void Start()
    {

        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        myFx = GetComponent<AudioSource>();
        myFx.Play(0);
        myFx.Pause();
        
        jaTem = false;
        jaTem2 = false;
        jaTem3 = false;
        jaTem4 = false;

        segurando = false;
        colocadoE = false;
        colocadoD = false;
        criando = false;
        armMao = false;
        tempoPoçaCola = 1;
        tempoBarreiraLego = 2;
        tempoEstrepeLego = 3;
        obj5Id = 5;
        obj4Id = 5;
        instance = this;

    }



    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -21, 23),
         Mathf.Clamp(this.transform.position.y, 1, 7), Mathf.Clamp(this.transform.position.z, -3, 15));
        //Move();

    }

    private void FixedUpdate()
    {

        Move();

        //Debug.Log("jatem :" + MesaEsquerda.instance.jaTem);

    }




    void Move()
    {

        movement = Input.GetAxisRaw(horizontal); //Horizontal
        movement2 = Input.GetAxisRaw(vertical); //Vertical
        rig.velocity = new Vector3(movement, rig.velocity.y, movement2).normalized * Speed;


        Vector3 normalizedInputVector = new Vector3(movement, 0, movement2);
        if (normalizedInputVector != Vector3.zero)
        {
            targetVision.transform.position = transform.position + normalizedInputVector * 5;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetVision.position - transform.position), 10 * Time.fixedDeltaTime);

        }
        //transform.LookAt(targetVision);


        if (segurando == true) anim.SetBool("segurando", true);
        else anim.SetBool("segurando", false);

        if (movement != 0.00f || movement2 != 0.00f)
        {
            anim.SetBool("andando", true);
            myFx.UnPause();
        }
        else
        {
            anim.SetBool("andando", false);
            myFx.Pause();

        }

 

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Speed = 13;
            anim.SetBool("correndo", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Speed = 8;
            anim.SetBool("correndo", false);
        }


    }

    public void AtivarSom(string s)
    {

        switch (s)
        {
            case "P_cola":
                myFx.PlayOneShot(PegarCola);
                break;

            case "P_ouro":
                myFx.PlayOneShot(PegarOuro);
                break;

            case "P_lego":
                myFx.PlayOneShot(PegarLego);
                break;

            case "C_cola":
                myFx.PlayOneShot(CraftCola);
                break;

            case "C_ouro":
                myFx.PlayOneShot(CraftOuro);
                break;

            case "C_lego":
                myFx.PlayOneShot(CraftLego);
                break;

            case "C_erro":
                myFx.PlayOneShot(CraftErro);
                break;

            case "A_cola":
                myFx.PlayOneShot(JogarCola);
                break;

            case "A_ouro":
                myFx.PlayOneShot(JogarOuro);
                break;

            case "A_lego":
                myFx.PlayOneShot(JogarLego);
                break;

            case "chave":
                myFx.PlayOneShot(PegarChave);
                break;

            case "lixo":
                myFx.PlayOneShot(JogarNoLixo);
                break;

            case "passos":
                myFx.PlayOneShot(Passos);
                break;

            case "mesa":
                myFx.PlayOneShot(NaMesa);
                break;

        }

    }

    public void OnLoadBarCraft(Collision collision)
    {
        if (Input.GetKeyDown(TeclaMartelo) && collision.gameObject.CompareTag("mesa") && MesaEsquerda.instance.colocadoD && MesaEsquerda.instance.colocadoE)
        {
            MesaEsquerda.instance.loadBarCraft.SetActive(true);
            //MesaEsquerda.instance.loadBarCraft.GetComponent<Animator>().Play("loadBarCraftAnim");
        }
        else if (Input.GetKeyUp(TeclaMartelo))
        {
            MesaEsquerda.instance.loadBarCraft.SetActive(false);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        OnLoadBarCraft(collision);


        if (Input.GetKey(TeclaMartelo))
        {
            if (segurando == false)
            {

                if (collision.gameObject.CompareTag("mesa"))
                {

                    if (criando == true)
                    {
                        obj7Id = obj6Id;
                        if (obj7Id == 0)//cola
                        {

                            RotX2 = -90;
                            RotY2 = 0;
                            RotZ2 = 0;
                            ArmSom = "P_cola";
                        }//metal
                        if (obj7Id == 1)//lego
                        {

                            RotX2 = -90;
                            RotY2 = 0;
                            RotZ2 = 0;
                            ArmSom = "P_ouro";
                        }//lego

                        if (obj7Id == 2)//ouro
                        {

                            RotX2 = 0;
                            RotY2 = 90;
                            RotZ2 = 0;
                            ArmSom = "P_lego";
                        }//cola

                        obj7 = Instantiate(armMesaArray[obj7Id], mao.transform.position, Quaternion.Euler(RotX2, RotY2, RotZ2));



                        if (obj7.GetComponent<Rigidbody>())
                        {
                            obj7.GetComponent<Rigidbody>().isKinematic = true;
                            obj7.transform.position = mao.transform.position;
                            obj7.transform.rotation = mao.transform.rotation;
                            obj7.transform.parent = mao.transform;
                            AtivarSom(ArmSom);

                            switch (obj7Id)
                            {
                                case 0:
                                    obj7.transform.eulerAngles -= new Vector3(90.0f, 0.0f, 0.0f);
                                    break;
                                case 1:
                                    obj7.transform.eulerAngles -= new Vector3(-90.0f, 0.0f, 0.0f);
                                    break;
                                case 2:
                                    obj7.transform.eulerAngles -= new Vector3(0.0f, 0f, 0.0f);
                                    break;

                            }
                        }

                        /* if (obj7.GetComponent<Rigidbody>())
                         {
                             obj7.GetComponent<Rigidbody>().isKinematic = true;
                             obj7.transform.position = mao.transform.position;
                             //obj7.transform.rotation = mao.transform.rotation;
                             obj7.transform.parent = mao.transform;
                         }*/
                        Destroy(obj6);
                        criando = false;
                        MesaEsquerda.instance.colocadoE = false;
                        MesaEsquerda.instance.colocadoD = false;
                        armMao = true;
                        segurando = true;

                        MesaEsquerda.instance.obj5ID = 5;
                        MesaEsquerda.instance.obj4ID = 5;
                    }
                }
                if (collision.gameObject.CompareTag("bau"))
                {
                    if (collision.gameObject.layer == 13)//cola
                    {
                        obj3Id = 0;
                        RotX1 = 0;
                        RotY1 = 0;
                        RotZ1 = 0;
                        ArmSom = "P_cola";
                    }//metal
                    if (collision.gameObject.layer == 14)//lego
                    {
                        obj3Id = 1;
                        RotX1 = 0;
                        RotY1 = 0;
                        RotZ1 = 0;
                        ArmSom = "P_lego";
                    }//lego

                    if (collision.gameObject.layer == 15)//ouro
                    {
                        obj3Id = 2;
                        RotX1 = 0;
                        RotY1 = 0;
                        RotZ1 = 0;
                        ArmSom = "P_ouro";
                    }//cola

                    obj3 = Instantiate(materiaisArray[obj3Id], mao.transform.position, Quaternion.Euler(RotX1, RotY1, RotZ1));
                    segurando = true;
                    if (obj3.GetComponent<Rigidbody>())
                    {
                        obj3.GetComponent<Rigidbody>().isKinematic = true;
                        obj3.transform.position = mao.transform.position;
                        obj3.transform.rotation = mao.transform.rotation;
                        obj3.transform.parent = mao.transform;
                        AtivarSom(ArmSom);
                        switch (obj3Id)
                        {
                            case 0:
                                obj3.transform.eulerAngles -= new Vector3(90.0f, 0.0f, 0.0f);
                                break;
                            case 1:
                                obj3.transform.eulerAngles -= new Vector3(90.0f, 0.0f, 0.0f);
                                break;
                            case 2:
                                this.obj3.transform.GetChild(0).gameObject.transform.eulerAngles -= new Vector3(0.0f, 90.0f, 0.0f);
                                break;

                        }
                    }
                }

            }

            if (segurando == true)
            {
                anim.SetBool("segurando", true);
                if (collision.gameObject.CompareTag("lixo"))
                {
                    Destroy(obj3);
                    Destroy(obj7);
                    segurando = false;
                    armMao = false;
                    AtivarSom("lixo");

                }
                if (collision.gameObject.CompareTag("mesa"))
                {
                    if (armMao == false)
                    {
                        if (collision.gameObject.layer == 11)
                        {
                            if (MesaEsquerda.instance.colocadoE == false)
                            {

                                MesaEsquerda.instance.obj4ID = obj3Id;
                                Destroy(obj3);
                                segurando = false;
                                MesaEsquerda.instance.colocadoE = true;
                                if (MesaEsquerda.instance.obj4ID == 0)//cola
                                {
                                    RotX1 = -90;
                                    RotY1 = 0;
                                    RotZ1 = 0;
                                }
                                if (MesaEsquerda.instance.obj4ID == 1)//lego
                                {
                                    RotX1 = -90;
                                    RotY1 = 0;
                                    RotZ1 = 0;
                                }
                                if (MesaEsquerda.instance.obj4ID == 2)//ouro
                                {
                                    RotX1 = 0;
                                    RotY1 = 90;
                                    RotZ1 = 0;
                                }
                                MesaEsquerda.instance.obj4 = Instantiate(materiaisArray[MesaEsquerda.instance.obj4ID], mesaArray[0].transform.position + new Vector3(0, 0.4f, 0f), Quaternion.Euler(RotX1, RotY1, RotZ1));
                                AtivarSom("mesa");
                            }
                        }
                        if (collision.gameObject.layer == 12)
                        {
                            if (MesaEsquerda.instance.colocadoD == false)
                            {
                                MesaEsquerda.instance.obj5ID = obj3Id;
                                Destroy(obj3);
                                segurando = false;
                                MesaEsquerda.instance.colocadoD = true;
                                if (MesaEsquerda.instance.obj5ID == 0)//cola
                                {
                                    RotX1 = -90;
                                    RotY1 = 0;
                                    RotZ1 = 0;
                                }
                                if (MesaEsquerda.instance.obj5ID == 1)//lego
                                {
                                    RotX1 = -90;
                                    RotY1 = 0;
                                    RotZ1 = 0;
                                }
                                if (MesaEsquerda.instance.obj5ID == 2)//ouro
                                {
                                    RotX1 = 0;
                                    RotX1 = 0;
                                    RotY1 = 90;
                                    RotZ1 = 0;
                                }
                                MesaEsquerda.instance.obj5 = Instantiate(materiaisArray[MesaEsquerda.instance.obj5ID], mesaArray[1].transform.position + new Vector3(0, 0.4f, 0f), Quaternion.Euler(RotX1, RotY1, RotZ1));
                                AtivarSom("mesa");
                            }
                        }
                    }
                }
            }
        }




        if (Input.GetKey(TeclaMartelo))
        {
            if (collision.gameObject.CompareTag("mesa"))
            {
                if (criando == false)
                {
                    if (MesaEsquerda.instance.obj4ID == 0 && MesaEsquerda.instance.obj5ID == 0)//poça de cola
                    {
                        if (tempoPoçaCola <= 0)
                        {
                            //Debug.Log("novo item");
                            obj6Id = 0;
                            obj6 = Instantiate(armMesaArray[obj6Id], mesaArray[0].transform.position + new Vector3(0, 0.5f, 0f), Quaternion.identity);
                            Destroy(MesaEsquerda.instance.obj4);
                            Destroy(MesaEsquerda.instance.obj5);
                            criando = true;
                            MesaEsquerda.instance.obj5ID = 5;
                            MesaEsquerda.instance.obj4ID = 5;
                            tempoPoçaCola = 1;
                            AtivarSom("C_cola");
                        }
                        else
                        {
                            MesaEsquerda.instance.colocadoE = true;
                            MesaEsquerda.instance.colocadoD = true;
                            tempoPoçaCola -= Time.deltaTime;
                           
                            //Debug.Log(tempo0);
                        }
                    }
                    if (MesaEsquerda.instance.obj4ID == 1 && MesaEsquerda.instance.obj5ID == 1)//barreira de lego
                    {
                        if (tempoBarreiraLego <= 0)
                        {
                            //Debug.Log("novo item");
                            obj6Id = 1;
                            obj6 = Instantiate(armMesaArray[obj6Id], mesaArray[0].transform.position + new Vector3(0, 0.2f, 0f), Quaternion.Euler(-90f, 0f, 0));
                            Destroy(MesaEsquerda.instance.obj4);
                            Destroy(MesaEsquerda.instance.obj5);
                            criando = true;
                            MesaEsquerda.instance.obj5ID = 5;
                            MesaEsquerda.instance.obj4ID = 5;
                            tempoBarreiraLego = 2;
                            AtivarSom("C_lego");
                        }
                        else
                        {
                            MesaEsquerda.instance.colocadoE = true;
                            MesaEsquerda.instance.colocadoD = true;
                            tempoBarreiraLego -= Time.deltaTime;
                            //Debug.Log(tempo1);
                        }
                    }
                    if (MesaEsquerda.instance.obj4ID == 1 && MesaEsquerda.instance.obj5ID == 2 || MesaEsquerda.instance.obj4ID == 2 && MesaEsquerda.instance.obj5ID == 1)// estrepe de lego
                    {
                        if (tempoEstrepeLego <= 0)
                        {
                            //Debug.Log("novo item");
                            obj6Id = 2;
                            obj6 = Instantiate(armMesaArray[obj6Id], mesaArray[0].transform.position + new Vector3(0, 0.5f, 0f), Quaternion.identity);
                            Destroy(MesaEsquerda.instance.obj4);
                            Destroy(MesaEsquerda.instance.obj5);
                            criando = true;
                            MesaEsquerda.instance.obj5ID = 5;
                            MesaEsquerda.instance.obj4ID = 5;
                            tempoEstrepeLego = 3;
                            AtivarSom("C_ouro");
                        }
                        else
                        {
                            MesaEsquerda.instance.colocadoE = true;
                            MesaEsquerda.instance.colocadoD = true;
                            tempoEstrepeLego -= Time.deltaTime;
                            //Debug.Log(tempo2);
                        }
                    }
                    else if ((MesaEsquerda.instance.obj4ID == 0 && MesaEsquerda.instance.obj5ID == 2) || (MesaEsquerda.instance.obj4ID == 2 && MesaEsquerda.instance.obj5ID == 0) || (MesaEsquerda.instance.obj4ID == 0 && MesaEsquerda.instance.obj5ID == 1) || (MesaEsquerda.instance.obj4ID == 1 && MesaEsquerda.instance.obj5ID == 0) || (MesaEsquerda.instance.obj4ID == 2 && MesaEsquerda.instance.obj5ID == 2))
                    {
                        Destroy(MesaEsquerda.instance.obj4);
                        Destroy(MesaEsquerda.instance.obj5);
                        MesaEsquerda.instance.obj5ID = 5;
                        MesaEsquerda.instance.obj4ID = 5;
                        MesaEsquerda.instance.colocadoE = false;
                        MesaEsquerda.instance.colocadoD = false;
                        AtivarSom("C_erro");

                    }
                }

            }
        }
    }


    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKey(TeclaMartelo))
        {

            //armadilha1 armScript = GameObject.Find("armadilha1").GetComponent<armadilha1>();
            if (armMao == true)
            {
                if (obj7Id == 0)//poça cola
                {

                    RotX1 = 90;
                    RotY1 = 90;
                    RotZ1 = 90;
                    ArmSom = "A_cola";

                }//metal
                if (obj7Id == 1)//muro lego
                {

                    RotX1 = -90;
                    RotY1 = 90;
                    RotZ1 = 0;
                    ArmSom = "A_ouro";
                }//lego

                if (obj7Id == 2)//estrepe de lego
                {

                    RotX1 = 0;
                    RotY1 = 0;
                    RotZ1 = 0;
                    ArmSom = "A_lego";
                }//cola
                if (collision.gameObject.CompareTag("LA1"))
                {
                    if (MesaEsquerda.instance.jaTem == false)
                    {
                        armMao = false;
                        segurando = false;
                        GameObject obj = Instantiate(armArray[obj7Id], LA[0].transform.position, Quaternion.Euler(RotX1, RotY1, RotZ1));
                        Destroy(obj7);
                        MesaEsquerda.instance.jaTem = true;
                        //armadilha1.instance.la = 1;
                        aonde = 1;
                        //armadilha1 armadilha1 = GameObject.Find("armadilha1").GetComponent<armadilha1>();
                        AtivarSom(ArmSom);
                    }

                }
                if (collision.gameObject.CompareTag("LA2"))
                {
                    if (MesaEsquerda.instance.jaTem2 == false)
                    {
                        armMao = false;
                        segurando = false;
                        GameObject obj = Instantiate(armArray[obj7Id], LA[1].transform.position, Quaternion.Euler(RotX1, RotY1, RotZ1));
                        Destroy(obj7);
                        MesaEsquerda.instance.jaTem2 = true;
                        //armadilha1.instance.la = 2;
                        aonde = 2;
                        AtivarSom(ArmSom);
                    }
                }
                if (collision.gameObject.CompareTag("LA3"))
                {
                    if (MesaEsquerda.instance.jaTem3 == false)
                    {
                        armMao = false;
                        segurando = false;
                        GameObject obj = Instantiate(armArray[obj7Id], LA[2].transform.position, Quaternion.Euler(RotX1, RotY1, RotZ1));
                        Destroy(obj7);
                        MesaEsquerda.instance.jaTem3 = true;
                        //armadilha1.instance.la = 3;
                        aonde = 3;
                        //armadilha1 armadilha1 = GameObject.Find("armadilha1").GetComponent<armadilha1>();
                        AtivarSom(ArmSom);
                    }

                }
                if (collision.gameObject.CompareTag("LA4"))
                {
                    if (MesaEsquerda.instance.jaTem4 == false)
                    {
                        armMao = false;
                        segurando = false;
                        GameObject obj = Instantiate(armArray[obj7Id], LA[3].transform.position, Quaternion.Euler(RotX1, RotY1, RotZ1));
                        Destroy(obj7);
                        MesaEsquerda.instance.jaTem4 = true;
                        aonde = 4;
                        //armadilha1 armadilha1 = GameObject.Find("armadilha1").GetComponent<armadilha1>();
                        AtivarSom(ArmSom);
                    }

                }
            }





            if (collision.gameObject.CompareTag("botao") && comKey == true)
            {
                comKey = false;
                newchave.SetActive(false);
               
                segurando = false;
                Destroy(newchave, 3);
                

            }





            if (collision.gameObject.CompareTag("chave") && segurando == false)
            {
                newchave = Instantiate(chave, mao.transform.position, Quaternion.identity);
                newchave.GetComponent<chaves>().enabled = false;
                newchave.transform.position = mao.transform.position + new Vector3(0.23f, 0.0f, 0.0f);
                newchave.transform.rotation = mao.transform.rotation;
                newchave.transform.eulerAngles -= new Vector3(0.0f, 0.0f, 0.0f);
                newchave.transform.parent = mao.transform;
                segurando = true;
                comKey = true;
                Destroy(collision.gameObject);
                AtivarSom("chave");

            }
        }
    }
}
