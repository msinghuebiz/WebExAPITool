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
    /// Definitions for the relationship in a meta class. 
    /// </summary>
    [DataContract]
    public partial class MetaRelationshipDefinition :  IEquatable<MetaRelationshipDefinition>, IValidatableObject
    {
        /// <summary>
        /// Api access definition for this relationship  
        /// </summary>
        /// <value>Api access definition for this relationship  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ApiAccessEnum
        {
            
            /// <summary>
            /// Enum NoAccess for "NoAccess"
            /// </summary>
            [EnumMember(Value = "NoAccess")]
            NoAccess,
            
            /// <summary>
            /// Enum ReadOnly for "ReadOnly"
            /// </summary>
            [EnumMember(Value = "ReadOnly")]
            ReadOnly,
            
            /// <summary>
            /// Enum CreateOnly for "CreateOnly"
            /// </summary>
            [EnumMember(Value = "CreateOnly")]
            CreateOnly,
            
            /// <summary>
            /// Enum ReadWrite for "ReadWrite"
            /// </summary>
            [EnumMember(Value = "ReadWrite")]
            ReadWrite,
            
            /// <summary>
            /// Enum WriteOnly for "WriteOnly"
            /// </summary>
            [EnumMember(Value = "WriteOnly")]
            WriteOnly,
            
            /// <summary>
            /// Enum ReadOnCreate for "ReadOnCreate"
            /// </summary>
            [EnumMember(Value = "ReadOnCreate")]
            ReadOnCreate
        }

        /// <summary>
        /// Api access definition for this relationship  
        /// </summary>
        /// <value>Api access definition for this relationship  </value>
        [DataMember(Name="ApiAccess", EmitDefaultValue=false)]
        public ApiAccessEnum? ApiAccess { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaRelationshipDefinition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public MetaRelationshipDefinition()
        {
        }
        

        /// <summary>
        /// Specifies whether the relationship is a collection  
        /// </summary>
        /// <value>Specifies whether the relationship is a collection  </value>
        [DataMember(Name="Collection", EmitDefaultValue=false)]
        public bool? Collection { get; private set; }

        /// <summary>
        /// Name of the relationship as defined in the model.yaml  
        /// </summary>
        /// <value>Name of the relationship as defined in the model.yaml  </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; private set; }

        /// <summary>
        /// Fully qualified type of the foreign MO   
        /// </summary>
        /// <value>Fully qualified type of the foreign MO   </value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public string Type { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MetaRelationshipDefinition {\n");
            sb.Append("  ApiAccess: ").Append(ApiAccess).Append("\n");
            sb.Append("  Collection: ").Append(Collection).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(obj as MetaRelationshipDefinition);
        }

        /// <summary>
        /// Returns true if MetaRelationshipDefinition instances are equal
        /// </summary>
        /// <param name="other">Instance of MetaRelationshipDefinition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetaRelationshipDefinition other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ApiAccess == other.ApiAccess ||
                    this.ApiAccess != null &&
                    this.ApiAccess.Equals(other.ApiAccess)
                ) && 
                (
                    this.Collection == other.Collection ||
                    this.Collection != null &&
                    this.Collection.Equals(other.Collection)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
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
                if (this.ApiAccess != null)
                    hash = hash * 59 + this.ApiAccess.GetHashCode();
                if (this.Collection != null)
                    hash = hash * 59 + this.Collection.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
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
