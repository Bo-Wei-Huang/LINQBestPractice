using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBestPractice.ExceptCompareReferenceType
{
    public class Product: IEquatable<Product>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductSerialNumber { get; set; }

        public bool Equals(Product other)
        {
            if (other is null)
                return false;

            return
                this.ProductId == other.ProductId &&
                this.ProductName == other.ProductName &&
                this.ProductSerialNumber == other.ProductSerialNumber;
        }

        public override bool Equals(object obj) => Equals(obj as Product);

        public override int GetHashCode() => (ProductId, ProductName, ProductSerialNumber).GetHashCode();
    }

    public class ImplementIEquatableSolution
    {

        //Note: 這邊的 Produc 類別 要改用實作了IEquatable 介面的Product 類別

        private readonly List<Product> _fromClientRequest;

        private readonly List<Product> _fromDBData;

        public ImplementIEquatableSolution()
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
