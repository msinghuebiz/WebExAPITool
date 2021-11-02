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
    /// FirmwareUpgrade
    /// </summary>
    [DataContract]
    public partial class FirmwareUpgrade :  IEquatable<FirmwareUpgrade>, IValidatableObject
    {
        /// <summary>
        /// Desired upgrade mode to choose either direct download based upgrade or network share upgrade   
        /// </summary>
        /// <value>Desired upgrade mode to choose either direct download based upgrade or network share upgrade   </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UpgradeTypeEnum
        {
            
            /// <summary>
            /// Enum Directupgrade for "direct_upgrade"
            /// </summary>
            [EnumMember(Value = "direct_upgrade")]
            Directupgrade,
            
            /// <summary>
            /// Enum Networkupgrade for "network_upgrade"
            /// </summary>
            [EnumMember(Value = "network_upgrade")]
            Networkupgrade
        }

        /// <summary>
        /// Desired upgrade mode to choose either direct download based upgrade or network share upgrade   
        /// </summary>
        /// <value>Desired upgrade mode to choose either direct download based upgrade or network share upgrade   </value>
        [DataMember(Name="UpgradeType", EmitDefaultValue=false)]
        public UpgradeTypeEnum? UpgradeType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FirmwareUpgrade" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="Device">Device.</param>
        /// <param name="DirectDownload">Direct download options in case the upgradeType is direct download based upgrade  .</param>
        /// <param name="Distributable">Distributable.</param>
        /// <param name="NetworkShare">Network share options in case of the upgradeType is network share based upgrade  .</param>
        /// <param name="Server">Server.</param>
        /// <param name="UpgradeStatus">UpgradeStatus.</param>
        /// <param name="UpgradeType">Desired upgrade mode to choose either direct download based upgrade or network share upgrade    (default to UpgradeTypeEnum.Directupgrade).</param>
        public FirmwareUpgrade(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), AssetDeviceRegistrationRef Device = default(AssetDeviceRegistrationRef), FirmwareDirectDownload DirectDownload = default(FirmwareDirectDownload), FirmwareDistributableRef Distributable = default(FirmwareDistributableRef), FirmwareNetworkShare NetworkShare = default(FirmwareNetworkShare), ComputeRackUnitRef Server = default(ComputeRackUnitRef), FirmwareUpgradeStatusRef UpgradeStatus = default(FirmwareUpgradeStatusRef), UpgradeTypeEnum? UpgradeType = UpgradeTypeEnum.Directupgrade)
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.Device = Device;
            this.DirectDownload = DirectDownload;
            this.Distributable = Distributable;
            this.NetworkShare = NetworkShare;
            this.Server = Server;
            this.UpgradeStatus = UpgradeStatus;
            // use default value if no "UpgradeType" provided
            if (UpgradeType == null)
            {
                this.UpgradeType = UpgradeTypeEnum.Directupgrade;
            }
            else
            {
                this.UpgradeType = UpgradeType;
            }
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
        /// Gets or Sets Device
        /// </summary>
        [DataMember(Name="Device", EmitDefaultValue=false)]
        public AssetDeviceRegistrationRef Device { get; set; }

        /// <summary>
        /// Direct download options in case the upgradeType is direct download based upgrade  
        /// </summary>
        /// <value>Direct download options in case the upgradeType is direct download based upgrade  </value>
        [DataMember(Name="DirectDownload", EmitDefaultValue=false)]
        public FirmwareDirectDownload DirectDownload { get; set; }

        /// <summary>
        /// Gets or Sets Distributable
        /// </summary>
        [DataMember(Name="Distributable", EmitDefaultValue=false)]
        public FirmwareDistributableRef Distributable { get; set; }

        /// <summary>
        /// Network share options in case of the upgradeType is network share based upgrade  
        /// </summary>
        /// <value>Network share options in case of the upgradeType is network share based upgrade  </value>
        [DataMember(Name="NetworkShare", EmitDefaultValue=false)]
        public FirmwareNetworkShare NetworkShare { get; set; }

        /// <summary>
        /// Gets or Sets Server
        /// </summary>
        [DataMember(Name="Server", EmitDefaultValue=false)]
        public ComputeRackUnitRef Server { get; set; }

        /// <summary>
        /// Gets or Sets UpgradeStatus
        /// </summary>
        [DataMember(Name="UpgradeStatus", EmitDefaultValue=false)]
        public FirmwareUpgradeStatusRef UpgradeStatus { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareUpgrade {\n");
            sb.Append("  AccountMoid: ").Append(AccountMoid).Append("\n");
            sb.Append("  Ancestors: ").Append(Ancestors).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  ModTime: ").Append(ModTime).Append("\n");
            sb.Append("  Moid: ").Append(Moid).Append("\n");
            sb.Append("  ObjectType: ").Append(ObjectType).Append("\n");
            sb.Append("  Owners: ").Append(Owners).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Device: ").Append(Device).Append("\n");
            sb.Append("  DirectDownload: ").Append(DirectDownload).Append("\n");
            sb.Append("  Distributable: ").Append(Distributable).Append("\n");
            sb.Append("  NetworkShare: ").Append(NetworkShare).Append("\n");
            sb.Append("  Server: ").Append(Server).Append("\n");
            sb.Append("  UpgradeStatus: ").Append(UpgradeStatus).Append("\n");
            sb.Append("  UpgradeType: ").Append(UpgradeType).Append("\n");
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
            return this.Equals(obj as FirmwareUpgrade);
        }

        /// <summary>
        /// Returns true if FirmwareUpgrade instances are equal
        /// </summary>
        /// <param name="other">Instance of FirmwareUpgrade to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FirmwareUpgrade other)
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
                    this.Device == other.Device ||
                    this.Device != null &&
                    this.Device.Equals(other.Device)
                ) && 
                (
                    this.DirectDownload == other.DirectDownload ||
                    this.DirectDownload != null &&
                    this.DirectDownload.Equals(other.DirectDownload)
                ) && 
                (
                    this.Distributable == other.Distributable ||
                    this.Distributable != null &&
                    this.Distributable.Equals(other.Distributable)
                ) && 
                (
                    this.NetworkShare == other.NetworkShare ||
                    this.NetworkShare != null &&
                    this.NetworkShare.Equals(other.NetworkShare)
                ) && 
                (
                    this.Server == other.Server ||
                    this.Server != null &&
                    this.Server.Equals(other.Server)
                ) && 
                (
                    this.UpgradeStatus == other.UpgradeStatus ||
                    this.UpgradeStatus != null &&
                    this.UpgradeStatus.Equals(other.UpgradeStatus)
                ) && 
                (
                    this.UpgradeType == other.UpgradeType ||
                    this.UpgradeType != null &&
                    this.UpgradeType.Equals(other.UpgradeType)
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
                if (this.Device != null)
                    hash = hash * 59 + this.Device.GetHashCode();
                if (this.DirectDownload != null)
                    hash = hash * 59 + this.DirectDownload.GetHashCode();
                if (this.Distributable != null)
                    hash = hash * 59 + this.Distributable.GetHashCode();
                if (this.NetworkShare != null)
                    hash = hash * 59 + this.NetworkShare.GetHashCode();
                if (this.Server != null)
                    hash = hash * 59 + this.Server.GetHashCode();
                if (this.UpgradeStatus != null)
                    hash = hash * 59 + this.UpgradeStatus.GetHashCode();
                if (this.UpgradeType != null)
                    hash = hash * 59 + this.UpgradeType.GetHashCode();
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
