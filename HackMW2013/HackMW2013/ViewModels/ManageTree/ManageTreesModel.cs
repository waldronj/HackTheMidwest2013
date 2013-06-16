using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HackMW2013.Models;

namespace HackMW2013.ViewModels.ManageTree
{
    public class ManageTreesModel
    {
        public List<Tree> Trees { get; set; }

        public string Name { get; set; }
    }
}