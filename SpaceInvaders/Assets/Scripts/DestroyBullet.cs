﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, seconds); 
    }

 }
