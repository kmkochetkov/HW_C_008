using System.Threading.Tasks.Dataflow;
// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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


//////////////////////////////////////////////////////////////////////
// Блоки оставлены для удобства отладки, чтобы видеть, в каком направлении движется заполнение массива
// Направление заполнения, координаты элемента, элемент, номер кольца заполнения
// Console.WriteLine($"Вправо({i},{j}) - {num} кольцо {ringCounter})");
// Заполнение происходит по кольцам граням, из 4х граней образуется кольцо. Начинаем от элемента с индексаим 0,0

// Заполняем масив.
int[,] ComplArray(int[,] col)
{
int num = 1;
int rows = col.GetLength(0);
int columns = col.GetLength(0);

int colCounter = columns;
int rowsCounter = 0;
int i = 0;
int j = 0;

int ringCounter=0;

while(ringCounter < rows/2 || ringCounter < columns/2 )
{
    for (j=0+ringCounter; j < columns-2-ringCounter+1; j++) // 1 Движение по строке вправо
    {
        col[i,j]=num;
        // Console.WriteLine($"Вправо({i},{j}) - {num} кольцо {ringCounter})");
        num++;
        
    }

    for (i=0+ringCounter; i < rows-1-ringCounter; i++) // 2 Движение по столбцу вниз
    {
        col[i,j]=num;
        // Console.WriteLine($"Вниз({i},{j}) - {num})");
        num++;
        
    }

    colCounter = j;
    for ( j=colCounter ; j > ringCounter-0; j--)  // 3 Движениепо строке влево
    {
        col[i,j]=num;
        // Console.WriteLine($"Влево({i},{j}) - {num})");
        num++;
        
    }

    rowsCounter = i;
    for (i=rowsCounter; i > ringCounter+0; i--)  // 4 Движениепо столбцу вверх
        {
            col[i,j]=num;
            // Console.WriteLine($"Вверх({i},{j}) - {num})");
            num++;
                
        }
    i++;
    ringCounter++;
    // Console.WriteLine($"{ringCounter},{num}");
    // Console.WriteLine($"{ringCounter}е кольцо, координата элемента - {i},{j}");

}
return col;
}
//////////////////////////////////////////////////////////////////////





// Вывод массива на консоль
void PrintArray(int[,] col)
{
int rows = col.GetLength(0) + 1;
int columns = col.GetLength(1) + 1;

    for (int i=0; i < rows - 1; i++)
    {
        Console.WriteLine();
        for ( int j = 0; j < columns - 1; j++)
        {
            Console.Write($"{col[i,j]} ");            
        }
        Console.WriteLine();
    }
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
int rows = array.GetLength(0);
int columns = array.GetLength(0);


Console.WriteLine($"Массив размера: {rows}X{columns}");


int[,] array1= ComplArray(array);
PrintArray(array1);

