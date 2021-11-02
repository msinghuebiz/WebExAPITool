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
    /// Specifies node configuration details such as management and storage data IP ranges. For HyperFlex Edge, storage data IP range is pre-defined. 
    /// </summary>
    [DataContract]
    public partial class HyperflexNodeConfigPolicy :  IEquatable<HyperflexNodeConfigPolicy>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperflexNodeConfigPolicy" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="Description">Description of the policy.  .</param>
        /// <param name="Name">Name of the policy.   .</param>
        /// <param name="ClusterProfiles">List of cluster profiles using this policy .</param>
        /// <param name="DataIpRange">Storage data IP range  .</param>
        /// <param name="HxdpIpRange">HX storage management IP range  .</param>
        /// <param name="MgmtIpRange">Management IP range  .</param>
        /// <param name="NodeNamePrefix">Specifies a node name prefix that is used to automatically generate the default hostname for each server. A dash (-) will be appended to the prefix followed by the node number to form a hostname. This default naming scheme can be manually overridden in the node configuration. The maximum length of a prefix is 60 and must only contain alphanumeric characters or dash (-).   .</param>
        /// <param name="Organization">Organization .</param>
        public HyperflexNodeConfigPolicy(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), string Description = default(string), string Name = default(string), List<HyperflexClusterProfileRef> ClusterProfiles = default(List<HyperflexClusterProfileRef>), HyperflexIpAddrRange DataIpRange = default(HyperflexIpAddrRange), HyperflexIpAddrRange HxdpIpRange = default(HyperflexIpAddrRange), HyperflexIpAddrRange MgmtIpRange = default(HyperflexIpAddrRange), string NodeNamePrefix = default(string), IamAccountRef Organization = default(IamAccountRef))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.Description = Description;
            this.Name = Name;
            this.ClusterProfiles = ClusterProfiles;
            this.DataIpRange = DataIpRange;
            this.HxdpIpRange = HxdpIpRange;
            this.MgmtIpRange = MgmtIpRange;
            this.NodeNamePrefix = NodeNamePrefix;
            this.Organization = Organization;
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
        /// Description of the policy.  
        /// </summary>
        /// <value>Description of the policy.  </value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Name of the policy.   
        /// </summary>
        /// <value>Name of the policy.   </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// List of cluster profiles using this policy 
        /// </summary>
        /// <value>List of cluster profiles using this policy </value>
        [DataMember(Name="ClusterProfiles", EmitDefaultValue=false)]
        public List<HyperflexClusterProfileRef> ClusterProfiles { get; set; }

        /// <summary>
        /// Storage data IP range  
        /// </summary>
        /// <value>Storage data IP range  </value>
        [DataMember(Name="DataIpRange", EmitDefaultValue=false)]
        public HyperflexIpAddrRange DataIpRange { get; set; }

        /// <summary>
        /// HX storage management IP range  
        /// </summary>
        /// <value>HX storage management IP range  </value>
        [DataMember(Name="HxdpIpRange", EmitDefaultValue=false)]
        public HyperflexIpAddrRange HxdpIpRange { get; set; }

        /// <summary>
        /// Management IP range  
        /// </summary>
        /// <value>Management IP range  </value>
        [DataMember(Name="MgmtIpRange", EmitDefaultValue=false)]
        public HyperflexIpAddrRange MgmtIpRange { get; set; }

        /// <summary>
        /// Specifies a node name prefix that is used to automatically generate the default hostname for each server. A dash (-) will be appended to the prefix followed by the node number to form a hostname. This default naming scheme can be manually overridden in the node configuration. The maximum length of a prefix is 60 and must only contain alphanumeric characters or dash (-).   
        /// </summary>
        /// <value>Specifies a node name prefix that is used to automatically generate the default hostname for each server. A dash (-) will be appended to the prefix followed by the node number to form a hostname. This default naming scheme can be manually overridden in the node configuration. The maximum length of a prefix is 60 and must only contain alphanumeric characters or dash (-).   </value>
        [DataMember(Name="NodeNamePrefix", EmitDefaultValue=false)]
        public string NodeNamePrefix { get; set; }

        /// <summary>
        /// Organization 
        /// </summary>
        /// <value>Organization </value>
        [DataMember(Name="Organization", EmitDefaultValue=false)]
        public IamAccountRef Organization { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HyperflexNodeConfigPolicy {\n");
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
            sb.Append("  ClusterProfiles: ").Append(ClusterProfiles).Append("\n");
            sb.Append("  DataIpRange: ").Append(DataIpRange).Append("\n");
            sb.Append("  HxdpIpRange: ").Append(HxdpIpRange).Append("\n");
            sb.Append("  MgmtIpRange: ").Append(MgmtIpRange).Append("\n");
            sb.Append("  NodeNamePrefix: ").Append(NodeNamePrefix).Append("\n");
            sb.Append("  Organization: ").Append(Organization).Append("\n");
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
            return this.Equals(obj as HyperflexNodeConfigPolicy);
        }

        /// <summary>
        /// Returns true if HyperflexNodeConfigPolicy instances are equal
        /// </summary>
        /// <param name="other">Instance of HyperflexNodeConfigPolicy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HyperflexNodeConfigPolicy other)
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
                    this.ClusterProfiles == other.ClusterProfiles ||
                    this.ClusterProfiles != null &&
                    this.ClusterProfiles.SequenceEqual(other.ClusterProfiles)
                ) && 
                (
                    this.DataIpRange == other.DataIpRange ||
                    this.DataIpRange != null &&
                    this.DataIpRange.Equals(other.DataIpRange)
                ) && 
                (
                    this.HxdpIpRange == other.HxdpIpRange ||
                    this.HxdpIpRange != null &&
                    this.HxdpIpRange.Equals(other.HxdpIpRange)
                ) && 
                (
                    this.MgmtIpRange == other.MgmtIpRange ||
                    this.MgmtIpRange != null &&
                    this.MgmtIpRange.Equals(other.MgmtIpRange)
                ) && 
                (
                    this.NodeNamePrefix == other.NodeNamePrefix ||
                    this.NodeNamePrefix != null &&
                    this.NodeNamePrefix.Equals(other.NodeNamePrefix)
                ) && 
                (
                    this.Organization == other.Organization ||
                    this.Organization != null &&
                    this.Organization.Equals(other.Organization)
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
                if (this.ClusterProfiles != null)
                    hash = hash * 59 + this.ClusterProfiles.GetHashCode();
                if (this.DataIpRange != null)
                    hash = hash * 59 + this.DataIpRange.GetHashCode();
                if (this.HxdpIpRange != null)
                    hash = hash * 59 + this.HxdpIpRange.GetHashCode();
                if (this.MgmtIpRange != null)
                    hash = hash * 59 + this.MgmtIpRange.GetHashCode();
                if (this.NodeNamePrefix != null)
                    hash = hash * 59 + this.NodeNamePrefix.GetHashCode();
                if (this.Organization != null)
                    hash = hash * 59 + this.Organization.GetHashCode();
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
