using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ResidentAddress Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            //this code was remove on the Refactor of passing the greedy constructor tests
           // EmploymentPositions = new List<Employment>();
        }

        public Person(string firstname, string lastname,
                    ResidentAddress address, List<Employment> employments)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentNullException("FirstName", "First name cannot be missing and must have a character");
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentNullException("LastName", "Last name cannot be missing and must have a character");
            FirstName = firstname.Trim();
            LastName = lastname.Trim();
            Address = address;
            //this code was remove on the Refactor of passing the greedy constructor tests
            //if (employments == null)
            //    EmploymentPositions = new List<Employment>();
            //else
            //    EmploymentPositions = employments;
            if (employments != null)
                EmploymentPositions = employments;
        }
    }
}
