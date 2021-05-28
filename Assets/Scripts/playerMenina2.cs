using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMenina2 : MonoBehaviour
{
    public static playerMenina2 instance;
    [SerializeField] private float Speed;
    [SerializeField] private Transform targetVision;
    private Rigidbody rig;
    //Vector3 movement;
    // float contador = 5;

    public AudioSource myFx;
    public AudioClip JogarNoLixo, PegarCola, PegarLego, PegarOuro, JogarCola, JogarLego, JogarOuro, CraftCola, CraftLego, CraftOuro;


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
    GameObject obj3;//materiais
    GameObject obj4;//material na mesa esquerda
    GameObject obj5;//material na mesa direita
    GameObject obj6;//armadilha na mesa
    GameObject obj7;//armadilha na mao


    int obj3Id;//id dos materiais na mao  (i)
    int obj4Id;//id dos materiais na mesa
    int obj5Id;//id dos materiais na mesa
    int obj6Id;//id das armadilhas prontas ()
    int obj7Id;//id das armadilhas na mao (armId)

    

    float tempoPoçaCola = 1;//tempo PoçaCola
    float tempoBarreiraLego = 2;//BarreiraLego
    float tempoEstrepeLego = 3;//EstrepeLego


    bool segurando;//obj3 ou obj7 instanciados na mao ou n
    bool colocadoE;//colocou material na mesa esquerda
    bool colocadoD;//colocou material na mesa direita
    bool criando;//está no processo de criação(colocando os materiais)
    bool armMao;//se o obj7 está na mão(armadilha na mão)

    public bool jaTem;
    public bool jaTem2;
    public bool jaTem3;
    public bool jaTem4;
    public int aonde;

    public KeyCode TeclaPegar = KeyCode.V;
    public KeyCode TeclaJuntar = KeyCode.V;
    public KeyCode TeclaJogar = KeyCode.V;

    private float movement;
    private float movement2;

    private Animator anim;

    private int RotX, RotY, RotZ = 0;
    public int RotX1 { get => RotX; set => RotX = value; }
    public int RotY1 { get => RotY; set => RotY = value; }
    public int RotZ1 { get => RotZ; set => RotZ = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
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

    private void FixedUpdate()
    {
        Move();
    }



    public void noLixo()
    {
        myFx.PlayOneShot(JogarNoLixo);
    }
    public void jogarCola()
    {
        myFx.PlayOneShot(JogarCola);
    }
    public void jogarLego()
    {
        myFx.PlayOneShot(JogarLego);
    }
    public void jogarOuro()
    {
        myFx.PlayOneShot(JogarOuro);
    }
    public void pegarCola()
    {
        myFx.PlayOneShot(PegarCola);
    }
    public void pegarLego()
    {
        myFx.PlayOneShot(PegarLego);
    }
    public void pegarOuro()
    {
        myFx.PlayOneShot(PegarOuro);
    }
    public void craftCola()
    {
        myFx.PlayOneShot(CraftCola);
    }
    public void craftLego()
    {
        myFx.PlayOneShot(CraftLego);
    }
    public void craftOuro()
    {
        myFx.PlayOneShot(CraftOuro);
    }




    void Move()
    {

        Vector3 normalizedInputVector = new Vector3(movement, 0, movement2);
        if (normalizedInputVector != Vector3.zero)
        {
            targetVision.transform.position = transform.position + normalizedInputVector;
        }
        transform.LookAt(targetVision);


        movement = Input.GetAxisRaw("Horizontal2");
        movement2 = Input.GetAxisRaw("Vertical2");
        rig.velocity = new Vector3(movement, rig.velocity.y, movement2).normalized * Speed;

        if (segurando == true) anim.SetBool("segurando", true);
        else anim.SetBool("segurando", false);

        if (movement != 0.00f || movement2 != 0.00f)
        {
            anim.SetBool("andando", true);

        }
        else
        {
            anim.SetBool("andando", false);

        }


        //rotação do player
        //if (movement == 1)

        //    transform.eulerAngles = new Vector3(0, 90, 0);
        //else if (movement == -1)
        //    transform.eulerAngles = new Vector3(0, -90, 0);
        //else if (movement2 == 1)
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //else if (movement2 == -1)
        //    transform.eulerAngles = new Vector3(0, 180, 0);


        //if (segurando == true) anim.SetBool("segurando", true);
        //else anim.SetBool("segurando", false);


        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
        //Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        //{


        //    anim.SetBool("andando", true);

        //}
        //else
        //{
        //   anim.SetBool("andando", false);

        //}




        //if (Input.GetKey(KeyCode.A))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    rig.velocity = new Vector3(movement * Speed, rig.velocity.y, rig.velocity.z);
        //    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, movement2 * Speed);

        //}
        if (Input.GetKey(KeyCode.LeftShift))
        {
           
            anim.SetBool("correndo", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
           
            anim.SetBool("correndo", false);
        }




    }

    private void OnCollisionStay(Collision collision)
    {

        if (Input.GetKey(TeclaPegar))
        {
            if (segurando == false)
            {
                if (collision.gameObject.CompareTag("mesa"))
                {
                    if (criando == true)
                    {
                        obj7Id = obj6Id;
                        obj7 = Instantiate(armMesaArray[obj7Id], mao.transform.position, Quaternion.identity);
                        if (obj7.GetComponent<Rigidbody>())
                        {
                            obj7.GetComponent<Rigidbody>().isKinematic = true;
                            obj7.transform.position = mao.transform.position;
                            obj7.transform.rotation = mao.transform.rotation;
                            obj7.transform.parent = mao.transform;
                        }
                        Destroy(obj6);
                        criando = false;
                        colocadoE = false;
                        colocadoD = false;
                        armMao = true;
                        segurando = true;

                        obj5Id = 5;
                        obj4Id = 5;
                    }
                }
                if (collision.gameObject.CompareTag("bau"))
                {
                    if (collision.gameObject.layer == 13)//cola
                    {
                        obj3Id = 0;
                        RotX1 = -90;
                        RotY1 = 0;
                        RotZ1 = 0;
                        pegarCola();

                    }
                    if (collision.gameObject.layer == 14)//lego
                    {
                        obj3Id = 1;
                        RotX1 = -90;
                        RotY1 = 0;
                        RotZ1 = 0;
                        pegarLego();
                    }//lego

                    if (collision.gameObject.layer == 15)//ouro
                    {
                        obj3Id = 2;
                        RotX1 = 0;
                        RotY1 = 90;
                        RotZ1 = 0;
                        pegarOuro();
                    }//cola

                    obj3 = Instantiate(materiaisArray[obj3Id], mao.transform.position, Quaternion.Euler(RotX1, RotY1, RotZ1));
                    segurando = true;
                    if (obj3.GetComponent<Rigidbody>())
                    {
                        obj3.GetComponent<Rigidbody>().isKinematic = true;
                        obj3.transform.position = mao.transform.position;
                        //obj3.transform.rotation = mao.transform.rotation;
                        obj3.transform.parent = mao.transform;
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
                    noLixo();

                }
                if (collision.gameObject.CompareTag("mesa"))
                {
                    if (armMao == false)
                    {
                        if (collision.gameObject.layer == 11)
                        {
                            if (colocadoE == false)
                             {

                            obj4Id = obj3Id;
                            Destroy(obj3);
                            segurando = false;
                            colocadoE = true;
                            if (obj4Id == 0)//cola
                            {
                                RotX1 = -90;
                                RotY1 = 0;
                                RotZ1 = 0;
                            }
                            if (obj4Id == 1)//lego
                            {
                                RotX1 = -90;
                                RotY1 = 0;
                                RotZ1 = 0;
                            }
                            if (obj4Id == 2)//ouro
                            {
                                RotX1 = 0;
                                RotY1 = 90;
                                RotZ1 = 0;
                            }
                            obj4 = Instantiate(materiaisArray[obj4Id], mesaArray[0].transform.position + new Vector3(0, 0.4f, 0f), Quaternion.Euler(RotX1, RotY1, RotZ1));

                        }
                    }
                        if (collision.gameObject.layer == 12)
                        {
                        if (colocadoD == false)
                        {
                            obj5Id = obj3Id;
                            Destroy(obj3);
                            segurando = false;
                            colocadoD = true;
                            if (obj5Id == 0)//cola
                            {
                                RotX1 = -90;
                                RotY1 = 0;
                                RotZ1 = 0;
                            }
                            if (obj5Id == 1)//lego
                            {
                                RotX1 = -90;
                                RotY1 = 0;
                                RotZ1 = 0;
                            }
                            if (obj5Id == 2)//ouro
                            {
                                RotX1 = 0;
                                RotY1 = 90;
                                RotZ1 = 0;
                            }
                            obj5 = Instantiate(materiaisArray[obj5Id], mesaArray[1].transform.position + new Vector3(0, 0.4f, 0f), Quaternion.Euler(RotX1, RotY1, RotZ1));
                            
                        }
                    }
                    }
                }
            }
        }


        if (Input.GetKey(TeclaJuntar))
        {
            if (collision.gameObject.CompareTag("mesa"))
            {
                if (criando == false)
                {
                    if (obj4Id == 0 && obj5Id == 0)//poça de cola
                    {
                        if (tempoPoçaCola <= 0)
                        {
                            Debug.Log("novo item");
                            obj6Id = 0;
                            obj6 = Instantiate(armMesaArray[obj6Id], mesaArray[0].transform.position + new Vector3(0, 0.5f, 0f), Quaternion.identity);
                            Destroy(obj4);
                            Destroy(obj5);
                            criando = true;
                            obj5Id = 5;
                            obj4Id = 5;
                            tempoPoçaCola = 1;
                            craftCola();
                        }
                        else
                        {
                            colocadoE = true;
                            colocadoD = true;
                            tempoPoçaCola -= Time.deltaTime;
                            //Debug.Log(tempo0);
                        }
                    }
                    if (obj4Id == 1 && obj5Id == 1)//barreira de lego
                    {
                        if (tempoBarreiraLego <= 0)
                        {
                            Debug.Log("novo item");
                            obj6Id = 1;
                            obj6 = Instantiate(armMesaArray[obj6Id], mesaArray[0].transform.position + new Vector3(0, 0.2f, 0f), Quaternion.Euler(-90f, 0f, 0));
                            Destroy(obj4);
                            Destroy(obj5);
                            criando = true;
                            obj5Id = 5;
                            obj4Id = 5;
                            tempoBarreiraLego = 2;
                            craftLego();
                        }
                        else
                        {
                            colocadoE = true;
                            colocadoD = true;
                            tempoBarreiraLego -= Time.deltaTime;
                            //Debug.Log(tempo1);
                        }
                    }
                    if (obj4Id == 1 && obj5Id == 2 || obj4Id == 2 && obj5Id == 1)// estrepe de lego
                    {
                        if (tempoEstrepeLego <= 0)
                        {
                            Debug.Log("novo item");
                            obj6Id = 2;
                            obj6 = Instantiate(armMesaArray[obj6Id], mesaArray[0].transform.position + new Vector3(0, 0.5f, 0f), Quaternion.identity);
                            Destroy(obj4);
                            Destroy(obj5);
                            criando = true;
                            obj5Id = 5;
                            obj4Id = 5;
                            tempoEstrepeLego = 3;
                            craftOuro();
                        }
                        else
                        {
                            colocadoE = true;
                            colocadoD = true;
                            tempoEstrepeLego -= Time.deltaTime;
                            //Debug.Log(tempo2);
                        }
                    }
                    else if (obj4Id == 0 && obj5Id == 2 || (obj4Id == 2 && obj5Id == 0) || (obj4Id == 0 && obj5Id == 1) || (obj4Id == 1 && obj5Id == 0) || (obj4Id == 2 && obj5Id == 2))
                    {
                        noLixo();
                        Destroy(obj4);
                        Destroy(obj5);
                        obj5Id = 5;
                        obj4Id = 5;
                        colocadoE = false;
                        colocadoD = false;

                    }
                }

            }
        }
    }


    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKey(TeclaJogar))
        {
            //armadilha1 armScript = GameObject.Find("armadilha1").GetComponent<armadilha1>();
            if (armMao == true)
            {

                if (collision.gameObject.CompareTag("LA1"))
                {
                    if (jaTem == false)
                    {
                        armMao = false;
                        segurando = false;
                        if (obj7Id == 1)
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[0].transform.position, Quaternion.Euler(-90f, 90f, 0));
                        }
                        else
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[0].transform.position, Quaternion.identity);
                        }
                        jogarOuro();
                        Destroy(obj7);
                        jaTem = true;
                        aonde = 1;
                        //armadilha1 armadilha1 = GameObject.Find("armadilha1").GetComponent<armadilha1>();

                    }

                }
                if (collision.gameObject.CompareTag("LA2"))
                {
                    if (jaTem2 == false)
                    {
                        armMao = false;
                        segurando = false;
                        if (obj7Id == 1)
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[1].transform.position, Quaternion.Euler(-90f, 90f, 0));
                        }
                        else
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[1].transform.position, Quaternion.identity);
                        }
                        jogarLego();
                        Destroy(obj7);
                        jaTem2 = true;
                        aonde = 2;
                    }
                }
                if (collision.gameObject.CompareTag("LA3"))
                {
                    if (jaTem3 == false)
                    {
                        armMao = false;
                        segurando = false;
                        if (obj7Id == 1)
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[2].transform.position, Quaternion.Euler(-90f, 90f, 0));
                        }
                        else
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[2].transform.position, Quaternion.identity);
                        }
                        jogarCola();
                        Destroy(obj7);
                        jaTem3 = true;
                        aonde = 3;
                        //armadilha1 armadilha1 = GameObject.Find("armadilha1").GetComponent<armadilha1>();

                    }

                }
                if (collision.gameObject.CompareTag("LA4"))
                {
                    if (jaTem4 == false)
                    {
                        armMao = false;
                        segurando = false;
                        if (obj7Id == 1)
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[3].transform.position, Quaternion.Euler(-90f, 90f, 0));

                        }
                        else
                        {
                            GameObject obj = Instantiate(armArray[obj7Id], LA[3].transform.position, Quaternion.identity);
                        }
                        Destroy(obj7);
                        jaTem4 = true;
                        aonde = 4;
                        //armadilha1 armadilha1 = GameObject.Find("armadilha1").GetComponent<armadilha1>();

                    }

                }
            }
        }
    }
}
