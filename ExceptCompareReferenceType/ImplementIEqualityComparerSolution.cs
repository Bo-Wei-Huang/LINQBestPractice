using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQBestPractice.Models;

namespace LINQBestPractice.ExceptCompareReferenceType
{
    /// <summary>
    /// 實作了IEqualityComparer 也可用在 Intersect ,Distinct中
    /// </summary>
    public class ProductComparer : IEqualityComparer<LINQBestPractice.Models.Product>
    {
        public bool Equals(Models.Product x, Models.Product y)
        {
            if (object.ReferenceEquals(x, y))
                return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;

            return
                x.ProductId == y.ProductId &&
                x.ProductName == y.ProductName &&
                x.ProductSerialNumber == y.ProductSerialNumber;
        }

        public int GetHashCode(Models.Product obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashProductId = obj.ProductId.GetHashCode();

            int hashProductName = obj.ProductName == null ? 0 : obj.ProductName.GetHashCode();

            int hashProductSerialNumber = obj.ProductSerialNumber == null ? 0 : obj.ProductSerialNumber.GetHashCode();

            return hashProductId ^ hashProductName ^ hashProductSerialNumber;
        }
    }


    public class ImplementIEqualityComparerSolution 
    {
        private readonly List<LINQBestPractice.Models.Product> _fromClientRequest;

        private readonly List<LINQBestPractice.Models.Product> _fromDBData;

        public ImplementIEqualityComparerSolution()
        {
            _fromClientRequest = new List<LINQBestPractice.Models.Product>()
            {
                new LINQBestPractice.Models.Product{ ProductId=1,ProductName="Iphone14 Pro Max",ProductSerialNumber="SN001"},
                new LINQBestPractice.Models.Product{ ProductId=2,ProductName="Iphone14 Pro",ProductSerialNumber="SN002"},
                new LINQBestPractice.Models.Product{ ProductId=3,ProductName="Iphone13 Pro Max",ProductSerialNumber="SN003"}
            };

            _fromDBData = new List<LINQBestPractice.Models.Product>()
            {
                new LINQBestPractice.Models.Product{ ProductId=1,ProductName="Iphone14 Pro Max",ProductSerialNumber="SN001"},
                new LINQBestPractice.Models.Product{ ProductId=4,ProductName="Iphone13 Pro",ProductSerialNumber="SN004"},
                new LINQBestPractice.Models.Product{ ProductId=3,ProductName="Iphone13 Pro Max",ProductSerialNumber="SN003"}
            };
        }

        public List<LINQBestPractice.Models.Product> DoLINQExcept()
        {
            return _fromClientRequest.Except(_fromDBData,new ProductComparer()).ToList();
        }
    }
}
