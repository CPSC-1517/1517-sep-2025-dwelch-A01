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
            if (newemployment == null)
                throw new ArgumentNullException("Employment", "Missing data for employment");

            //one could code a loop to examine each item in the collection to determind if there
            //  is a duplicate history instance
            //However, lets used methods that have already been built to do searching of a collection
            //First step: determine if you need a copy of the instance
            //  in this case: only the knowledge that an instance exist is needed
            //  (do not actual need the instance)
            //  condition: only at least one needs to exist: .Any()

            //within the method one can place one or more delegates (conditions) that
            //  determine if the action is true or false
            //delegate syntax structure:
            //      collectionplaceholderlabel => collectionplaceholderlabel[.property] [condition] value 
            //                  [ && or || another condition ...]
            //typically the collectionplaceholderlabel is very short such x
            //the collectionplaceholderlabel represents any instance in your collection at any time
            if (EmploymentPositions.Any(x => x.Title == newemployment.Title
                                        && x.StartDate.Equals(newemployment.StartDate)))
                throw new ArgumentException($"Duplicate employment. Employment record {newemployment.Title} on {newemployment.StartDate}",
                    "Employment");

            EmploymentPositions.Add(newemployment);
        }

        public void ChangeFullName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
