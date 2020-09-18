using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneBookManager
    {
        public override string ToString()
        {
            string str = $@"취미는 {this.Hobby}이고, 좋아하는 음식은 {this.Food}입니다.";
            return str;
        }

        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        int curCnt = 0;

        public string Hobby { get; set; }
        public string Food { get; set; }
        #region 생성자
        public PhoneBookManager()
        {

        }

        public PhoneBookManager(string hobby, string food)
        {
            this.Hobby = hobby;
            this.Food = food;
        }
        #endregion


        public void ShowMenu()
        {
            Console.WriteLine("------------------------ 주소록 --------------------------");
            Console.WriteLine("1. 입력  |  2. 목록  |  3. 검색  |  4. 삭제  |  5. 종료");
            Console.WriteLine("---------------------------------------------------------");
            Console.Write("선택: ");
        }

        public void InputData()
        {
            Console.WriteLine("1.일반     2.대학    3.회사");
            Console.Write("선택 >> ");
            int choice = int.Parse(Console.ReadLine().Trim());

            //필수항목들 무조건 실행
            
             Console.Write("이름: ");
             string name = Console.ReadLine().Trim();
             //if (name == "") or if (name.Length < 1) or if (name.Equals(""))
             if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("이름은 필수입력입니다");
                    return;
                }
             else
                {
                    int dataIdx = SearchName(name);
                    if (dataIdx > -1)
                        {
                            Console.WriteLine("이미 등록된 이름입니다. 다른 이름으로 입력하세요");
                            return;
                        }
                }
             
             Console.Write("전화번호: ");
             string phone = Console.ReadLine().Trim();
             if (string.IsNullOrEmpty(phone))
                {
                    Console.WriteLine("전화번호는 필수입력입니다");
                    return;
                }
             
             Console.Write("생일: ");
             string birth = Console.ReadLine().Trim();

             if (birth.Length < 1)
                 infoStorage[curCnt++] = new PhoneInfo(name, phone);
             else
               infoStorage[curCnt++] = new PhoneInfo(name, phone, birth);

             if (choice == 1) 
                {
                    PhoneInfo regularfriend = new PhoneInfo(name, phone, birth);
                    regularfriend.ShowPhoneInfo(); 
                }       
           


            if(choice == 2)
            { 
                Console.Write("전공을 입력하세요: ");
                string major = Console.ReadLine().Trim();

                if (major.Equals(""))
                {
                    Console.WriteLine("전공은 필수입력입니다");
                    return;
                }
                
                Console.Write("학번을 입력하세요 : ");
                string year = Console.ReadLine().Trim();
                
                if (string.IsNullOrEmpty(year))      //말도 안되는 학번 걸러내기
                    {
                    Console.WriteLine("학번은 필수입력입니다.");
                    return;
                    }

                PhoneUnivInfo collegeFriend = new PhoneUnivInfo(name, phone, birth, major, year);
                collegeFriend.ShowPhoneInfo();
            }

            else if (choice == 3)
            {
                Console.Write("부서를 입력하세요: ");
                string department = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(department))
                {
                    Console.WriteLine("부서는 필수입력입니다");
                    return;
                }

                Console.Write("회사를 입력하세요: ");
                string company = Console.ReadLine().Trim();

                if (company.Equals(""))
                {
                    Console.WriteLine("회사는 필수입력입니다");
                    return;
                }
                PhoneCompanyInfo companyFriend = new PhoneCompanyInfo(name, phone, birth, department, company);
                companyFriend.ShowPhoneInfo();
            }
        }
        
        public void ListData()
        {
            if (curCnt == 0)
            {
                Console.WriteLine("입력된 데이터가 없습니다.");
                return;
            }

            for (int i = 0; i < curCnt; i++)
            {
                infoStorage[i].ShowPhoneInfo();
            }
        }

        public void SearchData()
        {
            Console.WriteLine("주소록 검색을 시작합니다......");
            int dataIdx = SearchName();
            if (dataIdx < 0)
            {
                Console.WriteLine("검색된 데이터가 없습니다");
            }
            else
            {
                infoStorage[dataIdx].ShowPhoneInfo();
            }

            #region 모두 찾기
            //int findCnt = 0;
            //for(int i=0; i<curCnt; i++)
            //{
            //    // ==, Equals(), CompareTo()
            //    if (infoStorage[i].Name.Replace(" ","").CompareTo(name) == 0)
            //    {
            //        infoStorage[i].ShowPhoneInfo();
            //        findCnt++;
            //    }
            //}
            //if (findCnt < 1)
            //{
            //    Console.WriteLine("검색된 데이터가 없습니다");
            //}
            //else
            //{
            //    Console.WriteLine($"총 {findCnt} 명이 검색되었습니다.");
            //}
            #endregion
        }

        private int SearchName()
        {
            Console.Write("이름: ");
            string name = Console.ReadLine().Trim().Replace(" ", "");

            for (int i = 0; i < curCnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private int SearchName(string name)
        {
            for (int i = 0; i < curCnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void DeleteData()
        {
            Console.WriteLine("주소록 삭제를 시작합니다......");

            int dataIdx = SearchName();
            if (dataIdx < 0)
            {
                Console.WriteLine("삭제할 데이터가 없습니다");
            }
            else
            {
                for (int i = dataIdx; i < curCnt; i++)
                {
                    infoStorage[i] = infoStorage[i + 1];
                }
                curCnt--;
                Console.WriteLine("주소록 삭제가 완료되었습니다");
            }
        }
    }
}
