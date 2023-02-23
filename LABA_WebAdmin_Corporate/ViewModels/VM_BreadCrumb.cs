using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.ViewModels
{
	public class VM_BreadCrumb
	{
        public string ParentName { get; set; }
        public string ParentUrl { get; set; }
        public string ChildName { get; set; }
        public string ChildUrl { get; set; }
        public string CurrentName { get; set; }
        public bool IsHiddenTitle { get; set; } = false;
    }
}
