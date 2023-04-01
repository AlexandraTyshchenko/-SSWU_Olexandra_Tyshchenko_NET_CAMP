using System.Text;

namespace homework_1._2
{
    class Result
    {
        public int max { get; set; }
        public int color { get; set; }
        public int[] start { get; set; }
        public int[] end { get; set; }

        public Result()
        {
            max = 0;
            color = 0;
            start = new int[2];
            end = new int[2];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"max length= {max}, color={color},start=[{start[0]}][{start[1]}],end=[{end[0]}][{end[1]}]");
            return sb.ToString();
        }

    }
    internal class Matrix
    {

        private int[,] _matrix;
        private int _m;
        private int _n;
        private readonly Random _random;
        public Matrix(int m = 3, int n = 3)
        {
            _random = new Random();
            _matrix = new int[_m = m, _n = n];
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = _random.Next(17);
                }
            }
        }
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < _matrix.GetLength(1); ++j)
                {
                    sb.Append(string.Format("{0," + 4 + "}", _matrix[i, j]));
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

       public Result findColor()
        {
            Result result = new Result();
            int buf;
            int[] bufstart = new int[2];
            int[] bufend = new int[2];
           // Надмірна кількість циклів. Достатньо 2.
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {

                bufstart[0] = i; bufend[0] = i;
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    buf = 1;
                    bufstart[1] = j;
                    for (int k = j + 1; k < _matrix.GetLength(1); k++)
                    {
                        if (_matrix[i, k - 1] == _matrix[i, k])
                        {
                            buf++;
                        }
                        else
                        {
                            bufend[1] = k - 1;
                            break;
                        }
                    }
                    if (result.max < buf)
                    {
                        result.max = buf;
                        result.color = _matrix[i, j];
                        result.start[1] = bufstart[1];
                        result.end[1] = bufend[1];
                        result.start[0] = bufstart[0];
                        result.end[0] = bufend[0];
                    }
                }
            }
            return result;
        }



    }
}
