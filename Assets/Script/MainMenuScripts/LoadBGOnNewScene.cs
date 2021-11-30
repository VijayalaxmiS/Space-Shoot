﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBGOnNewScene : MonoBehaviour
{

    private static LoadBGOnNewScene instance = null;
    public static LoadBGOnNewScene Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
