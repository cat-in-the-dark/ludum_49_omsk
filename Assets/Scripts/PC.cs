using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PC
{
    public Currency currentCurrency;
    public MotherBoardPart motherBoard;
    public PowerSupplyPart powerSupply;

    private List<CpuPart> cpuSlots = new List<CpuPart>();
    private List<RamPart> ramSlots = new List<RamPart>();
    private List<GpuPart> gpuSlots = new List<GpuPart>();
    private List<DiskPart> diskSlots = new List<DiskPart>();

    public PC(MotherBoardPart motherBoard, PowerSupplyPart powerSupply) {
        this.motherBoard = motherBoard;
        this.powerSupply = powerSupply;
    }

    public bool AddCpu(CpuPart cpuPart)
    {
        if (cpuSlots.Count < motherBoard.CpuSlots)
        {
            cpuSlots.Add(cpuPart);
            return true;
        }
        return false;
    }

    public bool AddRam(RamPart ramPart)
    {
        if (ramSlots.Count < motherBoard.RamSlots)
        {
            ramSlots.Add(ramPart);
            return true;
        }
        return false;
    }

    public bool AddGpu(GpuPart gpuPart)
    {
        if (gpuSlots.Count < motherBoard.GpuSlots)
        {
            gpuSlots.Add(gpuPart);
            return true;
        }
        return false;
    }

    public bool AddDisk(DiskPart diskPart)
    {
        if (diskSlots.Count < motherBoard.DiskSlots)
        {
            diskSlots.Add(diskPart);
            return true;
        }
        return false;
    }

    public void ReplaceCpu(CpuPart cpuPart, int index)
    {
        cpuSlots[index] = cpuPart;
    }

    public void ReplaceRam(RamPart ramPart, int index)
    {
        ramSlots[index] = ramPart;
    }

    public void ReplaceGpu(GpuPart gpuPart, int index)
    {
        gpuSlots[index] = gpuPart;
    }

    public void ReplaceDisk(DiskPart diskPart, int index)
    {
        diskSlots[index] = diskPart;
    }

    public List<CpuPart> GetCpuSlots()
    {
        return cpuSlots;
    }

    public List<RamPart> GetRamSlots()
    {
        return ramSlots;
    }

    public List<GpuPart> GetGpuSlots()
    {
        return gpuSlots;
    }

    public List<DiskPart> GetDiskSlots()
    {
        return diskSlots;
    }

    public bool CheckPower()
    {
        double psuPower = powerSupply.Energy;

        double cpuPower = cpuSlots.Aggregate(0.0, (acc, cpu) => acc + cpu.Energy);
        double ramPower = ramSlots.Aggregate(0.0, (acc, ram) => acc + ram.Energy);
        double gpuPower = gpuSlots.Aggregate(0.0, (acc, gpu) => acc + gpu.Energy);
        double diskPower = diskSlots.Aggregate(0.0, (acc, disk) => acc + disk.Energy);

        return psuPower >= (cpuPower + ramPower + gpuPower + diskPower);
    }

    public bool CanMine()
    {
        // Check we have at least a CPU, a RAM and enough power
        return CheckPower() && motherBoard != null && cpuSlots.Count() != 0 && ramSlots.Count() != 0;
    }

    public double GetDollarsPerSec()
    {
        return GetDollarsPerSecFor(currentCurrency);
    }

    public double GetDollarsPerSecFor(Currency currency)
    {
        if (!CanMine()) return 0;

        double cpuPower = cpuSlots.Aggregate(0.0, (acc, obj) => acc + obj.CpuPower);
        double ramPower = ramSlots.Aggregate(0.0, (acc, obj) => acc + obj.CpuRam);
        double diskPower = diskSlots.Aggregate(0.0, (acc, obj) => acc + obj.DiskSize);
        double gpuPower = gpuSlots.Aggregate(0.0, (acc, obj) => acc + obj.CudaPower);

        cpuPower *= currency.cpuScore;
        ramPower *= currency.ramScore;
        diskPower *= currency.diskScore;
        gpuPower *= currency.gpuScore;

        return currency.USDRate * (cpuPower + ramPower + diskPower + gpuPower);
    }
}
