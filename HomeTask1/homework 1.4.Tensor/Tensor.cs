namespace TensorTask
{// Щоб було ще краще, треба зробити клас-узагальнення та здійснити неявне приведення до типу Tensor масивів. 
    internal class Tensor
    {
        private readonly int[] _dimensionSizes;
        private int[] _data;
        public int First//для першого елемента або для задавання змінної одної розмірності 1
        {
            get
            {
                return _data[0];
            }
            set
            {
                _data[0] = value;
            }
        }


        public Tensor(params int[] dimensionSizes)
        {
            if (dimensionSizes.Length == 0)
            {
                _data = new int[1];

            }
            else
            {
                int size = 1;
                _dimensionSizes = new int[dimensionSizes.Length];
                for (int i = 0; i < dimensionSizes.Length; i++)
                {
                    size *= dimensionSizes[i];
                    _dimensionSizes[i] = dimensionSizes[i];
                }
                _data = new int[size];
            }

        }


        public int this[params int[] dimensionIndexes]
        {

            get
            {
                CheckIndex(dimensionIndexes);
                return _data[ReturnIndex(dimensionIndexes)];
            }
            set
            {
                CheckIndex(dimensionIndexes);
                _data[ReturnIndex(dimensionIndexes)] = value;
            }
        }


        private void CheckIndex(int[] dimensionIndexes)
        {
            for (int i = 0; i < dimensionIndexes.Length; i++)
            {
                if (dimensionIndexes[i] >= _dimensionSizes[i] || dimensionIndexes[i] < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }


        private int ReturnIndex(int[] dimensionIndexes)
        {
            int index = 0;
            int multiply_result;
            for (int n = 0; n < dimensionIndexes.Length; n++)
            {
                multiply_result = 1;
                for (int m = _dimensionSizes.Length - 1; m > n; m--)
                {
                    multiply_result *= _dimensionSizes[m];
                }

                index += multiply_result * dimensionIndexes[n];
            }
            return index;
        }


        public int GetSize(int index)
        {
            if (index >= _dimensionSizes.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return _dimensionSizes[index];
        }




    }
}
