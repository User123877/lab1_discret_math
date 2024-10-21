namespace discret_math_lab_1
{

    class Program
    {
        static Figure A, B, C, D;


        static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Ввод фигур (A, B, C, D)");
                Console.WriteLine("2. Проверить принадлежность точки множеству");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите опцию (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InputFigures();
                        break;
                    case "2":
                        CheckPoint();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Недопустимый вариант. Пожалуйста, выберите 1-3.");
                        break;
                }
                Console.WriteLine();
            }
        }

        //Метод для ввода переменных 
        static void InputFigures()
        {
            Console.WriteLine("Ввод фигуры A:");
            A = InputFigure();
            Console.WriteLine("Ввод фигуры B:");
            B = InputFigure();
            Console.WriteLine("Ввод фигуры C:");
            C = InputFigure();
            Console.WriteLine("Ввод фигуры D:");
            D = InputFigure();
        }

        //Метод для проверки и построения круга или произвольного прямоуг.
        static Figure InputFigure()
        {
            Figure fig = new Figure();
            Console.Write("Является ли фигура кругом? (да/нет): ");
            string type = Console.ReadLine().ToLower();
            fig.isCircle = type == "да";

            Console.Write("Введите координату X центра: ");
            fig.x0 = double.Parse(Console.ReadLine());
            Console.Write("Введите координату Y центра: ");
            fig.y0 = double.Parse(Console.ReadLine());

            if (fig.isCircle)
            {
                Console.Write("Введите радиус: ");
                fig.R = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Введите ширину: ");
                fig.w = double.Parse(Console.ReadLine());
                Console.Write("Введите высоту: ");
                fig.h = double.Parse(Console.ReadLine());
            }
            return fig;
        }

        // МЕтод для проверки выражения, является ли точка в наших областях
        static void CheckPoint()
        {
            Console.Write("Введите координату X точки: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите координату Y точки: ");
            double y = double.Parse(Console.ReadLine());

            bool inA = IsPointInFigure(A, x, y);
            bool inB = IsPointInFigure(B, x, y);
            bool inC = IsPointInFigure(C, x, y);
            bool inD = IsPointInFigure(D, x, y);

            // Проверка выражения.
            bool result = ((!inA) && (inB || inC)) || inD;

            if (result)
            {
                Console.WriteLine("Точка принадлежит множеству.");
            }
            else
            {
                Console.WriteLine("Точка не принадлежит множеству.");
            }
        }

        static bool IsPointInFigure(Figure fig, double x, double y)
        {
            if (fig.isCircle)
            {
                // Точка внутри круга?
                double dx = x - fig.x0;
                double dy = y - fig.y0;
                return dx * dx + dy * dy <= fig.R * fig.R;
            }
            else
            {
                // Точка внутри прямоуг.
                double left = fig.x0 - fig.w / 2;
                double right = fig.x0 + fig.w / 2;
                double top = fig.y0 + fig.h / 2;
                double bottom = fig.y0 - fig.h / 2;
                return x >= left && x <= right && y >= bottom && y <= top;
            }
        }
    }
}
