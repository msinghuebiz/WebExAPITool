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
    /// This type specifies a download path/location (supports S3 currently) 
    /// </summary>
    [DataContract]
    public partial class TaskFileDownloadInfo :  IEquatable<TaskFileDownloadInfo>, IValidatableObject
    {
        /// <summary>
        /// The type of download location   
        /// </summary>
        /// <value>The type of download location   </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum S3 for "S3"
            /// </summary>
            [EnumMember(Value = "S3")]
            S3,
            
            /// <summary>
            /// Enum Local for "Local"
            /// </summary>
            [EnumMember(Value = "Local")]
            Local,
            
            /// <summary>
            /// Enum Inline for "Inline"
            /// </summary>
            [EnumMember(Value = "Inline")]
            Inline
        }

        /// <summary>
        /// The type of download location   
        /// </summary>
        /// <value>The type of download location   </value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskFileDownloadInfo" /> class.
        /// </summary>
        /// <param name="Contents">If the type of the download is inline, it will read the file from the contents here.  .</param>
        /// <param name="Path">The path of the download from the specified source location (If type is S3, then this is the object key)  .</param>
        /// <param name="Source">The source of the download location (If type is S3, then this is the bucket name)  .</param>
        /// <param name="Type">The type of download location    (default to TypeEnum.S3).</param>
        public TaskFileDownloadInfo(string Contents = default(string), string Path = default(string), string Source = default(string), TypeEnum? Type = TypeEnum.S3)
        {
            this.Contents = Contents;
            this.Path = Path;
            this.Source = Source;
            // use default value if no "Type" provided
            if (Type == null)
            {
                this.Type = TypeEnum.S3;
            }
            else
            {
                this.Type = Type;
            }
        }
        
        /// <summary>
        /// If the type of the download is inline, it will read the file from the contents here.  
        /// </summary>
        /// <value>If the type of the download is inline, it will read the file from the contents here.  </value>
        [DataMember(Name="Contents", EmitDefaultValue=false)]
        public string Contents { get; set; }

        /// <summary>
        /// The path of the download from the specified source location (If type is S3, then this is the object key)  
        /// </summary>
        /// <value>The path of the download from the specified source location (If type is S3, then this is the object key)  </value>
        [DataMember(Name="Path", EmitDefaultValue=false)]
        public string Path { get; set; }

        /// <summary>
        /// The source of the download location (If type is S3, then this is the bucket name)  
        /// </summary>
        /// <value>The source of the download location (If type is S3, then this is the bucket name)  </value>
        [DataMember(Name="Source", EmitDefaultValue=false)]
        public string Source { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaskFileDownloadInfo {\n");
            sb.Append("  Contents: ").Append(Contents).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
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
            return this.Equals(obj as TaskFileDownloadInfo);
        }

        /// <summary>
        /// Returns true if TaskFileDownloadInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of TaskFileDownloadInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskFileDownloadInfo other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Contents == other.Contents ||
                    this.Contents != null &&
                    this.Contents.Equals(other.Contents)
                ) && 
                (
                    this.Path == other.Path ||
                    this.Path != null &&
                    this.Path.Equals(other.Path)
                ) && 
                (
                    this.Source == other.Source ||
                    this.Source != null &&
                    this.Source.Equals(other.Source)
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
                if (this.Contents != null)
                    hash = hash * 59 + this.Contents.GetHashCode();
                if (this.Path != null)
                    hash = hash * 59 + this.Path.GetHashCode();
                if (this.Source != null)
                    hash = hash * 59 + this.Source.GetHashCode();
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