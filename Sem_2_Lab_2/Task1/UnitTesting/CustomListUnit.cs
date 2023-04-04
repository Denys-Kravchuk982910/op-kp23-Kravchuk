using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Tools;

namespace Task1.UnitTesting
{
    public class CustomListUnit
    {
        private CustomList<TestClass> _customList;

        public CustomListUnit()
        {
            _customList = new CustomList<TestClass>();
        }

        public bool AddUnit() 
        {
            _customList.Add(new TestClass(1));
            _customList.Add(new TestClass(2));
            _customList.Add(new TestClass(3));
            _customList.Add(new TestClass(4));


            if(_customList.Count == 4)
            {
                return true;
            }

            return false;
        }

        public bool GetValueUnit() 
        {
            if(_customList[0].Value == 1)
            {
                return true;
            }

            return false;
        }

        public bool SetValueUnit()
        {
            _customList[0].Value = 100;
            if (_customList[0].Value == 100)
            {
                _customList[0].Value = 1;
                return true;
            }
            return false;
        }
    }

    public class TestClass
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; } 
        }

        public TestClass(int value)
        {
           _value = value;
        }
    }
}
