using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class MessageRoomObject
    {

        public string roomId { get; set; }
        public string toPersonId { get; set; }
        public string toPersonEmail { get; set; }
        public string text { get; set; }
        

        //        {
        //  "roomId": "Y2lzY29zcGFyazovL3VzL1JPT00vYmJjZWIxYWQtNDNmMS0zYjU4LTkxNDctZjE0YmIwYzRkMTU0",
        //  "toPersonId": "Y2lzY29zcGFyazovL3VzL1BFT1BMRS9mMDZkNzFhNS0wODMzLTRmYTUtYTcyYS1jYzg5YjI1ZWVlMmX",
        //  "toPersonEmail": "julie@example.com",
        //  "text": "PROJECT UPDATE - A new project plan has been published on Box: http://box.com/s/lf5vj. The PM for this project is Mike C. and the Engineering Manager is Jane W.",
        //  "markdown": "**PROJECT UPDATE** A new project plan has been published [on Box](http://box.com/s/lf5vj). The PM for this project is <@personEmail:mike@example.com> and the Engineering Manager is <@personEmail:jane@example.com>.",
        //  "files": [
        //    "http://www.example.com/images/media.png"
        //  ],
        //  "attachments": [
        //    {
        //      "contentType": "application/vnd.microsoft.card.adaptive",
        //      "content": {
        //        "type": "AdaptiveCard",
        //        "version": "1.0",
        //        "body": [
        //          {
        //            "type": "TextBlock",
        //            "text": "Adaptive Cards",
        //            "size": "large"
        //          }
        //        ],
        //        "actions": [
        //          {
        //            "type": "Action.OpenUrl",
        //            "url": "http://adaptivecards.io",
        //            "title": "Learn More"
        //          }
        //        ]
        //      }    
        //    }
        //  ]
        //}




    }
}
