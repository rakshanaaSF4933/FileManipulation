using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVJSON
{
    public enum GenderDetails
    {
        Default,Male,Female,Transgender
    }
    public class StudentDetails
    {
        public string Name{get;set;}
        public string FatherName{get;set;}
        public DateTime DOB{get;set;}
        public GenderDetails Gender{get;set;}
        public int Mark{get;set;}

        public StudentDetails(string name,string fatherName,DateTime dob,GenderDetails gender,int mark)
        {
            Name= name;
            FatherName = fatherName;
            DOB=dob;
            Gender = gender;
            Mark = mark;
        }
    }
}