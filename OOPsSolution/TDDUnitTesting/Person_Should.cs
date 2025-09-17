using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OOPsReview;


namespace TDDUnitTesting
{
    public class Person_Should
    {
        #region Constructor
        #region valid data
        //a Fact unit test executes once
        //without the [Fact] annotation, the method is NOT considered a unit test
        //  it would just be a method within this class
        [Fact]
        public void Successfully_Create_An_Instance_Using_the_Default_Constructor()
        {
            //Arrange (this is the setup of values need for doing the test)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            //this is the number of instances in the List<Employee>
            int expectedEmploymentPositionCount = 0;


            //Act (this is the action that is under testing)
            //sut: subject under test
            //Image that the Act is a line of code from a program
            Person sut = new Person();


            //Assert (check the results of the act (Act) against expected Values (Arrange))
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedFirstName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);

        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_With_No_Address_Or_Employments()
        {
            //Arrange 
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            //this is the number of instances in the List<Employee>
            int expectedEmploymentPositionCount = 0;

            //Act 
            //In this example real data is sent to the greedy constructor
            //the object arguments are not used, thus they are null
            Person sut = new Person("   Don  ","  Welch  ",null,null);

            //Assert 
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_With_No_Employments()
        {
            //Arrange 
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            //this is the number of instances in the List<Employee>
            int expectedEmploymentPositionCount = 0;

            //now one needs to included the setup for address
            ResidentAddress expectedAddress = new ResidentAddress(123, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");

            //Act 
            //In this example real data is sent to the greedy constructor
            //the employment object argument is not used
            Person sut = new Person("   Don  ", "  Welch  ", expectedAddress, null);

            //Assert 
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
        }
        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_With_All_Data()
        {
            //Arrange 
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            //now one needs to included the setup for address
            ResidentAddress expectedAddress = new ResidentAddress(123, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");

            //how to test a collection?
            //create individual instances of the item in the list
            //in this example those instances are objects
            //you must remember each object has a unique GUID
            //NOTE: you CANNOT reuse a single variable to hold the separate instances
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2013/10/10"), 6.5);
            //remember that if no year was supplied the length of holding the current
            //      position is calculated for the instance
            Employment two = new Employment("PG II", SupervisoryLevel.TeamLeader,
                                DateTime.Parse("2020/04/04"));
            List<Employment> employments = new List<Employment>();
            employments.Add(one);
            employments.Add(two);
            int expectedEmploymentPositionCount = 2;

            //Act 
            //In this example real data is sent to the greedy constructor
            //the employment object argument is not used
            Person sut = new Person("   Don  ", "  Welch  ", expectedAddress, employments);

            //Assert 
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);
            //best practice for a collection is to first test the count to be correct
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
            //then test the contents of the collection
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(employments);

        }
        #endregion
        #region exception testing
        //the second test annotation used is called [Theory]
        //it will execute n number of times as a loop
        //n is determined by the number [InlineData()] annotations following the [Theory]
        //to setup the test header, you must include a parameter in a parameter list
        //  one for each, value in the InlineData set of values
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Creating_Greedy_Constructor_Instance_With_Missing_FirstName(string firstname)
        {
            //Arrange
            //possible values for FirstName: null, empty string, blank string
            //the setup of an exception test does not have to be as extensive as a successful test
            //  as the objective is to catch the exception that is thrown
            //in this example there will be no need to check expected values

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person(firstname, "Welch", null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Creating_Greedy_Constructor_Instance_With_Missing_LastName(string lastname)
        {
            //Arrange
            //possible values for FirstName: null, empty string, blank string
            //the setup of an exception test does not have to be as extensive as a successful test
            //  as the objective is to catch the exception that is thrown
            //in this example there will be no need to check expected values

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person("Don", lastname, null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }

        //combine the previous to separate Theory tests into one
        [Theory]
        [InlineData(null,"Welch")]
        [InlineData("", "Welch")]
        [InlineData("    ", "Welch")]
        [InlineData("Don", null)]
        [InlineData("Don", "")]
        [InlineData("Don", "    ")]
        public void Throw_Exception_Creating_Greedy_Constructor_Instance_With_Missing_First_Or_Last_Name(string firstname, string lastname)
        {
            //Arrange
            //possible values for FirstName: null, empty string, blank string
            //the setup of an exception test does not have to be as extensive as a successful test
            //  as the objective is to catch the exception that is thrown
            //in this example there will be no need to check expected values

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person(firstname, lastname, null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
        #endregion

        #region Properties
        #region valid data
        #endregion
        #region exception testing
        #endregion
        #endregion

        #region Methods
        #region valid data
        #endregion
        #region exception testing
        #endregion
        #endregion
    }
}
