using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PCManager : MonoBehaviour
{
    private List<PC> computers = new List<PC>();
    [SerializeField]
    private double incomePerSec = 0;
    public double IncomePerSec => incomePerSec;

    [SerializeField]
    private double balance = 0;
    public double Balance => balance;

    public void AddComputer(PC computer)
    {
        computers.Add(computer);
    }

    // Update is called once per frame
    // And update current income per sec and balance
    void UpdateBalance()
    {
        incomePerSec = computers.Aggregate(0.0, (acc, pc) => acc + pc.GetDollarsPerSec());
        balance += incomePerSec * Time.deltaTime;
    }

    void Update()
    {
        UpdateBalance();
    }
}
