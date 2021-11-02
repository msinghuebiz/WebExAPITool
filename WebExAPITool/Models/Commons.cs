using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{

    public class Common
    {
        public static string ConnectionString { get; set; }
        public const string _GetAuthorise = "authorize?client_id={0}&response_type=code&redirect_uri={1}&scope=spark-compliance%3Amemberships_read%20spark-admin%3Aresource_groups_read%20spark%3Aall%20spark-compliance%3Amemberships_write%20spark-admin%3Apeople_write%20spark-admin%3Aroles_read%20spark-admin%3Aorganizations_read%20spark-admin%3Aresource_group_memberships_read%20spark-compliance%3Aevents_read%20spark-admin%3Aresource_group_memberships_write%20spark-compliance%3Arooms_read%20spark-compliance%3Ateam_memberships_read%20spark-admin%3Acall_qualities_read%20spark-compliance%3Amessages_write%20spark-compliance%3Ateam_memberships_write%20spark%3Akms%20audit%3Aevents_read%20spark-compliance%3Ateams_read%20spark-admin%3Alicenses_read%20spark-compliance%3Amessages_read%20spark-admin%3Apeople_read&state={2}";
        public const string _GetAccessToken = "access_token";
        public const string _GetTeamMessage = "messages";
        public const string _GetAccessTokenContent = "grant_type=authorization_code&" +
                                                                            "code={0}&" +
                                                                            "client_id={1}&" +
                                                                            "client_secret={2}";


        public const string _ListProgressClient = "Progress/ShowProgress?progress={0}";

    }
    public class CommonUpdateFields
    {
        //	personalTeleconf/account/accountIndex					
        public const string _WebExID = "webExId";
       
     
        
        public const string _SchedulingPermission = "schedulingPermission";
        public const string _HostPin = "personalMeetingRoom/hostPIN";
        public const string _TimeZoneID = "timeZoneID";
        public const string _phones_phone = "phones/phone";
        public const string _phones_PIN = "phones/PIN";
        public const string _phones_pager = "phones/pager";
        public const string _defaultCallIn_countryAlias = "defaultCallIn/defaultGlobalCallInNum/countryAlias";
        public const string _defaultCallIn_phoneNumber = "defaultCallIn/defaultGlobalCallInNum/phoneNumber";
        public const string _defaultCallIn_tollFree = "defaultCallIn/defaultGlobalCallInNum/tollFree";
        public const string _personalTeleconf_subscriberAccessCode = "personalTeleconf/account/subscriberAccessCode";
        public const string _personalTeleconf_participantFullAccessCode = "personalTeleconf/account/participantFullAccessCode";
        public const string _personalTeleconf_Account_joinBeforeHost = "personalTeleconf/account/joinBeforeHost";
        public const string _personalTeleconf_joinBeforeHost = "personalTeleconf/joinBeforeHost";



    }

    public enum UserColumnType
    {
        User,
        Site
    }

    public enum FrequencyType
    {
        Day,
        Month,
        Min
    }

}
