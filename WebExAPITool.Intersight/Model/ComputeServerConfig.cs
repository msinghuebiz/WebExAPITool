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
    /// This captures the configurable properties of servers common to both a server and a server profile. The user will apply these properties on a server directly when the server is not associated with a server profile and through a server profile when the server is attached with a server profile. 
    /// </summary>
    [DataContract]
    public partial class ComputeServerConfig :  IEquatable<ComputeServerConfig>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComputeServerConfig" /> class.
        /// </summary>
        /// <param name="AssetTag">User defined asset tag of the server  .</param>
        /// <param name="UserLabel">User defined description of the server   .</param>
        public ComputeServerConfig(string AssetTag = default(string), string UserLabel = default(string))
        {
            this.AssetTag = AssetTag;
            this.UserLabel = UserLabel;
        }
        
        /// <summary>
        /// User defined asset tag of the server  
        /// </summary>
        /// <value>User defined asset tag of the server  </value>
        [DataMember(Name="AssetTag", EmitDefaultValue=false)]
        public string AssetTag { get; set; }

        /// <summary>
        /// User defined description of the server   
        /// </summary>
        /// <value>User defined description of the server   </value>
        [DataMember(Name="UserLabel", EmitDefaultValue=false)]
        public string UserLabel { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ComputeServerConfig {\n");
            sb.Append("  AssetTag: ").Append(AssetTag).Append("\n");
            sb.Append("  UserLabel: ").Append(UserLabel).Append("\n");
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
            return this.Equals(obj as ComputeServerConfig);
        }

        /// <summary>
        /// Returns true if ComputeServerConfig instances are equal
        /// </summary>
        /// <param name="other">Instance of ComputeServerConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ComputeServerConfig other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AssetTag == other.AssetTag ||
                    this.AssetTag != null &&
                    this.AssetTag.Equals(other.AssetTag)
                ) && 
                (
                    this.UserLabel == other.UserLabel ||
                    this.UserLabel != null &&
                    this.UserLabel.Equals(other.UserLabel)
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
                if (this.AssetTag != null)
                    hash = hash * 59 + this.AssetTag.GetHashCode();
                if (this.UserLabel != null)
                    hash = hash * 59 + this.UserLabel.GetHashCode();
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