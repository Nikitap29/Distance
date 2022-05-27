using System;

namespace Distance
{
    /// <summary>
    /// Объект-отрезок профиля
    /// </summary>
    class Segment
    {
        /// <summary>
        /// Координата Х первой точки отрезка
        /// </summary>
        public double X1 = 0;
        /// <summary>
        /// Координата Y первой точки отрезка
        /// </summary>
        public double Y1 = 0;
        /// <summary>
        /// Координата Х второй точки отрезка
        /// </summary>
        public double X2 = 0;
        /// <summary>
        /// Координата Y второй точки отрезка
        /// </summary>
        public double Y2 = 0;
        /// <summary>
        /// Кооэффициент К в уравнении прямой
        /// </summary>
        public double K = 0;
        /// <summary>
        /// Кооэффициент B в уравнении прямой
        /// </summary>
        public double B = 0;
        /// <summary>
        /// Вертикальный тип отрезка (false -горизонтальный)
        /// </summary>
        public bool type;
        /// <summary>
        /// Номер отрезка в профиле
        /// </summary>
        public int number;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="num"></param>
        public Segment(double x1, double y1, double x2, double y2, int num)
        {
            //задаем координаты точек и номер отрезка в профиле
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            number = num;
            //если разница по Y больше разницы по Х, то отрезок считается вертикальным, а иначе горизонтальным
            if (Math.Abs(x2 - x1) < Math.Abs(y2 - y1)) type = true;
            else type = false;
            FindKoef();
        }

        /// <summary>
        /// Нахождение коэффициентов уравнения прямой
        /// </summary>
        public void FindKoef()
        {
            //если отрезок вертикальный, то Х считается за ординату
            if (type)
            {
                K = (X2 - X1) / (Y2 - Y1);
                B = X1 - K * Y1;
            }
            //иначе Y считается за ординату
            else
            {
                K = (Y2 - Y1) / (X2 - X1);
                B = Y1 - K * X1;
            }
        }

        /// <summary>
        /// Нахождение ординаты
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double FindOrdinate(double a)
        {
            return K * a + B; //находим ординату по абсциссе
        }

        /// <summary>
        /// Буферный сегмент - сохраняет кратчайший отрезок от точки до другого отрезка
        /// </summary>
        public static Segment seg_buf = new Segment(0,0,0,0,0);

        /// <summary>
        /// Нахождение длины отрезка
        /// </summary>
        /// <param name="seg"></param>
        /// <returns></returns>
        public static double Dist(Segment seg)
        {
            if (seg == null) return 0; //если null, то 0, иначе по формуле
            return Math.Sqrt((seg.X1 - seg.X2) * (seg.X1 - seg.X2) + (seg.Y1 - seg.Y2) * (seg.Y1 - seg.Y2));
        }

        /// <summary>
        /// Нахождение расстояния между точками
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double Dist(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)); //расчет по формуле
        }

    }
}
