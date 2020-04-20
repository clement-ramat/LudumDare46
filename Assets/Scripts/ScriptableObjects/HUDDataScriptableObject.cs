﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HUDData", menuName = "ScriptableObjects/HUDData", order = 1)]
public class HUDDataScriptableObject : ScriptableObject
{

    public float timeSinceStart;


    public Vector3 spawnPosition;

    public Vector3 goalPosition;

    public Vector3 iceCubePosition;


}
