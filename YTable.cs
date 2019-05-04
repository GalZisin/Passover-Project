using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc170419
{
    class YTable
    {
        public int Id { get; set; }
        public int YValue { get; set; }

        public override string ToString()
        {
            return $"{Id} {YValue}";
        }
        public static bool operator ==(YTable y1, YTable y2)
        {
            if (ReferenceEquals(y1, null) && ReferenceEquals(y2, null))
            {
                return true;
            }

            if (ReferenceEquals(y1, null) || ReferenceEquals(y2, null))
            {
                return false;
            }

            if (y1.YValue == y2.YValue)
                return true;

            return false;
        }
        public static bool operator !=(YTable y1, YTable y2)
        {
            return !(y1 == y2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            YTable otherYValue = obj as YTable;

            return this.YValue == otherYValue.YValue;
        }
        public override int GetHashCode()
        {
            return (int)this.Id;
        }
    }
}
