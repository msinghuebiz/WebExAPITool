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
    /// Configuration settings for a HyperFlex cluster 
    /// </summary>
    [DataContract]
    public partial class HyperflexClusterProfile :  IEquatable<HyperflexClusterProfile>, IValidatableObject
    {
        /// <summary>
        /// Defines the type of the profile. Accepted value is instance.   
        /// </summary>
        /// <value>Defines the type of the profile. Accepted value is instance.   </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Instance for "instance"
            /// </summary>
            [EnumMember(Value = "instance")]
            Instance
        }

        /// <summary>
        /// Hypervisor type for the HyperFlex cluster  
        /// </summary>
        /// <value>Hypervisor type for the HyperFlex cluster  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum HypervisorTypeEnum
        {
            
            /// <summary>
            /// Enum ESXi for "ESXi"
            /// </summary>
            [EnumMember(Value = "ESXi")]
            ESXi
        }

        /// <summary>
        /// Management platform for the HyperFlex cluster  
        /// </summary>
        /// <value>Management platform for the HyperFlex cluster  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MgmtPlatformEnum
        {
            
            /// <summary>
            /// Enum FI for "FI"
            /// </summary>
            [EnumMember(Value = "FI")]
            FI,
            
            /// <summary>
            /// Enum EDGE for "EDGE"
            /// </summary>
            [EnumMember(Value = "EDGE")]
            EDGE
        }

        /// <summary>
        /// Defines the type of the profile. Accepted value is instance.   
        /// </summary>
        /// <value>Defines the type of the profile. Accepted value is instance.   </value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Hypervisor type for the HyperFlex cluster  
        /// </summary>
        /// <value>Hypervisor type for the HyperFlex cluster  </value>
        [DataMember(Name="HypervisorType", EmitDefaultValue=false)]
        public HypervisorTypeEnum? HypervisorType { get; set; }
        /// <summary>
        /// Management platform for the HyperFlex cluster  
        /// </summary>
        /// <value>Management platform for the HyperFlex cluster  </value>
        [DataMember(Name="MgmtPlatform", EmitDefaultValue=false)]
        public MgmtPlatformEnum? MgmtPlatform { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperflexClusterProfile" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="Description">Description of the profile.  .</param>
        /// <param name="Name">Name of the profile.  .</param>
        /// <param name="SrcTemplate">SrcTemplate.</param>
        /// <param name="Type">Defines the type of the profile. Accepted value is instance.    (default to TypeEnum.Instance).</param>
        /// <param name="Action">User initiated action. Each profile type has its own supported actions. For hyperflex cluster profile, the supported actions are - - Validate, Deploy, Continue, Retry, Abort, Unassign For server profile, the support actions are - - Deploy, Unassign  .</param>
        /// <param name="ConfigContext">ConfigContext.</param>
        /// <param name="AutoSupport">AutoSupport.</param>
        /// <param name="ClusterNetwork">ClusterNetwork.</param>
        /// <param name="ClusterStorage">ClusterStorage.</param>
        /// <param name="ConfigResult">The profile configuration (deploy, validation) results with the overall state and detailed result messages. .</param>
        /// <param name="DataIpAddress">Storage data IP address for the HyperFlex cluster  .</param>
        /// <param name="ExtFcStorage">ExtFcStorage.</param>
        /// <param name="ExtIscsiStorage">ExtIscsiStorage.</param>
        /// <param name="HypervisorType">Hypervisor type for the HyperFlex cluster   (default to HypervisorTypeEnum.ESXi).</param>
        /// <param name="LocalCredential">LocalCredential.</param>
        /// <param name="MacAddressPrefix">MAC address prefix 00:25:B5:XX  .</param>
        /// <param name="MgmtIpAddress">Management IP address for the HyperFlex cluster  .</param>
        /// <param name="MgmtPlatform">Management platform for the HyperFlex cluster   (default to MgmtPlatformEnum.FI).</param>
        /// <param name="NodeConfig">NodeConfig.</param>
        /// <param name="NodeProfileConfig">List of node profiles representing the configuraion of the corresponding HX cluster nodes .</param>
        /// <param name="Organization">Organization .</param>
        /// <param name="ProxySetting">ProxySetting.</param>
        /// <param name="Replication">Specifies the number of copies of each data block written  .</param>
        /// <param name="StorageDataVlan">VLAN for the HyperFlex storage data traffic  .</param>
        /// <param name="SysConfig">SysConfig.</param>
        /// <param name="UcsmConfig">UcsmConfig.</param>
        /// <param name="VcenterConfig">VcenterConfig.</param>
        /// <param name="WwxnPrefix">WWxN prefix 20:00:00:25:B5:XX   .</param>
        public HyperflexClusterProfile(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), string Description = default(string), string Name = default(string), PolicyAbstractProfileRef SrcTemplate = default(PolicyAbstractProfileRef), TypeEnum? Type = TypeEnum.Instance, string Action = default(string), PolicyConfigContext ConfigContext = default(PolicyConfigContext), HyperflexAutoSupportPolicyRef AutoSupport = default(HyperflexAutoSupportPolicyRef), HyperflexClusterNetworkPolicyRef ClusterNetwork = default(HyperflexClusterNetworkPolicyRef), HyperflexClusterStoragePolicyRef ClusterStorage = default(HyperflexClusterStoragePolicyRef), HyperflexConfigResultRef ConfigResult = default(HyperflexConfigResultRef), string DataIpAddress = default(string), HyperflexExtFcStoragePolicyRef ExtFcStorage = default(HyperflexExtFcStoragePolicyRef), HyperflexExtIscsiStoragePolicyRef ExtIscsiStorage = default(HyperflexExtIscsiStoragePolicyRef), HypervisorTypeEnum? HypervisorType = HypervisorTypeEnum.ESXi, HyperflexLocalCredentialPolicyRef LocalCredential = default(HyperflexLocalCredentialPolicyRef), string MacAddressPrefix = default(string), string MgmtIpAddress = default(string), MgmtPlatformEnum? MgmtPlatform = MgmtPlatformEnum.FI, HyperflexNodeConfigPolicyRef NodeConfig = default(HyperflexNodeConfigPolicyRef), List<HyperflexNodeProfileRef> NodeProfileConfig = default(List<HyperflexNodeProfileRef>), IamAccountRef Organization = default(IamAccountRef), HyperflexProxySettingPolicyRef ProxySetting = default(HyperflexProxySettingPolicyRef), long? Replication = default(long?), HyperflexNamedVlan StorageDataVlan = default(HyperflexNamedVlan), HyperflexSysConfigPolicyRef SysConfig = default(HyperflexSysConfigPolicyRef), HyperflexUcsmConfigPolicyRef UcsmConfig = default(HyperflexUcsmConfigPolicyRef), HyperflexVcenterConfigPolicyRef VcenterConfig = default(HyperflexVcenterConfigPolicyRef), string WwxnPrefix = default(string))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.Description = Description;
            this.Name = Name;
            this.SrcTemplate = SrcTemplate;
            // use default value if no "Type" provided
            if (Type == null)
            {
                this.Type = TypeEnum.Instance;
            }
            else
            {
                this.Type = Type;
            }
            this.Action = Action;
            this.ConfigContext = ConfigContext;
            this.AutoSupport = AutoSupport;
            this.ClusterNetwork = ClusterNetwork;
            this.ClusterStorage = ClusterStorage;
            this.ConfigResult = ConfigResult;
            this.DataIpAddress = DataIpAddress;
            this.ExtFcStorage = ExtFcStorage;
            this.ExtIscsiStorage = ExtIscsiStorage;
            // use default value if no "HypervisorType" provided
            if (HypervisorType == null)
            {
                this.HypervisorType = HypervisorTypeEnum.ESXi;
            }
            else
            {
                this.HypervisorType = HypervisorType;
            }
            this.LocalCredential = LocalCredential;
            this.MacAddressPrefix = MacAddressPrefix;
            this.MgmtIpAddress = MgmtIpAddress;
            // use default value if no "MgmtPlatform" provided
            if (MgmtPlatform == null)
            {
                this.MgmtPlatform = MgmtPlatformEnum.FI;
            }
            else
            {
                this.MgmtPlatform = MgmtPlatform;
            }
            this.NodeConfig = NodeConfig;
            this.NodeProfileConfig = NodeProfileConfig;
            this.Organization = Organization;
            this.ProxySetting = ProxySetting;
            this.Replication = Replication;
            this.StorageDataVlan = StorageDataVlan;
            this.SysConfig = SysConfig;
            this.UcsmConfig = UcsmConfig;
            this.VcenterConfig = VcenterConfig;
            this.WwxnPrefix = WwxnPrefix;
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
        /// Description of the profile.  
        /// </summary>
        /// <value>Description of the profile.  </value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Name of the profile.  
        /// </summary>
        /// <value>Name of the profile.  </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets SrcTemplate
        /// </summary>
        [DataMember(Name="SrcTemplate", EmitDefaultValue=false)]
        public PolicyAbstractProfileRef SrcTemplate { get; set; }


        /// <summary>
        /// User initiated action. Each profile type has its own supported actions. For hyperflex cluster profile, the supported actions are - - Validate, Deploy, Continue, Retry, Abort, Unassign For server profile, the support actions are - - Deploy, Unassign  
        /// </summary>
        /// <value>User initiated action. Each profile type has its own supported actions. For hyperflex cluster profile, the supported actions are - - Validate, Deploy, Continue, Retry, Abort, Unassign For server profile, the support actions are - - Deploy, Unassign  </value>
        [DataMember(Name="Action", EmitDefaultValue=false)]
        public string Action { get; set; }

        /// <summary>
        /// Gets or Sets ConfigContext
        /// </summary>
        [DataMember(Name="ConfigContext", EmitDefaultValue=false)]
        public PolicyConfigContext ConfigContext { get; set; }

        /// <summary>
        /// Gets or Sets AutoSupport
        /// </summary>
        [DataMember(Name="AutoSupport", EmitDefaultValue=false)]
        public HyperflexAutoSupportPolicyRef AutoSupport { get; set; }

        /// <summary>
        /// Gets or Sets ClusterNetwork
        /// </summary>
        [DataMember(Name="ClusterNetwork", EmitDefaultValue=false)]
        public HyperflexClusterNetworkPolicyRef ClusterNetwork { get; set; }

        /// <summary>
        /// Gets or Sets ClusterStorage
        /// </summary>
        [DataMember(Name="ClusterStorage", EmitDefaultValue=false)]
        public HyperflexClusterStoragePolicyRef ClusterStorage { get; set; }

        /// <summary>
        /// The profile configuration (deploy, validation) results with the overall state and detailed result messages. 
        /// </summary>
        /// <value>The profile configuration (deploy, validation) results with the overall state and detailed result messages. </value>
        [DataMember(Name="ConfigResult", EmitDefaultValue=false)]
        public HyperflexConfigResultRef ConfigResult { get; set; }

        /// <summary>
        /// Storage data IP address for the HyperFlex cluster  
        /// </summary>
        /// <value>Storage data IP address for the HyperFlex cluster  </value>
        [DataMember(Name="DataIpAddress", EmitDefaultValue=false)]
        public string DataIpAddress { get; set; }

        /// <summary>
        /// Gets or Sets ExtFcStorage
        /// </summary>
        [DataMember(Name="ExtFcStorage", EmitDefaultValue=false)]
        public HyperflexExtFcStoragePolicyRef ExtFcStorage { get; set; }

        /// <summary>
        /// Gets or Sets ExtIscsiStorage
        /// </summary>
        [DataMember(Name="ExtIscsiStorage", EmitDefaultValue=false)]
        public HyperflexExtIscsiStoragePolicyRef ExtIscsiStorage { get; set; }


        /// <summary>
        /// Gets or Sets LocalCredential
        /// </summary>
        [DataMember(Name="LocalCredential", EmitDefaultValue=false)]
        public HyperflexLocalCredentialPolicyRef LocalCredential { get; set; }

        /// <summary>
        /// MAC address prefix 00:25:B5:XX  
        /// </summary>
        /// <value>MAC address prefix 00:25:B5:XX  </value>
        [DataMember(Name="MacAddressPrefix", EmitDefaultValue=false)]
        public string MacAddressPrefix { get; set; }

        /// <summary>
        /// Management IP address for the HyperFlex cluster  
        /// </summary>
        /// <value>Management IP address for the HyperFlex cluster  </value>
        [DataMember(Name="MgmtIpAddress", EmitDefaultValue=false)]
        public string MgmtIpAddress { get; set; }


        /// <summary>
        /// Gets or Sets NodeConfig
        /// </summary>
        [DataMember(Name="NodeConfig", EmitDefaultValue=false)]
        public HyperflexNodeConfigPolicyRef NodeConfig { get; set; }

        /// <summary>
        /// List of node profiles representing the configuraion of the corresponding HX cluster nodes 
        /// </summary>
        /// <value>List of node profiles representing the configuraion of the corresponding HX cluster nodes </value>
        [DataMember(Name="NodeProfileConfig", EmitDefaultValue=false)]
        public List<HyperflexNodeProfileRef> NodeProfileConfig { get; set; }

        /// <summary>
        /// Organization 
        /// </summary>
        /// <value>Organization </value>
        [DataMember(Name="Organization", EmitDefaultValue=false)]
        public IamAccountRef Organization { get; set; }

        /// <summary>
        /// Gets or Sets ProxySetting
        /// </summary>
        [DataMember(Name="ProxySetting", EmitDefaultValue=false)]
        public HyperflexProxySettingPolicyRef ProxySetting { get; set; }

        /// <summary>
        /// Specifies the number of copies of each data block written  
        /// </summary>
        /// <value>Specifies the number of copies of each data block written  </value>
        [DataMember(Name="Replication", EmitDefaultValue=false)]
        public long? Replication { get; set; }

        /// <summary>
        /// VLAN for the HyperFlex storage data traffic  
        /// </summary>
        /// <value>VLAN for the HyperFlex storage data traffic  </value>
        [DataMember(Name="StorageDataVlan", EmitDefaultValue=false)]
        public HyperflexNamedVlan StorageDataVlan { get; set; }

        /// <summary>
        /// Gets or Sets SysConfig
        /// </summary>
        [DataMember(Name="SysConfig", EmitDefaultValue=false)]
        public HyperflexSysConfigPolicyRef SysConfig { get; set; }

        /// <summary>
        /// Gets or Sets UcsmConfig
        /// </summary>
        [DataMember(Name="UcsmConfig", EmitDefaultValue=false)]
        public HyperflexUcsmConfigPolicyRef UcsmConfig { get; set; }

        /// <summary>
        /// Gets or Sets VcenterConfig
        /// </summary>
        [DataMember(Name="VcenterConfig", EmitDefaultValue=false)]
        public HyperflexVcenterConfigPolicyRef VcenterConfig { get; set; }

        /// <summary>
        /// WWxN prefix 20:00:00:25:B5:XX   
        /// </summary>
        /// <value>WWxN prefix 20:00:00:25:B5:XX   </value>
        [DataMember(Name="WwxnPrefix", EmitDefaultValue=false)]
        public string WwxnPrefix { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HyperflexClusterProfile {\n");
            sb.Append("  AccountMoid: ").Append(AccountMoid).Append("\n");
            sb.Append("  Ancestors: ").Append(Ancestors).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  ModTime: ").Append(ModTime).Append("\n");
            sb.Append("  Moid: ").Append(Moid).Append("\n");
            sb.Append("  ObjectType: ").Append(ObjectType).Append("\n");
            sb.Append("  Owners: ").Append(Owners).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SrcTemplate: ").Append(SrcTemplate).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  ConfigContext: ").Append(ConfigContext).Append("\n");
            sb.Append("  AutoSupport: ").Append(AutoSupport).Append("\n");
            sb.Append("  ClusterNetwork: ").Append(ClusterNetwork).Append("\n");
            sb.Append("  ClusterStorage: ").Append(ClusterStorage).Append("\n");
            sb.Append("  ConfigResult: ").Append(ConfigResult).Append("\n");
            sb.Append("  DataIpAddress: ").Append(DataIpAddress).Append("\n");
            sb.Append("  ExtFcStorage: ").Append(ExtFcStorage).Append("\n");
            sb.Append("  ExtIscsiStorage: ").Append(ExtIscsiStorage).Append("\n");
            sb.Append("  HypervisorType: ").Append(HypervisorType).Append("\n");
            sb.Append("  LocalCredential: ").Append(LocalCredential).Append("\n");
            sb.Append("  MacAddressPrefix: ").Append(MacAddressPrefix).Append("\n");
            sb.Append("  MgmtIpAddress: ").Append(MgmtIpAddress).Append("\n");
            sb.Append("  MgmtPlatform: ").Append(MgmtPlatform).Append("\n");
            sb.Append("  NodeConfig: ").Append(NodeConfig).Append("\n");
            sb.Append("  NodeProfileConfig: ").Append(NodeProfileConfig).Append("\n");
            sb.Append("  Organization: ").Append(Organization).Append("\n");
            sb.Append("  ProxySetting: ").Append(ProxySetting).Append("\n");
            sb.Append("  Replication: ").Append(Replication).Append("\n");
            sb.Append("  StorageDataVlan: ").Append(StorageDataVlan).Append("\n");
            sb.Append("  SysConfig: ").Append(SysConfig).Append("\n");
            sb.Append("  UcsmConfig: ").Append(UcsmConfig).Append("\n");
            sb.Append("  VcenterConfig: ").Append(VcenterConfig).Append("\n");
            sb.Append("  WwxnPrefix: ").Append(WwxnPrefix).Append("\n");
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
            return this.Equals(obj as HyperflexClusterProfile);
        }

        /// <summary>
        /// Returns true if HyperflexClusterProfile instances are equal
        /// </summary>
        /// <param name="other">Instance of HyperflexClusterProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HyperflexClusterProfile other)
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
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.SrcTemplate == other.SrcTemplate ||
                    this.SrcTemplate != null &&
                    this.SrcTemplate.Equals(other.SrcTemplate)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Action == other.Action ||
                    this.Action != null &&
                    this.Action.Equals(other.Action)
                ) && 
                (
                    this.ConfigContext == other.ConfigContext ||
                    this.ConfigContext != null &&
                    this.ConfigContext.Equals(other.ConfigContext)
                ) && 
                (
                    this.AutoSupport == other.AutoSupport ||
                    this.AutoSupport != null &&
                    this.AutoSupport.Equals(other.AutoSupport)
                ) && 
                (
                    this.ClusterNetwork == other.ClusterNetwork ||
                    this.ClusterNetwork != null &&
                    this.ClusterNetwork.Equals(other.ClusterNetwork)
                ) && 
                (
                    this.ClusterStorage == other.ClusterStorage ||
                    this.ClusterStorage != null &&
                    this.ClusterStorage.Equals(other.ClusterStorage)
                ) && 
                (
                    this.ConfigResult == other.ConfigResult ||
                    this.ConfigResult != null &&
                    this.ConfigResult.Equals(other.ConfigResult)
                ) && 
                (
                    this.DataIpAddress == other.DataIpAddress ||
                    this.DataIpAddress != null &&
                    this.DataIpAddress.Equals(other.DataIpAddress)
                ) && 
                (
                    this.ExtFcStorage == other.ExtFcStorage ||
                    this.ExtFcStorage != null &&
                    this.ExtFcStorage.Equals(other.ExtFcStorage)
                ) && 
                (
                    this.ExtIscsiStorage == other.ExtIscsiStorage ||
                    this.ExtIscsiStorage != null &&
                    this.ExtIscsiStorage.Equals(other.ExtIscsiStorage)
                ) && 
                (
                    this.HypervisorType == other.HypervisorType ||
                    this.HypervisorType != null &&
                    this.HypervisorType.Equals(other.HypervisorType)
                ) && 
                (
                    this.LocalCredential == other.LocalCredential ||
                    this.LocalCredential != null &&
                    this.LocalCredential.Equals(other.LocalCredential)
                ) && 
                (
                    this.MacAddressPrefix == other.MacAddressPrefix ||
                    this.MacAddressPrefix != null &&
                    this.MacAddressPrefix.Equals(other.MacAddressPrefix)
                ) && 
                (
                    this.MgmtIpAddress == other.MgmtIpAddress ||
                    this.MgmtIpAddress != null &&
                    this.MgmtIpAddress.Equals(other.MgmtIpAddress)
                ) && 
                (
                    this.MgmtPlatform == other.MgmtPlatform ||
                    this.MgmtPlatform != null &&
                    this.MgmtPlatform.Equals(other.MgmtPlatform)
                ) && 
                (
                    this.NodeConfig == other.NodeConfig ||
                    this.NodeConfig != null &&
                    this.NodeConfig.Equals(other.NodeConfig)
                ) && 
                (
                    this.NodeProfileConfig == other.NodeProfileConfig ||
                    this.NodeProfileConfig != null &&
                    this.NodeProfileConfig.SequenceEqual(other.NodeProfileConfig)
                ) && 
                (
                    this.Organization == other.Organization ||
                    this.Organization != null &&
                    this.Organization.Equals(other.Organization)
                ) && 
                (
                    this.ProxySetting == other.ProxySetting ||
                    this.ProxySetting != null &&
                    this.ProxySetting.Equals(other.ProxySetting)
                ) && 
                (
                    this.Replication == other.Replication ||
                    this.Replication != null &&
                    this.Replication.Equals(other.Replication)
                ) && 
                (
                    this.StorageDataVlan == other.StorageDataVlan ||
                    this.StorageDataVlan != null &&
                    this.StorageDataVlan.Equals(other.StorageDataVlan)
                ) && 
                (
                    this.SysConfig == other.SysConfig ||
                    this.SysConfig != null &&
                    this.SysConfig.Equals(other.SysConfig)
                ) && 
                (
                    this.UcsmConfig == other.UcsmConfig ||
                    this.UcsmConfig != null &&
                    this.UcsmConfig.Equals(other.UcsmConfig)
                ) && 
                (
                    this.VcenterConfig == other.VcenterConfig ||
                    this.VcenterConfig != null &&
                    this.VcenterConfig.Equals(other.VcenterConfig)
                ) && 
                (
                    this.WwxnPrefix == other.WwxnPrefix ||
                    this.WwxnPrefix != null &&
                    this.WwxnPrefix.Equals(other.WwxnPrefix)
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
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.SrcTemplate != null)
                    hash = hash * 59 + this.SrcTemplate.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.Action != null)
                    hash = hash * 59 + this.Action.GetHashCode();
                if (this.ConfigContext != null)
                    hash = hash * 59 + this.ConfigContext.GetHashCode();
                if (this.AutoSupport != null)
                    hash = hash * 59 + this.AutoSupport.GetHashCode();
                if (this.ClusterNetwork != null)
                    hash = hash * 59 + this.ClusterNetwork.GetHashCode();
                if (this.ClusterStorage != null)
                    hash = hash * 59 + this.ClusterStorage.GetHashCode();
                if (this.ConfigResult != null)
                    hash = hash * 59 + this.ConfigResult.GetHashCode();
                if (this.DataIpAddress != null)
                    hash = hash * 59 + this.DataIpAddress.GetHashCode();
                if (this.ExtFcStorage != null)
                    hash = hash * 59 + this.ExtFcStorage.GetHashCode();
                if (this.ExtIscsiStorage != null)
                    hash = hash * 59 + this.ExtIscsiStorage.GetHashCode();
                if (this.HypervisorType != null)
                    hash = hash * 59 + this.HypervisorType.GetHashCode();
                if (this.LocalCredential != null)
                    hash = hash * 59 + this.LocalCredential.GetHashCode();
                if (this.MacAddressPrefix != null)
                    hash = hash * 59 + this.MacAddressPrefix.GetHashCode();
                if (this.MgmtIpAddress != null)
                    hash = hash * 59 + this.MgmtIpAddress.GetHashCode();
                if (this.MgmtPlatform != null)
                    hash = hash * 59 + this.MgmtPlatform.GetHashCode();
                if (this.NodeConfig != null)
                    hash = hash * 59 + this.NodeConfig.GetHashCode();
                if (this.NodeProfileConfig != null)
                    hash = hash * 59 + this.NodeProfileConfig.GetHashCode();
                if (this.Organization != null)
                    hash = hash * 59 + this.Organization.GetHashCode();
                if (this.ProxySetting != null)
                    hash = hash * 59 + this.ProxySetting.GetHashCode();
                if (this.Replication != null)
                    hash = hash * 59 + this.Replication.GetHashCode();
                if (this.StorageDataVlan != null)
                    hash = hash * 59 + this.StorageDataVlan.GetHashCode();
                if (this.SysConfig != null)
                    hash = hash * 59 + this.SysConfig.GetHashCode();
                if (this.UcsmConfig != null)
                    hash = hash * 59 + this.UcsmConfig.GetHashCode();
                if (this.VcenterConfig != null)
                    hash = hash * 59 + this.VcenterConfig.GetHashCode();
                if (this.WwxnPrefix != null)
                    hash = hash * 59 + this.WwxnPrefix.GetHashCode();
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
