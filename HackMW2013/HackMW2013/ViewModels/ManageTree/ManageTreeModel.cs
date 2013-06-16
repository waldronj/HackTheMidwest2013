using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HackMW2013.Models;

namespace HackMW2013.ViewModels.ManageTree
{
    public class ManageTreeModel
    {
        public Tree Tree { get; set; }
        
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}