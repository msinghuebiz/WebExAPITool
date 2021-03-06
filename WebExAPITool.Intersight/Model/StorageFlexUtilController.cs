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
    /// Storage Flex Util Adapter 
    /// </summary>
    [DataContract]
    public partial class StorageFlexUtilController :  IEquatable<StorageFlexUtilController>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageFlexUtilController" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="ComputeBoard">ComputeBoard.</param>
        /// <param name="ControllerName">ControllerName.</param>
        /// <param name="ControllerStatus">ControllerStatus.</param>
        /// <param name="FfControllerId">FfControllerId.</param>
        /// <param name="FlexUtilPhysicalDrives">FlexUtilPhysicalDrives.</param>
        /// <param name="FlexUtilVirtualDrives">FlexUtilVirtualDrives.</param>
        /// <param name="InternalState">InternalState.</param>
        /// <param name="RegisteredDevice">RegisteredDevice.</param>
        public StorageFlexUtilController(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), ComputeBoardRef ComputeBoard = default(ComputeBoardRef), string ControllerName = default(string), string ControllerStatus = default(string), string FfControllerId = default(string), List<StorageFlexUtilPhysicalDriveRef> FlexUtilPhysicalDrives = default(List<StorageFlexUtilPhysicalDriveRef>), List<StorageFlexUtilVirtualDriveRef> FlexUtilVirtualDrives = default(List<StorageFlexUtilVirtualDriveRef>), string InternalState = default(string), AssetDeviceRegistrationRef RegisteredDevice = default(AssetDeviceRegistrationRef))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.ComputeBoard = ComputeBoard;
            this.ControllerName = ControllerName;
            this.ControllerStatus = ControllerStatus;
            this.FfControllerId = FfControllerId;
            this.FlexUtilPhysicalDrives = FlexUtilPhysicalDrives;
            this.FlexUtilVirtualDrives = FlexUtilVirtualDrives;
            this.InternalState = InternalState;
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
        /// Gets or Sets ComputeBoard
        /// </summary>
        [DataMember(Name="ComputeBoard", EmitDefaultValue=false)]
        public ComputeBoardRef ComputeBoard { get; set; }

        /// <summary>
        /// Gets or Sets ControllerName
        /// </summary>
        [DataMember(Name="ControllerName", EmitDefaultValue=false)]
        public string ControllerName { get; set; }

        /// <summary>
        /// Gets or Sets ControllerStatus
        /// </summary>
        [DataMember(Name="ControllerStatus", EmitDefaultValue=false)]
        public string ControllerStatus { get; set; }

        /// <summary>
        /// Gets or Sets FfControllerId
        /// </summary>
        [DataMember(Name="FfControllerId", EmitDefaultValue=false)]
        public string FfControllerId { get; set; }

        /// <summary>
        /// Gets or Sets FlexUtilPhysicalDrives
        /// </summary>
        [DataMember(Name="FlexUtilPhysicalDrives", EmitDefaultValue=false)]
        public List<StorageFlexUtilPhysicalDriveRef> FlexUtilPhysicalDrives { get; set; }

        /// <summary>
        /// Gets or Sets FlexUtilVirtualDrives
        /// </summary>
        [DataMember(Name="FlexUtilVirtualDrives", EmitDefaultValue=false)]
        public List<StorageFlexUtilVirtualDriveRef> FlexUtilVirtualDrives { get; set; }

        /// <summary>
        /// Gets or Sets InternalState
        /// </summary>
        [DataMember(Name="InternalState", EmitDefaultValue=false)]
        public string InternalState { get; set; }

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
            sb.Append("class StorageFlexUtilController {\n");
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
            sb.Append("  ComputeBoard: ").Append(ComputeBoard).Append("\n");
            sb.Append("  ControllerName: ").Append(ControllerName).Append("\n");
            sb.Append("  ControllerStatus: ").Append(ControllerStatus).Append("\n");
            sb.Append("  FfControllerId: ").Append(FfControllerId).Append("\n");
            sb.Append("  FlexUtilPhysicalDrives: ").Append(FlexUtilPhysicalDrives).Append("\n");
            sb.Append("  FlexUtilVirtualDrives: ").Append(FlexUtilVirtualDrives).Append("\n");
            sb.Append("  InternalState: ").Append(InternalState).Append("\n");
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
            return this.Equals(obj as StorageFlexUtilController);
        }

        /// <summary>
        /// Returns true if StorageFlexUtilController instances are equal
        /// </summary>
        /// <param name="other">Instance of StorageFlexUtilController to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StorageFlexUtilController other)
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
                    this.ComputeBoard == other.ComputeBoard ||
                    this.ComputeBoard != null &&
                    this.ComputeBoard.Equals(other.ComputeBoard)
                ) && 
                (
                    this.ControllerName == other.ControllerName ||
                    this.ControllerName != null &&
                    this.ControllerName.Equals(other.ControllerName)
                ) && 
                (
                    this.ControllerStatus == other.ControllerStatus ||
                    this.ControllerStatus != null &&
                    this.ControllerStatus.Equals(other.ControllerStatus)
                ) && 
                (
                    this.FfControllerId == other.FfControllerId ||
                    this.FfControllerId != null &&
                    this.FfControllerId.Equals(other.FfControllerId)
                ) && 
                (
                    this.FlexUtilPhysicalDrives == other.FlexUtilPhysicalDrives ||
                    this.FlexUtilPhysicalDrives != null &&
                    this.FlexUtilPhysicalDrives.SequenceEqual(other.FlexUtilPhysicalDrives)
                ) && 
                (
                    this.FlexUtilVirtualDrives == other.FlexUtilVirtualDrives ||
                    this.FlexUtilVirtualDrives != null &&
                    this.FlexUtilVirtualDrives.SequenceEqual(other.FlexUtilVirtualDrives)
                ) && 
                (
                    this.InternalState == other.InternalState ||
                    this.InternalState != null &&
                    this.InternalState.Equals(other.InternalState)
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
                if (this.ComputeBoard != null)
                    hash = hash * 59 + this.ComputeBoard.GetHashCode();
                if (this.ControllerName != null)
                    hash = hash * 59 + this.ControllerName.GetHashCode();
                if (this.ControllerStatus != null)
                    hash = hash * 59 + this.ControllerStatus.GetHashCode();
                if (this.FfControllerId != null)
                    hash = hash * 59 + this.FfControllerId.GetHashCode();
                if (this.FlexUtilPhysicalDrives != null)
                    hash = hash * 59 + this.FlexUtilPhysicalDrives.GetHashCode();
                if (this.FlexUtilVirtualDrives != null)
                    hash = hash * 59 + this.FlexUtilVirtualDrives.GetHashCode();
                if (this.InternalState != null)
                    hash = hash * 59 + this.InternalState.GetHashCode();
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
