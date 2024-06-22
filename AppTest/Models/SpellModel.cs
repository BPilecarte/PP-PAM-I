using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.Models
{
    public class SpellModel
    {
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;

        public string Detail => $"Level: {Level}, School: {School}";
    }
}
