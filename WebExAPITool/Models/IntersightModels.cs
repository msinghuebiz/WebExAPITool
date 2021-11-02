using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExAPITool.Intersight.Client;
using WebExAPITool.Intersight.Model;

namespace WebExAPITool.Models
{
    public class AlarmDetailsInterSight
    {
        public CondAlarm alarmDetails { get; set; }
        public ComputeBlade AncesstorDetails { get; set; }
        public TopSystem AffectedTopSystem { get; set; }
        public EquipmentChassis AffectedEquipmentChansis { get; set; }
        
    }
}
