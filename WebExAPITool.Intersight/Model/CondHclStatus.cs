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
    /// The HCL status of a managed object after we have validated the managed object components&#39; firmware and drivers against the HCL. 
    /// </summary>
    [DataContract]
    public partial class CondHclStatus :  IEquatable<CondHclStatus>, IValidatableObject
    {
        /// <summary>
        /// the reason for the HCL status. It will be one of the following \&quot;Missing-Os-Info\&quot; - we are missing os information in the inventory from the device connector \&quot;Incompatible-Components\&quot; - we have 1 or more components with \&quot;Not-Validated\&quot; status \&quot;Compatible\&quot; - all the components have \&quot;Validated\&quot; status  
        /// </summary>
        /// <value>the reason for the HCL status. It will be one of the following \&quot;Missing-Os-Info\&quot; - we are missing os information in the inventory from the device connector \&quot;Incompatible-Components\&quot; - we have 1 or more components with \&quot;Not-Validated\&quot; status \&quot;Compatible\&quot; - all the components have \&quot;Validated\&quot; status  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReasonEnum
        {
            
            /// <summary>
            /// Enum MissingOsInfo for "Missing-Os-Info"
            /// </summary>
            [EnumMember(Value = "Missing-Os-Info")]
            MissingOsInfo,
            
            /// <summary>
            /// Enum IncompatibleComponents for "Incompatible-Components"
            /// </summary>
            [EnumMember(Value = "Incompatible-Components")]
            IncompatibleComponents,
            
            /// <summary>
            /// Enum Compatible for "Compatible"
            /// </summary>
            [EnumMember(Value = "Compatible")]
            Compatible
        }

        /// <summary>
        /// the status of the managed objects compatibility against HCL. The status can be one of the following \&quot;Unknown\&quot; - we do not have enough information to evaluate against the HCL data \&quot;Validated\&quot; - we have validated all components against the HCL and they all have \&quot;Validated\&quot; status \&quot;Not-Validated\&quot; - we have validated all components against the HCL and 1 or more has \&quot;Not-Validated\&quot; status   
        /// </summary>
        /// <value>the status of the managed objects compatibility against HCL. The status can be one of the following \&quot;Unknown\&quot; - we do not have enough information to evaluate against the HCL data \&quot;Validated\&quot; - we have validated all components against the HCL and they all have \&quot;Validated\&quot; status \&quot;Not-Validated\&quot; - we have validated all components against the HCL and 1 or more has \&quot;Not-Validated\&quot; status   </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            
            /// <summary>
            /// Enum Incomplete for "Incomplete"
            /// </summary>
            [EnumMember(Value = "Incomplete")]
            Incomplete,
            
            /// <summary>
            /// Enum NotFound for "Not-Found"
            /// </summary>
            [EnumMember(Value = "Not-Found")]
            NotFound,
            
            /// <summary>
            /// Enum Validated for "Validated"
            /// </summary>
            [EnumMember(Value = "Validated")]
            Validated
        }

        /// <summary>
        /// the reason for the HCL status. It will be one of the following \&quot;Missing-Os-Info\&quot; - we are missing os information in the inventory from the device connector \&quot;Incompatible-Components\&quot; - we have 1 or more components with \&quot;Not-Validated\&quot; status \&quot;Compatible\&quot; - all the components have \&quot;Validated\&quot; status  
        /// </summary>
        /// <value>the reason for the HCL status. It will be one of the following \&quot;Missing-Os-Info\&quot; - we are missing os information in the inventory from the device connector \&quot;Incompatible-Components\&quot; - we have 1 or more components with \&quot;Not-Validated\&quot; status \&quot;Compatible\&quot; - all the components have \&quot;Validated\&quot; status  </value>
        [DataMember(Name="Reason", EmitDefaultValue=false)]
        public ReasonEnum? Reason { get; set; }
        /// <summary>
        /// the status of the managed objects compatibility against HCL. The status can be one of the following \&quot;Unknown\&quot; - we do not have enough information to evaluate against the HCL data \&quot;Validated\&quot; - we have validated all components against the HCL and they all have \&quot;Validated\&quot; status \&quot;Not-Validated\&quot; - we have validated all components against the HCL and 1 or more has \&quot;Not-Validated\&quot; status   
        /// </summary>
        /// <value>the status of the managed objects compatibility against HCL. The status can be one of the following \&quot;Unknown\&quot; - we do not have enough information to evaluate against the HCL data \&quot;Validated\&quot; - we have validated all components against the HCL and they all have \&quot;Validated\&quot; status \&quot;Not-Validated\&quot; - we have validated all components against the HCL and 1 or more has \&quot;Not-Validated\&quot; status   </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CondHclStatus" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="Details">a collection of all the HclStatusDetails .</param>
        /// <param name="HclFirmwareVersion">the current CIMC version for the server normalized for querying HCL data  .</param>
        /// <param name="HclModel">the managed object&#39;s model to validate normalized for querying HCL data  .</param>
        /// <param name="HclOsVendor">the OS Vendor for the managed object to validate normalized for querying HCL data. Empty if we are missing this information  .</param>
        /// <param name="HclOsVersion">the OS Version for the managed object to validate normalized for querying HCL data. Empty if we are missing this information  .</param>
        /// <param name="HclProcessor">the managed object&#39;s processor to validate if applicable normalized for querying HCL data. It is left empty if processor is not required for the HCL validation, for example if we are evaluating some other managedObject that is not a server. Currently only server validation is supported.  .</param>
        /// <param name="InvFirmwareVersion">the current CIMC version for the server as received from inventory  .</param>
        /// <param name="InvModel">the managed object&#39;s model to validate as received from the inventory.  .</param>
        /// <param name="InvOsVendor">the OS Vendor for the managed object to validate as received from inventory. Empty if we are missing this information  .</param>
        /// <param name="InvOsVersion">the OS Version for the managed object to validate as received from inventory. Empty if we are missing this information  .</param>
        /// <param name="InvProcessor">the managed object&#39;s processor to validate if applicable as received from inventory. It is left empty if processor is not required for the HCL validation, for example if we are evaluating some other managedObject that is not a server. Currently only server validation is supported.  .</param>
        /// <param name="ManagedObject">specifies the managed object for which this HCLStatus applies .</param>
        /// <param name="Reason">the reason for the HCL status. It will be one of the following \&quot;Missing-Os-Info\&quot; - we are missing os information in the inventory from the device connector \&quot;Incompatible-Components\&quot; - we have 1 or more components with \&quot;Not-Validated\&quot; status \&quot;Compatible\&quot; - all the components have \&quot;Validated\&quot; status   (default to ReasonEnum.MissingOsInfo).</param>
        /// <param name="RegisteredDevice">Relationship to the registered device. We need this in order to correctly set permissions during device claim .</param>
        /// <param name="Status">the status of the managed objects compatibility against HCL. The status can be one of the following \&quot;Unknown\&quot; - we do not have enough information to evaluate against the HCL data \&quot;Validated\&quot; - we have validated all components against the HCL and they all have \&quot;Validated\&quot; status \&quot;Not-Validated\&quot; - we have validated all components against the HCL and 1 or more has \&quot;Not-Validated\&quot; status    (default to StatusEnum.Incomplete).</param>
        public CondHclStatus(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), List<CondHclStatusDetailRef> Details = default(List<CondHclStatusDetailRef>), string HclFirmwareVersion = default(string), string HclModel = default(string), string HclOsVendor = default(string), string HclOsVersion = default(string), string HclProcessor = default(string), string InvFirmwareVersion = default(string), string InvModel = default(string), string InvOsVendor = default(string), string InvOsVersion = default(string), string InvProcessor = default(string), InventoryBaseRef ManagedObject = default(InventoryBaseRef), ReasonEnum? Reason = ReasonEnum.MissingOsInfo, AssetDeviceRegistrationRef RegisteredDevice = default(AssetDeviceRegistrationRef), StatusEnum? Status = StatusEnum.Incomplete)
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.Details = Details;
            this.HclFirmwareVersion = HclFirmwareVersion;
            this.HclModel = HclModel;
            this.HclOsVendor = HclOsVendor;
            this.HclOsVersion = HclOsVersion;
            this.HclProcessor = HclProcessor;
            this.InvFirmwareVersion = InvFirmwareVersion;
            this.InvModel = InvModel;
            this.InvOsVendor = InvOsVendor;
            this.InvOsVersion = InvOsVersion;
            this.InvProcessor = InvProcessor;
            this.ManagedObject = ManagedObject;
            // use default value if no "Reason" provided
            if (Reason == null)
            {
                this.Reason = ReasonEnum.MissingOsInfo;
            }
            else
            {
                this.Reason = Reason;
            }
            this.RegisteredDevice = RegisteredDevice;
            // use default value if no "Status" provided
            if (Status == null)
            {
                this.Status = StatusEnum.Incomplete;
            }
            else
            {
                this.Status = Status;
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
        /// a collection of all the HclStatusDetails 
        /// </summary>
        /// <value>a collection of all the HclStatusDetails </value>
        [DataMember(Name="Details", EmitDefaultValue=false)]
        public List<CondHclStatusDetailRef> Details { get; set; }

        /// <summary>
        /// the current CIMC version for the server normalized for querying HCL data  
        /// </summary>
        /// <value>the current CIMC version for the server normalized for querying HCL data  </value>
        [DataMember(Name="HclFirmwareVersion", EmitDefaultValue=false)]
        public string HclFirmwareVersion { get; set; }

        /// <summary>
        /// the managed object&#39;s model to validate normalized for querying HCL data  
        /// </summary>
        /// <value>the managed object&#39;s model to validate normalized for querying HCL data  </value>
        [DataMember(Name="HclModel", EmitDefaultValue=false)]
        public string HclModel { get; set; }

        /// <summary>
        /// the OS Vendor for the managed object to validate normalized for querying HCL data. Empty if we are missing this information  
        /// </summary>
        /// <value>the OS Vendor for the managed object to validate normalized for querying HCL data. Empty if we are missing this information  </value>
        [DataMember(Name="HclOsVendor", EmitDefaultValue=false)]
        public string HclOsVendor { get; set; }

        /// <summary>
        /// the OS Version for the managed object to validate normalized for querying HCL data. Empty if we are missing this information  
        /// </summary>
        /// <value>the OS Version for the managed object to validate normalized for querying HCL data. Empty if we are missing this information  </value>
        [DataMember(Name="HclOsVersion", EmitDefaultValue=false)]
        public string HclOsVersion { get; set; }

        /// <summary>
        /// the managed object&#39;s processor to validate if applicable normalized for querying HCL data. It is left empty if processor is not required for the HCL validation, for example if we are evaluating some other managedObject that is not a server. Currently only server validation is supported.  
        /// </summary>
        /// <value>the managed object&#39;s processor to validate if applicable normalized for querying HCL data. It is left empty if processor is not required for the HCL validation, for example if we are evaluating some other managedObject that is not a server. Currently only server validation is supported.  </value>
        [DataMember(Name="HclProcessor", EmitDefaultValue=false)]
        public string HclProcessor { get; set; }

        /// <summary>
        /// the current CIMC version for the server as received from inventory  
        /// </summary>
        /// <value>the current CIMC version for the server as received from inventory  </value>
        [DataMember(Name="InvFirmwareVersion", EmitDefaultValue=false)]
        public string InvFirmwareVersion { get; set; }

        /// <summary>
        /// the managed object&#39;s model to validate as received from the inventory.  
        /// </summary>
        /// <value>the managed object&#39;s model to validate as received from the inventory.  </value>
        [DataMember(Name="InvModel", EmitDefaultValue=false)]
        public string InvModel { get; set; }

        /// <summary>
        /// the OS Vendor for the managed object to validate as received from inventory. Empty if we are missing this information  
        /// </summary>
        /// <value>the OS Vendor for the managed object to validate as received from inventory. Empty if we are missing this information  </value>
        [DataMember(Name="InvOsVendor", EmitDefaultValue=false)]
        public string InvOsVendor { get; set; }

        /// <summary>
        /// the OS Version for the managed object to validate as received from inventory. Empty if we are missing this information  
        /// </summary>
        /// <value>the OS Version for the managed object to validate as received from inventory. Empty if we are missing this information  </value>
        [DataMember(Name="InvOsVersion", EmitDefaultValue=false)]
        public string InvOsVersion { get; set; }

        /// <summary>
        /// the managed object&#39;s processor to validate if applicable as received from inventory. It is left empty if processor is not required for the HCL validation, for example if we are evaluating some other managedObject that is not a server. Currently only server validation is supported.  
        /// </summary>
        /// <value>the managed object&#39;s processor to validate if applicable as received from inventory. It is left empty if processor is not required for the HCL validation, for example if we are evaluating some other managedObject that is not a server. Currently only server validation is supported.  </value>
        [DataMember(Name="InvProcessor", EmitDefaultValue=false)]
        public string InvProcessor { get; set; }

        /// <summary>
        /// specifies the managed object for which this HCLStatus applies 
        /// </summary>
        /// <value>specifies the managed object for which this HCLStatus applies </value>
        [DataMember(Name="ManagedObject", EmitDefaultValue=false)]
        public InventoryBaseRef ManagedObject { get; set; }


        /// <summary>
        /// Relationship to the registered device. We need this in order to correctly set permissions during device claim 
        /// </summary>
        /// <value>Relationship to the registered device. We need this in order to correctly set permissions during device claim </value>
        [DataMember(Name="RegisteredDevice", EmitDefaultValue=false)]
        public AssetDeviceRegistrationRef RegisteredDevice { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CondHclStatus {\n");
            sb.Append("  AccountMoid: ").Append(AccountMoid).Append("\n");
            sb.Append("  Ancestors: ").Append(Ancestors).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  ModTime: ").Append(ModTime).Append("\n");
            sb.Append("  Moid: ").Append(Moid).Append("\n");
            sb.Append("  ObjectType: ").Append(ObjectType).Append("\n");
            sb.Append("  Owners: ").Append(Owners).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  HclFirmwareVersion: ").Append(HclFirmwareVersion).Append("\n");
            sb.Append("  HclModel: ").Append(HclModel).Append("\n");
            sb.Append("  HclOsVendor: ").Append(HclOsVendor).Append("\n");
            sb.Append("  HclOsVersion: ").Append(HclOsVersion).Append("\n");
            sb.Append("  HclProcessor: ").Append(HclProcessor).Append("\n");
            sb.Append("  InvFirmwareVersion: ").Append(InvFirmwareVersion).Append("\n");
            sb.Append("  InvModel: ").Append(InvModel).Append("\n");
            sb.Append("  InvOsVendor: ").Append(InvOsVendor).Append("\n");
            sb.Append("  InvOsVersion: ").Append(InvOsVersion).Append("\n");
            sb.Append("  InvProcessor: ").Append(InvProcessor).Append("\n");
            sb.Append("  ManagedObject: ").Append(ManagedObject).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  RegisteredDevice: ").Append(RegisteredDevice).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(obj as CondHclStatus);
        }

        /// <summary>
        /// Returns true if CondHclStatus instances are equal
        /// </summary>
        /// <param name="other">Instance of CondHclStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CondHclStatus other)
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
                    this.Details == other.Details ||
                    this.Details != null &&
                    this.Details.SequenceEqual(other.Details)
                ) && 
                (
                    this.HclFirmwareVersion == other.HclFirmwareVersion ||
                    this.HclFirmwareVersion != null &&
                    this.HclFirmwareVersion.Equals(other.HclFirmwareVersion)
                ) && 
                (
                    this.HclModel == other.HclModel ||
                    this.HclModel != null &&
                    this.HclModel.Equals(other.HclModel)
                ) && 
                (
                    this.HclOsVendor == other.HclOsVendor ||
                    this.HclOsVendor != null &&
                    this.HclOsVendor.Equals(other.HclOsVendor)
                ) && 
                (
                    this.HclOsVersion == other.HclOsVersion ||
                    this.HclOsVersion != null &&
                    this.HclOsVersion.Equals(other.HclOsVersion)
                ) && 
                (
                    this.HclProcessor == other.HclProcessor ||
                    this.HclProcessor != null &&
                    this.HclProcessor.Equals(other.HclProcessor)
                ) && 
                (
                    this.InvFirmwareVersion == other.InvFirmwareVersion ||
                    this.InvFirmwareVersion != null &&
                    this.InvFirmwareVersion.Equals(other.InvFirmwareVersion)
                ) && 
                (
                    this.InvModel == other.InvModel ||
                    this.InvModel != null &&
                    this.InvModel.Equals(other.InvModel)
                ) && 
                (
                    this.InvOsVendor == other.InvOsVendor ||
                    this.InvOsVendor != null &&
                    this.InvOsVendor.Equals(other.InvOsVendor)
                ) && 
                (
                    this.InvOsVersion == other.InvOsVersion ||
                    this.InvOsVersion != null &&
                    this.InvOsVersion.Equals(other.InvOsVersion)
                ) && 
                (
                    this.InvProcessor == other.InvProcessor ||
                    this.InvProcessor != null &&
                    this.InvProcessor.Equals(other.InvProcessor)
                ) && 
                (
                    this.ManagedObject == other.ManagedObject ||
                    this.ManagedObject != null &&
                    this.ManagedObject.Equals(other.ManagedObject)
                ) && 
                (
                    this.Reason == other.Reason ||
                    this.Reason != null &&
                    this.Reason.Equals(other.Reason)
                ) && 
                (
                    this.RegisteredDevice == other.RegisteredDevice ||
                    this.RegisteredDevice != null &&
                    this.RegisteredDevice.Equals(other.RegisteredDevice)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
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
                if (this.Details != null)
                    hash = hash * 59 + this.Details.GetHashCode();
                if (this.HclFirmwareVersion != null)
                    hash = hash * 59 + this.HclFirmwareVersion.GetHashCode();
                if (this.HclModel != null)
                    hash = hash * 59 + this.HclModel.GetHashCode();
                if (this.HclOsVendor != null)
                    hash = hash * 59 + this.HclOsVendor.GetHashCode();
                if (this.HclOsVersion != null)
                    hash = hash * 59 + this.HclOsVersion.GetHashCode();
                if (this.HclProcessor != null)
                    hash = hash * 59 + this.HclProcessor.GetHashCode();
                if (this.InvFirmwareVersion != null)
                    hash = hash * 59 + this.InvFirmwareVersion.GetHashCode();
                if (this.InvModel != null)
                    hash = hash * 59 + this.InvModel.GetHashCode();
                if (this.InvOsVendor != null)
                    hash = hash * 59 + this.InvOsVendor.GetHashCode();
                if (this.InvOsVersion != null)
                    hash = hash * 59 + this.InvOsVersion.GetHashCode();
                if (this.InvProcessor != null)
                    hash = hash * 59 + this.InvProcessor.GetHashCode();
                if (this.ManagedObject != null)
                    hash = hash * 59 + this.ManagedObject.GetHashCode();
                if (this.Reason != null)
                    hash = hash * 59 + this.Reason.GetHashCode();
                if (this.RegisteredDevice != null)
                    hash = hash * 59 + this.RegisteredDevice.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
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
