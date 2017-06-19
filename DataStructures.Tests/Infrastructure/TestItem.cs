using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataStructures.Tests.Infrastructure
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class TestItem : IEquatable<TestItem>, IComparable<TestItem>
    {
        public int IntValue { get; set; }
        public string StringValue { get; set; }

        public override string ToString()
        {
            return string.Format("{0} , {1}", this.IntValue, this.StringValue);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = this.IntValue.GetHashCode();

                hash = (hash * 397) ^ this.StringValue.GetHashCode();

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TestItem other = obj as TestItem;

            if (obj == null)
            {
                return false;
            }

            return this.IntValue == other.IntValue
                && this.StringValue == other.StringValue;
        }

        public bool Equals(TestItem other)
        {
            if (other == null)
            {
                return false;
            }

            return this.IntValue == other.IntValue
                && this.StringValue == other.StringValue;
        }

        private string DebuggerDisplay
        {
            get
            {
                return string.Format("Int = {0}, String = {1}", this.IntValue, this.StringValue);
            }
        }

        public int CompareTo(TestItem other)
        {
            if (other == null || this.IntValue > other.IntValue)
            {
                return 1;
            }

            if (this.IntValue < other.IntValue)
            {
                return -1;
            }

            return 0;
        }
    }
}
