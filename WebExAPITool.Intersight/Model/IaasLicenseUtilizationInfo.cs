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
    /// License list with the Utilization info for UCSD 
    /// </summary>
    [DataContract]
    public partial class IaasLicenseUtilizationInfo :  IEquatable<IaasLicenseUtilizationInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IaasLicenseUtilizationInfo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public IaasLicenseUtilizationInfo()
        {
        }
        
        /// <summary>
        /// Number of licenses actually used for this feature  
        /// </summary>
        /// <value>Number of licenses actually used for this feature  </value>
        [DataMember(Name="ActualUsed", EmitDefaultValue=false)]
        public long? ActualUsed { get; private set; }

        /// <summary>
        /// License Label  
        /// </summary>
        /// <value>License Label  </value>
        [DataMember(Name="Label", EmitDefaultValue=false)]
        public string Label { get; private set; }

        /// <summary>
        /// License limit for this license feature  
        /// </summary>
        /// <value>License limit for this license feature  </value>
        [DataMember(Name="LicensedLimit", EmitDefaultValue=false)]
        public string LicensedLimit { get; private set; }

        /// <summary>
        /// SKU for the license   
        /// </summary>
        /// <value>SKU for the license   </value>
        [DataMember(Name="Sku", EmitDefaultValue=false)]
        public string Sku { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IaasLicenseUtilizationInfo {\n");
            sb.Append("  ActualUsed: ").Append(ActualUsed).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  LicensedLimit: ").Append(LicensedLimit).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
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
            return this.Equals(obj as IaasLicenseUtilizationInfo);
        }

        /// <summary>
        /// Returns true if IaasLicenseUtilizationInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of IaasLicenseUtilizationInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IaasLicenseUtilizationInfo other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ActualUsed == other.ActualUsed ||
                    this.ActualUsed != null &&
                    this.ActualUsed.Equals(other.ActualUsed)
                ) && 
                (
                    this.Label == other.Label ||
                    this.Label != null &&
                    this.Label.Equals(other.Label)
                ) && 
                (
                    this.LicensedLimit == other.LicensedLimit ||
                    this.LicensedLimit != null &&
                    this.LicensedLimit.Equals(other.LicensedLimit)
                ) && 
                (
                    this.Sku == other.Sku ||
                    this.Sku != null &&
                    this.Sku.Equals(other.Sku)
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
                if (this.ActualUsed != null)
                    hash = hash * 59 + this.ActualUsed.GetHashCode();
                if (this.Label != null)
                    hash = hash * 59 + this.Label.GetHashCode();
                if (this.LicensedLimit != null)
                    hash = hash * 59 + this.LicensedLimit.GetHashCode();
                if (this.Sku != null)
                    hash = hash * 59 + this.Sku.GetHashCode();
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
