// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


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
            col[i,j] = rand.Next(0 , 100);
        }
    }
return col;
}


// Печать массива введена для контроля работы программы
// Добавлена проверка на крайний элемент массива для печати без последней запятой
void PrintArray(int[,] col)
{
int rows = col.GetUpperBound(0) + 1;
int columns = col.Length / rows;
    
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



int MinStringSum(int[,] col)
{
int minStringSum = 0;
int stringSum = 0;
int rowNum = 0;
int rows = col.GetUpperBound(0) + 1;
int columns = col.Length / rows;

for (int f=0; f<columns; f++)
        {
            stringSum = stringSum + col[0,f];
        }
minStringSum = stringSum;

for (int i=0; i<rows; i++)
    {
        stringSum = 0;

        for (int j=0; j<columns; j++)
        {
            stringSum = stringSum + col[i,j];
            
        }
        if (stringSum < minStringSum)
            {
                minStringSum = stringSum;
                rowNum = i;
            }
    Console.WriteLine($"Сумма элементов {i+1}й строки {stringSum}");
    }
    
return (rowNum+1);
}




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
int[,] tempArray=ComplArray(array);
PrintArray(tempArray);
Console.WriteLine($"Строка с наименьшей суммой элементов: {MinStringSum(tempArray)}");


