/* 
 * Intersight REST API
 *
 * This is Intersight REST API 
 *
 * OpenAPI spec version: 0.1.0-559
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = WebExAPITool.Intersight.Client.SwaggerDateConverter;

namespace WebExAPITool.Intersight.Model
{
    /// <summary>
    /// Fabric Interconnect of a UCS 
    /// </summary>
    [DataContract]
    public partial class NetworkElement :  IEquatable<NetworkElement>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkElement" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="Cards">Cards.</param>
        /// <param name="Fanmodules">Fanmodules.</param>
        /// <param name="FaultSummary">FaultSummary.</param>
        /// <param name="ManagementContoller">ManagementContoller.</param>
        /// <param name="ManagementEntity">ManagementEntity.</param>
        /// <param name="Psus">Psus.</param>
        /// <param name="RegisteredDevice">RegisteredDevice.</param>
        /// <param name="TopSystem">TopSystem.</param>
        /// <param name="UcsmRunningFirmware">UcsmRunningFirmware.</param>
        public NetworkElement(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), List<EquipmentSwitchCardRef> Cards = default(List<EquipmentSwitchCardRef>), List<EquipmentFanModuleRef> Fanmodules = default(List<EquipmentFanModuleRef>), long? FaultSummary = default(long?), ManagementControllerRef ManagementContoller = default(ManagementControllerRef), ManagementEntityRef ManagementEntity = default(ManagementEntityRef), List<EquipmentPsuRef> Psus = default(List<EquipmentPsuRef>), AssetDeviceRegistrationRef RegisteredDevice = default(AssetDeviceRegistrationRef), TopSystemRef TopSystem = default(TopSystemRef), FirmwareRunningFirmwareRef UcsmRunningFirmware = default(FirmwareRunningFirmwareRef))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.Cards = Cards;
            this.Fanmodules = Fanmodules;
            this.FaultSummary = FaultSummary;
            this.ManagementContoller = ManagementContoller;
            this.ManagementEntity = ManagementEntity;
            this.Psus = Psus;
            this.RegisteredDevice = RegisteredDevice;
            this.TopSystem = TopSystem;
            this.UcsmRunningFirmware = UcsmRunningFirmware;
        }
        
        /// <summary>
        /// The Account ID for this managed object.  
        /// </summary>
        /// <value>The Account ID for this managed object.  </value>
        [DataMember(Name="AccountMoid", EmitDefaultValue=false)]
        public string AccountMoid { get; private set; }

        /// <summary>
        /// Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. 
        /// </summary>
        /// <value>Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. </value>
        [DataMember(Name="Ancestors", EmitDefaultValue=false)]
        public List<MoBaseMoRef> Ancestors { get; set; }

        /// <summary>
        /// The time when this managed object was created.  
        /// </summary>
        /// <value>The time when this managed object was created.  </value>
        [DataMember(Name="CreateTime", EmitDefaultValue=false)]
        public DateTime? CreateTime { get; private set; }

        /// <summary>
        /// The time when this managed object was last modified.  
        /// </summary>
        /// <value>The time when this managed object was last modified.  </value>
        [DataMember(Name="ModTime", EmitDefaultValue=false)]
        public DateTime? ModTime { get; private set; }

        /// <summary>
        /// A unique identifier of this Managed Object instance.  
        /// </summary>
        /// <value>A unique identifier of this Managed Object instance.  </value>
        [DataMember(Name="Moid", EmitDefaultValue=false)]
        public string Moid { get; set; }

        /// <summary>
        /// The fully-qualified type of this managed object, e.g. the class name.  
        /// </summary>
        /// <value>The fully-qualified type of this managed object, e.g. the class name.  </value>
        [DataMember(Name="ObjectType", EmitDefaultValue=false)]
        public string ObjectType { get; private set; }

        /// <summary>
        /// An array of owners which represent effective ownership of this object.   
        /// </summary>
        /// <value>An array of owners which represent effective ownership of this object.   </value>
        [DataMember(Name="Owners", EmitDefaultValue=false)]
        public List<string> Owners { get; set; }

        /// <summary>
        /// The direct ancestor of this managed object in the containment hierarchy. 
        /// </summary>
        /// <value>The direct ancestor of this managed object in the containment hierarchy. </value>
        [DataMember(Name="Parent", EmitDefaultValue=false)]
        public MoBaseMoRef Parent { get; set; }

        /// <summary>
        /// An array of tags, which allow to add key, value meta-data to managed objects.   
        /// </summary>
        /// <value>An array of tags, which allow to add key, value meta-data to managed objects.   </value>
        [DataMember(Name="Tags", EmitDefaultValue=false)]
        public List<MoTag> Tags { get; set; }

        /// <summary>
        /// Gets or Sets DeviceMoId
        /// </summary>
        [DataMember(Name="DeviceMoId", EmitDefaultValue=false)]
        public string DeviceMoId { get; private set; }

        /// <summary>
        /// Gets or Sets Dn
        /// </summary>
        [DataMember(Name="Dn", EmitDefaultValue=false)]
        public string Dn { get; private set; }

        /// <summary>
        /// Gets or Sets Rn
        /// </summary>
        [DataMember(Name="Rn", EmitDefaultValue=false)]
        public string Rn { get; private set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        [DataMember(Name="Model", EmitDefaultValue=false)]
        public string Model { get; private set; }

        /// <summary>
        /// Gets or Sets Revision
        /// </summary>
        [DataMember(Name="Revision", EmitDefaultValue=false)]
        public string Revision { get; private set; }

        /// <summary>
        /// Gets or Sets Serial
        /// </summary>
        [DataMember(Name="Serial", EmitDefaultValue=false)]
        public string Serial { get; private set; }

        /// <summary>
        /// Gets or Sets Vendor
        /// </summary>
        [DataMember(Name="Vendor", EmitDefaultValue=false)]
        public string Vendor { get; private set; }

        /// <summary>
        /// Gets or Sets AdminInbandInterfaceState
        /// </summary>
        [DataMember(Name="AdminInbandInterfaceState", EmitDefaultValue=false)]
        public string AdminInbandInterfaceState { get; private set; }

        /// <summary>
        /// Gets or Sets Cards
        /// </summary>
        [DataMember(Name="Cards", EmitDefaultValue=false)]
        public List<EquipmentSwitchCardRef> Cards { get; set; }

        /// <summary>
        /// Gets or Sets Fanmodules
        /// </summary>
        [DataMember(Name="Fanmodules", EmitDefaultValue=false)]
        public List<EquipmentFanModuleRef> Fanmodules { get; set; }

        /// <summary>
        /// Gets or Sets FaultSummary
        /// </summary>
        [DataMember(Name="FaultSummary", EmitDefaultValue=false)]
        public long? FaultSummary { get; set; }

        /// <summary>
        /// Gets or Sets InbandIpAddress
        /// </summary>
        [DataMember(Name="InbandIpAddress", EmitDefaultValue=false)]
        public string InbandIpAddress { get; private set; }

        /// <summary>
        /// Gets or Sets InbandIpGateway
        /// </summary>
        [DataMember(Name="InbandIpGateway", EmitDefaultValue=false)]
        public string InbandIpGateway { get; private set; }

        /// <summary>
        /// Gets or Sets InbandIpMask
        /// </summary>
        [DataMember(Name="InbandIpMask", EmitDefaultValue=false)]
        public string InbandIpMask { get; private set; }

        /// <summary>
        /// Gets or Sets InbandVlan
        /// </summary>
        [DataMember(Name="InbandVlan", EmitDefaultValue=false)]
        public long? InbandVlan { get; private set; }

        /// <summary>
        /// Gets or Sets ManagementContoller
        /// </summary>
        [DataMember(Name="ManagementContoller", EmitDefaultValue=false)]
        public ManagementControllerRef ManagementContoller { get; set; }

        /// <summary>
        /// Gets or Sets ManagementEntity
        /// </summary>
        [DataMember(Name="ManagementEntity", EmitDefaultValue=false)]
        public ManagementEntityRef ManagementEntity { get; set; }

        /// <summary>
        /// Gets or Sets OutOfBandIpAddress
        /// </summary>
        [DataMember(Name="OutOfBandIpAddress", EmitDefaultValue=false)]
        public string OutOfBandIpAddress { get; private set; }

        /// <summary>
        /// Gets or Sets OutOfBandIpGateway
        /// </summary>
        [DataMember(Name="OutOfBandIpGateway", EmitDefaultValue=false)]
        public string OutOfBandIpGateway { get; private set; }

        /// <summary>
        /// Gets or Sets OutOfBandIpMask
        /// </summary>
        [DataMember(Name="OutOfBandIpMask", EmitDefaultValue=false)]
        public string OutOfBandIpMask { get; private set; }

        /// <summary>
        /// Gets or Sets OutOfBandMac
        /// </summary>
        [DataMember(Name="OutOfBandMac", EmitDefaultValue=false)]
        public string OutOfBandMac { get; private set; }

        /// <summary>
        /// Gets or Sets Psus
        /// </summary>
        [DataMember(Name="Psus", EmitDefaultValue=false)]
        public List<EquipmentPsuRef> Psus { get; set; }

        /// <summary>
        /// Gets or Sets RegisteredDevice
        /// </summary>
        [DataMember(Name="RegisteredDevice", EmitDefaultValue=false)]
        public AssetDeviceRegistrationRef RegisteredDevice { get; set; }

        /// <summary>
        /// Gets or Sets SwitchId
        /// </summary>
        [DataMember(Name="SwitchId", EmitDefaultValue=false)]
        public string SwitchId { get; private set; }

        /// <summary>
        /// Gets or Sets TopSystem
        /// </summary>
        [DataMember(Name="TopSystem", EmitDefaultValue=false)]
        public TopSystemRef TopSystem { get; set; }

        /// <summary>
        /// Gets or Sets UcsmRunningFirmware
        /// </summary>
        [DataMember(Name="UcsmRunningFirmware", EmitDefaultValue=false)]
        public FirmwareRunningFirmwareRef UcsmRunningFirmware { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NetworkElement {\n");
            sb.Append("  AccountMoid: ").Append(AccountMoid).Append("\n");
            sb.Append("  Ancestors: ").Append(Ancestors).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  ModTime: ").Append(ModTime).Append("\n");
            sb.Append("  Moid: ").Append(Moid).Append("\n");
            sb.Append("  ObjectType: ").Append(ObjectType).Append("\n");
            sb.Append("  Owners: ").Append(Owners).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  DeviceMoId: ").Append(DeviceMoId).Append("\n");
            sb.Append("  Dn: ").Append(Dn).Append("\n");
            sb.Append("  Rn: ").Append(Rn).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Revision: ").Append(Revision).Append("\n");
            sb.Append("  Serial: ").Append(Serial).Append("\n");
            sb.Append("  Vendor: ").Append(Vendor).Append("\n");
            sb.Append("  AdminInbandInterfaceState: ").Append(AdminInbandInterfaceState).Append("\n");
            sb.Append("  Cards: ").Append(Cards).Append("\n");
            sb.Append("  Fanmodules: ").Append(Fanmodules).Append("\n");
            sb.Append("  FaultSummary: ").Append(FaultSummary).Append("\n");
            sb.Append("  InbandIpAddress: ").Append(InbandIpAddress).Append("\n");
            sb.Append("  InbandIpGateway: ").Append(InbandIpGateway).Append("\n");
            sb.Append("  InbandIpMask: ").Append(InbandIpMask).Append("\n");
            sb.Append("  InbandVlan: ").Append(InbandVlan).Append("\n");
            sb.Append("  ManagementContoller: ").Append(ManagementContoller).Append("\n");
            sb.Append("  ManagementEntity: ").Append(ManagementEntity).Append("\n");
            sb.Append("  OutOfBandIpAddress: ").Append(OutOfBandIpAddress).Append("\n");
            sb.Append("  OutOfBandIpGateway: ").Append(OutOfBandIpGateway).Append("\n");
            sb.Append("  OutOfBandIpMask: ").Append(OutOfBandIpMask).Append("\n");
            sb.Append("  OutOfBandMac: ").Append(OutOfBandMac).Append("\n");
            sb.Append("  Psus: ").Append(Psus).Append("\n");
            sb.Append("  RegisteredDevice: ").Append(RegisteredDevice).Append("\n");
            sb.Append("  SwitchId: ").Append(SwitchId).Append("\n");
            sb.Append("  TopSystem: ").Append(TopSystem).Append("\n");
            sb.Append("  UcsmRunningFirmware: ").Append(UcsmRunningFirmware).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as NetworkElement);
        }

        /// <summary>
        /// Returns true if NetworkElement instances are equal
        /// </summary>
        /// <param name="other">Instance of NetworkElement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NetworkElement other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AccountMoid == other.AccountMoid ||
                    this.AccountMoid != null &&
                    this.AccountMoid.Equals(other.AccountMoid)
                ) && 
                (
                    this.Ancestors == other.Ancestors ||
                    this.Ancestors != null &&
                    this.Ancestors.SequenceEqual(other.Ancestors)
                ) && 
                (
                    this.CreateTime == other.CreateTime ||
                    this.CreateTime != null &&
                    this.CreateTime.Equals(other.CreateTime)
                ) && 
                (
                    this.ModTime == other.ModTime ||
                    this.ModTime != null &&
                    this.ModTime.Equals(other.ModTime)
                ) && 
                (
                    this.Moid == other.Moid ||
                    this.Moid != null &&
                    this.Moid.Equals(other.Moid)
                ) && 
                (
                    this.ObjectType == other.ObjectType ||
                    this.ObjectType != null &&
                    this.ObjectType.Equals(other.ObjectType)
                ) && 
                (
                    this.Owners == other.Owners ||
                    this.Owners != null &&
                    this.Owners.SequenceEqual(other.Owners)
                ) && 
                (
                    this.Parent == other.Parent ||
                    this.Parent != null &&
                    this.Parent.Equals(other.Parent)
                ) && 
                (
                    this.Tags == other.Tags ||
                    this.Tags != null &&
                    this.Tags.SequenceEqual(other.Tags)
                ) && 
                (
                    this.DeviceMoId == other.DeviceMoId ||
                    this.DeviceMoId != null &&
                    this.DeviceMoId.Equals(other.DeviceMoId)
                ) && 
                (
                    this.Dn == other.Dn ||
                    this.Dn != null &&
                    this.Dn.Equals(other.Dn)
                ) && 
                (
                    this.Rn == other.Rn ||
                    this.Rn != null &&
                    this.Rn.Equals(other.Rn)
                ) && 
                (
                    this.Model == other.Model ||
                    this.Model != null &&
                    this.Model.Equals(other.Model)
                ) && 
                (
                    this.Revision == other.Revision ||
                    this.Revision != null &&
                    this.Revision.Equals(other.Revision)
                ) && 
                (
                    this.Serial == other.Serial ||
                    this.Serial != null &&
                    this.Serial.Equals(other.Serial)
                ) && 
                (
                    this.Vendor == other.Vendor ||
                    this.Vendor != null &&
                    this.Vendor.Equals(other.Vendor)
                ) && 
                (
                    this.AdminInbandInterfaceState == other.AdminInbandInterfaceState ||
                    this.AdminInbandInterfaceState != null &&
                    this.AdminInbandInterfaceState.Equals(other.AdminInbandInterfaceState)
                ) && 
                (
                    this.Cards == other.Cards ||
                    this.Cards != null &&
                    this.Cards.SequenceEqual(other.Cards)
                ) && 
                (
                    this.Fanmodules == other.Fanmodules ||
                    this.Fanmodules != null &&
                    this.Fanmodules.SequenceEqual(other.Fanmodules)
                ) && 
                (
                    this.FaultSummary == other.FaultSummary ||
                    this.FaultSummary != null &&
                    this.FaultSummary.Equals(other.FaultSummary)
                ) && 
                (
                    this.InbandIpAddress == other.InbandIpAddress ||
                    this.InbandIpAddress != null &&
                    this.InbandIpAddress.Equals(other.InbandIpAddress)
                ) && 
                (
                    this.InbandIpGateway == other.InbandIpGateway ||
                    this.InbandIpGateway != null &&
                    this.InbandIpGateway.Equals(other.InbandIpGateway)
                ) && 
                (
                    this.InbandIpMask == other.InbandIpMask ||
                    this.InbandIpMask != null &&
                    this.InbandIpMask.Equals(other.InbandIpMask)
                ) && 
                (
                    this.InbandVlan == other.InbandVlan ||
                    this.InbandVlan != null &&
                    this.InbandVlan.Equals(other.InbandVlan)
                ) && 
                (
                    this.ManagementContoller == other.ManagementContoller ||
                    this.ManagementContoller != null &&
                    this.ManagementContoller.Equals(other.ManagementContoller)
                ) && 
                (
                    this.ManagementEntity == other.ManagementEntity ||
                    this.ManagementEntity != null &&
                    this.ManagementEntity.Equals(other.ManagementEntity)
                ) && 
                (
                    this.OutOfBandIpAddress == other.OutOfBandIpAddress ||
                    this.OutOfBandIpAddress != null &&
                    this.OutOfBandIpAddress.Equals(other.OutOfBandIpAddress)
                ) && 
                (
                    this.OutOfBandIpGateway == other.OutOfBandIpGateway ||
                    this.OutOfBandIpGateway != null &&
                    this.OutOfBandIpGateway.Equals(other.OutOfBandIpGateway)
                ) && 
                (
                    this.OutOfBandIpMask == other.OutOfBandIpMask ||
                    this.OutOfBandIpMask != null &&
                    this.OutOfBandIpMask.Equals(other.OutOfBandIpMask)
                ) && 
                (
                    this.OutOfBandMac == other.OutOfBandMac ||
                    this.OutOfBandMac != null &&
                    this.OutOfBandMac.Equals(other.OutOfBandMac)
                ) && 
                (
                    this.Psus == other.Psus ||
                    this.Psus != null &&
                    this.Psus.SequenceEqual(other.Psus)
                ) && 
                (
                    this.RegisteredDevice == other.RegisteredDevice ||
                    this.RegisteredDevice != null &&
                    this.RegisteredDevice.Equals(other.RegisteredDevice)
                ) && 
                (
                    this.SwitchId == other.SwitchId ||
                    this.SwitchId != null &&
                    this.SwitchId.Equals(other.SwitchId)
                ) && 
                (
                    this.TopSystem == other.TopSystem ||
                    this.TopSystem != null &&
                    this.TopSystem.Equals(other.TopSystem)
                ) && 
                (
                    this.UcsmRunningFirmware == other.UcsmRunningFirmware ||
                    this.UcsmRunningFirmware != null &&
                    this.UcsmRunningFirmware.Equals(other.UcsmRunningFirmware)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.AccountMoid != null)
                    hash = hash * 59 + this.AccountMoid.GetHashCode();
                if (this.Ancestors != null)
                    hash = hash * 59 + this.Ancestors.GetHashCode();
                if (this.CreateTime != null)
                    hash = hash * 59 + this.CreateTime.GetHashCode();
                if (this.ModTime != null)
                    hash = hash * 59 + this.ModTime.GetHashCode();
                if (this.Moid != null)
                    hash = hash * 59 + this.Moid.GetHashCode();
                if (this.ObjectType != null)
                    hash = hash * 59 + this.ObjectType.GetHashCode();
                if (this.Owners != null)
                    hash = hash * 59 + this.Owners.GetHashCode();
                if (this.Parent != null)
                    hash = hash * 59 + this.Parent.GetHashCode();
                if (this.Tags != null)
                    hash = hash * 59 + this.Tags.GetHashCode();
                if (this.DeviceMoId != null)
                    hash = hash * 59 + this.DeviceMoId.GetHashCode();
                if (this.Dn != null)
                    hash = hash * 59 + this.Dn.GetHashCode();
                if (this.Rn != null)
                    hash = hash * 59 + this.Rn.GetHashCode();
                if (this.Model != null)
                    hash = hash * 59 + this.Model.GetHashCode();
                if (this.Revision != null)
                    hash = hash * 59 + this.Revision.GetHashCode();
                if (this.Serial != null)
                    hash = hash * 59 + this.Serial.GetHashCode();
                if (this.Vendor != null)
                    hash = hash * 59 + this.Vendor.GetHashCode();
                if (this.AdminInbandInterfaceState != null)
                    hash = hash * 59 + this.AdminInbandInterfaceState.GetHashCode();
                if (this.Cards != null)
                    hash = hash * 59 + this.Cards.GetHashCode();
                if (this.Fanmodules != null)
                    hash = hash * 59 + this.Fanmodules.GetHashCode();
                if (this.FaultSummary != null)
                    hash = hash * 59 + this.FaultSummary.GetHashCode();
                if (this.InbandIpAddress != null)
                    hash = hash * 59 + this.InbandIpAddress.GetHashCode();
                if (this.InbandIpGateway != null)
                    hash = hash * 59 + this.InbandIpGateway.GetHashCode();
                if (this.InbandIpMask != null)
                    hash = hash * 59 + this.InbandIpMask.GetHashCode();
                if (this.InbandVlan != null)
                    hash = hash * 59 + this.InbandVlan.GetHashCode();
                if (this.ManagementContoller != null)
                    hash = hash * 59 + this.ManagementContoller.GetHashCode();
                if (this.ManagementEntity != null)
                    hash = hash * 59 + this.ManagementEntity.GetHashCode();
                if (this.OutOfBandIpAddress != null)
                    hash = hash * 59 + this.OutOfBandIpAddress.GetHashCode();
                if (this.OutOfBandIpGateway != null)
                    hash = hash * 59 + this.OutOfBandIpGateway.GetHashCode();
                if (this.OutOfBandIpMask != null)
                    hash = hash * 59 + this.OutOfBandIpMask.GetHashCode();
                if (this.OutOfBandMac != null)
                    hash = hash * 59 + this.OutOfBandMac.GetHashCode();
                if (this.Psus != null)
                    hash = hash * 59 + this.Psus.GetHashCode();
                if (this.RegisteredDevice != null)
                    hash = hash * 59 + this.RegisteredDevice.GetHashCode();
                if (this.SwitchId != null)
                    hash = hash * 59 + this.SwitchId.GetHashCode();
                if (this.TopSystem != null)
                    hash = hash * 59 + this.TopSystem.GetHashCode();
                if (this.UcsmRunningFirmware != null)
                    hash = hash * 59 + this.UcsmRunningFirmware.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
