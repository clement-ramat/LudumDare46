﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField]
    private HUDDataScriptableObject hudData;
    void Awake()
    {
        hudData.spawnTransform = this.transform;
    }


}
