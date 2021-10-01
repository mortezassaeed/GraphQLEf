using HotChocolate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Common.Models
{
    //[GraphQLDescription("this entity is for store your platfrom infortamtion")]
    public class Platform
    {
        public int Id { get; set; }
        [Required]
        //[GraphQLDescription("this field is for repersent your platfrom name")]
        public string Name { get; set; }
        public string LicenseKey { get; set; }
        public ICollection<Command> Commands { get; set; }

    }
}
