using System;
using System.Collections.Generic;

namespace Kolokwium2_poprawkowy.Models
{
    public partial class VolunteerPet
    {
        public int IdPet { get; set; }
        public int IdVolunteer { get; set; }
        public DateTime DateAccepted { get; set; }

        public virtual Pet IdPetNavigation { get; set; }
        public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
