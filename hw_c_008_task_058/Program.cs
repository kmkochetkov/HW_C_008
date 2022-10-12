// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18



// Заполняем масив случайными числами.
double[,] ComplArray(double[,] col)
{
Random rand = new Random();
int rows = col.GetLength(0) + 1;
int columns = col.GetLength(1) + 1;
int j = 0;
for (int i=0; i < rows - 1; i++)
    {
        for (j=0 ; j < columns-1; j++)
        {       
            col[i,j]=rand.Next(1 , 10);          
        }
        
    }
return col;    
}


// Метод печати массива
void PrintArray(double[,] col)
{
int rows = col.GetLength(0) + 1;
int columns = col.GetLength(1) + 1;
int j = 0;
for (int i=0; i < rows - 1; i++)
        {
            for (j=0 ; j < columns-1; j++)
            {       
                Console.Write($"{col[i,j]} ");      
            }
            Console.WriteLine();
        }    
}


// Ввод размера
int Num()
{
    int num=0;
    try
    {
        Console.Write(" :> ");
        num = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {    
        Console.WriteLine("Нужно вводить целое число!");
    }
    return num;
}



// Метод произведения матриц
double[,] MultMath(double[,] col1, double[,] col2)
{

    int rows1 = col1.GetLength(0) + 1;
    int columns1 = col1.GetLength(1) + 1;
    int rows2 = col2.GetLength(0) + 1;
    int columns2 = col2.GetLength(1) + 1;
    double[,] col = new double[(rows1-1),(columns2-1)];
    if (rows1==columns2)
    {
    for(int i = 0; i < rows1-1; i++)
        for(int j = 0; j < columns2-1; j++)
        {
            col[i,j] = 0;
            for(int k = 0; k < columns1-1; k++)
                col[i,j] += col1[i,k] * col2[k,j];
        }
    }    
   return col;   
}

// Основная программа
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Произведение двух матриц существует в случае,");
Console.WriteLine("     если число строк первой матрицы");
Console.WriteLine("   равно числу столбцов второй матрицы!");
Console.WriteLine("В случае невыполнения условия, будет возвращена нулевая матрица,");
Console.WriteLine("размерностью [число строк первой Х число столбцов второй]");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Введите размер первой матрицы");
Console.Write("n1 ");
int n1 = Num();
Console.Write("m1 ");
int m1 = Num();
double[,] arr1 = new double[m1,n1];

Console.WriteLine("Введите размер второй матрицы");
Console.Write("n2 ");
int n2 = Num();
Console.Write("m2 ");
int m2 = Num();

double[,] arr2 = new double[m2,n2];
double[,] arr3 = new double[m1,n2];

// Заполнение матриц множителей
double[,] arrayA=ComplArray(arr1);
double[,] arrayB=ComplArray(arr2);
Console.WriteLine("*********");
PrintArray(arrayA);
Console.WriteLine("*********");
PrintArray(arrayB);

Console.WriteLine("*********");
Console.WriteLine("Произведение матриц:");
arr3 = MultMath(arrayA,arrayB);
PrintArray(arr3);

Console.WriteLine($"Размер итоговой матрицы: {arr3.GetLength(0)}X{arr3.GetLength(1)}");

int rows3 = arr3.GetLength(0) + 1;
int columns3 = arr3.GetLength(1) + 1;



// // Для проверки работы метода умножения матриц ввел данные из условия
// Console.WriteLine("*********");
// double[,] a = new double[,] {{2,4},{3,2}};
// PrintArray(a);
// Console.WriteLine("*********");
// double[,] b = new double[,] {{3,4},{3,3}};

// PrintArray(b);
// Console.WriteLine("*********");
// double[,] c = new double[2,2];
// c = MultMath(a,b);
// PrintArray(c);

