using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superhero.Models
{
    public class Super_Heroes
    {
        [Key]
        public int ID { get; set; }
        public string HeroName { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbilty { get; set; }
        public string SecondaryAbility { get; set; }
        public string CatchPhrase { get; set; }
    }
}