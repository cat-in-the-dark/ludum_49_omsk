using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCManager : MonoBehaviour
{
    private List<PC> computers;

    public void AddComputer(PC computer) {
        computers.Add(computer);
    }
}
