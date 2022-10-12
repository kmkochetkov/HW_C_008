// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы
// каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)




// Заполняем масив случайными числами.
int[,,] ComplArray(int[,,] col)
{
Random rand = new Random();
int rows = col.GetLength(0) + 1;
int columns = col.GetLength(1) + 1;
int depth = col.GetLength(2) + 1;
int j = 0;
int tempNum = 0;
bool checker = true;

    for(int k = 0; k < depth - 1 ; k++)
    {
        for (int i=0; i < rows - 1; i++)
        {
            while (j < columns - 1)
            {
               
                
                tempNum = rand.Next(10 , 100);
                checker = CheckNum(col, tempNum);
                if ( checker == false)
                {
                    col[i,j,k]=tempNum;
                    j++;
                }
           
            }
            j = 0;
        }
    
    }
    return col;
}



// Вывод массива на консоль
void PrintArray(int[,,] col)
{
int rows = col.GetLength(0) + 1;
int columns = col.GetLength(1) + 1;
int depth = col.GetLength(2) + 1;

    for (int k=0; k < depth - 1; k++)
    {
        Console.WriteLine();
        for (int i=0; i < rows - 1; i++)
        {
            Console.WriteLine();
            for ( int j = 0; j < columns - 1; j++)
            {
                Console.Write($"{col[i,j,k]}({i},{j},{k}) ");
                
            }
            Console.WriteLine();
        }
    }
}



// Метод проверки элемента, вводимого в массив на уникальность
bool CheckNum(int[,,] col, int num)
{
int rows = col.GetLength(0) + 1;
int columns = col.GetLength(1) + 1;
int depth = col.GetLength(2) + 1;
bool checker = false;
    for (int k=0; k < depth - 1; k++)
    {
        for (int i=0; i < rows - 1; i++)
        {
            for ( int j = 0; j < columns - 1; j++)
            {
                if (num == col[i,j,k])
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
        }
    }
return checker;
}




// Метод ввода начальных данных
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
 

// Основная программа

// Блок ввода размера массива пользователем
// Введена проверка введённого размера. Он должен быть целым, больше 0.
// Если введено число меньше "1", то размер приравнивается "1"
Console.WriteLine("Задайте размер трехмерного массива");
int m = 0;
int n = 0;
int k = 0;

Console.Write("Введите количество строк m");
m = Num();
if ( m < 1)
    {
        m=1;
    }

Console.Write("Введите количество столбцов n");
n = Num();
if ( n < 1)
    {
        n=1;
    }

Console.Write("Введите количество рядов k ");
k = Num();
if ( k < 1)
    {
        n=1;
    }



int[,,] array = new int[m,n,k];

int firstDimention = array.GetLength(0); // 1й размер массива
int secondDimention = array.GetLength(1); // 2й размер массива
int thirdDimension = array.GetLength(2); // 3й размер массива

Console.WriteLine($"Массив размера: {firstDimention}X{secondDimention}X{thirdDimension}");
int[,,] tempArray = ComplArray(array);
PrintArray(tempArray);