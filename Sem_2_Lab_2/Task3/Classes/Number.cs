using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public class Number
    {
        public int _value { get; set; }

        public Number(int value)
        {
            _value = value;
        }

        public int Value 
        { get => this._value;
          private set => this._value = value; }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
