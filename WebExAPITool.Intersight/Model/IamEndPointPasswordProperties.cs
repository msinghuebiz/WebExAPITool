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
    /// Password properties for endpoint users 
    /// </summary>
    [DataContract]
    public partial class IamEndPointPasswordProperties :  IEquatable<IamEndPointPasswordProperties>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IamEndPointPasswordProperties" /> class.
        /// </summary>
        /// <param name="EnablePasswordExpiry">Enables password expiry on the endpoint  .</param>
        /// <param name="EnforceStrongPassword">Enables a strong password policy Strong password requirements: A. The password must have a minimum of 8 and a maximum of 20 characters. B. The password must not contain the User&#39;s Name. C. The password must contain characters from three of the following four categories. 1) English uppercase characters (A through Z). 2) English lowercase characters (a through z). 3) Base 10 digits (0 through 9). 4) Non-alphabetic characters (!, @, #, $, %, ^, &amp;, *, -, _, +, &#x3D;). .</param>
        /// <param name="GracePeriod">Time period until when you can use the existing password, after it expires  .</param>
        /// <param name="NotificationPeriod">Specifies the duration by when the password will expire  .</param>
        /// <param name="PasswordExpiryDuration">Set time period for password expiration. Value should be greater than notification period and grace period.  .</param>
        /// <param name="PasswordHistory">Tracks password change history. Specifies in number of instances, that the new password was already used.   .</param>
        public IamEndPointPasswordProperties(bool? EnablePasswordExpiry = default(bool?), bool? EnforceStrongPassword = default(bool?), long? GracePeriod = default(long?), long? NotificationPeriod = default(long?), long? PasswordExpiryDuration = default(long?), long? PasswordHistory = default(long?))
        {
            this.EnablePasswordExpiry = EnablePasswordExpiry;
            this.EnforceStrongPassword = EnforceStrongPassword;
            this.GracePeriod = GracePeriod;
            this.NotificationPeriod = NotificationPeriod;
            this.PasswordExpiryDuration = PasswordExpiryDuration;
            this.PasswordHistory = PasswordHistory;
        }
        
        /// <summary>
        /// Enables password expiry on the endpoint  
        /// </summary>
        /// <value>Enables password expiry on the endpoint  </value>
        [DataMember(Name="EnablePasswordExpiry", EmitDefaultValue=false)]
        public bool? EnablePasswordExpiry { get; set; }

        /// <summary>
        /// Enables a strong password policy Strong password requirements: A. The password must have a minimum of 8 and a maximum of 20 characters. B. The password must not contain the User&#39;s Name. C. The password must contain characters from three of the following four categories. 1) English uppercase characters (A through Z). 2) English lowercase characters (a through z). 3) Base 10 digits (0 through 9). 4) Non-alphabetic characters (!, @, #, $, %, ^, &amp;, *, -, _, +, &#x3D;). 
        /// </summary>
        /// <value>Enables a strong password policy Strong password requirements: A. The password must have a minimum of 8 and a maximum of 20 characters. B. The password must not contain the User&#39;s Name. C. The password must contain characters from three of the following four categories. 1) English uppercase characters (A through Z). 2) English lowercase characters (a through z). 3) Base 10 digits (0 through 9). 4) Non-alphabetic characters (!, @, #, $, %, ^, &amp;, *, -, _, +, &#x3D;). </value>
        [DataMember(Name="EnforceStrongPassword", EmitDefaultValue=false)]
        public bool? EnforceStrongPassword { get; set; }

        /// <summary>
        /// Time period until when you can use the existing password, after it expires  
        /// </summary>
        /// <value>Time period until when you can use the existing password, after it expires  </value>
        [DataMember(Name="GracePeriod", EmitDefaultValue=false)]
        public long? GracePeriod { get; set; }

        /// <summary>
        /// Specifies the duration by when the password will expire  
        /// </summary>
        /// <value>Specifies the duration by when the password will expire  </value>
        [DataMember(Name="NotificationPeriod", EmitDefaultValue=false)]
        public long? NotificationPeriod { get; set; }

        /// <summary>
        /// Set time period for password expiration. Value should be greater than notification period and grace period.  
        /// </summary>
        /// <value>Set time period for password expiration. Value should be greater than notification period and grace period.  </value>
        [DataMember(Name="PasswordExpiryDuration", EmitDefaultValue=false)]
        public long? PasswordExpiryDuration { get; set; }

        /// <summary>
        /// Tracks password change history. Specifies in number of instances, that the new password was already used.   
        /// </summary>
        /// <value>Tracks password change history. Specifies in number of instances, that the new password was already used.   </value>
        [DataMember(Name="PasswordHistory", EmitDefaultValue=false)]
        public long? PasswordHistory { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IamEndPointPasswordProperties {\n");
            sb.Append("  EnablePasswordExpiry: ").Append(EnablePasswordExpiry).Append("\n");
            sb.Append("  EnforceStrongPassword: ").Append(EnforceStrongPassword).Append("\n");
            sb.Append("  GracePeriod: ").Append(GracePeriod).Append("\n");
            sb.Append("  NotificationPeriod: ").Append(NotificationPeriod).Append("\n");
            sb.Append("  PasswordExpiryDuration: ").Append(PasswordExpiryDuration).Append("\n");
            sb.Append("  PasswordHistory: ").Append(PasswordHistory).Append("\n");
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
            return this.Equals(obj as IamEndPointPasswordProperties);
        }

        /// <summary>
        /// Returns true if IamEndPointPasswordProperties instances are equal
        /// </summary>
        /// <param name="other">Instance of IamEndPointPasswordProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IamEndPointPasswordProperties other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.EnablePasswordExpiry == other.EnablePasswordExpiry ||
                    this.EnablePasswordExpiry != null &&
                    this.EnablePasswordExpiry.Equals(other.EnablePasswordExpiry)
                ) && 
                (
                    this.EnforceStrongPassword == other.EnforceStrongPassword ||
                    this.EnforceStrongPassword != null &&
                    this.EnforceStrongPassword.Equals(other.EnforceStrongPassword)
                ) && 
                (
                    this.GracePeriod == other.GracePeriod ||
                    this.GracePeriod != null &&
                    this.GracePeriod.Equals(other.GracePeriod)
                ) && 
                (
                    this.NotificationPeriod == other.NotificationPeriod ||
                    this.NotificationPeriod != null &&
                    this.NotificationPeriod.Equals(other.NotificationPeriod)
                ) && 
                (
                    this.PasswordExpiryDuration == other.PasswordExpiryDuration ||
                    this.PasswordExpiryDuration != null &&
                    this.PasswordExpiryDuration.Equals(other.PasswordExpiryDuration)
                ) && 
                (
                    this.PasswordHistory == other.PasswordHistory ||
                    this.PasswordHistory != null &&
                    this.PasswordHistory.Equals(other.PasswordHistory)
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
                if (this.EnablePasswordExpiry != null)
                    hash = hash * 59 + this.EnablePasswordExpiry.GetHashCode();
                if (this.EnforceStrongPassword != null)
                    hash = hash * 59 + this.EnforceStrongPassword.GetHashCode();
                if (this.GracePeriod != null)
                    hash = hash * 59 + this.GracePeriod.GetHashCode();
                if (this.NotificationPeriod != null)
                    hash = hash * 59 + this.NotificationPeriod.GetHashCode();
                if (this.PasswordExpiryDuration != null)
                    hash = hash * 59 + this.PasswordExpiryDuration.GetHashCode();
                if (this.PasswordHistory != null)
                    hash = hash * 59 + this.PasswordHistory.GetHashCode();
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
