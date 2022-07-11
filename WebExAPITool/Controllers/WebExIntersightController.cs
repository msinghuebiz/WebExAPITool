using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebExAPITool.Intersight.Client;
using WebExAPITool.Intersight.Model;
using WebExAPITool.Models.DB;
using WebExAPITool.Models;
using System.Net.Mail;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
//using Avro.Generic;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using NuGet.Frameworks;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
//using WebExAPITool.Intersight.Api;
//using Confluent.SchemaRegistry.Serdes;
//using Confluent.SchemaRegistry;



namespace WebExAPITool.Controllers
{

    //    [Route("api/[controller]")]
    //    [ApiController]
    //    public class WebExIntersightController : ControllerBase
    //    {

    //        private readonly WebExDBContext _Context;
    //        public WebExIntersightController(WebExDBContext context)
    //        {
    //            _Context = context;
    //        }
    //    } 
    //}


    [Route("api/[controller]")]
    [ApiController]
    public class WebExIntersightController : ControllerBase
    {

        private readonly WebExDBContext _Context;
        private readonly IConfiguration _Config;
        private string _KafkaServer;
        private string _KafkaServer2;
        private string _OrgName;
        private string _OrgName2;
        private string _KafkaTopic;
        private string _KafkaTopic2;
        private string _ApiKey;
        private string _ApiKey2;
        private string _IntersightPath;
        private string _IntersightPath2;
        private string _emailSubject;
        private string _emailenable;
        private string _kafkaenable;
        private string _elasticenable;

        private DateTime lastAlarms;
        private readonly IHostingEnvironment _Host;

        public WebExIntersightController(WebExDBContext context, IConfiguration config, IHostingEnvironment host)
        {
            _Context = context;
            _Config = config;
            _OrgName = config.GetSection("KafkaSettings").GetValue<string>("OrgName1");
            _OrgName2 = config.GetSection("KafkaSettings").GetValue<string>("OrgName2");
            _KafkaServer = config.GetSection("KafkaSettings").GetValue<string>("ServerIP1");
            _KafkaServer2 = config.GetSection("KafkaSettings").GetValue<string>("ServerIP2");
            _KafkaTopic = config.GetSection("KafkaSettings").GetValue<string>("KafkaTopic1");
            _KafkaTopic2 = config.GetSection("KafkaSettings").GetValue<string>("KafkaTopic2");
            _IntersightPath = config.GetSection("IntersightSettings").GetValue<string>("path1");
            _IntersightPath2 = config.GetSection("IntersightSettings").GetValue<string>("path2");
            _ApiKey = config.GetSection("IntersightSettings").GetValue<string>("api_key1");
            _ApiKey2 = config.GetSection("IntersightSettings").GetValue<string>("api_key2");

           _Host = host;


        }
        private WebExAPITool.Intersight.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        public WebExAPITool.Intersight.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }


        [HttpGet]
        [Route("GetStatus")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> GetStatus()
        {
            var result = new HttpResponseMessage();
            result.StatusCode = System.Net.HttpStatusCode.OK;

            return result;
        }


        [HttpGet]
        [Route("GetServerDetailsSearch")]
        public async Task<List<ServerDetails>> GetServerDetailsSearch([FromBody]Dictionary<string, string> searchedItems)
        {
            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();
            //var paramAffected1 = new Dictionary<String, object>();
            //paramAffected1.Add("moid", "5d07acf86176752d305a7787");

          
            //var qparam = new Dictionary<string, object>();
            //qparam.Add("$skip", i);

            var argparam = new Dictionary<string, object>();
            foreach (var item in searchedItems)
            {
                argparam.Add(item.Key, item.Value);
            }

            var enteredName = argparam["Name"].ToString();

           // compute / physical - summaries / 5ddec4056176752d317daaee

                  //var serverOut1 = exeIntersight.ExecuteAPI<StoragePhysicalDiskUsage>("/storage/PhysicalDiskUsages/{moid}", paramAffected1, null).Result.Data;
                  //var aa = serverOut1;
                  var output = new List<ServerDetails>();
            var paramaaAffected = new Dictionary<String, object>();
            paramaaAffected.Add("moid", "5ddec4056176752d317daaee");
            var ww = exeIntersight.ExecuteAPI<ComputePhysicalSummary>("/compute/PhysicalSummaries/{moid}",_IntersightPath, _ApiKey, paramaaAffected);
            var serverOut1 = exeIntersight.ExecuteAPI<ComputeBladeList>("/compute/Blades", _IntersightPath, _ApiKey, null, null);


            var serverOut = exeIntersight.ExecuteAPI<ComputePhysicalSummary >("/compute/PhysicalSummaries/{moid}", _IntersightPath, _ApiKey, paramaaAffected).Result.Data;

            var aa = serverOut;
            var aaa = string.Empty;
             //foreach (var item in serverOut.Results.Where( r => r.UserLabel == argparam["Name"].ToString()))
             //   {

            //       var server = new ServerDetails();
            //       server.Compute = item;
            //       foreach (var itemInventory in item.GenericInventoryHolders)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemInventory.Moid);

            //           var inventoryOut = exeIntersight.ExecuteAPI<InventoryGenericInventory>("/inventory/GenericInventoryHolders/{moid}", paramAffected).Result.Data;
            //           server.Inventory = new List<InventoryGenericInventory>();
            //           server.Inventory.Add(inventoryOut);
            //       }

            //       foreach (var itemAncestor in item.Ancestors)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemAncestor.Moid);

            //           string url = GetCompiledIntersightURL(itemAncestor.ObjectType);

            //           var outputInner = exeIntersight.ExecuteAPI<EquipmentChassis>(url, paramAffected).Result.Data;
            //           server.Ancestors = new List<EquipmentChassis>();
            //           server.Ancestors.Add(outputInner);
            //       }

            //       foreach (var itemAdapter in item.Adapters)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemAdapter.Moid);

            //           string url = GetCompiledIntersightURL(itemAdapter.ObjectType);

            //           var outputInner = exeIntersight.ExecuteAPI<AdapterUnit>(url, paramAffected).Result.Data;
            //           server.AdapterUnits = new List<AdapterUnit>();
            //           server.AdapterUnits.Add(outputInner);
            //       }
            //       foreach (var itemBios in item.BiosUnits)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemBios.Moid);

            //           string url = GetCompiledIntersightURL(itemBios.ObjectType);

            //           var outputInner = exeIntersight.ExecuteAPI<BiosUnit>(url, paramAffected).Result.Data;
            //           server.BiosUnits = new List<BiosUnit>();
            //           server.BiosUnits.Add(outputInner);
            //       }


            //       var parambmc = new Dictionary<String, object>();
            //       parambmc.Add("moid", item.Bmc.Moid);

            //       string urlBMC = GetCompiledIntersightURL(item.Bmc.ObjectType);

            //       var outputInnerBMC = exeIntersight.ExecuteAPI<ManagementController>(urlBMC, parambmc).Result.Data;
            //       server.ManagementControllers = new List<ManagementController>();
            //       server.ManagementControllers.Add(outputInnerBMC);

            //       var paramboard = new Dictionary<String, object>();
            //       paramboard.Add("moid", item.Board.Moid);

            //       string urlboard = GetCompiledIntersightURL(item.Board.ObjectType);

            //       var outputInnerBoard = exeIntersight.ExecuteAPI<ComputeBoard>(urlboard, paramboard).Result.Data;
            //       var computeBoardDet = new ComputeBoardDetails();
            //       computeBoardDet.ComputeBoardDet = outputInnerBoard;

            //       foreach (var itemMemoryArray in outputInnerBoard.MemoryArrays)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemMemoryArray.Moid);

            //           string url = GetCompiledIntersightURL(itemMemoryArray.ObjectType);

            //           var outputInner = exeIntersight.ExecuteAPI<MemoryArray>(url, paramAffected).Result.Data;
            //           computeBoardDet.MemoryArrays = new List<MemoryArray>();
            //           computeBoardDet.MemoryArrays.Add(outputInner);
            //       }
            //       foreach (var itemProcessor in outputInnerBoard.Processors)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemProcessor.Moid);

            //           string url = GetCompiledIntersightURL(itemProcessor.ObjectType);

            //           var outputInner = exeIntersight.ExecuteAPI<ProcessorUnit>(url, paramAffected).Result.Data;
            //           computeBoardDet.ProcessorUnits = new List<ProcessorUnit>();
            //           computeBoardDet.ProcessorUnits.Add(outputInner);
            //       }

            //       foreach (var itemStorageCon in outputInnerBoard.StorageControllers)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemStorageCon.Moid);

            //           string url = GetCompiledIntersightURL(itemStorageCon.ObjectType);

            //           var outputInner = exeIntersight.ExecuteAPI<StorageController>(url, paramAffected).Result.Data;
            //           computeBoardDet.StorageControllers = new List<StorageController>();
            //           computeBoardDet.StorageControllers.Add(outputInner);




            //       }

            //       foreach (var itemStorageFlex in outputInnerBoard.StorageFlexFlashControllers)
            //       {
            //           var paramAffected = new Dictionary<String, object>();
            //           paramAffected.Add("moid", itemStorageFlex.Moid);

            //           string url = GetCompiledIntersightURL(itemStorageFlex.ObjectType);

            //           var outputInner = exeIntersight.ExecuteAPI<StorageFlexFlashController>(url, paramAffected).Result.Data;
            //           computeBoardDet.StorageFlexFlashControllers = new List<StorageFlexFlashController>();
            //           computeBoardDet.StorageFlexFlashControllers.Add(outputInner);
            //       }

            //       server.ComputeBoards = new List<ComputeBoardDetails>();

            //       server.ComputeBoards.Add(computeBoardDet);





            //       var paramLocatorLed = new Dictionary<String, object>();
            //       paramLocatorLed.Add("moid", item.LocatorLed.Moid);

            //       string urlLocatorLed = GetCompiledIntersightURL(item.LocatorLed.ObjectType);

            //       var outputInnerEquipmentLocatorLed = exeIntersight.ExecuteAPI<EquipmentLocatorLed>(urlLocatorLed, paramLocatorLed).Result.Data;
            //       server.EquipmentLocatorLeds = new List<EquipmentLocatorLed>();
            //       server.EquipmentLocatorLeds.Add(outputInnerEquipmentLocatorLed);

            //       var paramRegisteredDevice = new Dictionary<String, object>();
            //       paramRegisteredDevice.Add("moid", item.RegisteredDevice.Moid);

            //       string urlRegisteredDevice = GetCompiledIntersightURL(item.RegisteredDevice.ObjectType);

            //       var outputInnerRegisteredDevice = exeIntersight.ExecuteAPI<AssetDeviceRegistration>(urlRegisteredDevice, paramRegisteredDevice).Result.Data;
            //       server.AssetDeviceRegistrations = new List<AssetDeviceRegistration>();
            //       server.AssetDeviceRegistrations.Add(outputInnerRegisteredDevice);

            //       var paramTopSystem = new Dictionary<String, object>();
            //       paramTopSystem.Add("moid", item.TopSystem.Moid);

            //       string urlTopSystem = GetCompiledIntersightURL(item.TopSystem.ObjectType);

            //       var outputInnerTopSystem = exeIntersight.ExecuteAPI<TopSystem>(urlTopSystem, paramTopSystem).Result.Data;
            //       server.TopSystems = new List<TopSystem>();
            //       server.TopSystems.Add(outputInnerTopSystem);


            //       output.Add(server);
            //   }

            return output;
        }

        [HttpGet]
        [Route("GetServerDetails")]
        public async Task<List<ServerDetails>> GetServerDetails()
        {
            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();
            //var paramAffected1 = new Dictionary<String, object>();
            //paramAffected1.Add("moid", "5d07acf86176752d305a7787");

            //var serverOut1 = exeIntersight.ExecuteAPI<StoragePhysicalDiskUsage>("/storage/PhysicalDiskUsages/{moid}", paramAffected1, null).Result.Data;
            //var aa = serverOut1;
            var output = new List<ServerDetails>();

            for (int i = 0; i < 366; i += 100)
            {
                var param = new Dictionary<string, object>();
                param.Add("$skip", i);
                
                var serverOut = exeIntersight.ExecuteAPI<ComputeBladeList>("/compute/Blades", _IntersightPath, _ApiKey, null, param).Result.Data;
           
                foreach (var item in serverOut.Results)
                {

                    var server = new ServerDetails();
                    server.Compute = item;
                    foreach (var itemInventory in item.GenericInventoryHolders)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemInventory.Moid);

                        var inventoryOut = exeIntersight.ExecuteAPI<InventoryGenericInventory>("/inventory/GenericInventoryHolders/{moid}", _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        server.Inventory = new List<InventoryGenericInventory>();
                        server.Inventory.Add(inventoryOut);
                    }

                    foreach (var itemAncestor in item.Ancestors)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemAncestor.Moid);

                        string url = GetCompiledIntersightURL(itemAncestor.ObjectType);

                        var outputInner = exeIntersight.ExecuteAPI<EquipmentChassis>(url, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        server.Ancestors = new List<EquipmentChassis>();
                        server.Ancestors.Add(outputInner);
                    }

                    foreach (var itemAdapter in item.Adapters)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemAdapter.Moid);

                        string url = GetCompiledIntersightURL(itemAdapter.ObjectType);

                        var outputInner = exeIntersight.ExecuteAPI<AdapterUnit>(url, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        server.AdapterUnits = new List<AdapterUnit>();
                        server.AdapterUnits.Add(outputInner);
                    }
                    foreach (var itemBios in item.BiosUnits)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemBios.Moid);

