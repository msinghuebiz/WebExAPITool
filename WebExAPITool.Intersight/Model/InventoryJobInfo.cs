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
    /// Complex type representing the Job Information of a device 
    /// </summary>
    [DataContract]
    public partial class InventoryJobInfo :  IEquatable<InventoryJobInfo>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets ExecutionStatus
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExecutionStatusEnum
        {
            
            /// <summary>
            /// Enum Unknown for "Unknown"
            /// </summary>
            [EnumMember(Value = "Unknown")]
            Unknown,
            
            /// <summary>
            /// Enum Scheduled for "Scheduled"
            /// </summary>
            [EnumMember(Value = "Scheduled")]
            Scheduled,
            
            /// <summary>
            /// Enum Completed for "Completed"
            /// </summary>
            [EnumMember(Value = "Completed")]
            Completed,
            
            /// <summary>
            /// Enum Error for "Error"
            /// </summary>
            [EnumMember(Value = "Error")]
            Error
        }

        /// <summary>
        /// Gets or Sets ExecutionStatus
        /// </summary>
        [DataMember(Name="ExecutionStatus", EmitDefaultValue=false)]
        public ExecutionStatusEnum? ExecutionStatus { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryJobInfo" /> class.
        /// </summary>
        /// <param name="Properties">Properties.</param>
        /// <param name="Regex">Regex.</param>
        public InventoryJobInfo(List<string> Properties = default(List<string>), List<string> Regex = default(List<string>))
        {
            this.Properties = Properties;
            this.Regex = Regex;
        }
        

        /// <summary>
        /// Gets or Sets JobName
        /// </summary>
        [DataMember(Name="JobName", EmitDefaultValue=false)]
        public string JobName { get; private set; }

        /// <summary>
        /// Gets or Sets LastProcessedTime
        /// </summary>
        [DataMember(Name="LastProcessedTime", EmitDefaultValue=false)]
        public DateTime? LastProcessedTime { get; private set; }

        /// <summary>
        /// Gets or Sets LastScheduledTime
        /// </summary>
        [DataMember(Name="LastScheduledTime", EmitDefaultValue=false)]
        public DateTime? LastScheduledTime { get; private set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [DataMember(Name="Properties", EmitDefaultValue=false)]
        public List<string> Properties { get; set; }

        /// <summary>
        /// Gets or Sets Regex
        /// </summary>
        [DataMember(Name="Regex", EmitDefaultValue=false)]
        public List<string> Regex { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InventoryJobInfo {\n");
            sb.Append("  ExecutionStatus: ").Append(ExecutionStatus).Append("\n");
            sb.Append("  JobName: ").Append(JobName).Append("\n");
            sb.Append("  LastProcessedTime: ").Append(LastProcessedTime).Append("\n");
            sb.Append("  LastScheduledTime: ").Append(LastScheduledTime).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  Regex: ").Append(Regex).Append("\n");
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
            return this.Equals(obj as InventoryJobInfo);
        }

        /// <summary>
        /// Returns true if InventoryJobInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of InventoryJobInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InventoryJobInfo other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ExecutionStatus == other.ExecutionStatus ||
                    this.ExecutionStatus != null &&
                    this.ExecutionStatus.Equals(other.ExecutionStatus)
                ) && 
                (
                    this.JobName == other.JobName ||
                    this.JobName != null &&
                    this.JobName.Equals(other.JobName)
                ) && 
                (
                    this.LastProcessedTime == other.LastProcessedTime ||
                    this.LastProcessedTime != null &&
                    this.LastProcessedTime.Equals(other.LastProcessedTime)
                ) && 
                (
                    this.LastScheduledTime == other.LastScheduledTime ||
                    this.LastScheduledTime != null &&
                    this.LastScheduledTime.Equals(other.LastScheduledTime)
                ) && 
                (
                    this.Properties == other.Properties ||
                    this.Properties != null &&
                    this.Properties.SequenceEqual(other.Properties)
                ) && 
                (
                    this.Regex == other.Regex ||
                    this.Regex != null &&
                    this.Regex.SequenceEqual(other.Regex)
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
                if (this.ExecutionStatus != null)
                    hash = hash * 59 + this.ExecutionStatus.GetHashCode();
                if (this.JobName != null)
                    hash = hash * 59 + this.JobName.GetHashCode();
                if (this.LastProcessedTime != null)
                    hash = hash * 59 + this.LastProcessedTime.GetHashCode();
                if (this.LastScheduledTime != null)
                    hash = hash * 59 + this.LastScheduledTime.GetHashCode();
                if (this.Properties != null)
                    hash = hash * 59 + this.Properties.GetHashCode();
                if (this.Regex != null)
                    hash = hash * 59 + this.Regex.GetHashCode();
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
