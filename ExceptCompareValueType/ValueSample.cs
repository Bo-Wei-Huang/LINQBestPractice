using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBestPractice.ExceptCompareValueType
{
    public class ValueSample
    {
        private readonly List<int> _fromClientRequest;

        private readonly List<int> _fromDBData;

        public ValueSample()
        {
            _fromClientRequest = new List<int>()
            {
                1,2,3,4,5
            };

            _fromDBData = new List<int>()
            {
                    1,2,7,4,5
            };
        }

        public List<int> DoLINQExcept()
        {
            return _fromClientRequest.Except(_fromDBData).ToList();
        }
    }
}
