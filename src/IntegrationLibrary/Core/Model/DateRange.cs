using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class DateRange : ValueObject<DateRange>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        protected override bool EqualsCore(DateRange other)
        {
            return Start == other.Start && End == other.End;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Start.GetHashCode();
                hashCode ^= End.GetHashCode();
                return hashCode;
            }
        }
    }
}
