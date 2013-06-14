using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    //Define a class BitArray64 to hold 64 bit values inside an ulong value.
    //Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
    public class BitArray64 : IEnumerable<int>
    {
        private const int NumberOfBits = 64;
        private ulong value;
        private bool[] bits;

        public ulong Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                for (int i = 0; i < NumberOfBits; i++)
                {
                    if (((value >> i) & 1) == 1)
                    {
                        this.bits[i] = true;
                    }
                }
            }
        }

        public BitArray64()
        {
            this.bits = new bool[64];
            this.Value = 0;

        }

        public BitArray64(ulong number)
        {
            this.bits = new bool[64];
            this.Value = number;
        }

        //indexer
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= NumberOfBits)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Index must be between 0 and {0}.", NumberOfBits));
                }
                if (bits[index])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (index < 0 || index >= NumberOfBits)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Index must be between 0 and {0}.", NumberOfBits));
                }
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Bit must be 0 or 1.");
                }
                if (value == 1)
                {
                    this.bits[index] = true;
                    this.value += (ulong)1 << index;
                }
                else //if (value == 0)
                {
                    this.bits[index] = false;
                    this.value -= (ulong)1 << index;
                }
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 other = obj as BitArray64;
            if (other == null)
            {
                return false;
            }
            return this.Value == other.Value;
        }

        public static bool operator ==(BitArray64 b1, BitArray64 b2)
        {
            return b1.Equals(b2);
        }
        public static bool operator !=(BitArray64 b1, BitArray64 b2)
        {
            return !b1.Equals(b2);
        }

        public override int GetHashCode()
        {
            int result = 0;
            int pow = 1;
            for (int i = 0; i < NumberOfBits; i++)
            {
                if (bits[i])
                {
                    result += pow;
                }
                pow *= 2;
            }
            return result;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = NumberOfBits-1; i >= 0; i--)
            {
                yield return bits[i] ? 1 : 0;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var enumerator = bits.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}
