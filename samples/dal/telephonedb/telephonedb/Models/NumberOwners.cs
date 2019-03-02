using System;
using System.Collections.Generic;

namespace telephonedb.Models
{
    public partial class NumberOwners
    {
        public NumberOwners()
        {
            TelephoneNumber = new HashSet<TelephoneNumber>();
        }

        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TelephoneNumber> TelephoneNumber { get; set; }
    }
}
