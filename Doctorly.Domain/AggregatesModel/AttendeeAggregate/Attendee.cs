using Doctorly.Domain.Common;

namespace Doctorly.Domain.AggregatesModel.AttendeeAggregate
{
    public class Attendee : EntityBase
    {
        protected Attendee() 
        {
        }

        public Attendee(string name, Email email)
        {
            if (name.Length > 100)
            {
                throw new Exception("The name is longer than 100 charachter");
            }

            Name = name;
            Email = email;
        }

        public string Name { get; private set; } = string.Empty;
        public Email Email { get; private set; }
        public virtual ICollection<Event> Events { get; private set; }
    }
}
