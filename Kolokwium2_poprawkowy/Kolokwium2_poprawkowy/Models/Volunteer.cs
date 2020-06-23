using System;
using System.Collections.Generic;

namespace Kolokwium2_poprawkowy.Models
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            InverseIdSupervisorNavigation = new HashSet<Volunteer>();
            VolunteerPet = new HashSet<VolunteerPet>();
        }

        public int IdVolunteer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime StartingDate { get; set; }
        public int? IdSupervisor { get; set; }

        public virtual Volunteer IdSupervisorNavigation { get; set; }
        public virtual ICollection<Volunteer> InverseIdSupervisorNavigation { get; set; }
        public virtual ICollection<VolunteerPet> VolunteerPet { get; set; }
    }
}
