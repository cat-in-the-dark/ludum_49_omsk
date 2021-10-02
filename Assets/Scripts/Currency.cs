using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Currency", menuName="Currency", order=52)]
public class Currency : ScriptableObject
{
    public string currencyName;
    public double USDRate;
}
