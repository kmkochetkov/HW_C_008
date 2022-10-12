// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2



// Метод ввода данных
int Num()
{
    int num=0;
    try
    {
        Console.Write(":> ");
        num = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {    
        Console.WriteLine("Нужно вводить целое число!");
    }
    return num;
}
 

// Заполняем масив случайными числами.
int[,] ComplArray(int[,] col)
{
Random rand = new Random();
int rows = col.GetUpperBound(0) + 1;
int columns = col.Length / rows;
    
    for (int i=0; i< rows; i++)
    {
        for ( int j = 0; j< columns; j++)
        {
            col[i,j] = rand.Next(-100, 100);
        }
    }
return col;
}


// Сортировка строк массива по убыванию
int[,] SorStringtArray(int[,] arr)
{
int rows = arr.GetUpperBound(0) + 1;
int columns = arr.Length / rows;
int temp = 0;

    for (int row = 0; row < rows; row++)    // Перебор строк массива
    {
        for (int counter = 0; counter < columns; counter++)   // Перебор столбцов массива
        {
        for (int sort = 0; sort < columns - 1; sort++)
            {
            if (arr[row, sort] < arr[row, sort + 1])    // Сортировка по строке массива
                {
                    temp = arr[row, sort + 1];
                    arr[row,sort + 1] = arr[row, sort];
                    arr[row, sort] = temp;
                }
            }
        }
    }
return arr;
}



// Печать массива введена для контроля работы программы
// Добавлена
void PrintArray(int[,] col)
{
int rows = col.GetUpperBound(0) + 1;
int columns = col.Length / rows;
    // проверка на крайний элемент массива для печати без последней запятой

    for (int i=0; i< rows; i++)
    {
        for ( int j = 0; j < columns; j++)
        {
            if (j != columns-1)
            {
            Console.Write($"{col[i,j]}, "); // Не крайний элемент массива в строке
            }
            else
            {
                Console.Write($"{col[i,j]}"); // Крайний элемент массива в строке
            }
        }
        Console.WriteLine();
    }
}


// Основная программа

// Блок ввода размера массива пользователем
// Введена проверка введённого размера. Он должен быть целым, больше 0.
// Если введено число меньше "1", то размер приравнивается "1"
Console.WriteLine("Задайте размер двумерного массива");
int m = 0;
int n = 0;

Console.Write("Введите количество строк");
m = Num();
if ( m < 1)
    {
        m=1;
    }

Console.Write("Введите количество столбцов");
n = Num();
if ( n < 1)
    {
        n=1;
    }

int[,] array = new int[m,n];
int[,] tempArray = ComplArray(array);

Console.WriteLine("Исходный массив:");
PrintArray(tempArray);
int[,] sortedArray = SorStringtArray(tempArray);
Console.WriteLine("");
Console.WriteLine("Массив, с отсортированными по убыванию строками:");
PrintArray(sortedArray);