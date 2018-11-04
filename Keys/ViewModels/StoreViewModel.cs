using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Keys.Models;

namespace Keys.ViewModels
{
    public class StoreViewModel
    {
        public Store Store { get; set; }
        public List<Store> StoreList { get; set; }
    }
}