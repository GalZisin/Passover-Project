using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc170419
{
    class Operation
    {
        public int Id { get; set; }
        public char CalcOperation {get; set;}
        public static bool operator ==(Operation x1, Operation x2)
        {
            if (ReferenceEquals(x1, null) && ReferenceEquals(x2, null))
            {
                return true;
            }

            if (ReferenceEquals(x1, null) || ReferenceEquals(x2, null))
            {
                return false;
            }

            if (x1.CalcOperation == x2.CalcOperation)
                return true;

            return false;
        }
        public static bool operator !=(Operation x1, Operation x2)
        {
            return !(x1 == x2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Operation otherClass = obj as Operation;

            return this.CalcOperation == otherClass.CalcOperation;
        }
        public override int GetHashCode()
        {
            return (int)this.Id;
        }
    }
}
