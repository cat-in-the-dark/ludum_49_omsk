using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public string PCName;
    public Currency currentCurrency;
    public MotherBoardPart motherBoard;
    public PowerSupplyPart powerSupply;

    private List<CpuPart> cpuSlots = new List<CpuPart>();
    private List<RamPart> ramSlots = new List<RamPart>();
    private List<GpuPart> gpuSlots = new List<GpuPart>();
    private List<DiskPart> diskSlots = new List<DiskPart>();

    public bool AddCpu(CpuPart cpuPart) {
        if (cpuSlots.Count < motherBoard.CpuSlots) {
            cpuSlots.Add(cpuPart);
            return true;
        }
        return false;
    }

    public bool AddRam(RamPart ramPart) {
        if (ramSlots.Count < motherBoard.RamSlots) {
            ramSlots.Add(ramPart);
            return true;
        }
        return false;
    }

    public bool AddGpu(GpuPart gpuPart) {
        if (gpuSlots.Count < motherBoard.GpuSlots) {
            gpuSlots.Add(gpuPart);
            return true;
        }
        return false;
    }

    public bool AddDisk(DiskPart diskPart) {
        if (diskSlots.Count < motherBoard.DiskSlots) {
            diskSlots.Add(diskPart);
            return true;
        }
        return false;
    }

    public void RemoveCpu(int index) {
        cpuSlots.RemoveAt(index);
    }

    public void RemoveRam(int index) {
        ramSlots.RemoveAt(index);
    }

    public void RemoveGpu(int index) {
        gpuSlots.RemoveAt(index);
    }

    public void RemoveDisk(int index) {
        diskSlots.RemoveAt(index);
    }

    public List<CpuPart> GetCpuSlots() {
        return cpuSlots;
    }

    public List<RamPart> GetRamSlots() {
        return ramSlots;
    }

    public List<GpuPart> GetGpuSlots() {
        return gpuSlots;
    }

    public List<DiskPart> GetDiskSlots() {
        return diskSlots;
    }

    public bool CheckPower() {
        double psuPower = powerSupply.Energy;

        double cpuPower = cpuSlots.Aggregate(0.0, (acc, cpu) => acc + cpu.Energy);
        double ramPower = ramSlots.Aggregate(0.0, (acc, ram) => acc + ram.Energy);
        double gpuPower = gpuSlots.Aggregate(0.0, (acc, gpu) => acc + gpu.Energy);
        double diskPower = diskSlots.Aggregate(0.0, (acc, disk) => acc + disk.Energy);

        return psuPower >= (cpuPower + ramPower + gpuPower + diskPower);
    }
}
