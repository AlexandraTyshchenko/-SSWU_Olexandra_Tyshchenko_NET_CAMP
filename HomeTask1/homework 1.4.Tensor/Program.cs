using TensorTask;
Random random= new Random();
Tensor tensor=new Tensor();
tensor.First = 2;
Console.WriteLine(tensor.First);
Tensor tensor1= new Tensor(3);
for(int i=0; i<tensor1.GetSize(0); i++)
{
    tensor1[i] = random.Next(1,6);
    Console.Write(tensor1[i]+" ");
}
Console.WriteLine();
tensor1[2] = 0;
for (int i = 0; i < tensor1.GetSize(0); i++)
{
    Console.Write(tensor1[i] + " ");
}
Tensor tensor3 = new Tensor(3, 4);
tensor3[2, 3] = 4;
