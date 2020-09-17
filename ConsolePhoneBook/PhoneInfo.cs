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

        public PhoneInfo()
        {

        }

        public PhoneInfo(string name, string phonenumber)
        {
            this.phonenumber = phonenumber;
            this.name = name;
        }

        public PhoneInfo(string name, string phonenumber, string birth)
        {
            this.phonenumber = phonenumber;
            this.name = name;
            this.birth = birth;
        }



        public void ShowPhoneInfo()
        {
            Console.WriteLine($"이름은 {name}이고, 전화번호는 {phonenumber}이며, 생일은 {birth}입니다.");
            return;
        }

        
    }
}
