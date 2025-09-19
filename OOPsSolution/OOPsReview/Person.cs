using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;
        public string FirstName 
        { 
            get { return _FirstName; } 
            set { _FirstName = value.Trim(); } 
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value.Trim(); }
        }
        public ResidentAddress Address { get; set; }
        public List<Employment> EmploymentPositions { get; private set; } = new List<Employment>();

        public string FullName
        //{ get { return LastName + ", " + FirstName; } }
        { get { return $"{LastName}, {FirstName}"; }
}

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
            FirstName = firstname; //.Trim(); using Refactoring, this Trim is unnecessary
            LastName = lastname; //.Trim(); using Refactoring, this Trim is unnecessary
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
