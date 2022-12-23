using System;
namespace DSA_DA
{
    public class D_Array
    {
        private int[] storage;
        private int lastItemIndex;

        // a constructor
        public D_Array(int size)
        {
            if (size > 0)
                storage = new int[size];
            else
                storage = new int[1];
            lastItemIndex = -1;
        }

        public int this[int index]
        {
            get
            {
                validate_idx(index);
                return storage[index];
            }
            set
            {
                validate_idx(index);
                storage[index] = value;
            }
        }

        public int Length()
        {
            return lastItemIndex + 1;
        }
        public int LengthOfStorage()
        {
            return storage.Length;
        }

        private void validate_idx(int index)
        {
            if (index < 0 || index > lastItemIndex)
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        public void expand_storage()
        {
            int[] temp = new int[storage.Length * 2];
            Array.Copy(storage, temp, storage.Length);
            storage = temp;
        }

        public void add(int data)
        {
            if (lastItemIndex == storage.Length - 1)
                expand_storage();
            lastItemIndex++;
            storage[lastItemIndex] = data;
        }

        public void insert(int index, int data)
        {
            validate_idx(index);
            if (lastItemIndex == storage.Length - 1) expand_storage();
            int moving_size = lastItemIndex - index + 1;
            Array.Copy(storage, index, storage, index + 1, moving_size);
            lastItemIndex++;
            storage[index] = data;
        }

        public void find(int data)
        {
            for (int i = 0; i <= lastItemIndex; i++)
            {
                if (storage[i] == data)
                {
                    Console.WriteLine("I found {0} at index {1}", data, i);
                    return;
                }

            }
            Console.WriteLine("I can't find it at all");
        }
        public void print()
        {
            for (int i = 0; i <= lastItemIndex; i++) Console.WriteLine(storage[i]);
        }

    }
    public class program
    {
        public static void Main(string[] args)
        {
            D_Array arr = new D_Array(2);
            arr.add(3);
            arr.add(4);
            arr.add(5);
            arr.insert(1, 7); // the index  the data
            arr.print();
            arr.find(7);
        }
    }
}