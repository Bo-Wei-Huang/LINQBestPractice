using LINQBestPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBestPractice.ExceptCompareReferenceType
{
    public class ErrorSample
    {
        private readonly List<Product> _fromClientRequest;

        private readonly List<Product> _fromDBData;

        public ErrorSample()
        {
            _fromClientRequest = new List<Product>()
            {
                new Product{ ProductId=1,ProductName="Iphone14 Pro Max",ProductSerialNumber="SN001"},
                new Product{ ProductId=2,ProductName="Iphone14 Pro",ProductSerialNumber="SN002"},
                new Product{ ProductId=3,ProductName="Iphone13 Pro Max",ProductSerialNumber="SN003"}
            };

            _fromDBData = new List<Product>()
            {
                new Product{ ProductId=1,ProductName="Iphone14 Pro Max",ProductSerialNumber="SN001"},
                new Product{ ProductId=4,ProductName="Iphone13 Pro",ProductSerialNumber="SN004"},
                new Product{ ProductId=3,ProductName="Iphone13 Pro Max",ProductSerialNumber="SN003"}
            };
        }

        public List<Product> DoLINQExcept()
        {
           return _fromClientRequest.Except(_fromDBData).ToList();
        }
    }
}
