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
    /// This MO contains information for a workflow instance 
    /// </summary>
    [DataContract]
    public partial class WorkflowWorkflowInfo :  IEquatable<WorkflowWorkflowInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowWorkflowInfo" /> class.
        /// </summary>
        /// <param name="Ancestors">Ancestors is an array containing the MO references of the ancestors in the object containment hierarchy. .</param>
        /// <param name="Moid">A unique identifier of this Managed Object instance.  .</param>
        /// <param name="Owners">An array of owners which represent effective ownership of this object.   .</param>
        /// <param name="Parent">The direct ancestor of this managed object in the containment hierarchy. .</param>
        /// <param name="Tags">An array of tags, which allow to add key, value meta-data to managed objects.   .</param>
        /// <param name="Account">An account owns the workflow instatnce .</param>
        /// <param name="EndTime">The time on which the workflow is ended.  .</param>
        /// <param name="Input">An input of the workflow  .</param>
        /// <param name="InstId">A workflow instance Id  .</param>
        /// <param name="MetaVersion">This is version of the workflow metadata  .</param>
        /// <param name="Name">A name of the workflow  .</param>
        /// <param name="Output">An output of the workflow  .</param>
        /// <param name="Progress">This field indicates percetage of workflow task execution  .</param>
        /// <param name="Src">The source microservice name  .</param>
        /// <param name="StartTime">The time on which the workflow is started.  .</param>
        /// <param name="Status">A status of the workflow (RUNNING, WAITING, COMPLETED, TIME_OUT, FAILED)  .</param>
        /// <param name="TaskInfos">TaskInfos.</param>
        /// <param name="UserId">UserId.</param>
        /// <param name="WorkflowCtx">The workflow workflow context which contains initiator and target information  .</param>
        /// <param name="WorkflowKey">This key contains workflow, initiator and target name. Fusion uses the key to do workflow dedup  .</param>
        /// <param name="WorkflowTaskCount">This attribute captures total workflow tasks   .</param>
        public WorkflowWorkflowInfo(List<MoBaseMoRef> Ancestors = default(List<MoBaseMoRef>), string Moid = default(string), List<string> Owners = default(List<string>), MoBaseMoRef Parent = default(MoBaseMoRef), List<MoTag> Tags = default(List<MoTag>), IamAccountRef Account = default(IamAccountRef), DateTime? EndTime = default(DateTime?), Object Input = default(Object), string InstId = default(string), string MetaVersion = default(string), string Name = default(string), Object Output = default(Object), float? Progress = default(float?), string Src = default(string), DateTime? StartTime = default(DateTime?), string Status = default(string), List<WorkflowTaskInfoRef> TaskInfos = default(List<WorkflowTaskInfoRef>), string UserId = default(string), Object WorkflowCtx = default(Object), string WorkflowKey = default(string), long? WorkflowTaskCount = default(long?))
        {
            this.Ancestors = Ancestors;
            this.Moid = Moid;
            this.Owners = Owners;
            this.Parent = Parent;
            this.Tags = Tags;
            this.Account = Account;
            this.EndTime = EndTime;
            this.Input = Input;
            this.InstId = InstId;
            this.MetaVersion = MetaVersion;
            this.Name = Name;
            this.Output = Output;
            this.Progress = Progress;
            this.Src = Src;
            this.StartTime = StartTime;
            this.Status = Status;
            this.TaskInfos = TaskInfos;
            this.UserId = UserId;
            this.WorkflowCtx = WorkflowCtx;
            this.WorkflowKey = WorkflowKey;
            this.WorkflowTaskCount = WorkflowTaskCount;
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
        /// An account owns the workflow instatnce 
        /// </summary>
        /// <value>An account owns the workflow instatnce </value>
        [DataMember(Name="Account", EmitDefaultValue=false)]
        public IamAccountRef Account { get; set; }

        /// <summary>
        /// The time on which the workflow is ended.  
        /// </summary>
        /// <value>The time on which the workflow is ended.  </value>
        [DataMember(Name="EndTime", EmitDefaultValue=false)]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// An input of the workflow  
        /// </summary>
        /// <value>An input of the workflow  </value>
        [DataMember(Name="Input", EmitDefaultValue=false)]
        public Object Input { get; set; }

        /// <summary>
        /// A workflow instance Id  
        /// </summary>
        /// <value>A workflow instance Id  </value>
        [DataMember(Name="InstId", EmitDefaultValue=false)]
        public string InstId { get; set; }

        /// <summary>
        /// This is version of the workflow metadata  
        /// </summary>
        /// <value>This is version of the workflow metadata  </value>
        [DataMember(Name="MetaVersion", EmitDefaultValue=false)]
        public string MetaVersion { get; set; }

        /// <summary>
        /// A name of the workflow  
        /// </summary>
        /// <value>A name of the workflow  </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// An output of the workflow  
        /// </summary>
        /// <value>An output of the workflow  </value>
        [DataMember(Name="Output", EmitDefaultValue=false)]
        public Object Output { get; set; }

        /// <summary>
        /// This field indicates percetage of workflow task execution  
        /// </summary>
        /// <value>This field indicates percetage of workflow task execution  </value>
        [DataMember(Name="Progress", EmitDefaultValue=false)]
        public float? Progress { get; set; }

        /// <summary>
        /// The source microservice name  
        /// </summary>
        /// <value>The source microservice name  </value>
        [DataMember(Name="Src", EmitDefaultValue=false)]
        public string Src { get; set; }

        /// <summary>
        /// The time on which the workflow is started.  
        /// </summary>
        /// <value>The time on which the workflow is started.  </value>
        [DataMember(Name="StartTime", EmitDefaultValue=false)]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// A status of the workflow (RUNNING, WAITING, COMPLETED, TIME_OUT, FAILED)  
        /// </summary>
        /// <value>A status of the workflow (RUNNING, WAITING, COMPLETED, TIME_OUT, FAILED)  </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets TaskInfos
        /// </summary>
        [DataMember(Name="TaskInfos", EmitDefaultValue=false)]
        public List<WorkflowTaskInfoRef> TaskInfos { get; set; }

        /// <summary>
        /// A type of the workflow (serverconfig, ansible_monitoring)  
        /// </summary>
        /// <value>A type of the workflow (serverconfig, ansible_monitoring)  </value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public string Type { get; private set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name="UserId", EmitDefaultValue=false)]
        public string UserId { get; set; }

        /// <summary>
        /// The workflow workflow context which contains initiator and target information  
        /// </summary>
        /// <value>The workflow workflow context which contains initiator and target information  </value>
        [DataMember(Name="WorkflowCtx", EmitDefaultValue=false)]
        public Object WorkflowCtx { get; set; }

        /// <summary>
        /// This key contains workflow, initiator and target name. Fusion uses the key to do workflow dedup  
        /// </summary>
        /// <value>This key contains workflow, initiator and target name. Fusion uses the key to do workflow dedup  </value>
        [DataMember(Name="WorkflowKey", EmitDefaultValue=false)]
        public string WorkflowKey { get; set; }

        /// <summary>
        /// This attribute captures total workflow tasks   
        /// </summary>
        /// <value>This attribute captures total workflow tasks   </value>
        [DataMember(Name="WorkflowTaskCount", EmitDefaultValue=false)]
        public long? WorkflowTaskCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkflowWorkflowInfo {\n");
            sb.Append("  AccountMoid: ").Append(AccountMoid).Append("\n");
            sb.Append("  Ancestors: ").Append(Ancestors).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  ModTime: ").Append(ModTime).Append("\n");
            sb.Append("  Moid: ").Append(Moid).Append("\n");
            sb.Append("  ObjectType: ").Append(ObjectType).Append("\n");
            sb.Append("  Owners: ").Append(Owners).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  InstId: ").Append(InstId).Append("\n");
            sb.Append("  MetaVersion: ").Append(MetaVersion).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Output: ").Append(Output).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
            sb.Append("  Src: ").Append(Src).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  TaskInfos: ").Append(TaskInfos).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  WorkflowCtx: ").Append(WorkflowCtx).Append("\n");
            sb.Append("  WorkflowKey: ").Append(WorkflowKey).Append("\n");
            sb.Append("  WorkflowTaskCount: ").Append(WorkflowTaskCount).Append("\n");
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
            return this.Equals(obj as WorkflowWorkflowInfo);
        }

        /// <summary>
        /// Returns true if WorkflowWorkflowInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of WorkflowWorkflowInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowWorkflowInfo other)
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
                    this.Account == other.Account ||
                    this.Account != null &&
                    this.Account.Equals(other.Account)
                ) && 
                (
                    this.EndTime == other.EndTime ||
                    this.EndTime != null &&
                    this.EndTime.Equals(other.EndTime)
                ) && 
                (
                    this.Input == other.Input ||
                    this.Input != null &&
                    this.Input.Equals(other.Input)
                ) && 
                (
                    this.InstId == other.InstId ||
                    this.InstId != null &&
                    this.InstId.Equals(other.InstId)
                ) && 
                (
                    this.MetaVersion == other.MetaVersion ||
                    this.MetaVersion != null &&
                    this.MetaVersion.Equals(other.MetaVersion)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Output == other.Output ||
                    this.Output != null &&
                    this.Output.Equals(other.Output)
                ) && 
                (
                    this.Progress == other.Progress ||
                    this.Progress != null &&
                    this.Progress.Equals(other.Progress)
                ) && 
                (
                    this.Src == other.Src ||
                    this.Src != null &&
                    this.Src.Equals(other.Src)
                ) && 
                (
                    this.StartTime == other.StartTime ||
                    this.StartTime != null &&
                    this.StartTime.Equals(other.StartTime)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.TaskInfos == other.TaskInfos ||
                    this.TaskInfos != null &&
                    this.TaskInfos.SequenceEqual(other.TaskInfos)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.UserId == other.UserId ||
                    this.UserId != null &&
                    this.UserId.Equals(other.UserId)
                ) && 
                (
                    this.WorkflowCtx == other.WorkflowCtx ||
                    this.WorkflowCtx != null &&
                    this.WorkflowCtx.Equals(other.WorkflowCtx)
                ) && 
                (
                    this.WorkflowKey == other.WorkflowKey ||
                    this.WorkflowKey != null &&
                    this.WorkflowKey.Equals(other.WorkflowKey)
                ) && 
                (
                    this.WorkflowTaskCount == other.WorkflowTaskCount ||
                    this.WorkflowTaskCount != null &&
                    this.WorkflowTaskCount.Equals(other.WorkflowTaskCount)
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
                if (this.Account != null)
                    hash = hash * 59 + this.Account.GetHashCode();
                if (this.EndTime != null)
                    hash = hash * 59 + this.EndTime.GetHashCode();
                if (this.Input != null)
                    hash = hash * 59 + this.Input.GetHashCode();
                if (this.InstId != null)
                    hash = hash * 59 + this.InstId.GetHashCode();
                if (this.MetaVersion != null)
                    hash = hash * 59 + this.MetaVersion.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Output != null)
                    hash = hash * 59 + this.Output.GetHashCode();
                if (this.Progress != null)
                    hash = hash * 59 + this.Progress.GetHashCode();
                if (this.Src != null)
                    hash = hash * 59 + this.Src.GetHashCode();
                if (this.StartTime != null)
                    hash = hash * 59 + this.StartTime.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.TaskInfos != null)
                    hash = hash * 59 + this.TaskInfos.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.UserId != null)
                    hash = hash * 59 + this.UserId.GetHashCode();
                if (this.WorkflowCtx != null)
                    hash = hash * 59 + this.WorkflowCtx.GetHashCode();
                if (this.WorkflowKey != null)
                    hash = hash * 59 + this.WorkflowKey.GetHashCode();
                if (this.WorkflowTaskCount != null)
                    hash = hash * 59 + this.WorkflowTaskCount.GetHashCode();
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
