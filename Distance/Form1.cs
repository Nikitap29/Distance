using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using ZedGraph;
using System.Drawing;

namespace Distance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Профиль 1
        /// </summary>
        List<Segment> profile1 = new List<Segment>();
        /// <summary>
        /// Профиль 2
        /// </summary>
        List<Segment> profile2 = new List<Segment>();

        /// <summary>
        /// Кнопка "Открыть файл 1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); //файл выбирается из диалога
            profile1 = Parser(openFileDialog1.FileName, Color.Blue, false); //профиль заполняется из файла через "парсер"
        }

        /// <summary>
        /// Кнопка "Открыть файл 2"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile2(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); //файл выбирается из диалога
            profile2 = Parser(openFileDialog1.FileName, Color.Red, false); //профиль заполняется из файла через "парсер"
        }

        /// <summary>
        /// "Парсер" текстовых файлов с отрезками
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="clr"></param>
        /// <param name="join"></param>
        /// <returns></returns>
        private List<Segment> Parser(string filename, Color clr, bool join)
        {
            List<Segment> profile = new List<Segment>(); //выходной профиль
            if (File.Exists(filename)) //если файл существует, то
            { 
                int j = 0; //используется для задания номера отрезка в профиле
                StreamReader fs = new StreamReader(filename); //открываем поток и пока не закончится файл читаем его
                while (!fs.EndOfStream)
                {
                    string[] s = fs.ReadLine().Split(' '); //делим входную строку
                    //добавляем новый объект-отрезок на основе данных из файла
                    Segment seg = new Segment(Convert.ToDouble(s[2].Replace('.', ',')), Convert.ToDouble(s[3].Replace('.', ',')),
                        Convert.ToDouble(s[4].Replace('.', ',')), Convert.ToDouble(s[5].Replace('.', ',')), j);
                    profile.Add(seg); //добавляем отрезок в выходной профиль
                    DrawSegment(seg, clr); //изображение профиля на графике
                    j++; //увеличиваем номер
                }
                fs.Close(); //закрываем поток
                if (join) //"склейка" отрезков, если необходимо
                {
                    List<Segment> profile_add = new List<Segment>(); //вспомогательный список
                    for (int i = 0; i < profile.Count - 1; i++) //перебор отрезков в профиле
                    {//новый объект-отрезок: первая точка - крайняя текущего отрезка, вторая - первая следующего отрезка
                        Segment seg = new Segment(profile[i].X2, profile[i].Y2, profile[i + 1].X1, profile[i + 1].Y1, 0);
                        profile_add.Add(seg); //добавляем отрезок во вспомогательный лист
                        DrawSegment(seg, clr); //дорисоываем профиль ("склеиваем")
                    }
                    //дополняем выходной профиль "склейками"
                    foreach (Segment seg in profile_add) profile.Add(seg);
                }
            }
            return profile;
        }

        /// <summary>
        /// Рисование отрезков
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="clr"></param>
        private void DrawSegment(Segment segment, Color clr)
        {
            GraphPane pane = zed.GraphPane; //объект-ячейка для рисования
            PointPairList list = new PointPairList //список точек
            {
                { segment.X1, segment.Y1 },
                { segment.X2, segment.Y2 }
            };
            pane.AddCurve("", list, clr, SymbolType.None); //добавляем линию на график
            //обновляем график
            zed.AxisChange();
            zed.Invalidate();
        }

        /// <summary>
        /// Кнопка "Расчет разницы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcDistances(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog(); //задаем файл для сохранения файла с отрезками разницы
            string filename = saveFileDialog1.FileName; //имя файла
            if (filename != "") //если имя не пустое, то
            {
                StreamWriter sw = new StreamWriter(filename); //открываем поток на запись этого файла
                foreach (Segment seg in profile1) //перебор отрезков профиля 1
                {
                    double x1_max, x1; //переменные для хранения промежуточных значений отрезков профиля 1
                    if (!seg.type) //если отрезок не вертикальный (горизонтальный), то
                    {
                        if (seg.X1 > seg.X2) //если Х1 больше Х2, то за минимум берется Х2, а за максимум Х1
                        {
                            x1 = seg.X2;
                            x1_max = seg.X1;
                        }
                        else //иначе наоборот
                        {
                            x1 = seg.X1;
                            x1_max = seg.X2;
                        }
                    }
                    else //если же отрезок вертикальный, то
                    {
                        if (seg.Y1 > seg.Y2) //если Y1 больше Y2, то за минимум берется Y2, а за максимум Y1 
                        {
                            x1 = seg.Y2;
                            x1_max = seg.Y1;
                        }
                        else //иначе наоборот
                        {
                            x1 = seg.Y1;
                            x1_max = seg.Y2;
                        }
                    }
                    while (x1 <= x1_max) //пока не подошли к максимуму
                    {
                        double x2_max, x2; //переменные для хранения промежуточных значений отрезков профиля 2
                        double dist_buf = 100000; //переменная для хранения промежуточного значения расстояния
                        foreach (Segment seg2 in profile2) //перебор отрезков профиля 2
                        { //если отрезок профиля 2 не лежит в окрестности отрезка профиля 1, то пропускаем этот отрезок
                            if (Math.Abs(seg2.number - seg.number) > 1) continue; 
                            if (!seg2.type) //если отрезок не вертикальный (горизонтальный), то
                            {
                                if (seg2.X1 > seg2.X2) //если Х1 больше Х2, то за минимум берется Х2, а за максимум Х1
                                {
                                    x2 = seg2.X2;
                                    x2_max = seg2.X1;
                                }
                                else //иначе наоборот
                                {
                                    x2 = seg2.X1;
                                    x2_max = seg2.X2;
                                }
                            }
                            else //если же отрезок вертикальный, то
                            {
                                if (seg2.Y1 > seg2.Y2) //если Y1 больше Y2, то за минимум берется Y2, а за максимум Y1 
                                {
                                    x2 = seg2.Y2;
                                    x2_max = seg2.Y1;
                                }
                                else //иначе наоборот
                                {
                                    x2 = seg2.Y1;
                                    x2_max = seg2.Y2;
                                }
                            }
                            while (x2 <= x2_max) //пока не подошли к максимуму
                            {
                                double y2 = seg2.FindOrdinate(x2); //определяем ординату отрезка профиля 2
                                double y1 = seg.FindOrdinate(x1); //определяем ординату отрезка профиля 1
                                double dist_now; //промежуточное хранилище дистанции
                                Segment seg3; //промежуточное хранение отрезка расстояния
                                //определение отрезка в зависимости от типа исходных отрезков
                                if (!seg.type && !seg2.type) seg3 = new Segment(x2, y2, x1, y1, 0);
                                else if (seg.type && !seg2.type) seg3 = new Segment(x2, y2, y1, x1, 0);
                                else if (!seg.type && seg2.type) seg3 = new Segment(y2, x2, x1, y1, 0);
                                else seg3 = new Segment(y2, x2, y1, x1, 0);
                                dist_now = Segment.Dist(seg3); //расчет дистанции
                                if (dist_now < dist_buf) //если рассчитанная дистанция меньше хранимой
                                {
                                    Segment.seg_buf = seg3; //сохраняем отрезок в буфер
                                    dist_buf = dist_now; //сохраняем дистанцию в буфер
                                }
                                x2 += 0.001; //прибавляем абсциссу профиля 2
                            }
                        }
                        //пишем в файл отрезок
                        sw.WriteLine("0 0 " + Segment.seg_buf.X1.ToString() + " " + Segment.seg_buf.Y1.ToString()
                            + " " + Segment.seg_buf.X2.ToString() + " " + Segment.seg_buf.Y2.ToString());
                        x1 += 1; //прибавляем абсциссу профиля 1
                    }
                }
                sw.Close(); //закрываем поток
                Parser(filename, Color.Green, false); //"парсим" и отображаем разницу
            }
        }

        /// <summary>
        /// Кнопка "Отобразить гистограмму"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawHist(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); //выбираем файл из окна
            string filename = openFileDialog1.FileName; //имя файла
            PointPairList list = new PointPairList(); //список точек
            GraphPane pane = zed2.GraphPane; //объект-ячейка для рисования
            double x1, x2, y1, y2, dist; //промежуточное хранилище данных
            if (File.Exists(filename)) //если выбранный файл существует
            {
                StreamReader fs = new StreamReader(filename); //открываем поток на чтение
                while (!fs.EndOfStream) //пока не конец файла читаем данные
                {
                    string[] s = fs.ReadLine().Split(' ');
                    x1 = Convert.ToDouble(s[2].Replace('.', ','));
                    y1 = Convert.ToDouble(s[3].Replace('.', ','));
                    x2 = Convert.ToDouble(s[4].Replace('.', ','));
                    y2 = Convert.ToDouble(s[5].Replace('.', ','));
                    Segment seg = new Segment(x1, y1, x2, y2, 0);
                    dist = Segment.Dist(seg);
                    if (seg.type) //если вертикальный отрезок и
                    {
                        //если Y1 больше Y2, то инертируем дистанцию 
                        if (seg.Y1 > seg.Y2) dist *= -1;
                    }
                    else //если горизонтальный отрезок и
                    {
                        //если Х1 больше Х2, то инертируем дистанцию
                        if (seg.X1 > seg.X2) dist *= -1;
                    }
                    list.Add(0, dist); //добавляем в список значение дистанции
                }
                fs.Close(); //закрываем поток
                double[] items = new double[list.Count]; //для записи в объект-гистограмму
                int k = list.Count-1; //счетчик гистограмм (инвертированный)
                foreach (PointPair p in list) //для каждого значения в списке
                {
                    items[k] = p.Y; //добавляем объект в хранилище
                    k--; //уменьшаем счетчик
                }
                BarItem curve = pane.AddBar("", null, items, Color.YellowGreen); //отрисовка гистограмм
                // Отключим градиентную заливку
                curve.Bar.Fill.Type = FillType.Solid;
                // Сделаем границы столбцов невидимыми
                curve.Bar.Border.IsVisible = false;
                zed2.AxisChange(); //обновляем график
                zed2.Invalidate();
            }
        }
    }
}
