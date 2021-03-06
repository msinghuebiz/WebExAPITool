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
    /// Physical / Virtual port of an adapter as seen by the host 
    /// </summary>
    [DataContract]
    public partial class AdapterHostEthInterface :  IEquatable<AdapterHostEthInterface>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterHostEthInterface" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="AdapterUnit">AdapterUnit.</param>
        /// <param name="RegisteredDevice">RegisteredDevice.</param>
        public AdapterHostEthInterface(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), AdapterUnitRef AdapterUnit = default(AdapterUnitRef), AssetDeviceRegistrationRef RegisteredDevice = default(AssetDeviceRegistrationRef))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.AdapterUnit = AdapterUnit;
            this.RegisteredDevice = RegisteredDevice;
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
        /// Gets or Sets AdapterUnit
        /// </summary>
        [DataMember(Name="AdapterUnit", EmitDefaultValue=false)]
        public AdapterUnitRef AdapterUnit { get; set; }

        /// <summary>
        /// Gets or Sets AdminState
        /// </summary>
        [DataMember(Name="AdminState", EmitDefaultValue=false)]
        public string AdminState { get; private set; }

        /// <summary>
        /// Gets or Sets EpDn
        /// </summary>
        [DataMember(Name="EpDn", EmitDefaultValue=false)]
        public string EpDn { get; private set; }

        /// <summary>
        /// Gets or Sets HostEthInterfaceId
        /// </summary>
        [DataMember(Name="HostEthInterfaceId", EmitDefaultValue=false)]
        public long? HostEthInterfaceId { get; private set; }

        /// <summary>
        /// Gets or Sets InterfaceType
        /// </summary>
        [DataMember(Name="InterfaceType", EmitDefaultValue=false)]
        public string InterfaceType { get; private set; }

        /// <summary>
        /// Gets or Sets MacAddress
        /// </summary>
        [DataMember(Name="MacAddress", EmitDefaultValue=false)]
        public string MacAddress { get; private set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets OperState
        /// </summary>
        [DataMember(Name="OperState", EmitDefaultValue=false)]
        public string OperState { get; private set; }

        /// <summary>
        /// Gets or Sets Operability
        /// </summary>
        [DataMember(Name="Operability", EmitDefaultValue=false)]
        public string Operability { get; private set; }

        /// <summary>
        /// Gets or Sets OriginalMacAddress
        /// </summary>
        [DataMember(Name="OriginalMacAddress", EmitDefaultValue=false)]
        public string OriginalMacAddress { get; private set; }

        /// <summary>
        /// Gets or Sets PciAddr
        /// </summary>
        [DataMember(Name="PciAddr", EmitDefaultValue=false)]
        public string PciAddr { get; private set; }

        /// <summary>
        /// Gets or Sets PeerDn
        /// </summary>
        [DataMember(Name="PeerDn", EmitDefaultValue=false)]
        public string PeerDn { get; private set; }

        /// <summary>
        /// Gets or Sets RegisteredDevice
        /// </summary>
        [DataMember(Name="RegisteredDevice", EmitDefaultValue=false)]
        public AssetDeviceRegistrationRef RegisteredDevice { get; set; }

        /// <summary>
        /// Gets or Sets VirtualizationPreference
        /// </summary>
        [DataMember(Name="VirtualizationPreference", EmitDefaultValue=false)]
        public string VirtualizationPreference { get; private set; }

        /// <summary>
        /// Gets or Sets VnicDn
        /// </summary>
        [DataMember(Name="VnicDn", EmitDefaultValue=false)]
        public string VnicDn { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AdapterHostEthInterface {\n");
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
            sb.Append("  AdapterUnit: ").Append(AdapterUnit).Append("\n");
            sb.Append("  AdminState: ").Append(AdminState).Append("\n");
            sb.Append("  EpDn: ").Append(EpDn).Append("\n");
            sb.Append("  HostEthInterfaceId: ").Append(HostEthInterfaceId).Append("\n");
            sb.Append("  InterfaceType: ").Append(InterfaceType).Append("\n");
            sb.Append("  MacAddress: ").Append(MacAddress).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OperState: ").Append(OperState).Append("\n");
            sb.Append("  Operability: ").Append(Operability).Append("\n");
            sb.Append("  OriginalMacAddress: ").Append(OriginalMacAddress).Append("\n");
            sb.Append("  PciAddr: ").Append(PciAddr).Append("\n");
            sb.Append("  PeerDn: ").Append(PeerDn).Append("\n");
            sb.Append("  RegisteredDevice: ").Append(RegisteredDevice).Append("\n");
            sb.Append("  VirtualizationPreference: ").Append(VirtualizationPreference).Append("\n");
            sb.Append("  VnicDn: ").Append(VnicDn).Append("\n");
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
            return this.Equals(obj as AdapterHostEthInterface);
        }

        /// <summary>
        /// Returns true if AdapterHostEthInterface instances are equal
        /// </summary>
        /// <param name="other">Instance of AdapterHostEthInterface to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AdapterHostEthInterface other)
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
                    this.AdapterUnit == other.AdapterUnit ||
                    this.AdapterUnit != null &&
                    this.AdapterUnit.Equals(other.AdapterUnit)
                ) && 
                (
                    this.AdminState == other.AdminState ||
                    this.AdminState != null &&
                    this.AdminState.Equals(other.AdminState)
                ) && 
                (
                    this.EpDn == other.EpDn ||
                    this.EpDn != null &&
                    this.EpDn.Equals(other.EpDn)
                ) && 
                (
                    this.HostEthInterfaceId == other.HostEthInterfaceId ||
                    this.HostEthInterfaceId != null &&
                    this.HostEthInterfaceId.Equals(other.HostEthInterfaceId)
                ) && 
                (
                    this.InterfaceType == other.InterfaceType ||
                    this.InterfaceType != null &&
                    this.InterfaceType.Equals(other.InterfaceType)
                ) && 
                (
                    this.MacAddress == other.MacAddress ||
                    this.MacAddress != null &&
                    this.MacAddress.Equals(other.MacAddress)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.OperState == other.OperState ||
                    this.OperState != null &&
                    this.OperState.Equals(other.OperState)
                ) && 
                (
                    this.Operability == other.Operability ||
                    this.Operability != null &&
                    this.Operability.Equals(other.Operability)
                ) && 
                (
                    this.OriginalMacAddress == other.OriginalMacAddress ||
                    this.OriginalMacAddress != null &&
                    this.OriginalMacAddress.Equals(other.OriginalMacAddress)
                ) && 
                (
                    this.PciAddr == other.PciAddr ||
                    this.PciAddr != null &&
                    this.PciAddr.Equals(other.PciAddr)
                ) && 
                (
                    this.PeerDn == other.PeerDn ||
                    this.PeerDn != null &&
                    this.PeerDn.Equals(other.PeerDn)
                ) && 
                (
                    this.RegisteredDevice == other.RegisteredDevice ||
                    this.RegisteredDevice != null &&
                    this.RegisteredDevice.Equals(other.RegisteredDevice)
                ) && 
                (
                    this.VirtualizationPreference == other.VirtualizationPreference ||
                    this.VirtualizationPreference != null &&
                    this.VirtualizationPreference.Equals(other.VirtualizationPreference)
                ) && 
                (
                    this.VnicDn == other.VnicDn ||
                    this.VnicDn != null &&
                    this.VnicDn.Equals(other.VnicDn)
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
                if (this.AdapterUnit != null)
                    hash = hash * 59 + this.AdapterUnit.GetHashCode();
                if (this.AdminState != null)
                    hash = hash * 59 + this.AdminState.GetHashCode();
                if (this.EpDn != null)
                    hash = hash * 59 + this.EpDn.GetHashCode();
                if (this.HostEthInterfaceId != null)
                    hash = hash * 59 + this.HostEthInterfaceId.GetHashCode();
                if (this.InterfaceType != null)
                    hash = hash * 59 + this.InterfaceType.GetHashCode();
                if (this.MacAddress != null)
                    hash = hash * 59 + this.MacAddress.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.OperState != null)
                    hash = hash * 59 + this.OperState.GetHashCode();
                if (this.Operability != null)
                    hash = hash * 59 + this.Operability.GetHashCode();
                if (this.OriginalMacAddress != null)
                    hash = hash * 59 + this.OriginalMacAddress.GetHashCode();
                if (this.PciAddr != null)
                    hash = hash * 59 + this.PciAddr.GetHashCode();
                if (this.PeerDn != null)
                    hash = hash * 59 + this.PeerDn.GetHashCode();
                if (this.RegisteredDevice != null)
                    hash = hash * 59 + this.RegisteredDevice.GetHashCode();
                if (this.VirtualizationPreference != null)
                    hash = hash * 59 + this.VirtualizationPreference.GetHashCode();
                if (this.VnicDn != null)
                    hash = hash * 59 + this.VnicDn.GetHashCode();
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
