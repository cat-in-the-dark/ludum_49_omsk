using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PC
{
    public PowerSupplyPart powerSupply;

    private MotherBoardPart motherBoard;
    private List<CpuPart> cpuSlots = new List<CpuPart>();
    private List<RamPart> ramSlots = new List<RamPart>();
    private List<GpuPart> gpuSlots = new List<GpuPart>();
    private List<DiskPart> diskSlots = new List<DiskPart>();

    public PC(MotherBoardPart motherBoard, PowerSupplyPart powerSupply) {
        SetMotherboard(motherBoard);
        this.powerSupply = powerSupply;
    }

    public MotherBoardPart GetMotherBoard() {
        return motherBoard;
    }

    public void SetMotherboard(MotherBoardPart motherboard) {
        this.motherBoard = motherboard;

        cpuSlots = new List<CpuPart>(new CpuPart[motherBoard.CpuSlots]);
        ramSlots = new List<RamPart>(new RamPart[motherBoard.RamSlots]);
        gpuSlots = new List<GpuPart>(new GpuPart[motherBoard.GpuSlots]);
        diskSlots = new List<DiskPart>(new DiskPart[motherBoard.DiskSlots]);
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

    public double GetPower() {
        double cpuPower = cpuSlots.Aggregate(0.0, (acc, cpu) => acc + (cpu == null ? 0 : cpu.Energy));
        double ramPower = ramSlots.Aggregate(0.0, (acc, ram) => acc + (ram == null ? 0 : ram.Energy));
        double gpuPower = gpuSlots.Aggregate(0.0, (acc, gpu) => acc + (gpu == null ? 0 : gpu.Energy));
        double diskPower = diskSlots.Aggregate(0.0, (acc, disk) => acc + (disk == null ? 0 : disk.Energy));

        return cpuPower + ramPower + gpuPower + diskPower;
    }

    public double GetPrice() {
        double mbPrice = motherBoard.Price;
        double psuPrice = powerSupply.Price;

        double cpuPrice = cpuSlots.Aggregate(0.0, (acc, cpu) => acc + (cpu == null ? 0 : cpu.Price));
        double ramPrice = ramSlots.Aggregate(0.0, (acc, ram) => acc + (ram == null ? 0 : ram.Price));
        double gpuPrice = gpuSlots.Aggregate(0.0, (acc, gpu) => acc + (gpu == null ? 0 : gpu.Price));
        double diskPrice = diskSlots.Aggregate(0.0, (acc, disk) => acc + (disk == null ? 0 : disk.Price));

        return mbPrice + psuPrice + cpuPrice + ramPrice + gpuPrice + diskPrice;
    }

    public bool CheckPower()
    {
        double psuPower = powerSupply.Energy;

        return psuPower >= GetPower();
    }

    public bool CanMine()
    {
        // Check we have at least a CPU, a RAM and enough power
        return CheckPower() && motherBoard != null && cpuSlots.Count() != 0 && ramSlots.Count() != 0;
    }

    public double GetDollarsPerSecFor(Currency currency)
    {
        if (!CanMine()) return 0;

        double cpuPower = cpuSlots.Aggregate(0.0, (acc, obj) => acc + (obj == null ? 0 : obj.CpuPower));
        double ramPower = ramSlots.Aggregate(0.0, (acc, obj) => acc + (obj == null ? 0 : obj.CpuRam));
        double diskPower = diskSlots.Aggregate(0.0, (acc, obj) => acc + (obj == null ? 0 : obj.DiskSize));
        double gpuPower = gpuSlots.Aggregate(0.0, (acc, obj) => acc + (obj == null ? 0 : obj.CudaPower));

        cpuPower *= currency.cpuScore;
        ramPower *= currency.ramScore;
        diskPower *= currency.diskScore;
        gpuPower *= currency.gpuScore;

        return currency.USDRate * (cpuPower + ramPower + diskPower + gpuPower);
    }
}
