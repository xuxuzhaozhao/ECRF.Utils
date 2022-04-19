using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECRF.Utils.GIT_EXTRACT.Models
{
    public class CommitLogModel
    {
        [DisplayName("SHA")]
        public string Sha { get; set; }
        [DisplayName("修改者")]
        public string Author { get; set; }
        [DisplayName("提交时间")]
        public string CommitDate { get; set; }
        [DisplayName("提交信息")]
        public string Message { get; set; }
    }
}