                        string url = GetCompiledIntersightURL(itemBios.ObjectType);

                        var outputInner = exeIntersight.ExecuteAPI<BiosUnit>(url, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        server.BiosUnits = new List<BiosUnit>();
                        server.BiosUnits.Add(outputInner);
                    }


                    var parambmc = new Dictionary<String, object>();
                    parambmc.Add("moid", item.Bmc.Moid);

                    string urlBMC = GetCompiledIntersightURL(item.Bmc.ObjectType);

                    var outputInnerBMC = exeIntersight.ExecuteAPI<ManagementController>(urlBMC, _IntersightPath, _ApiKey, parambmc).Result.Data;
                    server.ManagementControllers = new List<ManagementController>();
                    server.ManagementControllers.Add(outputInnerBMC);

                    var paramboard = new Dictionary<String, object>();
                    paramboard.Add("moid", item.Board.Moid);

                    string urlboard = GetCompiledIntersightURL(item.Board.ObjectType);

                    var outputInnerBoard = exeIntersight.ExecuteAPI<ComputeBoard>(urlboard, _IntersightPath, _ApiKey, paramboard).Result.Data;
                    var computeBoardDet = new ComputeBoardDetails();
                    computeBoardDet.ComputeBoardDet = outputInnerBoard;

                    foreach (var itemMemoryArray in outputInnerBoard.MemoryArrays)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemMemoryArray.Moid);

                        string url = GetCompiledIntersightURL(itemMemoryArray.ObjectType);

                        var outputInner = exeIntersight.ExecuteAPI<MemoryArray>(url, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        computeBoardDet.MemoryArrays = new List<MemoryArray>();
                        computeBoardDet.MemoryArrays.Add(outputInner);
                    }
                    foreach (var itemProcessor in outputInnerBoard.Processors)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemProcessor.Moid);

                        string url = GetCompiledIntersightURL(itemProcessor.ObjectType);

                        var outputInner = exeIntersight.ExecuteAPI<ProcessorUnit>(url, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        computeBoardDet.ProcessorUnits = new List<ProcessorUnit>();
                        computeBoardDet.ProcessorUnits.Add(outputInner);
                    }

                    foreach (var itemStorageCon in outputInnerBoard.StorageControllers)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemStorageCon.Moid);

                        string url = GetCompiledIntersightURL(itemStorageCon.ObjectType);

                        var outputInner = exeIntersight.ExecuteAPI<StorageController>(url, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        computeBoardDet.StorageControllers = new List<StorageController>();
                        computeBoardDet.StorageControllers.Add(outputInner);




                    }

                    foreach (var itemStorageFlex in outputInnerBoard.StorageFlexFlashControllers)
                    {
                        var paramAffected = new Dictionary<String, object>();
                        paramAffected.Add("moid", itemStorageFlex.Moid);

                        string url = GetCompiledIntersightURL(itemStorageFlex.ObjectType);

                        var outputInner = exeIntersight.ExecuteAPI<StorageFlexFlashController>(url, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                        computeBoardDet.StorageFlexFlashControllers = new List<StorageFlexFlashController>();
                        computeBoardDet.StorageFlexFlashControllers.Add(outputInner);
                    }

                    server.ComputeBoards = new List<ComputeBoardDetails>();

                    server.ComputeBoards.Add(computeBoardDet);





                    var paramLocatorLed = new Dictionary<String, object>();
                    paramLocatorLed.Add("moid", item.LocatorLed.Moid);

                    string urlLocatorLed = GetCompiledIntersightURL(item.LocatorLed.ObjectType);

                    var outputInnerEquipmentLocatorLed = exeIntersight.ExecuteAPI<EquipmentLocatorLed>(urlLocatorLed, _IntersightPath, _ApiKey, paramLocatorLed).Result.Data;
                    server.EquipmentLocatorLeds = new List<EquipmentLocatorLed>();
                    server.EquipmentLocatorLeds.Add(outputInnerEquipmentLocatorLed);

                    var paramRegisteredDevice = new Dictionary<String, object>();
                    paramRegisteredDevice.Add("moid", item.RegisteredDevice.Moid);

                    string urlRegisteredDevice = GetCompiledIntersightURL(item.RegisteredDevice.ObjectType);

                    var outputInnerRegisteredDevice = exeIntersight.ExecuteAPI<AssetDeviceRegistration>(urlRegisteredDevice, _IntersightPath, _ApiKey, paramRegisteredDevice).Result.Data;
                    server.AssetDeviceRegistrations = new List<AssetDeviceRegistration>();
                    server.AssetDeviceRegistrations.Add(outputInnerRegisteredDevice);

                    var paramTopSystem = new Dictionary<String, object>();
                    paramTopSystem.Add("moid", item.TopSystem.Moid);

                    string urlTopSystem = GetCompiledIntersightURL(item.TopSystem.ObjectType);

                    var outputInnerTopSystem = exeIntersight.ExecuteAPI<TopSystem>(urlTopSystem, _IntersightPath, _ApiKey, paramTopSystem).Result.Data;
                    server.TopSystems = new List<TopSystem>();
                    server.TopSystems.Add(outputInnerTopSystem);


                    output.Add(server);
                }
            }
            return output;
        }

        private string GetCompiledIntersightURL( string type)
        {
            string outputvalue = string.Empty;

            switch (type)
            {
                case "equipment.Chassis":
                    outputvalue = "/equipment/Chasses/{moid}";
                       break;
                case "adapter.Unit":
                    outputvalue = "/adapter/Units/{moid}";
                    break;
                case "bios.Unit":
                    outputvalue = "/bios/Units/{moid}";
                    break;
                case "management.Controller":
                    outputvalue = "/management/Controllers/{moid}";
                    break;
                case "compute.Board":
                    outputvalue = "/compute/Boards/{moid}";
                    break;
                case "inventory.GenericInventoryHolder":
                    outputvalue = "/inventory/GenericInventoryHolders/{moid}";
                    break;
                case "equipment.LocatorLed":
                    outputvalue = "/equipment/LocatorLeds/{moid}";
                    break;
                case "asset.DeviceRegistration":
                    outputvalue = "/asset/DeviceRegistrations/{moid}";
                    break;
                case "top.System":
                    outputvalue = "/top/Systems/{moid}";
                    break;
                case "memory.Array":
                    outputvalue = "/memory/Arrays/{moid}";
                    break;
                case "processor.Unit":
                    outputvalue = "/processor/Units/{moid}";
                    break;
                case "storage.Controller":
                    outputvalue = "/storage/Controllers/{moid}";
                    break;
                case "storage.FlexFlashController":
                    outputvalue = "/storage/FlexFlashControllers/{moid}";
                    break;
                default:
                    break;
            }

        return outputvalue;
    }

        [HttpGet]
        [Route("GetLatestAlarms")]
        public async Task<IntersightModel> GetLatestAlarms()
        {
            var param = new Dictionary<string, object>();
            param.Add("$top", "1000");
            param.Add("$orderby", "ModTime DESC");

            var result = new IntersightModel();
            result.AffectedListDetails = new Dictionary<string, Dictionary<string, string>>();
            result.AncestorListDetails = new Dictionary<string, Dictionary<string, string>>();
            result.ParentListDetails = new Dictionary<string, Dictionary<string, string>>();

            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();
                      
            var output = exeIntersight.ExecuteAPI<CondAlarmList>("/cond/Alarms", _IntersightPath, _ApiKey, null, param).Result.Data;

            foreach (var item in output.Results.ToList())
            {

                //var affectedValue = string.Empty;
                var affectedValue = await GetItemDetails(item.AffectedMoType, item.AffectedMoId, _IntersightPath, _ApiKey);
                var ancestorValue = await GetItemDetails(item.AncestorMoType, item.AncestorMoId, _IntersightPath, _ApiKey);
                var parentValue = string.Empty;
                //if (item.Parent != null )
                //{
                //   parentValue = await GetItemDetails(item.Parent.ObjectType, item.Parent.Moid);
                //}

                result.AffectedListDetails.Add(item.Moid, affectedValue);
                result.AncestorListDetails.Add(item.Moid, ancestorValue);
              //  result.ParentListDetails.Add(item.Moid, parentValue);
            }
            //// compile the string for the items 
            //foreach (var item in output.Results.Where(r => r.Severity != "Cleared").OrderByDescending(r => r.ModTime).ToList())
            //{

            //    // check when the current is critical or info 

            //    // get the compiled JSON 
            //    var ancesstorObject = result.AncestorListDetails[item.Moid];
            //    var ancesstorserial = string.Empty;
            //    var ancesstormodel = string.Empty;
            //    if (ancesstorObject.Count != 0)
            //    {
            //        ancesstorserial = ancesstorObject["Serial"];
            //        ancesstormodel = ancesstorObject["Model"];
            //    }
            //    var affectedObject = result.AffectedListDetails[item.Moid];
            //    var affectedserial = string.Empty;
            //    var affectedmodel = string.Empty;
            //    if (affectedObject.Count != 0)
            //    {
            //        affectedserial = affectedObject["Serial"];
            //        affectedmodel = affectedObject["Model"];
            //    }
            //    var outputJson = await CompileJSON(item, affectedserial, affectedmodel, ancesstorserial, ancesstormodel, "uebiz");

            //    // Set the data to kafka 
            //   SendDataToKafka(outputJson, _KafkaServer , _KafkaTopic );

            //}


            result.AlarmList = output;


            return result;
        }

        [HttpGet]
        [Route("GetLatestKey2Alarms")]
        public async Task<IntersightModel> GetLatestKey2Alarms()
        {
            var param = new Dictionary<string, object>();
            param.Add("$top", "1000");
            param.Add("$orderby", "ModTime DESC");

            var result = new IntersightModel();
            result.AffectedListDetails = new Dictionary<string, Dictionary<string, string>>();
            result.AncestorListDetails = new Dictionary<string, Dictionary<string, string>>();
            result.ParentListDetails = new Dictionary<string, Dictionary<string, string>>();

            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();

            var output = exeIntersight.ExecuteAPI<CondAlarmList>("/cond/Alarms", _IntersightPath2, _ApiKey2, null, param).Result.Data;

            foreach (var item in output.Results.ToList())
            {

                //var affectedValue = string.Empty;
                var affectedValue = await GetItemDetails(item.AffectedMoType, item.AffectedMoId, _IntersightPath2, _ApiKey2);
                var ancestorValue = await GetItemDetails(item.AncestorMoType, item.AncestorMoId, _IntersightPath2, _ApiKey2);
                var parentValue = string.Empty;
                //if (item.Parent != null )
                //{
                //   parentValue = await GetItemDetails(item.Parent.ObjectType, item.Parent.Moid);
                //}

                result.AffectedListDetails.Add(item.Moid, affectedValue);
                result.AncestorListDetails.Add(item.Moid, ancestorValue);
               // result.ParentListDetails.Add(item.Moid, parentValue);
            }
            //// compile the string for the items 
            //foreach (var item in output.Results.Where(r => r.Severity != "Cleared").OrderByDescending(r => r.ModTime).ToList())
            //{

            //    // check when the current is critical or info 

            //    // get the compiled JSON 
            //    var ancesstorObject = result.AncestorListDetails[item.Moid];
            //    var ancesstorserial = string.Empty;
            //    var ancesstormodel = string.Empty;
            //    if (ancesstorObject.Count != 0)
            //    {
            //        ancesstorserial = ancesstorObject["Serial"];
            //        ancesstormodel = ancesstorObject["Model"];
            //    }
            //    var affectedObject = result.AffectedListDetails[item.Moid];
            //    var affectedserial = string.Empty;
            //    var affectedmodel = string.Empty;
            //    if (affectedObject.Count != 0)
            //    {
            //        affectedserial = affectedObject["Serial"];
            //        affectedmodel = affectedObject["Model"];
            //    }
            //    var outputJson = await CompileJSON(item, affectedserial, affectedmodel, ancesstorserial, ancesstormodel, "Jefferies-Linux");


            //    // Set the data to kafka 
            //    SendDataToKafka(outputJson, _KafkaServer2 ,_KafkaTopic2);

            //}

            result.AlarmList = output;

            return result;
        }

        [HttpGet]
        [Route("SendLatestAlarm")]
        public async Task<int?> SendLatestAlarm()
        {
            var param = new Dictionary<string, object>();
            param.Add("$top", "1000");
            param.Add("$orderby", "ModTime DESC");

           
            var result = new IntersightModel();
            result.AffectedListDetails = new Dictionary<string, Dictionary<string, string>>();
            result.AncestorListDetails = new Dictionary<string, Dictionary<string, string>>();
            result.ParentListDetails = new Dictionary<string, Dictionary<string, string>>();

            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();

            var output = exeIntersight.ExecuteAPI<CondAlarmList>("/cond/Alarms", _IntersightPath, _ApiKey, null, param).Result.Data;

            foreach (var item in output.Results.ToList())
            {

                //var affectedValue = string.Empty;
                var affectedValue = await GetItemDetails(item.AffectedMoType, item.AffectedMoId, _IntersightPath2, _ApiKey2);
                var ancestorValue = await GetItemDetails(item.AncestorMoType, item.AncestorMoId, _IntersightPath2, _ApiKey2);
                var parentValue = string.Empty;
                //if (item.Parent != null )
                //{
                //   parentValue = await GetItemDetails(item.Parent.ObjectType, item.Parent.Moid);
                //}

                result.AffectedListDetails.Add(item.Moid, affectedValue);
                result.AncestorListDetails.Add(item.Moid, ancestorValue);
                // result.ParentListDetails.Add(item.Moid, parentValue);
            }
            // compile the string for the items 
            foreach (var item in output.Results.Where(r => r.Severity != "Cleared").OrderByDescending(r => r.ModTime).ToList())
            {

                // check when the current is critical or info 

                // get the compiled JSON 
                var ancesstorObject = result.AncestorListDetails[item.Moid];
                var ancesstorserial = string.Empty;
                var ancesstormodel = string.Empty;
                var ancesstorhost = string.Empty;
                var ancesstoripaddress = string.Empty;
                var ancesstorUserLabel = string.Empty;
                var ancesstorServiceProfile = string.Empty;
                if (ancesstorObject.Count != 0)
                {
                    if (ancesstorObject.ContainsKey("Serial"))
                    {
                        ancesstorserial = ancesstorObject["Serial"];
                    }
                    if (ancesstorObject.ContainsKey("Model"))
                    {
                        ancesstormodel = ancesstorObject["Model"];
                    }
                    if (ancesstorObject.ContainsKey("Host"))
                    {
                        ancesstorhost = ancesstorObject["Host"];
                    }
                    if (ancesstorObject.ContainsKey("IPAddress"))
                    {
                        ancesstoripaddress = ancesstorObject["IPAddress"];
                    }
                    if (ancesstorObject.ContainsKey("UserLabel"))
                    {
                        ancesstorUserLabel = ancesstorObject["UserLabel"];
                    }
                    if (ancesstorObject.ContainsKey("ServiceProfile"))
                    {
                        ancesstorServiceProfile = ancesstorObject["ServiceProfile"];
                    }
                }
                var affectedObject = result.AffectedListDetails[item.Moid];
                var affectedserial = string.Empty;
                var affectedmodel = string.Empty;
                var affectedhost = string.Empty;
                var affectedipaddress = string.Empty;
                var affectedUserLabel = string.Empty;
                var affectedServiceProfile = string.Empty;
                if (affectedObject.Count != 0)
                {
                    if (affectedObject.ContainsKey("Serial"))
                    {
                        affectedserial = affectedObject["Serial"];
                    }
                    if (affectedObject.ContainsKey("Model"))
                    {
                        affectedmodel = affectedObject["Model"];
                    }
                    if (affectedObject.ContainsKey("Host"))
                    {
                        affectedhost = affectedObject["Host"];
                    }
                    if (affectedObject.ContainsKey("IPAddress"))
                    {
                        affectedipaddress = affectedObject["IPAddress"];
                    }
                    if (ancesstorObject.ContainsKey("UserLabel"))
                    {
                        affectedUserLabel = ancesstorObject["UserLabel"];
                    }
                    if (ancesstorObject.ContainsKey("ServiceProfile"))
                    {
                        affectedServiceProfile = ancesstorObject["ServiceProfile"];
                    }
                }
                var outputJson = await CompileJSON(item, affectedserial, affectedmodel, affectedhost, affectedipaddress, ancesstorserial, ancesstormodel, ancesstorhost, ancesstoripaddress, _OrgName, affectedUserLabel, affectedServiceProfile, ancesstorUserLabel, ancesstorServiceProfile);


                // Set the data to kafka 
                SendDataToKafka(outputJson, _KafkaServer, _KafkaTopic);

            }

            result.AlarmList = output;

            return result.AlarmList.Results.Count;
        }

        [HttpGet]
        [Route("TestKafkaComm")]
        public async Task<int> TestKafkaComm(string message , string server , string topic)
        {
            try
            
            {
                // Set the data to kafka 
               var result =  await SendDataToKafka1(message, server, topic);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "Exception method - SendDataToKafka with message : " + ex.Message + "\r\n");
                System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
                System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
                return 0;
            }

            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "Ended method - SendLatestAlarmJef\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
            return 1;
        }

        [HttpGet]
        [Route("SendLatestAlarmJef")]
        public async Task<int?> SendLatestAlarmJef()
        {
               
            var filePath = _Config.GetSection("EmailSettings").GetValue<string>("filePath");
            var testApi = _Config.GetSection("EmailSettings").GetValue<string>("testApi");
            try
            {
                _emailSubject = _Config.GetSection("EmailSettings").GetValue<string>("subject");
                _emailenable = _Config.GetSection("EmailSettings").GetValue<string>("enable");
                _kafkaenable = _Config.GetSection("EmailSettings").GetValue<string>("kafkaenable");
                _elasticenable = _Config.GetSection("ElasticSettings").GetValue<string>("enable");

                filePath = filePath.Replace("{{current_date}}", DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year);

                var param = new Dictionary<string, object>();
                param.Add("$top", "1000");
                param.Add("$orderby", "ModTime DESC");

                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                System.IO.File.AppendAllText(filePath, "Started method - SendLatestAlarmJef\r\n");
                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                System.IO.File.AppendAllText(filePath, "Started Date time  - " + DateTime.Now.ToString() + "\r\n"); 


                // Get the start and end variables 
                var startVariable = _Config.GetSection("KafkaSettings").GetValue<string>("Start");
                var endVariable = _Config.GetSection("KafkaSettings").GetValue<string>("End");
                int startnumber = Int32.Parse(startVariable);
                int endnumber = Int32.Parse(endVariable);

                var triggerRow = _Context.WebExTrigger.FirstOrDefault();
                DateTime? universalDate = null;
                if (triggerRow != null)
                {
                    if (triggerRow.LastRunDateTime != null)
                    {
                        universalDate = triggerRow.LastRunDateTime.Value.ToUniversalTime();
                        if (testApi == "1")
                        {
                            universalDate = universalDate.Value.AddDays(-1);
                        }
                    }

                    //triggerRow.LastRunDateTime = DateTime.Now;
                    //_Context.SaveChanges();
                }

                for (int i = startnumber; i <= endnumber; i++)
                {
                    var orgName = _Config.GetSection("KafkaSettings").GetValue<string>("OrgName" + i.ToString());
                    var kafkaServer = _Config.GetSection("KafkaSettings").GetValue<string>("ServerIP" + i.ToString());
                    var kafkaTopic = _Config.GetSection("KafkaSettings").GetValue<string>("KafkaTopic" + i.ToString());
                    var intersightPath = _Config.GetSection("IntersightSettings").GetValue<string>("path" + i.ToString());
                    var apiKey = _Config.GetSection("IntersightSettings").GetValue<string>("api_key" + i.ToString());

                    var result = new IntersightModel();
                    result.AffectedListDetails = new Dictionary<string, Dictionary<string, string>>();
                    result.AncestorListDetails = new Dictionary<string, Dictionary<string, string>>();
                    result.ParentListDetails = new Dictionary<string, Dictionary<string, string>>();

                    var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();

                    var output = exeIntersight.ExecuteAPI<CondAlarmList>("/cond/Alarms", intersightPath, apiKey, null, param).Result.Data;

                    var loopOutput = output;
                    if (universalDate != null)
                    {
                        loopOutput.Results = output.Results.Where(r => r.ModTime.Value.ToUniversalTime()  > universalDate).ToList();
                    }

                    System.IO.File.AppendAllText(filePath, "organization Name  - " + orgName + " and total rows - " + loopOutput.Results.Where(r => r.Severity != "Cleared").OrderByDescending(r => r.ModTime).ToList().Count.ToString() + "\r\n");


                    foreach (var item in loopOutput.Results.Where(r => r.Severity != "Cleared").OrderByDescending(r => r.ModTime).ToList())
                    {

                        //var affectedValue = string.Empty;
                        var affectedValue = await GetItemDetails(item.AffectedMoType, item.AffectedMoId, intersightPath, apiKey);
                        var ancestorValue = await GetItemDetails(item.AncestorMoType, item.AncestorMoId, intersightPath, apiKey);
                        var parentValue = string.Empty;
                        //if (item.Parent != null )
                        //{
                        //   parentValue = await GetItemDetails(item.Parent.ObjectType, item.Parent.Moid);
                        //}

                        result.AffectedListDetails.Add(item.Moid, affectedValue);
                        result.AncestorListDetails.Add(item.Moid, ancestorValue);
                        // result.ParentListDetails.Add(item.Moid, parentValue);
                    }
                    // compile the string for the items 
                    foreach (var item in loopOutput.Results.Where(r => r.Severity != "Cleared").OrderByDescending(r => r.ModTime).ToList())
                    {

                        // check when the current is critical or info 

                        // get the compiled JSON 
                        var ancesstorObject = result.AncestorListDetails[item.Moid];
                        var ancesstorserial = string.Empty;
                        var ancesstormodel = string.Empty;
                        var ancesstorhost = string.Empty;
                        var ancesstoripaddress = string.Empty;
                        var ancesstorUserLabel = string.Empty;
                        var ancesstorServiceProfile = string.Empty;
                        if (ancesstorObject.Count != 0)
                        {
                            if (ancesstorObject.ContainsKey("Serial"))
                            {
                                ancesstorserial = ancesstorObject["Serial"];
                            }
                            if (ancesstorObject.ContainsKey("Model"))
                            {
                                ancesstormodel = ancesstorObject["Model"];
                            }
                            if (ancesstorObject.ContainsKey("Host"))
                            {
                                ancesstorhost = ancesstorObject["Host"];
                            }
                            if (ancesstorObject.ContainsKey("IPAddress"))
                            {
                                ancesstoripaddress = ancesstorObject["IPAddress"];
                            }
                            if (ancesstorObject.ContainsKey("UserLabel"))
                            {
                                ancesstorUserLabel = ancesstorObject["UserLabel"];
                            }
                            if (ancesstorObject.ContainsKey("ServiceProfile"))
                            {
                                ancesstorServiceProfile = ancesstorObject["ServiceProfile"];
                            }
                        }
                        var affectedObject = result.AffectedListDetails[item.Moid];
                        var affectedserial = string.Empty;
                        var affectedmodel = string.Empty;
                        var affectedhost = string.Empty;
                        var affectedipaddress = string.Empty;
                        var affectedUserLabel = string.Empty;
                        var affectedServiceProfile = string.Empty;
                        if (affectedObject.Count != 0)
                        {
                            if (affectedObject.ContainsKey("Serial"))
                            {
                                affectedserial = affectedObject["Serial"];
                            }
                            if (affectedObject.ContainsKey("Model"))
                            {
                                affectedmodel = affectedObject["Model"];
                            }
                            if (affectedObject.ContainsKey("Host"))
                            {
                                affectedhost = affectedObject["Host"];
                            }
                            if (affectedObject.ContainsKey("IPAddress"))
                            {
                                affectedipaddress = affectedObject["IPAddress"];
                            }
                            if (ancesstorObject.ContainsKey("UserLabel"))
                            {
                                affectedUserLabel = ancesstorObject["UserLabel"];
                            }
                            if (ancesstorObject.ContainsKey("ServiceProfile"))
                            {
                                affectedServiceProfile = ancesstorObject["ServiceProfile"];
                            }
                        }
                        var outputJson = await CompileJSON(item, affectedserial, affectedmodel, affectedhost, affectedipaddress, ancesstorserial, ancesstormodel, ancesstorhost, ancesstoripaddress, orgName, affectedUserLabel, affectedServiceProfile, ancesstorUserLabel, ancesstorServiceProfile);
                        var outputModel = await CompileKafkaStructure(item, affectedserial, affectedmodel, affectedhost, affectedipaddress, ancesstorserial, ancesstormodel, ancesstorhost, ancesstoripaddress, orgName, affectedUserLabel, affectedServiceProfile, ancesstorUserLabel, ancesstorServiceProfile);

                        try
                        {
                            if (_kafkaenable == "1")
                            {
                                // Set the data to kafka 
                                //SendDataToKafka(outputJson, kafkaServer, kafkaTopic);
                                var resultkafka = await SendDataToKafka1(outputJson, kafkaServer, kafkaTopic);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.IO.File.AppendAllText(filePath, "Exception method - SendDataToKafka with message : " + ex.Message + "\r\n");
                            System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                            System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                            return 0;
                        }

                        try
                        {
                            if (_elasticenable == "1")
                            {
                                // Set the data to kafka 
                                var objElastic = new Elastic(_Context, _Config);
                                var resultelastic = await objElastic.SendDataToelastic(outputModel, kafkaTopic);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.IO.File.AppendAllText(filePath, "Exception method - SendLatestAlarmJef while sending to elastic with message : " + ex.Message + "\r\n");
                            System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                            System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                            return 0;
                        }

                        try
                        {
                            // check when email is enabled 
                            if (_emailenable == "1")
                            {
                                var objModelEmail = new EmailModel();
                                string emailBody = objModelEmail.GetEmailBodyTemplate(_Host.ContentRootPath);
                                var dicEmailvariables = objModelEmail.GetCompiledDictionary(outputModel);
                                var dicEmailSubject = objModelEmail.GetCompiledSubjectDictionary(outputModel);
                                foreach (var itemPlaceholder in dicEmailvariables)
                                {
                                    emailBody = objModelEmail.ReplacePlaceholder(emailBody, "{{" + itemPlaceholder.Key + "}}", itemPlaceholder.Value);
                                }

                                var emailSubject = _emailSubject;
                                foreach (var itemSubjectPlaceholder in dicEmailSubject)
                                {
                                    emailSubject = objModelEmail.ReplacePlaceholder(emailSubject, "{{" + itemSubjectPlaceholder.Key + "}}", itemSubjectPlaceholder.Value);
                                }
                                var objEmails = new Emails(_Context, _Config);
                                objEmails.SendEmail(emailBody, emailSubject.Trim(), outputModel.payload.org_name );
                            }
                        }
                        catch (Exception ex )
                        {
                            System.IO.File.AppendAllText(filePath, "Exception method - SendLatestAlarmJef while sending email  with message : " + ex.Message + "\r\n");
                            System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                            System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                            // return 0;
                        }


                    }
                    System.IO.File.AppendAllText(filePath, "organization Name  - " + orgName + " and kafkaServer - " + kafkaServer + " and kafkaTopic - " + kafkaTopic + "\r\n");

                    result.AlarmList = loopOutput;
                }

                if (triggerRow != null)
                {
                    triggerRow.LastRunDateTime = DateTime.Now;
                    _Context.SaveChanges();
                }
                System.IO.File.AppendAllText(filePath, "Ended method - SendLatestAlarmJef\r\n");
                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                return 1;
            }
            catch ( Exception ex)
            {
                System.IO.File.AppendAllText(filePath, "Exception method - SendLatestAlarmJef with message : " + ex.Message + "\r\n");
                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                System.IO.File.AppendAllText(filePath, "*************************************\r\n");
                return 0;
            }
        }

        private async Task<DeliveryResult<Null,string>> SendDataToKafka1(string json, string kafkaServer, string kafkaTopic)
        {
            var result = new DeliveryResult<Null, string>();

            if (!(string.IsNullOrEmpty(kafkaServer)))
            {
                var conf = new ProducerConfig { BootstrapServers = kafkaServer };

                //p.Produce(kafkaTopic, new Message<Null, string> { Value = json }, handler);



                //Action<DeliveryReport<Null, string>> handler = r =>
                //    ShowKafkaMessage(r.Error.IsError, r.TopicPartitionOffset, r.Error.Reason);
                //    //Console.WriteLine(!r.Error.IsError
                //    //    ? $"Delivered message to {r.TopicPartitionOffset}"
                //    //    : $"Delivery Error: {r.Error.Reason}");

                using (var p = new ProducerBuilder<Null, string>(conf).Build())
                {
                    try
                    {

                        //p.Produce(kafkaTopic, new Message<Null, string> { Value = json }, handler);
                        result = await p.ProduceAsync(kafkaTopic, new Message<Null, string> { Value = json });

                        // wait for up to 10 seconds for any inflight messages to be delivered.
                       // p.Flush(TimeSpan.FromSeconds(10));
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        throw e;
                        
                    }
                }

            }
            return result;

        }

        private async void SendDataToKafka(string json, string kafkaServer, string kafkaTopic)
        {
            if (!(string.IsNullOrEmpty(kafkaServer)))
            {
                var conf = new ProducerConfig { BootstrapServers = kafkaServer };

                //Action<DeliveryReport<Null, string>> handler = r =>
                //    ShowKafkaMessage(r.Error.IsError, r.TopicPartitionOffset, r.Error.Reason);
                //    //Console.WriteLine(!r.Error.IsError
                //    //    ? $"Delivered message to {r.TopicPartitionOffset}"
                //    //    : $"Delivery Error: {r.Error.Reason}");

                using (var p = new ProducerBuilder<Null, string>(conf).Build())
                {
                    try
                    {

                        //p.Produce(kafkaTopic, new Message<Null, string> { Value = json }, handler);
                        var message = await p.ProduceAsync(kafkaTopic, new Message<Null, string> { Value = json });

                        // wait for up to 10 seconds for any inflight messages to be delivered.
                        p.Flush(TimeSpan.FromSeconds(10));
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        throw e;
                    }
                }
            }
        }
        public static void handler(DeliveryReport<Null, string> report )
        {

            string errormessage = report.TopicPartitionOffset.Topic;
            if (report.Error.IsError)
            {
               errormessage = report.Error.Reason;
            }
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "Started method - handler\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", errormessage + "\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "Ended method - handler\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
        }
        private void ShowKafkaMessage(bool IsError, TopicPartitionOffset  topicPartitionOffset, string reason)
        {
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "Ended method - SendLatestAlarmJef\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
            System.IO.File.AppendAllText("C:\\Log\\webApi.txt", "*************************************\r\n");
        }

        private async Task<KafkaStructure> CompileKafkaStructure(Intersight.Model.CondAlarm intersightResult, string affectedSerial, string affectedModel, string affectedhost, string affectedipaddress, string ancesstorSerial, string ancesstorModel, string ancesstorHost, string ancesstoripaddress, string orgName, string affectedUserLabel, string affectedServiceProfile, string ancesstorUserLabel, string ancesstorServiceProfile)
        {

            var model = new KafkaStructure();
            model.schema = new Schema();
            model.schema.fields = new List<IFields>();
            model.schema.fields.Add(GetFieldItem("measurement", false.ToString()));
            model.schema.fields.Add(GetFieldItem("name", false.ToString()));
            model.schema.fields.Add(GetFieldItem("descr", false.ToString()));
            model.schema.fields.Add(GetFieldItem("sev", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_obj", false.ToString()));
            model.schema.fields.Add(GetFieldItem("ancestor_obj", false.ToString()));
            model.schema.fields.Add(GetFieldItem("creation_time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("create_time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("modified_time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("last_transition_time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("creation_date_time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("last_tr_date_time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("mod_date_time", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_model", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_serial", false.ToString()));
            model.schema.fields.Add(GetFieldItem("ancestor_model", false.ToString()));
            model.schema.fields.Add(GetFieldItem("ancestor_serial", false.ToString()));
            model.schema.fields.Add(GetFieldItem("ancestor_userlabel", false.ToString()));
            model.schema.fields.Add(GetFieldItem("ancestor_serviceprofile", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_host", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_ipaddress", false.ToString()));
            model.schema.fields.Add(GetFieldItem("ancestor_host", false.ToString()));
            model.schema.fields.Add(GetFieldItem("ancestor_ipaddress", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_userlabel", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_serviceprofile", false.ToString()));
            model.schema.fields.Add(GetFieldItem("org_name", false.ToString()));
            model.schema.fields.Add(GetFieldMapItem("tags", true.ToString()));


            model.payload = new Payload();
            model.payload.tags = new Tags();
            model.payload.tags.affected_obj_tag = intersightResult.MsAffectedObject;
            model.payload.tags.affected_model_tag = affectedModel;
            model.payload.tags.affected_serial_tag = affectedSerial;
            model.payload.tags.affected_host_tag = affectedhost;
            model.payload.tags.affected_ipaddress_tag = affectedipaddress;
            model.payload.tags.affected_userlabel_tag = affectedUserLabel;
            model.payload.tags.affected_serviceprofile_tag = affectedServiceProfile;

            model.payload.tags.ancestor_obj_tag = intersightResult.AncestorMoType;
            model.payload.tags.ancestor_model_tag = ancesstorModel;
            model.payload.tags.ancestor_serial_tag = ancesstorSerial;
            model.payload.tags.ancestor_host_tag = ancesstorHost;
            model.payload.tags.ancestor_ipaddress_tag = ancesstoripaddress;
            model.payload.tags.ancestor_userlabel_tag = ancesstorUserLabel;
            model.payload.tags.ancestor_serviceprofile_tag = ancesstorServiceProfile;

            model.payload.tags.descr_tag = intersightResult.Description;
            model.payload.tags.name_tag = intersightResult.Name;
            model.payload.tags.sev_tag = intersightResult.Severity;
            model.payload.tags.org_name_tag = orgName;

            model.payload.affected_obj = intersightResult.MsAffectedObject;
            model.payload.affected_model = affectedModel;
            model.payload.affected_serial = affectedSerial;
            model.payload.affected_host = affectedhost;
            model.payload.affected_ipaddress = affectedipaddress;
            model.payload.affected_userlabel = affectedUserLabel;
            model.payload.affected_serviceprofile = affectedServiceProfile;

            model.payload.ancestor_obj = intersightResult.AncestorMoType;
            model.payload.ancestor_model = ancesstorModel;
            model.payload.ancestor_serial = ancesstorSerial;
            model.payload.ancestor_host = ancesstorHost;
            model.payload.ancestor_ipaddress = ancesstoripaddress;
            model.payload.ancestor_userlabel = ancesstorUserLabel;
            model.payload.ancestor_serviceprofile = ancesstorServiceProfile;

            model.payload.descr = intersightResult.Description;
            model.payload.create_time = intersightResult.CreateTime.Value.ToLongDateString() + " " + intersightResult.CreateTime.Value.ToLongTimeString();
            //model.payload.creation_time = intersightResult.CreationTime.Value.ToUniversalTime().ToLongDateString() + " " + intersightResult.CreationTime.Value.ToUniversalTime().ToLongTimeString();
            model.payload.creation_time = intersightResult.CreationTime.Value.ToUniversalTime();
            model.payload.last_transition_time = intersightResult.LastTransitionTime.Value.ToLongDateString() + " " + intersightResult.LastTransitionTime.Value.ToLongTimeString();
            //model.payload.modified_time = intersightResult.ModTime.Value.ToLongDateString() + " " + intersightResult.ModTime.Value.ToLongTimeString();
            model.payload.modified_time = intersightResult.ModTime.Value.ToUniversalTime();
            //model.payload.time = ((DateTimeOffset)intersightResult.CreateTime.Value).ToUnixTimeSeconds().ToString();
            var convertedCreationTime = intersightResult.CreationTime.Value.ToUniversalTime();
            var timeZoneInfoZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var timexoneESTCreationTime = TimeZoneInfo.ConvertTimeFromUtc(convertedCreationTime, timeZoneInfoZone);
            model.payload.creation_date_time = timexoneESTCreationTime.ToLongDateString() + " " + timexoneESTCreationTime.ToLongTimeString();
            //model.payload.last_tr_date_time = ((DateTimeOffset)intersightResult.LastTransitionTime.Value).ToUnixTimeSeconds().ToString();
            var convertedModTimeTime = intersightResult.ModTime.Value.ToUniversalTime();
            var timexoneESTModTimeTime = TimeZoneInfo.ConvertTimeFromUtc(convertedModTimeTime, timeZoneInfoZone);

            model.payload.mod_date_time = timexoneESTModTimeTime.ToLongDateString() + " " + timexoneESTModTimeTime.ToLongTimeString();

            model.payload.name = intersightResult.Name;
            model.payload.org_name = orgName;
            model.payload.sev = intersightResult.Severity;

            return model;

        }


        private async Task<string>  CompileJSON(Intersight.Model.CondAlarm intersightResult, string affectedSerial, string affectedModel, string affectedhost , string affectedipaddress, string ancesstorSerial, string ancesstorModel, string ancesstorHost, string ancesstoripaddress, string orgName, string affectedUserLabel, string affectedServiceProfile, string ancesstorUserLabel, string ancesstorServiceProfile)
        {
          
                var model = new KafkaStructure();
                model.schema = new Schema();
                model.schema.fields = new List<IFields>();
                model.schema.fields.Add(GetFieldItem("measurement", false.ToString()));
                model.schema.fields.Add(GetFieldItem("name", false.ToString()));
                model.schema.fields.Add(GetFieldItem("descr", false.ToString()));
                model.schema.fields.Add(GetFieldItem("sev", false.ToString()));
                model.schema.fields.Add(GetFieldItem("affected_obj", false.ToString()));
                model.schema.fields.Add(GetFieldItem("ancestor_obj", false.ToString()));
                model.schema.fields.Add(GetFieldItem("creation_time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("create_time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("modified_time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("last_transition_time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("creation_date_time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("last_tr_date_time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("mod_date_time", false.ToString()));
                model.schema.fields.Add(GetFieldItem("affected_model", false.ToString()));
                model.schema.fields.Add(GetFieldItem("affected_serial", false.ToString()));
                model.schema.fields.Add(GetFieldItem("ancestor_model", false.ToString()));
                model.schema.fields.Add(GetFieldItem("ancestor_serial", false.ToString()));
                model.schema.fields.Add(GetFieldItem("ancestor_userlabel", false.ToString()));
                model.schema.fields.Add(GetFieldItem("ancestor_serviceprofile", false.ToString()));
                model.schema.fields.Add(GetFieldItem("affected_host", false.ToString()));
                model.schema.fields.Add(GetFieldItem("affected_ipaddress", false.ToString()));
                model.schema.fields.Add(GetFieldItem("ancestor_host", false.ToString()));
                model.schema.fields.Add(GetFieldItem("ancestor_ipaddress", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_userlabel", false.ToString()));
            model.schema.fields.Add(GetFieldItem("affected_serviceprofile", false.ToString()));
            model.schema.fields.Add(GetFieldItem("org_name", false.ToString()));
                model.schema.fields.Add(GetFieldMapItem("tags", true.ToString()));


                model.payload = new Payload();
                model.payload.tags = new Tags();
                model.payload.tags.affected_obj_tag = intersightResult.MsAffectedObject;
                model.payload.tags.affected_model_tag = affectedModel;
                model.payload.tags.affected_serial_tag = affectedSerial;
                model.payload.tags.affected_host_tag = affectedhost;
                model.payload.tags.affected_ipaddress_tag = affectedipaddress;
                model.payload.tags.affected_userlabel_tag = affectedUserLabel;
                model.payload.tags.affected_serviceprofile_tag = affectedServiceProfile;

            model.payload.tags.ancestor_obj_tag  = intersightResult.AncestorMoType;
                model.payload.tags.ancestor_model_tag = ancesstorModel;
                model.payload.tags.ancestor_serial_tag = ancesstorSerial;
                model.payload.tags.ancestor_host_tag = ancesstorHost;
            model.payload.tags.ancestor_ipaddress_tag = ancesstoripaddress;
            model.payload.tags.ancestor_userlabel_tag = ancesstorUserLabel;
            model.payload.tags.ancestor_serviceprofile_tag = ancesstorServiceProfile;

            model.payload.tags.descr_tag   = intersightResult.Description;
                model.payload.tags.name_tag  = intersightResult.Name;
                model.payload.tags.sev_tag   = intersightResult.Severity;
                model.payload.tags.org_name_tag = orgName;

                model.payload.affected_obj = intersightResult.MsAffectedObject;
                model.payload.affected_model = affectedModel;
                model.payload.affected_serial = affectedSerial;
                model.payload.affected_host = affectedhost;
                model.payload.affected_ipaddress = affectedipaddress;
                model.payload.affected_userlabel = affectedUserLabel;
                model.payload.affected_serviceprofile = affectedServiceProfile;

                model.payload.ancestor_obj = intersightResult.AncestorMoType;
                model.payload.ancestor_model = ancesstorModel;
                model.payload.ancestor_serial = ancesstorSerial;
                model.payload.ancestor_host = ancesstorHost;
                model.payload.ancestor_ipaddress = ancesstoripaddress;
            model.payload.ancestor_userlabel = ancesstorUserLabel;
            model.payload.ancestor_serviceprofile = ancesstorServiceProfile;

            model.payload.descr = intersightResult.Description;
                model.payload.create_time = intersightResult.CreateTime.Value.ToLongDateString() + " " + intersightResult.CreateTime.Value.ToLongTimeString();
            //model.payload.creation_time = intersightResult.CreationTime.Value.ToUniversalTime().ToLongDateString() + " " + intersightResult.CreationTime.Value.ToUniversalTime().ToLongTimeString();
            model.payload.creation_time = intersightResult.CreationTime.Value.ToUniversalTime();
                model.payload.last_transition_time = intersightResult.LastTransitionTime.Value.ToLongDateString() + " " + intersightResult.LastTransitionTime.Value.ToLongTimeString();
            //model.payload.modified_time = intersightResult.ModTime.Value.ToUniversalTime().ToLongDateString() + " " + intersightResult.ModTime.Value.ToUniversalTime().ToLongTimeString();
            model.payload.modified_time = intersightResult.ModTime.Value.ToUniversalTime();
                //model.payload.time = ((DateTimeOffset)intersightResult.CreateTime.Value).ToUnixTimeSeconds().ToString();
                //model.payload.creation_date_time = ((DateTimeOffset)intersightResult.CreationTime.Value).ToUnixTimeSeconds().ToString();
                //model.payload.last_tr_date_time = ((DateTimeOffset)intersightResult.LastTransitionTime.Value).ToUnixTimeSeconds().ToString();
                //model.payload.mod_date_time = ((DateTimeOffset)intersightResult.ModTime.Value).ToUnixTimeSeconds().ToString();

                model.payload.name = intersightResult.Name;
                model.payload.org_name = orgName;
                model.payload.sev = intersightResult.Severity;

               return Newtonsoft.Json.JsonConvert.SerializeObject(model);
               
        }

        private IFields GetFieldItem(string name, string optional)
        {
            var model = new FieldsString();
            model.field = name;
            model.optional = optional;

            return model;
        }

        private IFields GetFieldMapItem(string name , string optional)
        {
            var model = new FieldsMap();
            model.field = name;
            model.optional = optional;
            model.keys = new KeyType();
            model.keys.type = "string";
            model.keys.optional = true.ToString ();
            model.values = new KeyType();
            model.values.type = "string";
            model.values.optional = true.ToString();


            return model;
        }

        [HttpPost]
        [Route("TestKafkaIPAsync")]
        public async void TestKafkaIPAsync()
        {
            //var conf = new ProducerConfig { BootstrapServers = "35.221.33.111:9092" };

            var config = new ProducerConfig { BootstrapServers = "35.221.33.111:9092" };

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    //var topicpart = new TopicPartition("Test-New-Data", new Partition(1));
                    var dr = await p.ProduceAsync("intersight-test_123TestKafkaIPAsync", new Message<Null, string> { Value = "TestKafkaIPAsync" });
                    // Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    // Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        [HttpPost]
        [Route("TestKafkaIPAsyncwp")]
        public async void TestKafkaIPAsyncwp()
        {
            //var conf = new ProducerConfig { BootstrapServers = "35.221.33.111:9092" };

            var config = new ProducerConfig { BootstrapServers = "35.221.33.111" };
            
            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    
                    var dr = await p.ProduceAsync("intersight-test_123TestKafkaIPAsyncwp", new Message<Null, string> { Value = "TestKafkaIPAsyncwp" });
                    // Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    // Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        [HttpPost]
        [Route("TestKafkaIP")]
        public async void TestKafkaIP()
        {
            var conf = new ProducerConfig { BootstrapServers = "35.221.33.111:9092" };

            Action<DeliveryReport<Null, string>> handler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");

            using (var p = new ProducerBuilder<Null, string>(conf).Build())
            {
                try
                { 
                    for (int i = 0; i < 100; ++i)
                    {
                        p.Produce("intersight-test_123TestKafkaIP", new Message<Null, string> { Value = "TestKafkaIP" + i.ToString() }, handler);
                    }

                    // wait for up to 10 seconds for any inflight messages to be delivered.
                    p.Flush(TimeSpan.FromSeconds(10));
                }
                catch (ProduceException<Null, string> e)
                {
                    // Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

            //var c = new ConsumerBuilder<Null, string>(conf).Build();
            //var result = c.Consume();
            //var aa = string.Empty;

        }

        [HttpPost]
        [Route("TestKafkaIPwp")]
        public async void TestKafkaIPwp()
        {
            var conf = new ProducerConfig { BootstrapServers = "35.221.33.111" };

            Action<DeliveryReport<Null, string>> handler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");

            using (var p = new ProducerBuilder<Null, string>(conf).Build())
            {
                for (int i = 0; i < 100; ++i)
                {
                    p.Produce("intersight-test_123TestKafkaIPwp", new Message<Null, string> { Value = "TestKafkaIPwp " + i.ToString() }, handler);
                }

                // wait for up to 10 seconds for any inflight messages to be delivered.
                p.Flush(TimeSpan.FromSeconds(10));
            }
        }

        [HttpPost]
        [Route("TestKafkaCloud")]
        public async void TestKafkaCloud()
        {
            var pConfig = new ProducerConfig
            {
                BootstrapServers = "35.221.33.111",
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                // Note: If your root CA certificates are in an unusual location you
                // may need to specify this using the SslCaLocation property.
                SaslUsername = "support@uebiz.com",
                SaslPassword = "wsxCDE45^"
            };

            using (var producer = new ProducerBuilder<Null, string>(pConfig).Build())
            {
                await producer.ProduceAsync("intersight-test_123TestKafkaCloud", new Message<Null, string> { Value = "test value cloud " })
                    .ContinueWith(task => task.IsFaulted
                        ? $"error producing message: {task.Exception.Message}"
                        : $"produced to: {task.Result.TopicPartitionOffset}");

                // block until all in-flight produce requests have completed (successfully
                // or otherwise) or 10s has elapsed.
                producer.Flush(TimeSpan.FromSeconds(10));
            }
        }

        static async Task CreateTopicAsync(string bootstrapServers, string topicName)
        {
            using (var adminClient = new AdminClientBuilder(new AdminClientConfig
            {
                BootstrapServers = bootstrapServers,
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                // Note: If your root CA certificates are in an unusual location you
                // may need to specify this using the SslCaLocation property.
                SaslUsername = "support@uebiz.com",
                SaslPassword = "wsxCDE45^"


            }).Build())
            {
                try
                {
                    await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                        new TopicSpecification { Name = topicName, ReplicationFactor = 1, NumPartitions = 1 } });
                }
                catch (CreateTopicsException e)
                {
                    Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
                }
            }
        }

        private async void SendToKafka(CondAlarmList alarms)
        {

            //foreach (var item in alarms.Results.Where(r => r.Severity != "Cleared").OrderByDescending(r => r.ModTime).ToList())
            //{
            //    var message = "Severity  " + item.Severity + " Description  " + item.Description;
            //}
            //35.221.33.111


            try
            {

                var pConfig = new ProducerConfig
                {
                    BootstrapServers = "35.221.33.111",
                    SaslMechanism = SaslMechanism.Plain,
                    SecurityProtocol = SecurityProtocol.SaslSsl,
                    // Note: If your root CA certificates are in an unusual location you
                    // may need to specify this using the SslCaLocation property.
                    SaslUsername = "support@uebiz.com",
                    SaslPassword = "wsxCDE45^"
                                    };

                using (var producer = new ProducerBuilder<Null, string>(pConfig).Build())
                {
                    await producer.ProduceAsync("intersight-test_123", new Message<Null, string> { Value = "test value" })
                          .ContinueWith(task => task.IsFaulted
                              ? $"error producing message: {task.Exception.Message}"
                              : $"produced to: {task.Result.TopicPartitionOffset}");

                    // block until all in-flight produce requests have completed (successfully
                    // or otherwise) or 10s has elapsed.
                    producer.Flush(TimeSpan.FromSeconds(10));
                }

            }
            catch (Exception ex)
            {

            }
        }


        [HttpGet]
        [Route("GetLatestHyperFlexAlarm")]
        public async Task<Intersight.Model.HyperflexAlarmList> GetLatestHyperFlexAlarm()
        {
            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();
            var output = exeIntersight.ExecuteAPI<HyperflexAlarmList>("/hyperflex/Alarms", _IntersightPath, _ApiKey).Result.Data;
            return output;
        }

        [HttpGet]
        [Route("SendUCSAlarms")]
        public async Task<bool> SendUCSAlarms()
        {
            // Get the latest alarms 
            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();
            var output = exeIntersight.ExecuteAPI<CondAlarmList>("/cond/Alarms", _IntersightPath, _ApiKey).Result.Data;

            // Get only critical alarms 
            var neededAlarmsList = output.Results.Where(r => r.Severity.ToLower() == "Critical".ToLower() | r.Severity.ToLower() == "Info".ToLower() && r.ModTime.Value.Date > DateTime.Now.AddDays(-2).Date).ToList();

            // Compile email Message 
            var message = await GetCompiledMessage(neededAlarmsList);

            // Send email with alarms details 



            return true;
        }


        private async Task<Dictionary<string,string>> GetItemDetails(string affectedtype, string affectedMOID, string path, string apiKey)
        {
            string webLink = "/{0}/{1}/";
            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();
            var compiledString = new Dictionary<string,string>();

            if (!(string.IsNullOrEmpty(affectedtype)))
            {
                var splittedAffected = affectedtype.Split(".");
                var paramAffected = new Dictionary<String, object>();
                paramAffected.Add("moid", affectedMOID);

                if (splittedAffected[0].ToLower() == "Equipment".ToLower() && splittedAffected[1].ToLower() == "Chassis".ToLower())
                {
                    var connectionString = string.Format(webLink, splittedAffected[0].ToString(), "Chasses");

                    var result  = exeIntersight.ExecuteAPI<EquipmentChassis>(connectionString + "{moid}", path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Serial", result.Serial.ToString());
                        compiledString.Add("Model", result.Model.ToString());
                        
                        
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "top".ToLower() && splittedAffected[1].ToLower() == "system".ToLower())
                {
                    var connectionString = "/top/Systems/{moid}";

                   var result  = exeIntersight.ExecuteAPI<TopSystem>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Name)))
                    {
                        compiledString.Add("Name", result.Name.ToString());
                        compiledString.Add("Mode", result.Mode.ToString());
                        compiledString.Add("IPAddress", result.Ipv4Address.ToString());
                        
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "aaa".ToLower() && splittedAffected[1].ToLower() == "AuditRecord".ToLower())
                {
                    var connectionString = "/aaa/AuditRecord/{moid}";

                    var result = exeIntersight.ExecuteAPI<AaaAuditRecord>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.TraceId)))
                    {
                        compiledString.Add("TraceID", result.TraceId.ToString());
                        compiledString.Add("SourceIP", result.SourceIp.ToString());
                        
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "adapter".ToLower() && splittedAffected[1].ToLower() == "ConfigPolicies".ToLower())
                {
                    var connectionString = "/adapter/ConfigPolicies/{moid}";

                    var result = exeIntersight.ExecuteAPI<PolicyAbstractConfigProfile>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Name)))
                    {
                        compiledString.Add("Description", result.Description.ToString());
                        compiledString.Add("Name", result.Name.ToString());
                        
                    }
                }

                else if (splittedAffected[0].ToLower() == "adapter".ToLower() && splittedAffected[1].ToLower() == "ExtEthInterfaces".ToLower())
                {
                    var connectionString = "/adapter/ExtEthInterfaces/{moid}";

                    var result = exeIntersight.ExecuteAPI<AdapterExtEthInterface>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.ExtEthInterfaceId)))
                    {
                        compiledString.Add("InterfaceID", result.ExtEthInterfaceId.ToString());
                        compiledString.Add("MacAddress", result.MacAddress.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());

                    }
                }

                else if (splittedAffected[0].ToLower() == "adapter".ToLower() && splittedAffected[1].ToLower() == "HostEthInterface".ToLower())
                {
                    var connectionString = "/adapter/HostEthInterface/{moid}";

                    var result = exeIntersight.ExecuteAPI<AdapterHostEthInterface>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("MacAddress", result.MacAddress.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());

                    }
                }
                else if (splittedAffected[0].ToLower() == "adapter".ToLower() && splittedAffected[1].ToLower() == "HostFcInterfaces".ToLower())
                {
                    var connectionString = "/adapter/HostFcInterfaces/{moid}";

                    var result = exeIntersight.ExecuteAPI<AdapterHostFcInterface>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Name", result.Name.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());

                    }
                }

                else if (splittedAffected[0].ToLower() == "adapter".ToLower() && splittedAffected[1].ToLower() == "HostIscsiInterfaces".ToLower())
                {
                    var connectionString = "/adapter/HostIscsiInterfaces/{moid}";

                    var result = exeIntersight.ExecuteAPI<AdapterHostIscsiInterface>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Name", result.Name.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());

                    }
                }
                else if (splittedAffected[0].ToLower() == "adapter".ToLower() && splittedAffected[1].ToLower() == "Units".ToLower())
                {
                    var connectionString = "/adapter/Units/{moid}";

                    var result = exeIntersight.ExecuteAPI<AdapterUnit>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("PartNumber", result.PartNumber.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());

                    }
                }
                else if (splittedAffected[0].ToLower() == "asset".ToLower() && splittedAffected[1].ToLower() == "DeviceConfiguration".ToLower())
                {
                    var connectionString = "/asset/DeviceConfiguration/{moid}";

                    var result = exeIntersight.ExecuteAPI<AssetDeviceConfiguration>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.LogLevel)))
                    {
                        compiledString.Add("LogLevel", result.LogLevel.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "asset".ToLower() && splittedAffected[1].ToLower() == "DeviceConnectorManager".ToLower())
                {
                    var connectionString = "/asset/DeviceConnectorManager/{moid}";

                    //var result = exeIntersight.ExecuteAPI<AssetDevicecon>(connectionString, paramAffected).Result.Data;
                    //compiledString = "Log Level : " + result.LogLevel.ToString();
                    
                }
                else if (splittedAffected[0].ToLower() == "asset".ToLower() && splittedAffected[1].ToLower() == "DeviceContractInformation".ToLower())
                {
                    var connectionString = "/asset/DeviceContractInformation/{moid}";

                    //var result = exeIntersight.ExecuteAPI<devicecontra>(connectionString, paramAffected).Result.Data;
                    //compiledString = "Log Level : " + result.LogLevel.ToString();

                }
                else if (splittedAffected[0].ToLower() == "asset".ToLower() && splittedAffected[1].ToLower() == "DeviceRegistration".ToLower())
                {
                    var connectionString = "/asset/DeviceRegistration/{moid}";

                    var result = exeIntersight.ExecuteAPI<AssetDeviceRegistration>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Moid)))
                    {
                        compiledString.Add("AccessKey", result.AccessKey.ToString());
                        compiledString.Add("Serial", string.Join(",", result.Serial).ToString());
                        compiledString.Add("Host", result.DeviceHostname.ToString());
                        compiledString.Add("IPAddress", result.DeviceIpAddress.ToString());
                          
                    }
                }
                else if (splittedAffected[0].ToLower() == "asset".ToLower() && splittedAffected[1].ToLower() == "ManagedDevice".ToLower())
                {
                    var connectionString = "/asset/ManagedDevice/{moid}";

                    //var result = exeIntersight.ExecuteAPI<managemen>(connectionString, paramAffected).Result.Data;
                    //compiledString = "Host Name : " + result.DeviceHostname.ToString() + ", IP Address :" + result.DeviceIpAddress.ToString();

                }
                else if (splittedAffected[0].ToLower() == "asset".ToLower() && splittedAffected[1].ToLower() == "Target".ToLower())
                {
                    var connectionString = "/asset/Target/{moid}";

                    //var result = exeIntersight.ExecuteAPI<AssetTargetFallbackFramework >(connectionString, paramAffected).Result.Data;
                    //compiledString = "Host Name : " + result.DeviceHostname.ToString() + ", IP Address :" + result.DeviceIpAddress.ToString();

                }
                else if (splittedAffected[0].ToLower() == "bios".ToLower() && splittedAffected[1].ToLower() == "BootDevice".ToLower())
                {
                    var connectionString = "/bios/BootDevice/{moid}";

                    var result = exeIntersight.ExecuteAPI<BootDeviceBase>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Name)))
                    {
                        compiledString.Add("Name", result.Name.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "bios".ToLower() && splittedAffected[1].ToLower() == "Unit".ToLower())
                {
                    var connectionString = "/bios/Unit/{moid}";

                    var result = exeIntersight.ExecuteAPI<BiosUnit>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Serial)))
                    {
                        compiledString.Add("Serial", result.Serial.ToString());
                        compiledString.Add("Model", result.Model.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "bios".ToLower() && splittedAffected[1].ToLower() == "Unit".ToLower())
                {
                    var connectionString = "/bios/Unit/{moid}";

                    var result = exeIntersight.ExecuteAPI<BiosUnit>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Serial)))
                    {
                        compiledString.Add("Serial", result.Serial.ToString());
                        compiledString.Add("Model", result.Model.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "cond".ToLower() && splittedAffected[1].ToLower() == "HclStatus".ToLower())
                {
                    var connectionString = "/cond/HclStatus/{moid}";

                    var result = exeIntersight.ExecuteAPI<CondHclStatus>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.HclModel)))
                    {
                        compiledString.Add("InvModel", result.InvModel.ToString());
                        compiledString.Add("Model", result.HclModel.ToString());
                        
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "cond".ToLower() && splittedAffected[1].ToLower() == "HclStatusDetail".ToLower())
                {
                    var connectionString = "/cond/HclStatusDetail/{moid}";

                    var result = exeIntersight.ExecuteAPI<CondHclStatusDetail>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.HclModel)))
                    {
                        compiledString.Add("InvModel", result.InvModel.ToString());
                        compiledString.Add("Model", result.HclModel.ToString());
                        
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "DeviceSummary".ToLower())
                {
                    var connectionString = "/equipment/DeviceSummary/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentDeviceSummary>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "Fan".ToLower())
                {
                    var connectionString = "/equipment/Fan/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentFan>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "FanModule".ToLower())
                {
                    var connectionString = "/equipment/FanModule/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentFanModule>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "Fex".ToLower())
                {
                    var connectionString = "/equipment/Fex/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentFex>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "IoCard".ToLower())
                {
                    var connectionString = "/equipment/IoCard/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentIoCard>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "IoCard".ToLower())
                {
                    var connectionString = "/equipment/IoCard/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentIoCard>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "IoCard".ToLower())
                {
                    var connectionString = "/equipment/IoCard/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentIoCard>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "equipment".ToLower() && splittedAffected[1].ToLower() == "Psu".ToLower())
                {
                    var connectionString = "/equipment/Psu/{moid}";

                    var result = exeIntersight.ExecuteAPI<EquipmentPsu>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "compute".ToLower() && splittedAffected[1].ToLower() == "Blade".ToLower())
                {
                    var connectionString = "/compute/Blades/{moid}";

                    var result = exeIntersight.ExecuteAPI<ComputeBlade>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        var ipstring = new List<string>();
                        foreach (var item in result.KvmIpAddresses)
                        {
                            ipstring.Add(item.Address);
                        }
                        compiledString.Add("IPAddress",string.Join(",", ipstring).ToString());
                        compiledString.Add("ServiceProfile", result.ServiceProfile.ToString());
                        compiledString.Add("UserLabel", result.UserLabel.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "network".ToLower() && splittedAffected[1].ToLower() == "Element".ToLower())
                {
                    var connectionString = "/network/Elements/{moid}";

                    var result = exeIntersight.ExecuteAPI<NetworkElement>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        compiledString.Add("IPAddress", result.InbandIpAddress.ToString());
                        
                    }
                }
                else if (splittedAffected[0].ToLower() == "compute".ToLower() && splittedAffected[1].ToLower() == "RackUnit".ToLower())
                {
                    var connectionString = "/compute/RackUnits/{moid}";

                    var result = exeIntersight.ExecuteAPI<ComputeRackUnit>(connectionString, path, apiKey, paramAffected).Result.Data;
                    if (!(string.IsNullOrEmpty(result.Model)))
                    {
                        compiledString.Add("Model", result.Model.ToString());
                        compiledString.Add("Serial", result.Serial.ToString());
                        compiledString.Add("ServiceProfile", result.ServiceProfile.ToString());
                        compiledString.Add("UserLabel", result.UserLabel.ToString());


                        var ipstring = new List<string>();
                        foreach (var item in result.KvmIpAddresses)
                        {
                            ipstring.Add(item.Address);
                        }
                        compiledString.Add("IPAddress", string.Join(",", ipstring).ToString());
                         
                    }
                }

            }

            return compiledString;

        }

        [HttpGet]
        [Route("GetAlarmDetails")]
        public async Task<AlarmDetailsInterSight> GetAlarmDetails(string moid)
        {
            var response = new AlarmDetailsInterSight();

            try
            {

                string webLink = "/{0}/{1}/";
                var param = new Dictionary<String, object>();
                param.Add("moid", moid);

                var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();

                var result = exeIntersight.ExecuteAPI<CondAlarm>("/cond/Alarms/{moid}", _IntersightPath, _ApiKey, param).Result.Data;
                response.alarmDetails = result;

                var affectedtype = result.AffectedMoType;
                if (!(string.IsNullOrEmpty(affectedtype)))
                {
                    var splittedAffected = affectedtype.Split(".");
                    var paramAffected = new Dictionary<String, object>();
                    paramAffected.Add("moid", result.AffectedMoId);

                    if (splittedAffected[0].ToLower() == "Equipment".ToLower() && splittedAffected[1].ToLower() == "Chassis".ToLower())
                    {
                        var connectionString = string.Format(webLink, splittedAffected[0].ToString(), "Chasses");

                        response.AffectedEquipmentChansis = exeIntersight.ExecuteAPI<EquipmentChassis>(connectionString + "{moid}", _IntersightPath, _ApiKey, paramAffected).Result.Data;
                    }
                    else if (splittedAffected[0].ToLower() == "top".ToLower() && splittedAffected[1].ToLower() == "system".ToLower())
                    {
                        var connectionString = "/top/Systems/{moid}";

                        response.AffectedTopSystem = exeIntersight.ExecuteAPI<TopSystem>(connectionString, _IntersightPath, _ApiKey, paramAffected).Result.Data;
                    }

                }


                var Ancestortype = result.AncestorMoType;
                if (!(string.IsNullOrEmpty(Ancestortype)))
                {
                    var splitted = Ancestortype.Split(".");
                    var paramAncestor = new Dictionary<String, object>();
                    paramAncestor.Add("moid", result.AncestorMoId);

                    if (splitted[0].ToLower() == "compute".ToLower() && splitted[1].ToLower() == "Blade".ToLower())
                    {
                        var connectionString = "/compute/Blades/{moid}";

                        response.AncesstorDetails = exeIntersight.ExecuteAPI<ComputeBlade>(connectionString, _IntersightPath, _ApiKey, paramAncestor).Result.Data;
                    }

                }









            }
            catch (Exception ex)
            {

            }

            return response;
        }

        //public async Task<Intersight.Model.CondAlarmList> GetLatestAlarms_old()
        //{
        //    Intersight.Model.CondAlarmList result = new Intersight.Model.CondAlarmList();
        //    try
        //    {
        //        ////https://5d079d727564612d305b9414.intersight.com/api/v1
        //        var path = "D:\\Projects\\Uebiz\\WebExAPITool\\WebExAPITool\\WebExAPITool.Intersight\\SecretKey.pem";
        //        var intersightIntialConfig = new Intersight.Client.IntersightApiClient("https://www.intersight.com/api/v1",
        //        path, "5d079d727564612d305b9414/5d76b95a7564612d30b70f60/5d76bb697564612d30b7bef9");



        //        //intersightIntialConfig.prepare_auth_header("/cond/Alarms", RestSharp.Method.Get, null, new Dictionary<string, string>());

        //        var localVarPath = "/cond/Alarms";
        //        var localVarPathParams = new Dictionary<String, String>();
        //        var localVarQueryParams = new Dictionary<String, String>();
        //        var localVarHeaderParams = new Dictionary<String, String>(intersightIntialConfig.Configuration.DefaultHeader);
        //        var localVarFormParams = new Dictionary<String, String>();
        //        var localVarFileParams = new Dictionary<String, FileParameter>();
        //        Object localVarPostBody = null;

        //        // to determine the Content-Type header
        //        String[] localVarHttpContentTypes = new String[] {
        //        "application/json"
        //    };
        //        String localVarHttpContentType = intersightIntialConfig.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

        //        // to determine the Accept header
        //        String[] localVarHttpHeaderAccepts = new String[] {
        //        "application/json"
        //    };
        //        String localVarHttpHeaderAccept = intersightIntialConfig.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
        //        if (localVarHttpHeaderAccept != null)
        //            localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);


        //        // make the HTTP request
        //        RestResponse localVarResponse = (RestResponse)intersightIntialConfig.CallApi(localVarPath,
        //            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
        //            localVarPathParams, localVarHttpContentType);

        //        int localVarStatusCode = (int)localVarResponse.StatusCode;

        //        if (ExceptionFactory != null)
        //        {
        //            Exception exception = ExceptionFactory("CondAlarmsGet", localVarResponse);
        //            if (exception != null) throw exception;
        //        }

        //        var response = new ApiResponse<CondAlarmList>(localVarStatusCode,
        //             localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
        //             (CondAlarmList)intersightIntialConfig.Configuration.ApiClient.Deserialize(localVarResponse, typeof(CondAlarmList)));


        //        result = response.Data;
        //        //  var client = new Intersight.Client.ApiClient(intersightIntialConfig.Configuration);


        //        //var alaramSet = new Intersight.Api.CondAlarmApi(intersightIntialConfig.Configuration);
        //        var alaramSet = new Intersight.Api.CondAlarmApi(intersightIntialConfig.Configuration);
        //        // alaramSet.Configuration = intersightIntialConfig.Configuration;
        //        var result1 = await alaramSet.CondAlarmsMoidGetAsync("aa");

        //        var aa = new Intersight.Api.EquipmentChassisApi();
        //        var result2 = aa.EquipmentChassesMoidGet("aa");
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return result;
        //}


        #region " Private Method "

        #region " Get Compiled Message "
        private async Task<Tuple<string, string>> GetCompiledMessage(List<CondAlarm> list)
        {
            string message = string.Empty;
            string subject = string.Empty;

            // get the distinct code out of list 
            var distinctCode = list.Select(r => r.Code).Distinct().ToList();

            foreach (var code in distinctCode)
            {


                // Loop through the list we have 
                foreach (var item in list.Where(r => r.Code == code).ToList())
                {
                    // Get the device details 
                    var registeredDevice = await GetRegisteredDevice(item.RegisteredDevice);


                    // get the information from the 
                    var itemDetails = await GetAlarmDetails(item.Moid);

                    subject = string.Format("{0} || {1} || {2}", registeredDevice.DeviceHostname, itemDetails.AffectedEquipmentChansis.Serial, item.Name);


                }
            }

            return new Tuple<string, string>(subject, message);
        }

        private async Task<AssetDeviceRegistration> GetRegisteredDevice(AssetDeviceRegistrationRef filledRegisteredDevice)
        {

            var param = new Dictionary<String, object>();
            param.Add("moid", filledRegisteredDevice.Moid);

            var exeIntersight = new WebExAPITool.Intersight.GetIntersightData();

            var result = exeIntersight.ExecuteAPI<AssetDeviceRegistration>("/asset/DeviceRegistrations/{moid}", _IntersightPath, _ApiKey, param).Result.Data;

            return result;
        }

        #endregion

        #region " Send Email "
        private async Task<string> CompileSubject(string message)
        {
            // send the email to the things 
            var newEmail = new MailMessage();


            return string.Empty;
        }
        #endregion



        #endregion
    }
}