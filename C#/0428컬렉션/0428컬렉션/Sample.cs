using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428컬렉션
{
    /// <summary>
    /// 테스트................
    /// </summary>
    class Sample
    {
        //배열
        List<Data> datalist = new List<Data>();
        //연결리스트
        LinkedList<Data> datalist1 = new LinkedList<Data>();

        public void Add(Data data)
        {
            datalist.Add(data);
            datalist1.AddLast(data);
        }

        public void PrintAll()
        {
            //데이터는 다 프로퍼티...
            Console.WriteLine("저장개수 : " + datalist.Count);
            foreach(Data d in datalist)
            {
                Console.WriteLine(d.Name + "," + d.Phone);
            }
            Console.WriteLine("-----------------------------------");
            foreach(Data d in datalist1)
            {
                Console.WriteLine(d.Name + "," + d.Phone);
            }
        }
    
        private Data NameToData(string name)
        {
            foreach(Data d in datalist)
            {
                if (d.Name.Equals(name) == true)
                    return d;
            }
            throw new Exception("해당 이름은 존재하지 않습니다.");
        }

        public void Selet(string name)
        {
            try
            {
                Data d = NameToData(name);
                Console.Out.WriteLine(d.Name + "," + d.Phone);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[수정에러] " + ex.Message);
            }
        }

        public void Update(string name, string upphone)
        {
            try
            {
                Data d = NameToData(name);
                d.Phone = upphone;
                Console.WriteLine("수정되었습니다.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("[수정에러] " + ex.Message);
            }
        }
    
        public void Delete(string name)
        {
            try
            {
                Data d = NameToData(name);
                datalist.Remove(d); //RemoveAt(idx)
                Console.WriteLine("삭제되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[수정에러] " + ex.Message);
            }
        }
    }
}
