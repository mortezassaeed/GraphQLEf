
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.Common.Models
{
    public class Result
    {
        public int Id { get; set; }
        public CommandResultType Type { get; set; }
        public string? Message { get; set; }
        [Required]
        public int CommandId {  get; set; }
        public Command Command { get; set; }
    }

    public enum CommandResultType
    {
        Ok,
        Error
    }
}
