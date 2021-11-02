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
    /// Provides management controls access to an endpoint 
    /// </summary>
    [DataContract]
    public partial class ManagementController :  IEquatable<ManagementController>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementController" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="AdapterUnit">AdapterUnit.</param>
        /// <param name="ComputeBlade">ComputeBlade.</param>
        /// <param name="ComputeRackUnit">ComputeRackUnit.</param>
        /// <param name="ManagementInterfaces">ManagementInterfaces.</param>
        /// <param name="NetworkElement">NetworkElement.</param>
        /// <param name="RegisteredDevice">RegisteredDevice.</param>
        /// <param name="RunningFirmware">RunningFirmware.</param>
        /// <param name="StorageSasExpander">StorageSasExpander.</param>
        /// <param name="TopSystem">TopSystem.</param>
        public ManagementController(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), AdapterUnitRef AdapterUnit = default(AdapterUnitRef), ComputeBladeRef ComputeBlade = default(ComputeBladeRef), ComputeRackUnitRef ComputeRackUnit = default(ComputeRackUnitRef), List<ManagementInterfaceRef> ManagementInterfaces = default(List<ManagementInterfaceRef>), NetworkElementRef NetworkElement = default(NetworkElementRef), AssetDeviceRegistrationRef RegisteredDevice = default(AssetDeviceRegistrationRef), List<FirmwareRunningFirmwareRef> RunningFirmware = default(List<FirmwareRunningFirmwareRef>), StorageSasExpanderRef StorageSasExpander = default(StorageSasExpanderRef), TopSystemRef TopSystem = default(TopSystemRef))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.AdapterUnit = AdapterUnit;
            this.ComputeBlade = ComputeBlade;
            this.ComputeRackUnit = ComputeRackUnit;
            this.ManagementInterfaces = ManagementInterfaces;
            this.NetworkElement = NetworkElement;
            this.RegisteredDevice = RegisteredDevice;
            this.RunningFirmware = RunningFirmware;
            this.StorageSasExpander = StorageSasExpander;
            this.TopSystem = TopSystem;
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
        /// Gets or Sets AdapterUnit
        /// </summary>
        [DataMember(Name="AdapterUnit", EmitDefaultValue=false)]
        public AdapterUnitRef AdapterUnit { get; set; }

        /// <summary>
        /// Gets or Sets ComputeBlade
        /// </summary>
        [DataMember(Name="ComputeBlade", EmitDefaultValue=false)]
        public ComputeBladeRef ComputeBlade { get; set; }

        /// <summary>
        /// Gets or Sets ComputeRackUnit
        /// </summary>
        [DataMember(Name="ComputeRackUnit", EmitDefaultValue=false)]
        public ComputeRackUnitRef ComputeRackUnit { get; set; }

        /// <summary>
        /// Gets or Sets ManagementInterfaces
        /// </summary>
        [DataMember(Name="ManagementInterfaces", EmitDefaultValue=false)]
        public List<ManagementInterfaceRef> ManagementInterfaces { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        [DataMember(Name="Model", EmitDefaultValue=false)]
        public string Model { get; private set; }

        /// <summary>
        /// Gets or Sets NetworkElement
        /// </summary>
        [DataMember(Name="NetworkElement", EmitDefaultValue=false)]
        public NetworkElementRef NetworkElement { get; set; }

        /// <summary>
        /// Gets or Sets RegisteredDevice
        /// </summary>
        [DataMember(Name="RegisteredDevice", EmitDefaultValue=false)]
        public AssetDeviceRegistrationRef RegisteredDevice { get; set; }

        /// <summary>
        /// Gets or Sets RunningFirmware
        /// </summary>
        [DataMember(Name="RunningFirmware", EmitDefaultValue=false)]
        public List<FirmwareRunningFirmwareRef> RunningFirmware { get; set; }

        /// <summary>
        /// Gets or Sets StorageSasExpander
        /// </summary>
        [DataMember(Name="StorageSasExpander", EmitDefaultValue=false)]
        public StorageSasExpanderRef StorageSasExpander { get; set; }

        /// <summary>
        /// Gets or Sets TopSystem
        /// </summary>
        [DataMember(Name="TopSystem", EmitDefaultValue=false)]
        public TopSystemRef TopSystem { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManagementController {\n");
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
            sb.Append("  AdapterUnit: ").Append(AdapterUnit).Append("\n");
            sb.Append("  ComputeBlade: ").Append(ComputeBlade).Append("\n");
            sb.Append("  ComputeRackUnit: ").Append(ComputeRackUnit).Append("\n");
            sb.Append("  ManagementInterfaces: ").Append(ManagementInterfaces).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  NetworkElement: ").Append(NetworkElement).Append("\n");
            sb.Append("  RegisteredDevice: ").Append(RegisteredDevice).Append("\n");
            sb.Append("  RunningFirmware: ").Append(RunningFirmware).Append("\n");
            sb.Append("  StorageSasExpander: ").Append(StorageSasExpander).Append("\n");
            sb.Append("  TopSystem: ").Append(TopSystem).Append("\n");
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
            return this.Equals(obj as ManagementController);
        }

        /// <summary>
        /// Returns true if ManagementController instances are equal
        /// </summary>
        /// <param name="other">Instance of ManagementController to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManagementController other)
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
                    this.AdapterUnit == other.AdapterUnit ||
                    this.AdapterUnit != null &&
                    this.AdapterUnit.Equals(other.AdapterUnit)
                ) && 
                (
                    this.ComputeBlade == other.ComputeBlade ||
                    this.ComputeBlade != null &&
                    this.ComputeBlade.Equals(other.ComputeBlade)
                ) && 
                (
                    this.ComputeRackUnit == other.ComputeRackUnit ||
                    this.ComputeRackUnit != null &&
                    this.ComputeRackUnit.Equals(other.ComputeRackUnit)
                ) && 
                (
                    this.ManagementInterfaces == other.ManagementInterfaces ||
                    this.ManagementInterfaces != null &&
                    this.ManagementInterfaces.SequenceEqual(other.ManagementInterfaces)
                ) && 
                (
                    this.Model == other.Model ||
                    this.Model != null &&
                    this.Model.Equals(other.Model)
                ) && 
                (
                    this.NetworkElement == other.NetworkElement ||
                    this.NetworkElement != null &&
                    this.NetworkElement.Equals(other.NetworkElement)
                ) && 
                (
                    this.RegisteredDevice == other.RegisteredDevice ||
                    this.RegisteredDevice != null &&
                    this.RegisteredDevice.Equals(other.RegisteredDevice)
                ) && 
                (
                    this.RunningFirmware == other.RunningFirmware ||
                    this.RunningFirmware != null &&
                    this.RunningFirmware.SequenceEqual(other.RunningFirmware)
                ) && 
                (
                    this.StorageSasExpander == other.StorageSasExpander ||
                    this.StorageSasExpander != null &&
                    this.StorageSasExpander.Equals(other.StorageSasExpander)
                ) && 
                (
                    this.TopSystem == other.TopSystem ||
                    this.TopSystem != null &&
                    this.TopSystem.Equals(other.TopSystem)
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
                if (this.AdapterUnit != null)
                    hash = hash * 59 + this.AdapterUnit.GetHashCode();
                if (this.ComputeBlade != null)
                    hash = hash * 59 + this.ComputeBlade.GetHashCode();
                if (this.ComputeRackUnit != null)
                    hash = hash * 59 + this.ComputeRackUnit.GetHashCode();
                if (this.ManagementInterfaces != null)
                    hash = hash * 59 + this.ManagementInterfaces.GetHashCode();
                if (this.Model != null)
                    hash = hash * 59 + this.Model.GetHashCode();
                if (this.NetworkElement != null)
                    hash = hash * 59 + this.NetworkElement.GetHashCode();
                if (this.RegisteredDevice != null)
                    hash = hash * 59 + this.RegisteredDevice.GetHashCode();
                if (this.RunningFirmware != null)
                    hash = hash * 59 + this.RunningFirmware.GetHashCode();
                if (this.StorageSasExpander != null)
                    hash = hash * 59 + this.StorageSasExpander.GetHashCode();
                if (this.TopSystem != null)
                    hash = hash * 59 + this.TopSystem.GetHashCode();
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
