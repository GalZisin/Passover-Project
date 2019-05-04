using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc170419
{
    class XTable
    {
        public int Id { get; set; }
        public int XValue { get; set; }
        public override string ToString()
        {
            return $"{Id} {XValue}";
        }
        public static bool operator ==(XTable x1, XTable x2)
        {
            if (ReferenceEquals(x1, null) && ReferenceEquals(x2, null))
            {
                return true;
            }

            if (ReferenceEquals(x1, null) || ReferenceEquals(x2, null))
            {
                return false;
            }

            if (x1.XValue == x2.XValue)
                return true;

            return false;
        }
        public static bool operator !=(XTable x1, XTable x2)
        {
            return !(x1 == x2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            XTable otherXValue = obj as XTable;

            return this.XValue == otherXValue.XValue;
        }
        public override int GetHashCode()
        {
            return (int)this.Id;
        }
    }
}
