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
    /// Interface that provides access to the management controller 
    /// </summary>
    [DataContract]
    public partial class ManagementInterface :  IEquatable<ManagementInterface>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementInterface" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="ManagementController">ManagementController.</param>
        /// <param name="RegisteredDevice">RegisteredDevice.</param>
        public ManagementInterface(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), ManagementControllerRef ManagementController = default(ManagementControllerRef), AssetDeviceRegistrationRef RegisteredDevice = default(AssetDeviceRegistrationRef))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.ManagementController = ManagementController;
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
        /// Gets or Sets Gateway
        /// </summary>
        [DataMember(Name="Gateway", EmitDefaultValue=false)]
        public string Gateway { get; private set; }

        /// <summary>
        /// Gets or Sets IpAddress
        /// </summary>
        [DataMember(Name="IpAddress", EmitDefaultValue=false)]
        public string IpAddress { get; private set; }

        /// <summary>
        /// Gets or Sets MacAddress
        /// </summary>
        [DataMember(Name="MacAddress", EmitDefaultValue=false)]
        public string MacAddress { get; private set; }

        /// <summary>
        /// Gets or Sets ManagementController
        /// </summary>
        [DataMember(Name="ManagementController", EmitDefaultValue=false)]
        public ManagementControllerRef ManagementController { get; set; }

        /// <summary>
        /// Gets or Sets Mask
        /// </summary>
        [DataMember(Name="Mask", EmitDefaultValue=false)]
        public string Mask { get; private set; }

        /// <summary>
        /// Gets or Sets RegisteredDevice
        /// </summary>
        [DataMember(Name="RegisteredDevice", EmitDefaultValue=false)]
        public AssetDeviceRegistrationRef RegisteredDevice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManagementInterface {\n");
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
            sb.Append("  Gateway: ").Append(Gateway).Append("\n");
            sb.Append("  IpAddress: ").Append(IpAddress).Append("\n");
            sb.Append("  MacAddress: ").Append(MacAddress).Append("\n");
            sb.Append("  ManagementController: ").Append(ManagementController).Append("\n");
            sb.Append("  Mask: ").Append(Mask).Append("\n");
            sb.Append("  RegisteredDevice: ").Append(RegisteredDevice).Append("\n");
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
            return this.Equals(obj as ManagementInterface);
        }

        /// <summary>
        /// Returns true if ManagementInterface instances are equal
        /// </summary>
        /// <param name="other">Instance of ManagementInterface to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManagementInterface other)
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
                    this.Gateway == other.Gateway ||
                    this.Gateway != null &&
                    this.Gateway.Equals(other.Gateway)
                ) && 
                (
                    this.IpAddress == other.IpAddress ||
                    this.IpAddress != null &&
                    this.IpAddress.Equals(other.IpAddress)
                ) && 
                (
                    this.MacAddress == other.MacAddress ||
                    this.MacAddress != null &&
                    this.MacAddress.Equals(other.MacAddress)
                ) && 
                (
                    this.ManagementController == other.ManagementController ||
                    this.ManagementController != null &&
                    this.ManagementController.Equals(other.ManagementController)
                ) && 
                (
                    this.Mask == other.Mask ||
                    this.Mask != null &&
                    this.Mask.Equals(other.Mask)
                ) && 
                (
                    this.RegisteredDevice == other.RegisteredDevice ||
                    this.RegisteredDevice != null &&
                    this.RegisteredDevice.Equals(other.RegisteredDevice)
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
                if (this.Gateway != null)
                    hash = hash * 59 + this.Gateway.GetHashCode();
                if (this.IpAddress != null)
                    hash = hash * 59 + this.IpAddress.GetHashCode();
                if (this.MacAddress != null)
                    hash = hash * 59 + this.MacAddress.GetHashCode();
                if (this.ManagementController != null)
                    hash = hash * 59 + this.ManagementController.GetHashCode();
                if (this.Mask != null)
                    hash = hash * 59 + this.Mask.GetHashCode();
                if (this.RegisteredDevice != null)
                    hash = hash * 59 + this.RegisteredDevice.GetHashCode();
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
