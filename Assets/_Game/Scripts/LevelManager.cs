﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } = null;

    public Transform endGoal = null;

    private void Awake()
    {
        Instance = this;
    }
}
