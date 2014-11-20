using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.ViewModels
{
    // Conforme o model por vezes crio varias ViewModels diferentes conforme o Request
    public class DummyItemViewModel
    {
        public int DummyItemID { get; set; }
        public string DummyDescription { get; set; }
    }

}