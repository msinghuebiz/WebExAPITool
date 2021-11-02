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
    /// Base message for connector messages that require authentication to be passed from cloud services. 
    /// </summary>
    [DataContract]
    public partial class ConnectorAuthMessage :  IEquatable<ConnectorAuthMessage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorAuthMessage" /> class.
        /// </summary>
        /// <param name="RemoteUserLocale">The platform locale to assign user. A locale defines one or more organizations (domains) the user is allowed access, and access is limited to the organizations specified in the locale.  .</param>
        /// <param name="RemoteUserName">User name passed to the platform for use in platform audit logs.  .</param>
        /// <param name="RemoteUserRoles">List of roles to pass to the platform to validate the action against  .</param>
        /// <param name="RemoteUserSessionId">Session Id passed to the platform for use in platforms auditing.   .</param>
        public ConnectorAuthMessage(string RemoteUserLocale = default(string), string RemoteUserName = default(string), string RemoteUserRoles = default(string), string RemoteUserSessionId = default(string))
        {
            this.RemoteUserLocale = RemoteUserLocale;
            this.RemoteUserName = RemoteUserName;
            this.RemoteUserRoles = RemoteUserRoles;
            this.RemoteUserSessionId = RemoteUserSessionId;
        }
        
        /// <summary>
        /// The platform locale to assign user. A locale defines one or more organizations (domains) the user is allowed access, and access is limited to the organizations specified in the locale.  
        /// </summary>
        /// <value>The platform locale to assign user. A locale defines one or more organizations (domains) the user is allowed access, and access is limited to the organizations specified in the locale.  </value>
        [DataMember(Name="RemoteUserLocale", EmitDefaultValue=false)]
        public string RemoteUserLocale { get; set; }

        /// <summary>
        /// User name passed to the platform for use in platform audit logs.  
        /// </summary>
        /// <value>User name passed to the platform for use in platform audit logs.  </value>
        [DataMember(Name="RemoteUserName", EmitDefaultValue=false)]
        public string RemoteUserName { get; set; }

        /// <summary>
        /// List of roles to pass to the platform to validate the action against  
        /// </summary>
        /// <value>List of roles to pass to the platform to validate the action against  </value>
        [DataMember(Name="RemoteUserRoles", EmitDefaultValue=false)]
        public string RemoteUserRoles { get; set; }

        /// <summary>
        /// Session Id passed to the platform for use in platforms auditing.   
        /// </summary>
        /// <value>Session Id passed to the platform for use in platforms auditing.   </value>
        [DataMember(Name="RemoteUserSessionId", EmitDefaultValue=false)]
        public string RemoteUserSessionId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConnectorAuthMessage {\n");
            sb.Append("  RemoteUserLocale: ").Append(RemoteUserLocale).Append("\n");
            sb.Append("  RemoteUserName: ").Append(RemoteUserName).Append("\n");
            sb.Append("  RemoteUserRoles: ").Append(RemoteUserRoles).Append("\n");
            sb.Append("  RemoteUserSessionId: ").Append(RemoteUserSessionId).Append("\n");
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
            return this.Equals(obj as ConnectorAuthMessage);
        }

        /// <summary>
        /// Returns true if ConnectorAuthMessage instances are equal
        /// </summary>
        /// <param name="other">Instance of ConnectorAuthMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConnectorAuthMessage other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.RemoteUserLocale == other.RemoteUserLocale ||
                    this.RemoteUserLocale != null &&
                    this.RemoteUserLocale.Equals(other.RemoteUserLocale)
                ) && 
                (
                    this.RemoteUserName == other.RemoteUserName ||
                    this.RemoteUserName != null &&
                    this.RemoteUserName.Equals(other.RemoteUserName)
                ) && 
                (
                    this.RemoteUserRoles == other.RemoteUserRoles ||
                    this.RemoteUserRoles != null &&
                    this.RemoteUserRoles.Equals(other.RemoteUserRoles)
                ) && 
                (
                    this.RemoteUserSessionId == other.RemoteUserSessionId ||
                    this.RemoteUserSessionId != null &&
                    this.RemoteUserSessionId.Equals(other.RemoteUserSessionId)
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
                if (this.RemoteUserLocale != null)
                    hash = hash * 59 + this.RemoteUserLocale.GetHashCode();
                if (this.RemoteUserName != null)
                    hash = hash * 59 + this.RemoteUserName.GetHashCode();
                if (this.RemoteUserRoles != null)
                    hash = hash * 59 + this.RemoteUserRoles.GetHashCode();
                if (this.RemoteUserSessionId != null)
                    hash = hash * 59 + this.RemoteUserSessionId.GetHashCode();
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
