using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _0521
{
    
    class Program
    {
        #region 첫번쨰 예제
        delegate int Calculate(int a, int b);//delegate 생성
        static int add(int n1, int n2)
        {
            return n1 + n2;
        }
        static int sub(int n1, int n2)
        {
            return n1 - n2;
        }

        static void exam1()
        {
            // 함수의 정의가 필요
            Calculate cal1 = add;// 객체생성
            cal1 += sub;
            
            Console.WriteLine(cal1(10, 20));     //add, sub

            //람다식(이름이 없는 함수)//알고리즘 만들때 간단히 정리
            Calculate cal2 = (a, b) => a + b;
            cal2 += (a, b) => a - b;
            Console.WriteLine(cal2(10, 20));
        }
        #endregion

        #region 문형식의 람다식
        delegate void DoSomething();

        static void exam2()
        {
            DoSomething DoIt = () =>
            {
                Console.WriteLine("문장출력1");
                Console.WriteLine("문장출력2");
                Console.WriteLine("문장출력3");
            };

            DoIt();
        }
        #endregion

        #region 람다식 사용예
        delegate string Concatenate(string[] args);

        static void exam3()
        {
            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach(string s in arr)
                {
                    result += s;
                }
                return result;
            };

            string[] temp = { "aaa", "bbb", "ccc" };
            Console.Write(concat(temp));
        }
        #endregion

        #region Func 사용예
        static void exam4()
        {
            // 입력 매개 변수는 없으며, 무조건 10을 반환
            Func<int> func1 = () => 10; 
            Console.WriteLine(func1()); // 10을 출력
            
            // 입력 매개 변수는 int 형식 하나, 반환 형식도 int
            Func<int, int> func2 = (x) => x * 2; 
            Console.WriteLine(func2(3)); // 6을 출력

            //정수값 2개, 실수값 1개를 받아서 합을 반환
            Func<int, int, float, float> func3 = (x, y, z) => x + y + z;
            Console.WriteLine(func3(10, 20, 30.1f));
        }
        #endregion

        #region Action 사용예
        static void exam5()
        {
            Action act1 = () => Console.WriteLine("Action()");
            act1();

            Action<int, int> act2 = (x, y) =>
            {
                int sum = x + y;
                Console.WriteLine("합의 결과 :" + sum);
            };
            act2(10, 20);

            int result = 0; //Action 은 리턴 존재X
            Action<int> act4 = (x) => result = x * x;
            Action<int> act3 = (x) =>
            {
                result = x * x;
            };
            act3(10);
            
            Console.WriteLine(result);
        }

        #endregion

        //=========================
        #region 람다식을 컬렉션에 사용 예
        static void exam6()
        {
            List<NameCard> list = new List<NameCard>();
            list.Add(new NameCard("홍길동", "010-1111-1111"));
            list.Add(new NameCard() { Phone = "010-2222-2222", Name = "이길순" });

            // var result;  IEnumerable<NameCard> == var
            IEnumerable<NameCard> result =
                list.Where<NameCard>(namecard => namecard.Name.Equals("이길순"));
            foreach(NameCard c in result)
            {
                Console.WriteLine(c);
            }
        }

        #endregion

        //데이터 저장소,   프로파일 저장할수 있는 리스트 생성,
        static List<Profile> profiles = new List<Profile>()
        {
            new Profile(){Name="정우성", Height=186},
            new Profile(){Name="김태희", Height=158},
            new Profile(){Name="고현정", Height=172},
            new Profile(){Name="이문세", Height=178},
            new Profile(){Name="하동훈", Height=171}
        };
        static List<Product> products = new List<Product>()
        {
            new Product(){Title="비트",        Star="정우성"},
            new Product(){Title="CF 다수",     Star="김태희"},
            new Product(){Title="아이리스",    Star="김태희"},
            new Product(){Title="모래시계",    Star="고현정"},
            new Product(){Title="Solo 예찬",   Star="이문세"}
        };

        #region Linq 사용하지 않은 예

        static int HeightSort(Profile p1, Profile p2)
        {
            return p2.Height - p1.Height;  //+값, 0, -값
        }
        static void exam7()
        {
            List<Profile> result = new List<Profile>(); 
            foreach(Profile p in profiles)
            {
                if (p.Height < 175)
                    result.Add(p);
            }
            //result.Sort(HeightSort);
            result.Sort( (p1,p2)=> p1.Height + p2.Height );//람다식 사용

            foreach(Profile p in result)
            {
                Console.WriteLine(p);
            }
        }
        #endregion

        #region 위 예제를 Linq를 사용하는 예제로 수정
        static void exam8()
        {
            var result = from p in profiles // p는 Profile타입
                         where p.Height < 175
                         orderby p.Height
                         select p;

            foreach(Profile p in result)
            {
                Console.WriteLine(p);
            }
        }
        #endregion


        #region FROM WHERE ORDERBY SELECT
       
        //Select
        static void exam9()
        {
            int[] nums = { 9, 2, 3, 123, 4, 23, 56, 24, 1 };

            var result = from value in nums
                         select value;

            foreach(int value in result)
            {
                Console.Write(value + ",");
            }
            Console.WriteLine();
        }
        //where : 짝수만 출력
        static void exam10()
        {
            int[] nums = { 9, 2, 3, 123, 4, 23, 56, 24, 1 };

            var result = from value in nums
                         where value % 2==0
                         select value;

            foreach (int value in result)
            {
                Console.Write(value + ",");
            }
            Console.WriteLine();
        }
        //orderby
        static void exam11()
        {
            int[] nums = { 9, 2, 3, 123, 4, 23, 56, 24, 1 };

            var result = from value in nums
                         where value % 2 == 0
                         orderby value descending
                         select value;

            foreach (int value in result)
            {
                Console.Write(value + ",");
            }
            Console.WriteLine();
        }
        #endregion

        #region Selet 수정
        static void exam12()
        {
            //175보다 작은 Profile 객체를 검색
            var result = from p in profiles
                              where p.Height < 175
                              orderby p.Height descending //ascending 이 기본값
                              select p;

            foreach (Profile p in result)
                Console.WriteLine("{0}, {1}", p.Name, p.Height);

            //175보다작은 Profile 들의 이름만검색
            var result1 = from p1 in profiles
                         where p1.Height < 175
                         orderby p1.Height descending //ascending 이 기본값
                         select p1.Name;

            foreach (string p in result1)
                Console.WriteLine(p+ " ");

            //모든 회원들의 키를 cm 가 아닌 inch로 변경해서 검색

            var result2 = from p2 in profiles
                          orderby p2.Height descending //ascending 이 기본값
                          select new    //new: 익명의 클래스를 정의
                          {
                              Name = p2.Name,
                              INchHeight = p2.Height *0.393
                          };
            //익명이기에 타입 키워드는 var
            foreach (var p in result2)
                Console.WriteLine(p + " ");

            //모든 회원들의 키를 cm 가 아닌 inch로 변경해서 검색

            var result3 = from p3 in profiles
                          orderby p3.Height descending //ascending 이 기본값
                          select new  ProfileInch  //new: 이름이 있는 클래스를 객체정의
                          {
                              Name = p3.Name,
                              HeightInch = p3.Height * 0.393
                          };
            //익명이기에 타입 키워드는 var
            foreach (ProfileInch p in result3)
                Console.WriteLine(p + " ");
        }

        #endregion

        #region from의 from 개념
        static void exam13()
        {
            Student[] stus =
           {
                new Student(){Name="연두반", Score=new int[]{99, 80, 70, 24}},
                new Student(){Name="분홍반", Score=new int[]{60, 45, 87, 72}},
                new Student(){Name="파랑반", Score=new int[]{92, 30, 85, 94}},
                new Student(){Name="노랑반", Score=new int[]{90, 88, 0, 17}}
            };

            var result = from stu in stus
                         from score in stu.Score
                         where score < 60
                         orderby score
                         select new         //새로운 익명 객체를 생성
                         {
                             Name = stu.Name,
                             Lowest = score
                         };
            foreach(var value in result)
            {
                Console.WriteLine("낙제 : {0}, {1}", value.Name, value.Lowest);
            }
        }
        #endregion

        #region GroupBy
        static void exam14()
        {
            var result = from p in profiles
                         group p by p.Height < 175 into _group
                         select new
                         {
                             GroupKey = _group.Key,
                             Profiles = _group
                         };
            foreach(var value in result)
            {
                Console.WriteLine("{0}",value.GroupKey? "175미만 ":"175포함이상");
                foreach(var pf in value.Profiles)
                {
                    Console.WriteLine("{0}, {1}", pf.Name, pf.Height);
                }
            }
        }
        #endregion

        #region join
        static void exam15()
        {

            //내부조인
            var result = from profile in profiles
                         join product in products on profile.Name equals product.Star
                         select new
                         {
                             Name = profile.Name,
                             Work = product.Title,
                             Height = profile.Height
                         };
            foreach(var value in result)
            {
                Console.WriteLine("이름 :{0}, 작품:{1}, 키:{2}cm",
                    value.Name, value.Work, value.Height);
            }

            Console.WriteLine("\n");
            //외부조인(상대방이 결과를 없어도 포함시키겠다
            var result1 = from profile in profiles
                         join product in products on profile.Name equals product.Star into ps
                         from product in ps.DefaultIfEmpty(new Product() { Title="-"})
                         select new
                         {
                             Name = profile.Name,
                             Work = product.Title,
                             Height = profile.Height
                         };
            foreach (var value in result1)
            {
                Console.WriteLine("이름 :{0}, 작품:{1}, 키:{2}cm",
                    value.Name, value.Work, value.Height);
            }
        }

        #endregion

        #region 집계함수(Max, Min, Average)
        static void exam16()
        {
            var result = from pro in profiles
                         group pro by pro.Height < 175 into gr
                         select new
                         {
                             Group = (gr.Key == true ? "175미만" : "175이상"),
                             Count = gr.Count(),
                             Max = gr.Max(pro=>pro.Height),
                             Min = gr.Min(pro=>pro.Height),
                             Sum = gr.Sum(pro=>pro.Height),
                             Average = gr.Average(pro=>pro.Height)
                         };
            foreach(var value in result)
            {
                Console.WriteLine("{0}, Count:{1}, Max:{2}, Min{3}, Sum{4}, Average:{5}",
                    value.Group, value.Count,value.Max, value.Min, value.Sum, value.Average);
            }
        }

        #endregion
        static void Main(string[] args)
        {
            exam16();
        }
    }
}
