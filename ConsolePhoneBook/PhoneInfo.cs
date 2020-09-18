using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo
    {
        string name;        //필수
        string phonenumber;     //필수
        string birth;


        public string Name { get { return name; } }
        public string PhoneNumber { get { return phonenumber; } }


        public PhoneInfo()
        {

        }

        public PhoneInfo(string name, string phonenumber)
        {
            this.phonenumber = phonenumber;
            this.name = name;
            //this.birth = ""; 
        }

        public PhoneInfo(string name, string phonenumber, string birth)
        {
            this.phonenumber = phonenumber;
            this.name = name;
            this.birth = birth;
        }



        public virtual void ShowPhoneInfo()
        {
            Console.WriteLine("name : " + this.name);
            Console.WriteLine("phonenumber : " + this.phonenumber);
            if (birth != null)
            Console.WriteLine("birth : " + this.birth);
            Console.WriteLine();
        }
    }

    public class PhoneUnivInfo : PhoneInfo
    {
        string major;
        string year;


        public PhoneUnivInfo(string name, string phonenumber, string birth, string major, string year) : base(name, phonenumber, birth)
        {
            this.major = major;
            this.year = year;

        }

        //오버라이드
        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.WriteLine($"전공은 {major}이고, 학번은 {year}입니다.");

        }

    }
    

    public class PhoneCompanyInfo : PhoneInfo
    {
        string department;
        string company;

        
        public PhoneCompanyInfo(string name, string phonenumber, string birth, string department, string company) : base(name, phonenumber, birth)
        {
            this.department = department;
            this.company = company;
        }

        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.WriteLine($"부서는 {this.department}이고, 회사는 {this.company}입니다.");
        }
    }


}
