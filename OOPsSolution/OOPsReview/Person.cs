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
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("FirstName", "First name cannot be missing or blank.");
                _FirstName = value.Trim(); 
            } 
        }
        public string LastName
        {
            get { return _LastName; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("LastName", "Last name cannot be missing or blank.");
                _LastName = value.Trim(); 
            }
        }
        public ResidentAddress Address { get; set; }

        //since the set is private NO direct altering of the property by an outside user
        //      is possible
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
            //the name validation is not required in the constructor as it is 
            //      also in the property and the constructor sends the incoming
            //      parameter value to the property and NOT directly into the data member
            //if (string.IsNullOrWhiteSpace(firstname))
            //    throw new ArgumentNullException("FirstName", "First name cannot be missing and must have a character");
            //if (string.IsNullOrWhiteSpace(lastname))
            //    throw new ArgumentNullException("LastName", "Last name cannot be missing and must have a character");
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

        public void AddEmployment(Employment newemployment)
        {
            EmploymentPositions.Add(newemployment);
        }
    }
}
