using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class Enemy : MonoBehaviour
{
    public string enemyName = "New Enemy";

    public HealthManager HealthManager { get; private set; } = null;

    private void Awake()
    {
        HealthManager = GetComponent<HealthManager>();
    }
}