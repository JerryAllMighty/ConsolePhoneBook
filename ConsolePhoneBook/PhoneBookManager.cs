using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    class PhoneBookManager
    {
        const int MAX_CNT = 10;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        int curCnt = 0;

        public void ShowMenu()
        {
            Console.WriteLine("--------------------주소록--------------------");
            Console.WriteLine("1.입력 |   2.목록    |   3.검색    |   4.삭제    |   5.종료");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("선택 : ");

        }

        public void InputData()
        {
            Console.WriteLine("이름을 입력해주세요");
            string inputname = Console.ReadLine();      //이 입력값을 배열에 넣으려고 함
            Console.WriteLine("전화번호를 입력해주세요");
            string inputphonenumber = Console.ReadLine();
            Console.WriteLine("생일을 입력해주세요");
            string inputbirth = Console.ReadLine();

            
        }

        public void ListData()
        {

        }

        public void SearchData()
        {
            
        }

        public void DeleteData()
        {

        }

        
    }
}
