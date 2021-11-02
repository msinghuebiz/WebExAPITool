using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models.AdminAPI
{
    public class QueryPeople :BasePageModel
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string ID { get; set; }
        public string OrgID { get; set; }
        public int Max { get; set; }

    }

    public class ResponsePeople
    {
        public string Name { get; set; }
        public List<PeopleItems> Items { get; set; }
        public List<string> NoFoundIDs { get; set; }
    }


}

public class PeopleItems
{
    public string ID { get; set; }
    public List<string> Emails { get; set; }
    public List<string> PhoneNumbers { get; set; }
    public string DisplayName { get; set; }
    public string NickName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Avatar { get; set; }
    public string OrgID { get; set; }
    public List<string> Roles { get; set; }
    public List<string> Licenses { get; set; }
    public string Created { get; set; }
    public string LastModified { get; set; }
    public string TimeZone { get; set; }
    public string LastActivity { get; set; }
    public Status Status { get; set; }
    public bool InvitePending { get; set; }
    public bool LogInEnabled { get; set; }
    public PersonType Type { get; set; }

}

public enum Status
{
    Active,
    Call,
    DoNotDisturb,
    Inactive,
    Meeting,
    OutOfOffice,
    Pending,
    Presenting,
    Unknown
}

public enum PersonType
{
    Person,
    Bot
}
