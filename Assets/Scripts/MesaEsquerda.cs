﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaEsquerda : MonoBehaviour
{
    public static MesaEsquerda instance;
    public int obj4ID;
    public int obj5ID;

    public GameObject obj5;
    public GameObject obj4;

    public bool colocadoE;
    public bool colocadoD;
    
    void Start()
    {
        obj4ID = 5;
        obj5ID = 5;
        instance = this;
    }

}