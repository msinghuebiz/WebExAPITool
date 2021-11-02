using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExAPITool.Intersight.Model;

namespace WebExAPITool.Models
{
    public class ServerList
    {
        public List<ServerDetails> Server { get; set; }
    }

    public class ServerDetails
    {
        public ComputeBlade Compute { get; set; }
        public List<InventoryGenericInventory>  Inventory { get; set; }
        public List<EquipmentChassis> Ancestors { get; set; }
        public List<AdapterUnit> AdapterUnits { get; set; }
        public List<BiosUnit> BiosUnits { get; set; }
        public List<ManagementController> ManagementControllers { get; set; }
        public List<ComputeBoardDetails> ComputeBoards { get; set; }
        public List<EquipmentLocatorLed> EquipmentLocatorLeds { get; set; }
        public List<AssetDeviceRegistration> AssetDeviceRegistrations { get; set; }
        public List<TopSystem> TopSystems { get; set; }
        
    }


    public class ComputeBoardDetails
    {
        public ComputeBoard ComputeBoardDet{ get; set; }
        public List<MemoryArray> MemoryArrays{ get; set; }
        public List<ProcessorUnit> ProcessorUnits { get; set; }
        public List<StorageController> StorageControllers { get; set; }
        public List<StorageFlexFlashController> StorageFlexFlashControllers { get; set; }
        
    }


}
