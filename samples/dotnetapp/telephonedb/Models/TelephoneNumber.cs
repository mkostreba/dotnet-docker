using System;
using System.Collections.Generic;

namespace telephonedb.Models
{
    public partial class TelephoneNumber
    {
        public int Id { get; set; }
        public short CountryCode { get; set; }
        public short AreaCode { get; set; }
        public short Prefix { get; set; }
        public short LineNumber { get; set; }
        public bool? IsOnNet { get; set; }
        public bool IsAssigned { get; set; }
        public string StringValue { get; set; }
        public int? OwnedBy { get; set; }
        public bool? IsPorted { get; set; }

        public virtual NumberOwners OwnedByNavigation { get; set; }
    }
}
