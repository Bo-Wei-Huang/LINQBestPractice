using LINQBestPractice.ExceptCompareReferenceType;
using LINQBestPractice.ExceptCompareValueType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBestPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            //如同預期 得到的結果會以TSource second為比對標準，以TSource first進行比對
            //回傳的結果會是與TSource second差異的序列
            //var valueExceptSample = new ValueSample();

            //foreach (var item in valueExceptSample.DoLINQExcept())
            //{
            //    Console.WriteLine($"Value:{item}");
            //}

            //Console.ReadLine();




            //結果與預期不符，理想中的結果應該是 ProductId =2 要被比對出來
            //但比對出來的結果卻是 ProductId 1 2 3 都被比對出來了
            //因為list 中的 product 是不同的 instance 所以就算其屬性的值相同，比對也不會成功
            //var errorExceptSample = new ErrorSample();

            //foreach (var item in errorExceptSample.DoLINQExcept())
            //{
            //    Console.WriteLine($"ProductId:{item.ProductId}");
            //    Console.WriteLine($"ProductName:{item.ProductName}");
            //    Console.WriteLine($"ProductSerialNumber:{item.ProductSerialNumber}");
            //}

            //Console.ReadLine();


            //結果符合預期
            //ProductId =2 被比對出來
            //var _implementIEquatableSolution = new ImplementIEquatableSolution();

            //foreach (var item in _implementIEquatableSolution.DoLINQExcept())
            //{
            //    Console.WriteLine($"ProductId:{item.ProductId}");
            //    Console.WriteLine($"ProductName:{item.ProductName}");
            //    Console.WriteLine($"ProductSerialNumber:{item.ProductSerialNumber}");
            //}

            //Console.ReadLine();


            //結果符合預期
            //ProductId =2 被比對出來
            var _implementIEqualityComparerSolution = new ImplementIEqualityComparerSolution();

            foreach (var item in _implementIEqualityComparerSolution.DoLINQExcept())
            {
                Console.WriteLine($"ProductId:{item.ProductId}");
                Console.WriteLine($"ProductName:{item.ProductName}");
                Console.WriteLine($"ProductSerialNumber:{item.ProductSerialNumber}");
            }

            Console.ReadLine();
        }
    }
}
