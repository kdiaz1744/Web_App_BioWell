using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App_BioWell.Models
{
    public class RoleTest
    {
        public RoleTest() { }

        public RoleTest(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}