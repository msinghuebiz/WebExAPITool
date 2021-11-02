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
    /// Definitions for the properties in a meta class. 
    /// </summary>
    [DataContract]
    public partial class MetaPropDefinition :  IEquatable<MetaPropDefinition>, IValidatableObject
    {
        /// <summary>
        /// Api access definition for the property.  
        /// </summary>
        /// <value>Api access definition for the property.  </value>
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
        /// Operational Security definition.  
        /// </summary>
        /// <value>Operational Security definition.  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OpSecurityEnum
        {
            
            /// <summary>
            /// Enum ClearText for "ClearText"
            /// </summary>
            [EnumMember(Value = "ClearText")]
            ClearText,
            
            /// <summary>
            /// Enum Encrypted for "Encrypted"
            /// </summary>
            [EnumMember(Value = "Encrypted")]
            Encrypted
        }

        /// <summary>
        /// Api access definition for the property.  
        /// </summary>
        /// <value>Api access definition for the property.  </value>
        [DataMember(Name="ApiAccess", EmitDefaultValue=false)]
        public ApiAccessEnum? ApiAccess { get; set; }
        /// <summary>
        /// Operational Security definition.  
        /// </summary>
        /// <value>Operational Security definition.  </value>
        [DataMember(Name="OpSecurity", EmitDefaultValue=false)]
        public OpSecurityEnum? OpSecurity { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropDefinition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public MetaPropDefinition()
        {
        }
        

        /// <summary>
        /// Name of the property as defined in the model.yaml  
        /// </summary>
        /// <value>Name of the property as defined in the model.yaml  </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; private set; }


        /// <summary>
        /// Api access definition.   
        /// </summary>
        /// <value>Api access definition.   </value>
        [DataMember(Name="SearchWeight", EmitDefaultValue=false)]
        public float? SearchWeight { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MetaPropDefinition {\n");
            sb.Append("  ApiAccess: ").Append(ApiAccess).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OpSecurity: ").Append(OpSecurity).Append("\n");
            sb.Append("  SearchWeight: ").Append(SearchWeight).Append("\n");
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
            return this.Equals(obj as MetaPropDefinition);
        }

        /// <summary>
        /// Returns true if MetaPropDefinition instances are equal
        /// </summary>
        /// <param name="other">Instance of MetaPropDefinition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetaPropDefinition other)
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
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.OpSecurity == other.OpSecurity ||
                    this.OpSecurity != null &&
                    this.OpSecurity.Equals(other.OpSecurity)
                ) && 
                (
                    this.SearchWeight == other.SearchWeight ||
                    this.SearchWeight != null &&
                    this.SearchWeight.Equals(other.SearchWeight)
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
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.OpSecurity != null)
                    hash = hash * 59 + this.OpSecurity.GetHashCode();
                if (this.SearchWeight != null)
                    hash = hash * 59 + this.SearchWeight.GetHashCode();
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
