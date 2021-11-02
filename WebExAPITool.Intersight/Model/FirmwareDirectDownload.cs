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
    /// FirmwareDirectDownload
    /// </summary>
    [DataContract]
    public partial class FirmwareDirectDownload :  IEquatable<FirmwareDirectDownload>, IValidatableObject
    {
        /// <summary>
        /// Source type referring the image to be downloaded from CCO or from a local https server  
        /// </summary>
        /// <value>Source type referring the image to be downloaded from CCO or from a local https server  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ImageSourceEnum
        {
            
            /// <summary>
            /// Enum Cco for "cco"
            /// </summary>
            [EnumMember(Value = "cco")]
            Cco,
            
            /// <summary>
            /// Enum LocalHttp for "localHttp"
            /// </summary>
            [EnumMember(Value = "localHttp")]
            LocalHttp
        }

        /// <summary>
        /// Option to control the upgrade, e.g., sd_upgrade_mount_only - download the image into sd and upgrade wait for the server on-next boot  
        /// </summary>
        /// <value>Option to control the upgrade, e.g., sd_upgrade_mount_only - download the image into sd and upgrade wait for the server on-next boot  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UpgradeoptionEnum
        {
            
            /// <summary>
            /// Enum Upgrademountonly for "sd_upgrade_mount_only"
            /// </summary>
            [EnumMember(Value = "sd_upgrade_mount_only")]
            Upgrademountonly,
            
            /// <summary>
            /// Enum Downloadonly for "sd_download_only"
            /// </summary>
            [EnumMember(Value = "sd_download_only")]
            Downloadonly,
            
            /// <summary>
            /// Enum Upgradeonly for "sd_upgrade_only"
            /// </summary>
            [EnumMember(Value = "sd_upgrade_only")]
            Upgradeonly,
            
            /// <summary>
            /// Enum Upgradefull for "sd_upgrade_full"
            /// </summary>
            [EnumMember(Value = "sd_upgrade_full")]
            Upgradefull
        }

        /// <summary>
        /// Source type referring the image to be downloaded from CCO or from a local https server  
        /// </summary>
        /// <value>Source type referring the image to be downloaded from CCO or from a local https server  </value>
        [DataMember(Name="ImageSource", EmitDefaultValue=false)]
        public ImageSourceEnum? ImageSource { get; set; }
        /// <summary>
        /// Option to control the upgrade, e.g., sd_upgrade_mount_only - download the image into sd and upgrade wait for the server on-next boot  
        /// </summary>
        /// <value>Option to control the upgrade, e.g., sd_upgrade_mount_only - download the image into sd and upgrade wait for the server on-next boot  </value>
        [DataMember(Name="Upgradeoption", EmitDefaultValue=false)]
        public UpgradeoptionEnum? Upgradeoption { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FirmwareDirectDownload" /> class.
        /// </summary>
        /// <param name="HttpServer">HTTP Server option when the image source is a local https server  .</param>
        /// <param name="ImageSource">Source type referring the image to be downloaded from CCO or from a local https server   (default to ImageSourceEnum.Cco).</param>
        /// <param name="IsPasswordSet">IsPasswordSet.</param>
        /// <param name="Password">Password as configured on the local https server  .</param>
        /// <param name="Upgradeoption">Option to control the upgrade, e.g., sd_upgrade_mount_only - download the image into sd and upgrade wait for the server on-next boot   (default to UpgradeoptionEnum.Upgrademountonly).</param>
        /// <param name="Username">Username as configured on the local https server   .</param>
        public FirmwareDirectDownload(FirmwareHttpServer HttpServer = default(FirmwareHttpServer), ImageSourceEnum? ImageSource = ImageSourceEnum.Cco, bool? IsPasswordSet = default(bool?), string Password = default(string), UpgradeoptionEnum? Upgradeoption = UpgradeoptionEnum.Upgrademountonly, string Username = default(string))
        {
            this.HttpServer = HttpServer;
            // use default value if no "ImageSource" provided
            if (ImageSource == null)
            {
                this.ImageSource = ImageSourceEnum.Cco;
            }
            else
            {
                this.ImageSource = ImageSource;
            }
            this.IsPasswordSet = IsPasswordSet;
            this.Password = Password;
            // use default value if no "Upgradeoption" provided
            if (Upgradeoption == null)
            {
                this.Upgradeoption = UpgradeoptionEnum.Upgrademountonly;
            }
            else
            {
                this.Upgradeoption = Upgradeoption;
            }
            this.Username = Username;
        }
        
        /// <summary>
        /// HTTP Server option when the image source is a local https server  
        /// </summary>
        /// <value>HTTP Server option when the image source is a local https server  </value>
        [DataMember(Name="HttpServer", EmitDefaultValue=false)]
        public FirmwareHttpServer HttpServer { get; set; }


        /// <summary>
        /// Gets or Sets IsPasswordSet
        /// </summary>
        [DataMember(Name="IsPasswordSet", EmitDefaultValue=false)]
        public bool? IsPasswordSet { get; set; }

        /// <summary>
        /// Password as configured on the local https server  
        /// </summary>
        /// <value>Password as configured on the local https server  </value>
        [DataMember(Name="Password", EmitDefaultValue=false)]
        public string Password { get; set; }


        /// <summary>
        /// Username as configured on the local https server   
        /// </summary>
        /// <value>Username as configured on the local https server   </value>
        [DataMember(Name="Username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareDirectDownload {\n");
            sb.Append("  HttpServer: ").Append(HttpServer).Append("\n");
            sb.Append("  ImageSource: ").Append(ImageSource).Append("\n");
            sb.Append("  IsPasswordSet: ").Append(IsPasswordSet).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Upgradeoption: ").Append(Upgradeoption).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
            return this.Equals(obj as FirmwareDirectDownload);
        }

        /// <summary>
        /// Returns true if FirmwareDirectDownload instances are equal
        /// </summary>
        /// <param name="other">Instance of FirmwareDirectDownload to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FirmwareDirectDownload other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.HttpServer == other.HttpServer ||
                    this.HttpServer != null &&
                    this.HttpServer.Equals(other.HttpServer)
                ) && 
                (
                    this.ImageSource == other.ImageSource ||
                    this.ImageSource != null &&
                    this.ImageSource.Equals(other.ImageSource)
                ) && 
                (
                    this.IsPasswordSet == other.IsPasswordSet ||
                    this.IsPasswordSet != null &&
                    this.IsPasswordSet.Equals(other.IsPasswordSet)
                ) && 
                (
                    this.Password == other.Password ||
                    this.Password != null &&
                    this.Password.Equals(other.Password)
                ) && 
                (
                    this.Upgradeoption == other.Upgradeoption ||
                    this.Upgradeoption != null &&
                    this.Upgradeoption.Equals(other.Upgradeoption)
                ) && 
                (
                    this.Username == other.Username ||
                    this.Username != null &&
                    this.Username.Equals(other.Username)
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
                if (this.HttpServer != null)
                    hash = hash * 59 + this.HttpServer.GetHashCode();
                if (this.ImageSource != null)
                    hash = hash * 59 + this.ImageSource.GetHashCode();
                if (this.IsPasswordSet != null)
                    hash = hash * 59 + this.IsPasswordSet.GetHashCode();
                if (this.Password != null)
                    hash = hash * 59 + this.Password.GetHashCode();
                if (this.Upgradeoption != null)
                    hash = hash * 59 + this.Upgradeoption.GetHashCode();
                if (this.Username != null)
                    hash = hash * 59 + this.Username.GetHashCode();
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
