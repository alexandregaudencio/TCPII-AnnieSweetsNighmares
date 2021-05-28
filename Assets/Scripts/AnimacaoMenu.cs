using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoMenu : MonoBehaviour
{
    public float m_Velocidade;
    public Transform[] m_Posicao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_Posicao[1].position, m_Velocidade * Time.deltaTime);
    }
}
