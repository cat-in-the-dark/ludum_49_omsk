using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event Data", order = 51)]
public class CurrancyEvent : ScriptableObject
{
    public string Text;
    public List<string> names;
    public List<double> multipliers;
}
