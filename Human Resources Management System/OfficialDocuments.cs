using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HR_MS
{
    public class OfficialDocuments
    {
        public string DocType = string.Empty;
        public string DocClass = string.Empty;
        public string DocID = string.Empty;
        public string IssuePlace = string.Empty;
        public DateTime DocIssueDate = new DateTime();
        public DateTime DocExpDate = new DateTime();
        public Image[] DocPicture = new Image[4];
    }
}
