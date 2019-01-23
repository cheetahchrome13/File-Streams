using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj10FileStreams
{
    /// <summary>
    /// Defines class fields and methods
    /// </summary>
    class StudentClass
    {
        private string lastName;
        private string firstName;
        private int idNumber;
        private string className;
        private string grade;

        /// <summary>
        /// Default no-arg constructor
        /// </summary>
        public StudentClass()
        {

        }

        /// <summary>
        /// This constructor requires all params
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="idNumber"></param>
        /// <param name="className"></param>
        /// <param name="grade"></param>
        public StudentClass(string lastName, string firstName, int idNumber, string className, string grade)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.idNumber = idNumber;
            this.className = className;
            this.grade = grade;
        }

        /// <summary>
        /// Properties/getters/setters
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public int IdNumber
        {
            get
            {
                return idNumber;
            }

            set
            {
                idNumber = value;
            }
        }

        public string ClassName
        {
            get
            {
                return className;
            }

            set
            {
                className = value;
            }
        }

        public string Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
            }
        }

        /// <summary>
        /// Output data in list box format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return lastName + ", " + firstName + "\t" + idNumber + "\t" + className + ": " + grade;
        }

        /// <summary>
        /// Output data in file format
        /// </summary>
        /// <returns></returns>
        public string ToFileString()
        {
            return lastName + "," + firstName + "," + idNumber + "," + className + "," + grade;
        }
    }//class
}//solution
