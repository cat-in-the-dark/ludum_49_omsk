using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PCManager : MonoBehaviour
{
    public NewsFeed newsFeed;
    public CurrancyEvent currancyEvent;
    public Currency currency;
    private List<PC> computers = new List<PC>();
    [SerializeField]
    private double incomePerSec = 0;
    public double IncomePerSec => incomePerSec;

    [SerializeField]
    private double balance = 0.0;
    public double Balance => balance;

    public List<CurrancyEvent> events = new List<CurrancyEvent>();

    public void AddComputer(PC computer)
    {
        computers.Add(computer);
    }

    // Update is called once per frame
    // And update current income per sec and balance
    double GetCurrencyMul()
    {
        // yes it's O(n) lookup because unity doesn't support Dictionary in ScriptableObjects
        var idx = currancyEvent.names.FindIndex((el) => el == currency.currencyName);
        if (idx >= 0 && idx < currancyEvent.multipliers.Count)
        {
            return currancyEvent.multipliers[idx];
        }
        else
        {
            return 1;
        }
    }

    void UpdateBalance()
    {
        incomePerSec = GetCurrencyMul() * computers.Aggregate(0.0, (acc, pc) => acc + pc.GetDollarsPerSecFor(currency));
        balance += incomePerSec * Time.deltaTime;
    }

    void SetEvent(int idx)
    {
        currancyEvent = events[idx];
        newsFeed.SetText(currancyEvent.Text);
    }

    void SpawnEvent()
    {
        var idx = Random.Range(0, events.Count);
        SetEvent(idx);
        float nextSpawnIn = Random.Range(5.0f, 10.0f);
        Invoke("SpawnEvent", nextSpawnIn);
    }

    void Update()
    {
        UpdateBalance();
    }

    void Start()
    {
        SetEvent(0);
        Invoke("SpawnEvent", 5.0f);
    }
}
