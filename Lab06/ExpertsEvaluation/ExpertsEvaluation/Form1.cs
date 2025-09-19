using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpertsEvaluation
{
    public partial class Form1 : Form
    {
        private readonly List<int> polar1GVNumbers = new List<int>();
        
        private readonly List<int> polar2GVNumbers = new List<int>();
        private readonly List<int> polar3GVNumbers = new List<int>();
        private readonly List<int> polar4GVNumbers = new List<int>();
        private readonly List<int> polar5GVNumbers = new List<int>();
        private readonly List<PointF> polar1GVPoints = new List<PointF>();
        private readonly List<PointF> polar2GVPoints = new List<PointF>();
        private readonly List<PointF> polar3GVPoints = new List<PointF>();
        private readonly List<PointF> polar4GVPoints = new List<PointF>();
        private readonly List<PointF> polar5GVPoints = new List<PointF>();
        string[] Criteria = new string[10]
        {
            "Точність управління та обчислень",
            "Ступінь стандартності інтерфейсів",
            "Функціональна повнота",
            "Стійкість до помилок",
            "Можливість розширення",
            "Зручність роботи",
            "Простота роботи",
            "Відповідність чинним стандартом",
            "Переносимість між ПЗ",
            "Зручність навчання",
        };

        int[][] weightCoef = new int[4][];
        int[][] userMarks = new int[10][];
        int[][] expertMarks = new int[3][];
        int[] expertsWeight;


        public Form1()
        {
            InitializeComponent();
            weightCoef[0] = new int[10] { 8, 5, 10, 6, 5, 9, 9, 6, 8, 7};
            weightCoef[1] = new int[10] { 5, 9, 6, 5, 5, 9, 7, 5, 6, 8};
            weightCoef[2] = new int[10] { 9, 6, 9, 10, 10, 7, 6, 10, 9, 6};
            weightCoef[3] = new int[10] { 7, 5, 6, 7, 4, 10, 10, 5, 6, 10};

            userMarks[0] = new int[20] { 6, 8, 9, 6, 9, 10, 7, 7, 6, 10, 10, 10, 9, 6, 7, 8, 6, 10, 8, 9 };
            userMarks[1] = new int[20] { 6, 8, 6, 5, 8, 6, 9, 7, 7, 10, 10, 10, 9, 10, 6, 7, 5, 10, 6, 5 };
            userMarks[2] = new int[20] { 6, 7, 6, 4, 4, 9, 8, 4, 6, 9, 5, 9, 8, 7, 4, 4, 4, 8, 4, 6 };
            userMarks[3] = new int[20] { 6, 8, 7, 8, 8, 9, 10, 10, 6, 7, 7, 8, 9, 8, 6, 6, 6, 10, 6, 9 };
            userMarks[4] = new int[20] { 4, 5, 6, 5, 5, 8, 8, 9, 4, 7, 4, 8, 8, 7, 7, 4, 4, 4, 6, 8 };
            userMarks[5] = new int[20] { 6, 6, 10, 6, 7, 9, 8, 10, 6, 10, 10, 8, 6, 9, 6, 6, 8, 10, 6, 10 };
            userMarks[6] = new int[20] { 6, 8, 9, 6, 7, 7, 6, 9, 6, 10, 5, 10, 5, 10, 8, 5, 7, 8, 5, 10 };
            userMarks[7] = new int[20] { 6, 4, 6, 4, 5, 6, 8, 7, 5, 6, 5, 5, 4, 7, 4, 4, 6, 9, 6, 4 };
            userMarks[8] = new int[20] { 8, 8, 10, 7, 6, 7, 10, 6, 6, 8, 10, 6, 9, 8, 9, 8, 6, 9, 6, 10 };
            userMarks[9] = new int[20] { 3, 4, 6, 3, 3, 3, 6, 5, 5, 7, 5, 5, 3, 5, 3, 4, 4, 3, 5, 4 };

            expertMarks[0] = new int[10] { 10, 9, 9, 6, 7, 9, 10, 6, 9, 6 };
            expertMarks[1] = new int[10] { 9, 8, 7, 5, 5, 7, 9, 8, 7, 5 };
            expertMarks[2] = new int[10] { 10, 8, 9, 8, 8, 8, 10, 7, 6, 9 };

            expertsWeight = new int[4] { 7, 8, 9, 5 };

            tabPage1_Click(this, new EventArgs());
            tabPage2_Click(this, new EventArgs());
            tabPage3_Click(this, new EventArgs());
            tabPage4_Click(this, new EventArgs());
            tabPage5_Click(this, new EventArgs());
            tabPage6_Click(this, new EventArgs());
            tabPage7_Click(this, new EventArgs());
            tabPage8_Click(this, new EventArgs());
            tabPage9_Click(this, new EventArgs());
            tabPage10_Click(this, new EventArgs());
        }

        PointF PolarToCartesian(PointF pointF)
        {
            double angleRad = (Math.PI / 180.0) * (pointF.X - 90);
            double x = pointF.Y * Math.Cos(angleRad);
            double y = pointF.Y * Math.Sin(angleRad);
            Console.WriteLine("new y" + y);
            return new PointF((float)x, (float)y);
        }
        
        public void Init()
        {
            weightCoef[0] = new int[10] { 8, 5, 10, 6, 5, 9, 9, 6, 8, 7 };
            weightCoef[1] = new int[10] { 5, 9, 6, 5, 5, 9, 7, 5, 6, 8 };
            weightCoef[2] = new int[10] { 9, 6, 9, 10, 10, 7, 6, 10, 9, 6 };
            weightCoef[3] = new int[10] { 7, 5, 6, 7, 4, 10, 10, 5, 6, 10 };

            userMarks[0] = new int[20] { 6, 8, 9, 6, 9, 10, 7, 7, 6, 10, 10, 10, 9, 6, 7, 8, 6, 10, 8, 9 };
            userMarks[1] = new int[20] { 6, 8, 6, 5, 8, 6, 9, 7, 7, 10, 10, 10, 9, 10, 6, 7, 5, 10, 6, 5 };
            userMarks[2] = new int[20] { 6, 7, 6, 4, 4, 9, 8, 4, 6, 9, 5, 9, 8, 7, 4, 4, 4, 8, 4, 6 };
            userMarks[3] = new int[20] { 6, 8, 7, 8, 8, 9, 10, 10, 6, 7, 7, 8, 9, 8, 6, 6, 6, 10, 6, 9 };
            userMarks[4] = new int[20] { 4, 5, 6, 5, 5, 8, 8, 9, 4, 7, 4, 8, 8, 7, 7, 4, 4, 4, 6, 8 };
            userMarks[5] = new int[20] { 6, 6, 10, 6, 7, 9, 8, 10, 6, 10, 10, 8, 6, 9, 6, 6, 8, 10, 6, 10 };
            userMarks[6] = new int[20] { 6, 8, 9, 6, 7, 7, 6, 9, 6, 10, 5, 10, 5, 10, 8, 5, 7, 8, 5, 10 };
            userMarks[7] = new int[20] { 6, 4, 6, 4, 5, 6, 8, 7, 5, 6, 5, 5, 4, 7, 4, 4, 6, 9, 6, 4 };
            userMarks[8] = new int[20] { 8, 8, 10, 7, 6, 7, 10, 6, 6, 8, 10, 6, 9, 8, 9, 8, 6, 9, 6, 10 };
            userMarks[9] = new int[20] { 3, 4, 6, 3, 3, 3, 6, 5, 5, 7, 5, 5, 3, 5, 3, 4, 4, 3, 5, 4 };

            expertMarks[0] = new int[10] { 10, 9, 9, 6, 7, 9, 10, 6, 9, 6 };
            expertMarks[1] = new int[10] { 9, 8, 7, 5, 5, 7, 9, 8, 7, 5 };
            expertMarks[2] = new int[10] { 10, 8, 9, 8, 8, 8, 10, 7, 6, 9 };

            expertsWeight = new int[4] { 7, 8, 9, 5 };
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            this.Height = 440;
            weightCoefGV.RowCount = 10;
            weightCoefGV.ColumnCount = 7;

            weightCoefGV.ColumnHeadersHeight = 20;
            weightCoefGV.Columns[0].HeaderText = "№ з/п";
            weightCoefGV.Columns[1].HeaderText = "Критерії / Вагові коефіцієнти";
            weightCoefGV.Columns[2].HeaderText = "Експерт галузі";
            weightCoefGV.Columns[3].HeaderText = "Експерт зручності";
            weightCoefGV.Columns[4].HeaderText = "Експерт з програмування";
            weightCoefGV.Columns[5].HeaderText = "Потенційні користувачі";
            weightCoefGV.Columns[6].HeaderText = "Середнє значення";

            for(int i = 0;i<weightCoefGV.RowCount; i++)
            {
                for(int j = 0; j < weightCoefGV.ColumnCount; j++)
                {
                    if (j == 0)
                        weightCoefGV.Rows[i].Cells[j].Value = (i + 1);
                    else if (j == 1)
                        weightCoefGV.Rows[i].Cells[j].Value = Criteria[i];
                    else if (j == 6)
                        weightCoefGV.Rows[i].Cells[j].Value = (Average(new int[] { weightCoef[0][i], weightCoef[1][i], weightCoef[2][i], weightCoef[3][i] })).ToString("0.00");
                    else
                    {
                        weightCoefGV.Rows[i].Cells[j].Value = weightCoef[j-2][i];
                    }
                }
            }
        }
        public double Average(double[] array)
        {
            double Sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Sum += array[i];
            }
            return Sum / array.Length;
        }

        public double Average(int[] array)
        {
            double Sum=0;
            for(int i = 0; i<array.Length; i++)
            {
                Sum += array[i];
            }
            return Sum / array.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < weightCoef.Length; i++)
            {
                for(int j = 0; j < weightCoef[i].Length; j++)
                {
                    weightCoef[i][j] = Convert.ToInt32(weightCoefGV.Rows[j].Cells[i+2].Value);
                }
            }
            tabPage1_Click(this, new EventArgs());
            tabPage3_Click(this, new EventArgs());
            tabPage4_Click(this, new EventArgs());
            tabPage5_Click(this, new EventArgs());
            tabPage6_Click(this, new EventArgs());
            tabPage7_Click(this, new EventArgs());
            tabPage8_Click(this, new EventArgs());
            tabPage9_Click(this, new EventArgs());
            tabPage10_Click(this, new EventArgs());
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            this.Height = 680;
            usersMarksGV.ColumnCount = 21;
            usersMarksGV.RowCount = 10;

            usersMarksGV.Columns[0].HeaderText = "№";
            usersMarksGV.ColumnHeadersHeight = 20;
            for(int i = 1;i< usersMarksGV.ColumnCount; i++){
                usersMarksGV.Columns[i].HeaderText = "User" + i;
            }
            
            for(int i = 0; i < usersMarksGV.RowCount; i++)
            {
                for(int j = 0; j< usersMarksGV.ColumnCount; j++)
                {
                    if (j == 0)
                        usersMarksGV.Rows[i].Cells[j].Value = (i + 1);
                    else
                        usersMarksGV.Rows[i].Cells[j].Value = userMarks[i][j-1];
                }
            }

            ExpertsMarksGV.RowCount = 10;
            ExpertsMarksGV.ColumnCount = 6;

            ExpertsMarksGV.Columns[0].HeaderText = "№";
            ExpertsMarksGV.Columns[1].HeaderText = "Експерт галузі";
            ExpertsMarksGV.Columns[2].HeaderText = "Експерт зручності";
            ExpertsMarksGV.Columns[3].HeaderText = "Експерт з програмування";
            ExpertsMarksGV.Columns[4].HeaderText = "Потенційні користувачі";
            ExpertsMarksGV.Columns[5].HeaderText = "Середнє значення";

            for (int i = 0; i<ExpertsMarksGV.RowCount; i++)
            {
                for(int j = 0; j<ExpertsMarksGV.ColumnCount; j++)
                {
                    if (j == 0)
                        ExpertsMarksGV.Rows[i].Cells[j].Value = (i + 1);
                    else if (j == 4)
                    {
                        ExpertsMarksGV.Rows[i].Cells[j].Value = Average(userMarks[i]);
                    }
                    else if (j == 5)
                    {
                        ExpertsMarksGV.Rows[i].Cells[j].Value = (Average(new double[] { Convert.ToInt32(ExpertsMarksGV.Rows[i].Cells[1].Value), Convert.ToInt32(ExpertsMarksGV.Rows[i].Cells[2].Value),
                            Convert.ToInt32(ExpertsMarksGV.Rows[i].Cells[3].Value), Convert.ToInt32(ExpertsMarksGV.Rows[i].Cells[4].Value) })).ToString("0.00");
                        ExpertsMarksGV.Rows[i].Cells[j-1].Value = (Average(userMarks[i])).ToString("0.00");
                    }
                    else
                        ExpertsMarksGV.Rows[i].Cells[j].Value = expertMarks[j - 1][i];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < userMarks.Length; i++)
            {
                for(int j = 0; j<userMarks[i].Length; j++)
                {
                    userMarks[i][j] = Convert.ToInt32(usersMarksGV.Rows[i].Cells[j + 1].Value);
                }
            }
            tabPage2_Click(this, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<expertMarks.Length; i++)
            {
                for(int j = 0; j < expertMarks[i].Length; j++)
                {
                    expertMarks[i][j] = Convert.ToInt32(ExpertsMarksGV.Rows[j].Cells[i+1].Value);
                }
            }
            tabPage2_Click(this, new EventArgs());
            tabPage3_Click(this, new EventArgs());
            tabPage4_Click(this, new EventArgs());
            tabPage5_Click(this, new EventArgs());
            tabPage6_Click(this, new EventArgs());
            tabPage7_Click(this, new EventArgs());
            tabPage8_Click(this, new EventArgs());
            tabPage9_Click(this, new EventArgs());
            tabPage10_Click(this, new EventArgs());
        }

        public double Sum(int[] array)
        {
            double Sum = 0;
            for(int i = 0; i<array.Length; i++)
            {
                Sum += array[i];
            }
            return Sum;
        }

        public double Sum(double[] array)
        {
            double Sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Sum += array[i];
            }
            return Sum;
        }

       

        private void tabPage3_Click(object sender, EventArgs e)
        {
            evaluationCrGV.RowCount = 11;
            evaluationCrGV.ColumnCount = 7;

            evaluationCrGV.Columns[0].HeaderText = "№";
            evaluationCrGV.Columns[1].HeaderText = "Критерії оцінювання якості ПЗ";
            evaluationCrGV.Columns[2].HeaderText = "Експерт галузі";
            evaluationCrGV.Columns[3].HeaderText = "Експерт зручності";
            evaluationCrGV.Columns[4].HeaderText = "Експерт з програмування";
            evaluationCrGV.Columns[5].HeaderText = "Узагальнені користувачі";
            evaluationCrGV.Columns[6].HeaderText = "Відношення";

            for (int i = 0; i < evaluationCrGV.RowCount-1; i++)
            {
                for (int j = 0; j < evaluationCrGV.ColumnCount; j++)
                {
                    if (j == 0)
                        evaluationCrGV.Rows[i].Cells[j].Value = (i + 1);
                    else if (j == 1)
                        evaluationCrGV.Rows[i].Cells[j].Value = Criteria[i];
                    else
                    {
                        evaluationCrGV.Rows[i].Cells[j].Value = weightCoefGV.Rows[i].Cells[j].Value + "/" + ExpertsMarksGV.Rows[i].Cells[j-1].Value  ;
                    }
                }
            }

            evaluationCrGV.Rows[10].Cells[0].Value = 11;
            evaluationCrGV.Rows[10].Cells[1].Value = "Загальна/середня кількість балів";
            for (int j = 2; j < evaluationCrGV.ColumnCount; j++)
            {
                evaluationCrGV.Rows[10].Cells[j].Value = (Sum(weightCoefGV, j)/10).ToString("0.00") + "/" + (Sum(ExpertsMarksGV, j-1)/10).ToString("0.00");
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            string[] exspertsType = new string[] { "Експерт галузі", "Експерт юзабіліті", "Експерт з програмування", "Потенційні користувачі" };
            expertsTypeGV.RowCount = 4;
            expertsTypeGV.ColumnCount = 3;

            expertsTypeGV.Columns[0].HeaderText = "Типи експертів";
            expertsTypeGV.Columns[1].HeaderText = "Абсолютний коефіцієнт вагомості";
            expertsTypeGV.Columns[2].HeaderText = "відносний коефіцієнт вагомості";

            for(int i = 0;i< expertsTypeGV.RowCount; i++)
            {
                expertsTypeGV.Rows[i].Cells[0].Value = exspertsType[i];
                expertsTypeGV.Rows[i].Cells[1].Value = expertsWeight[i];
                expertsTypeGV.Rows[i].Cells[2].Value = expertsWeight[i]*1.0/10;
            }

            complexIndicatorsGV.RowCount = 13;
            complexIndicatorsGV.ColumnCount = 8;

            complexIndicatorsGV.Columns[0].HeaderText = "№";
            complexIndicatorsGV.Columns[1].HeaderText = "Критерії оцінювання якості ПЗ";
            complexIndicatorsGV.Columns[2].HeaderText = "Оцінки експертів галузі";
            complexIndicatorsGV.Columns[3].HeaderText = "оцінки експертів зручності";
            complexIndicatorsGV.Columns[4].HeaderText = "Оцінки експертів програмування";
            complexIndicatorsGV.Columns[5].HeaderText = "Оцінки користувачів";
            complexIndicatorsGV.Columns[6].HeaderText = "Усереднені значення показника";
            complexIndicatorsGV.Columns[7].HeaderText = "Усереднені значення оцінок";


            for (int j = 0; j < complexIndicatorsGV.ColumnCount; j++)
            {
                if (j == 0 || j == 7 || j == 6)
                    continue;
                else if (j == 1)
                    complexIndicatorsGV.Rows[0].Cells[j].Value = "Коефіцієнти вагомості";
                else if (j >= 2 && j <= 5)
                    complexIndicatorsGV.Rows[0].Cells[j].Value = expertsWeight[j - 2]*1.0/10;
            }

           
            double averageWeight = 0;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 0; j < complexIndicatorsGV.ColumnCount; j++)
                {
                    if (j == 0)
                        complexIndicatorsGV.Rows[i].Cells[j].Value = i;
                    else if (j == 1)
                        complexIndicatorsGV.Rows[i].Cells[j].Value = Criteria[i - 1];
                    else if (j >= 2 && j <= 4)
                        complexIndicatorsGV.Rows[i].Cells[j].Value = Convert.ToDouble(weightCoefGV.Rows[i - 1].Cells[j].Value) * Convert.ToDouble(ExpertsMarksGV.Rows[i - 1].Cells[j - 1].Value);
                    else if(j == 5)
                        complexIndicatorsGV.Rows[i].Cells[j].Value = (Convert.ToDouble(weightCoefGV.Rows[i - 1].Cells[j].Value) * Convert.ToDouble(ExpertsMarksGV.Rows[i - 1].Cells[j - 1].Value)).ToString("0.00");

                    else if (j == 6)
                        complexIndicatorsGV.Rows[i].Cells[j].Value = (Math.Round(General(i)/ (Sum(expertsWeight)/10), 2)).ToString("0.00");
                    else if (j == 7)
                    {
                        averageWeight = Convert.ToDouble(weightCoefGV.Rows[i - 1].Cells[6].Value);
                        complexIndicatorsGV.Rows[i].Cells[j].Value = (Math.Round(General(i) / (((Sum(expertsWeight)/10) * averageWeight)),2)).ToString("0.00");
                    }
                }
            }

            for (int j = 0; j < complexIndicatorsGV.ColumnCount; j++)
            {
                
                if (j == 0)
                    continue;
                else if (j == 1)
                    complexIndicatorsGV.Rows[11].Cells[j].Value = "Усереднені оцінки";
                else if (j >= 2 && j <= 6)
                    complexIndicatorsGV.Rows[11].Cells[j].Value = General2(j);    
                else if (j == 7)
                    complexIndicatorsGV.Rows[11].Cells[j].Value = Math.Round(Sum(complexIndicatorsGV, 7)/10, 2);
            }

            for (int j = 0; j < complexIndicatorsGV.ColumnCount; j++)
            {
                if (j == 0)
                    continue;
                else if (j == 1)
                    complexIndicatorsGV.Rows[12].Cells[j].Value = "Оцінки з врахуванням вагомості експертів";
                else if (j >= 2 && j <= 5)
                    complexIndicatorsGV.Rows[12].Cells[j].Value = Math.Round(Convert.ToDouble(complexIndicatorsGV.Rows[11].Cells[j].Value) * Convert.ToDouble(complexIndicatorsGV.Rows[0].Cells[j].Value), 2);
                else if (j == 6)
                    complexIndicatorsGV.Rows[12].Cells[j].Value = Math.Round((Convert.ToDouble(complexIndicatorsGV.Rows[11].Cells[2].Value) + Convert.ToDouble(complexIndicatorsGV.Rows[11].Cells[3].Value) +
                        Convert.ToDouble(complexIndicatorsGV.Rows[11].Cells[4].Value) + Convert.ToDouble(complexIndicatorsGV.Rows[11].Cells[5].Value))/4, 2);
                else if (j == 7)
                    complexIndicatorsGV.Rows[12].Cells[j].Value = Math.Round((Convert.ToDouble(complexIndicatorsGV.Rows[12].Cells[2].Value) + Convert.ToDouble(complexIndicatorsGV.Rows[12].Cells[3].Value) +
                        Convert.ToDouble(complexIndicatorsGV.Rows[12].Cells[4].Value) + Convert.ToDouble(complexIndicatorsGV.Rows[12].Cells[5].Value)) / (Sum(expertsWeight) / 10), 2);
            }
            
            tabPage5_Click(null, new EventArgs());
        }

        public double General(int row)
        {
            double Sum = 0;
            for(int i = 2; i<6; i++)
            {
                Sum += Convert.ToDouble(complexIndicatorsGV.Rows[row].Cells[i].Value) * Convert.ToDouble(complexIndicatorsGV.Rows[0].Cells[i].Value);
            }
            return Sum;
        }

         public double Sum(DataGridView dg, int column)
        {
            double Sum = 0;
            for (int i = 0; i < dg.RowCount; i++)
            {
                Sum += Convert.ToDouble(dg.Rows[i].Cells[column].Value);
            }
            return Sum;
        }

        public double General2(int column)
        {
            double znam = 0, chus = 0;
            for (int i = 1; i < 11; i++)
            {
                znam += Convert.ToDouble(complexIndicatorsGV.Rows[i].Cells[column].Value);
                chus += Convert.ToDouble(weightCoefGV.Rows[i-1].Cells[column].Value);
            }
            return Math.Round(znam/chus, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<expertsWeight.Length; i++)
            {
                expertsWeight[i] = Convert.ToInt32(expertsTypeGV.Rows[i].Cells[1].Value);
            }
            tabPage4_Click(this, new EventArgs());
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            
            var coeff = expertsWeight[0] / 10.0;
            // chart5label
            polar1GV.ColumnCount = 4;
            polar1GV.RowCount = 10;

            polar1GV.Columns[0].HeaderText = "Критерії оцінювання";
            polar1GV.Columns[1].HeaderText = "Усереднені оцінки";
            polar1GV.Columns[2].HeaderText = "Зміна Кута";
            polar1GV.Columns[3].HeaderText = "Кут";

            double triangle = 0, value=0, sum = Sum(weightCoef[0]);
            // chart1.ChartAreas[0].AxisX.Minimum = 0;
            // chart1.ChartAreas[0].AxisX.Maximum = 180;
            // chart1.ChartAreas[0].AxisX.Interval = 90;
            chart1.ChartAreas[0].AxisX.Crossing = 90;
            chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.SharpTriangle;
            chart4.ChartAreas[0].AxisX.Crossing = 90;
            chart2.ChartAreas[0].AxisX.Crossing = 90;
            chart3.ChartAreas[0].AxisX.Crossing = 90;
            chart4.ChartAreas[0].AxisX.Crossing = 90;
            chart5.ChartAreas[0].AxisX.Crossing = 90;
            polarGV.ChartAreas[0].AxisX.Crossing = 90;
            
            var series2 = new Series("Series2");
            series2.ChartType = SeriesChartType.Polar;
            series2.BorderDashStyle = ChartDashStyle.Dash;
            series2.Color = Color.DimGray;
            if (chart1.Series.All(eee => eee.Name != "Series2"))
            {
                chart1.Series.Add(series2);
            }
            
            int c2 = 0;
            var points = new List<PointF>();
            var linesAreDrawn = false;
            chart1.Series["Series2"].Points.Clear();
            for (int i = 0; i<10; i++)
            {
                polar1GV.Rows[i].Cells[0].Value = Criteria[i];
                polar1GV.Rows[i].Cells[1].Value = complexIndicatorsGV.Rows[i+1].Cells[2].Value;
                value = Convert.ToDouble(complexIndicatorsGV.Rows[i+1].Cells[2].Value);
                polar1GV.Rows[i].Cells[2].Value =  Math.Round(360 * weightCoef[0][i] / sum, 2);               
                polar1GV.Rows[i].Cells[3].Value = triangle;
                polar1GVNumbers.Add((int)triangle);
                
                var counter = 0;
                var point2 = new PointF((float)triangle + 90, (float)value / (float)coeff);
                var point4 = new PointF((float)triangle + 90, (float)value);
                double lineTension = 0;
                chart1.PostPaint += (o, ee) =>
                {
                    if (counter == 0)
                    {
                        ee.ChartGraphics.Graphics.FillRectangle( Brushes.Transparent, new Rectangle(new Point(0, 0), new Size(1000, 1000)));
                    }
                    if (counter++ % 2 == 0)
                    {
                        return;
                    }
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    Pen pen = new Pen(Color.Red, 1);
                    pen.CustomEndCap = bigArrow;
                    var blackPen = new Pen(Color.Black, 1);
                    var polarPoint = PolarToCartesian(point2);
                    var polarPoint2 = PolarToCartesian(point4);
                    var point3 = new PointF(polarPoint.X + ee.Position.X + chart1.Width / 2, polarPoint.Y + ee.Position.Y + chart1.Height / 2);
                    var point5 = new PointF(polarPoint2.X + ee.Position.X + chart1.Width / 2, polarPoint2.Y + ee.Position.Y + chart1.Height / 2);
                    var curPoint = new PointF(ee.Position.X + chart1.Width / 2, ee.Position.Y + chart1.Height / 2);
                    points.Add(point5);
                    
                    ee.ChartGraphics.Graphics.DrawLine(pen, curPoint, point3);

                    if (!linesAreDrawn)
                    {
                        foreach (var polar1GvPoint in polar1GVNumbers)
                        {
                            if (polar1GvPoint == 0)
                            {
                                continue;
                            }
                            
                            var mPoint = 360 - polar1GvPoint;
                            var polar = PolarToCartesian(new PointF(mPoint + 90, 140));
                            var point6 = new PointF(polar.X + ee.Position.X + chart1.Width / 2, polar.Y + ee.Position.Y + chart1.Height / 2);
                            Console.WriteLine("point6 " + point6);
                            ee.ChartGraphics.Graphics.DrawLine(blackPen, curPoint, point6);
                            var font = new Font("Times New Roman", 12.25f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                            // ee.ChartGraphics.Graphics.DrawString((360 - mPoint).ToString(), font, Brushes.Black,point6);
                        }

                        linesAreDrawn = true;
                    }
                    
                    // polarGV.PostPaint += (sender2, polarGvArg) =>
                    // {
                    //     var polarMiddlePoint = new PointF(polarGvArg.Position.X + polarGV.Width / 2,
                    //         polarGvArg.Position.Y + polarGV.Height / 2);
                    //     polarGvArg.ChartGraphics.Graphics.DrawLine(pen, polarMiddlePoint, point3);
                    // };
                    
                    if (c2++ == 9)
                    {
                        ee.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (var path = new GraphicsPath())
                        {
                            var f = points.ToArray().Distinct().ToArray();
                            
                            path.StartFigure();
                            path.AddPolygon(points.ToArray().Distinct().ToArray());
                            path.CloseFigure();
                            path.FillMode = FillMode.Alternate;
                            using (var brush = new SolidBrush(Color.FromArgb(50, 255, 255, 0)))
                                ee.ChartGraphics.Graphics.FillPath(brush, path);
                        }
                    }
                };
                
                // chart1.Series.Add(arrowSeries);
                chart1.Series["Series1"].Points.AddXY(triangle, value);
                polar1GVPoints.Add(PolarToCartesian(new PointF((float)triangle, (float)value)));
                chart1.Series["Series2"].Points.AddXY(triangle, value / coeff);
                triangle += Math.Round(360 * weightCoef[0][i] / sum, 2);
            }
            value = Convert.ToDouble(complexIndicatorsGV.Rows [1].Cells[2].Value);
            chart1.Series["Series1"].Points.AddXY(360, value);
            chart1.Series["Series2"].Points.AddXY(360, value / coeff);
            
            var labels = new[] { chart1 };

            polar1GVNumbers.Add(0);
            var isFirst = true;
            var isIFixed = false;
            int lastIndex = polar1GVNumbers.Count - 1;
            
            foreach (var label in labels)
            {
                label.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                var prev = 0;
                for (int i = 359; i >= 0; i--)
                {
                    if (i == 359)
                    {
                        i = 0;
                    }
                    label.ChartAreas[0].AxisX.Interval = 1;
                    if (polar1GVNumbers.Contains(i))
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
                        var labelText = isFirst ? "" : polar1GVNumbers[lastIndex - 1 < 0 ? 0 : lastIndex--] + "\u00b0";
                        // labelText = "";
                        if (isFirst)
                        {
                            lastIndex--; 
                        }
                        isFirst = false;
                        var cus = new CustomLabel(i - 10, i + 10, labelText, lastIndex, LabelMarkStyle.Box);
                        cus.MarkColor = Color.Blue;
                        cus.LabelMark = LabelMarkStyle.None;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(cus);
                        cus.Axis.LineColor = Color.Blue;
                        if (i == 0 && !isIFixed)
                        {
                            i = 359;
                            isIFixed = true;
                        }
                    }
                    else
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineWidth = 0;
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i - 10, i + 10, "", lastIndex, LabelMarkStyle.Box));
                        // if (label.ChartAreas[0].AxisX.StripLines.Count > 0)
                        // {
                        //     label.ChartAreas[0].AxisX.StripLines[3].BorderColor = Color.Red;
                        // }
                    }
                }
            }
            
            
            // foreach (var label in labels)
            // {
            //     
            //     var prev = 0;
            //     for (int i = 359; i >= 0; i--)
            //     {
            //         if (polar1GVNumbers.Contains(i))
            //         {
            //             
            //             label.ChartAreas[0].AxisX.Interval = 360 - i - prev - 4;
            //             prev = 360 - i;
            //             var labelText = isFirst ? "" : polar1GVNumbers[lastIndex - 1 < 0 ? 0 : lastIndex--] + "\u00b0";
            //             if (isFirst)
            //             {
            //                 lastIndex--; 
            //             }
            //             isFirst = false;
            //             label.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i, labelText, 1, LabelMarkStyle.Box));
            //         }
            //     }
            // }

            double GetArea()
            {
                double summ = 0;
                for (int i = 0; i < polar1GVPoints.Count - 1; i++)
                {
                    var cur = polar1GVPoints[i].X * polar1GVPoints[i + 1].Y - polar1GVPoints[i].Y * polar1GVPoints[i + 1].X;
                    var cur2 = Math.Abs(cur);
                    summ += cur2;
                }

                return summ / 4;
            } 
            
            var text = new TextBox();
            text.Text = $"{Math.Round(GetArea(), 2)} ум.од.";
            text.Left = chart1.Width / 2 - 30;
            text.Top = chart1.Height / 2 - 10;
            chart1.Controls.Add(text);
            
            var text2ZZZ = new TextBox();
            text2ZZZ.Text = $"Z = {Math.Round(GetArea() / (Math.PI * 10000), 2)}";
            text2ZZZ.Left = (chart1.Width / 2 - 30 + 30);
            text2ZZZ.Top = chart1.Height / 2 - 10 + 100;

            if (hvTextBox is null)
            {
                hvTextBox = new TextBox();
                hvTextBox.Text = $"Hв = {expertsWeight[0] / 10.0}";
                hvTextBox.Left = chart1.Width / 2 - 30 -70;
                hvTextBox.Top = chart1.Height / 2 - 10 + 60;
            }
            else
            {
                hvTextBox.Text = $"Hв = {expertsWeight[0] / 10.0}";
            }
            
            var constText = new TextBox();
            constText.Text = "Sкр = 31415,93";
            constText.Left = chart1.Width / 2 - 30 - 50;
            constText.Top = chart1.Height / 2 - 10 -50;
            
            chart1.Controls.Add(text);
            chart1.Controls.Add(constText);
            chart1.Controls.Add(hvTextBox);
            chart1.Controls.Add(text2ZZZ);
        }

        private TextBox hvTextBox;
        
        private void tabPage6_Click(object sender, EventArgs e)
        {
            polar2GV.ColumnCount = 4;
            polar2GV.RowCount = 10;

            polar2GV.Columns[0].HeaderText = "Критерії оцінювання";
            polar2GV.Columns[1].HeaderText = "Усереднені оцінки";
            polar2GV.Columns[2].HeaderText = "Зміна Кута";
            polar2GV.Columns[3].HeaderText = "Кут";

            double triangle = 0, value = 0, sum = Sum(weightCoef[1]);
            chart2.Series["Series1"].Points.Clear();
            
            var series2 = new Series("Series2");
            series2.ChartType = SeriesChartType.Polar;
            series2.BorderDashStyle = ChartDashStyle.Dash;
            series2.Color = Color.DimGray;
            chart2.Series.Add(series2);
            int c2 = 0;
            var points = new List<PointF>();
            var linesAreDrawn = false;
            for (int i = 0; i<10; i++)
            {
                polar2GV.Rows[i].Cells[0].Value = Criteria[i];
                polar2GV.Rows[i].Cells[1].Value = complexIndicatorsGV.Rows[i + 1].Cells[3].Value;
                value = Convert.ToDouble(complexIndicatorsGV.Rows[i + 1].Cells[3].Value);
                polar2GV.Rows[i].Cells[2].Value = Math.Round(360 * weightCoef[1][i] / sum, 2);
                polar2GV.Rows[i].Cells[3].Value = triangle;
                polar2GVNumbers.Add((int)triangle);
                var arrowSeries = new Series();
                arrowSeries.Color = Color.Red;
                // arrowSeries.Points.AddXY(0, 0);
                arrowSeries.ChartType = SeriesChartType.Polar;
                // arrowSeries.Points.AddXY(triangle, value / 0.7);
                
                
                var counter = 0;
                var point2 = new PointF((float)triangle + 90, (float)value / 0.55f);
                var point4 = new PointF((float)triangle + 90, (float)value / 0.7F);
                double lineTension = 0;
                chart2.PostPaint += (o, ee) =>
                {
                    if (counter++ % 2 == 0)
                    {
                        return;
                    }
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    Pen pen = new Pen(Color.Red, 1);
                    pen.CustomEndCap = bigArrow;
                    var polarPoint = PolarToCartesian(point2);
                    var polarPoint2 = PolarToCartesian(point4);
                    var point3 = new PointF(polarPoint.X + ee.Position.X + chart2.Width / 2, polarPoint.Y + ee.Position.Y + chart2.Height / 2);
                    var point5 = new PointF(polarPoint2.X + ee.Position.X + chart2.Width / 2, polarPoint2.Y + ee.Position.Y + chart2.Height / 2);
                    var curPoint = new PointF(ee.Position.X + chart2.Width / 2, ee.Position.Y + chart2.Height / 2);
                    points.Add(point5);
                    ee.ChartGraphics.Graphics.DrawLine(pen, curPoint, point3);
                    
                    if (!linesAreDrawn)
                    {
                        foreach (var polar1GvPoint in polar2GVNumbers)
                        {
                            if (polar1GvPoint == 0)
                            {
                                continue;
                            }
                            
                            var mPoint = 360 - polar1GvPoint;
                            var polar = PolarToCartesian(new PointF(mPoint + 90, 140));
                            var point6 = new PointF(polar.X + ee.Position.X + chart2.Width / 2, polar.Y + ee.Position.Y + chart2.Height / 2);
                            Console.WriteLine("point6 " + point6);
                            ee.ChartGraphics.Graphics.DrawLine(new Pen(Color.Black, 1), curPoint, point6);
                            var font = new Font("Times New Roman", 12.25f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                            // ee.ChartGraphics.Graphics.DrawString((360 - mPoint).ToString(), font, Brushes.Black,point6);
                        }

                        linesAreDrawn = true;
                    }
                    
                    if (c2++ == 9)
                    {
                        ee.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (var path = new GraphicsPath())
                        {
                            var f = points.ToArray().Distinct().ToArray();
                            
                            path.StartFigure();
                            path.AddPolygon(points.ToArray().Distinct().ToArray());
                            path.CloseFigure();
                            path.FillMode = FillMode.Alternate;
                            using (var brush = new SolidBrush(Color.FromArgb(50, 255, 255, 0)))
                                ee.ChartGraphics.Graphics.FillPath(brush, path);
                        }
                    }
                };
                
                chart2.Series.Add(arrowSeries);
                chart2.Series["Series1"].Points.AddXY(triangle, value);
                polar2GVPoints.Add(PolarToCartesian(new PointF((float)triangle, (float)value)));
                chart2.Series["Series2"].Points.AddXY(triangle, value / 0.8);
                triangle += Math.Round(360 * weightCoef[1][i] / sum, 2);
            }
            value = Convert.ToDouble(complexIndicatorsGV.Rows[1].Cells[3].Value);
            chart2.Series["Series1"].Points.AddXY(360, value);
            chart2.Series["Series1"].Points.AddXY(360, value / 0.8);
            
            
            
            var labels = new[] { chart2 };

            polar2GVNumbers.Add(0);
            var isFirst = true;
            var isIFixed = false;
            int lastIndex = polar2GVNumbers.Count - 1;
            foreach (var label in labels)
            {
                var prev = 0;
                for (int i = 359; i >= 0; i--)
                {
                    if (i == 359)
                    {
                        i = 0;
                    }
                    label.ChartAreas[0].AxisX.Interval = 1;
                    if (polar2GVNumbers.Contains(i))
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
                        var labelText = isFirst ? "" : polar2GVNumbers[lastIndex - 1 < 0 ? 0 : lastIndex--] + "\u00b0";
                        // labelText = "";
                        if (isFirst)
                        {
                            lastIndex--; 
                        }
                        isFirst = false;
                        var cus = new CustomLabel(i - 10, i + 10, labelText, lastIndex, LabelMarkStyle.Box);
                        cus.MarkColor = Color.Blue;
                        cus.LabelMark = LabelMarkStyle.None;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(cus);
                        cus.Axis.LineColor = Color.Blue;
                        if (i == 0 && !isIFixed)
                        {
                            i = 359;
                            isIFixed = true;
                        }
                    }
                    else
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineWidth = 0;
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i - 10, i + 10, "", lastIndex, LabelMarkStyle.Box));
                        // if (label.ChartAreas[0].AxisX.StripLines.Count > 0)
                        // {
                        //     label.ChartAreas[0].AxisX.StripLines[3].BorderColor = Color.Red;
                        // }
                    }
                }
            }

            double GetArea()
            {
                double summ = 0;
                for (int i = 0; i < polar2GVPoints.Count - 1; i++)
                {
                    var cur = polar2GVPoints[i].X * polar2GVPoints[i + 1].Y - polar2GVPoints[i].Y * polar2GVPoints[i + 1].X;
                    var cur2 = Math.Abs(cur);
                    summ += cur2;
                }

                return summ / 4;
            } 
            
            var text = new TextBox();
            text.Text = $"{Math.Round(GetArea(), 2)} ум.од.";
            text.Left = chart2.Width / 2 - 30;
            text.Top = chart2.Height / 2 - 10;
            chart1.Controls.Add(text);
            
            var text2ZZZ = new TextBox();
            text2ZZZ.Text = $"Z = {Math.Round(GetArea() / (Math.PI * 10000), 2)}";
            text2ZZZ.Left = chart2.Width / 2 - 30 + 30;
            text2ZZZ.Top = chart2.Height / 2 - 10 + 100;
            
            var Hv = new TextBox();
            Hv.Text = "Hв = 0.8";
            Hv.Left = chart2.Width / 2 - 30 -70;
            Hv.Top = chart2.Height / 2 - 10 + 60;
            
            var constText = new TextBox();
            constText.Text = "Sкр = 31415,93";
            constText.Left = chart2.Width / 2 - 30 - 50;
            constText.Top = chart2.Height / 2 - 10 -50;
            
            chart2.Controls.Add(text);
            chart2.Controls.Add(constText);
            chart2.Controls.Add(Hv);
            chart2.Controls.Add(text2ZZZ);
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
            var label = chart3;
            var labelPoints = polar3GVPoints;
            var labelNumbers = polar3GVNumbers;
            polar3GV.ColumnCount = 4;
            polar3GV.RowCount = 10;

            polar3GV.Columns[0].HeaderText = "Критерії оцінювання";
            polar3GV.Columns[1].HeaderText = "Усереднені оцінки";
            polar3GV.Columns[2].HeaderText = "Зміна Кута";
            polar3GV.Columns[3].HeaderText = "Кут";
            double triangle = 0, value=0, sum = Sum(weightCoef[2]);
            
            var series2 = new Series("Series2");
            series2.ChartType = SeriesChartType.Polar;
            series2.BorderDashStyle = ChartDashStyle.Dash;
            series2.Color = Color.DimGray;
            label.Series.Add(series2);
            int c2 = 0;
            var points = new List<PointF>();
            label.Series["Series1"].Points.Clear();
            var isIFixed = false;
            var linesAreDrawn = false;
            for (int i = 0; i<10; i++)
            {
                
                polar3GV.Rows[i].Cells[0].Value = Criteria[i];
                polar3GV.Rows[i].Cells[1].Value = complexIndicatorsGV.Rows[i + 1].Cells[4].Value;
                value = Convert.ToDouble(complexIndicatorsGV.Rows[i + 1].Cells[4].Value);
                polar3GV.Rows[i].Cells[2].Value = Math.Round(360 * weightCoef[2][i] / sum, 2);
                polar3GV.Rows[i].Cells[3].Value = triangle;
                labelNumbers.Add((int)triangle);
                var arrowSeries = new Series();
                arrowSeries.Color = Color.Red;
                // arrowSeries.Points.AddXY(0, 0);
                arrowSeries.ChartType = SeriesChartType.Polar;
                // arrowSeries.Points.AddXY(triangle, value / 0.7);
                
                
                var counter = 0;
                var point2 = new PointF((float)triangle + 90, (float)value / 0.75f);
                var point4 = new PointF((float)triangle + 90, (float)value / 0.8f);
                double lineTension = 0;
                label.PostPaint += (o, ee) =>
                {
                    
                    if (counter++ % 2 == 0)
                    {
                        return;
                    }
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    Pen pen = new Pen(Color.Red, 1);
                    pen.CustomEndCap = bigArrow;
                    var polarPoint = PolarToCartesian(point2);
                    var polarPoint2 = PolarToCartesian(point4);
                    var point3 = new PointF(polarPoint.X + ee.Position.X + label.Width / 2, polarPoint.Y + ee.Position.Y + label.Height / 2);
                    var point5 = new PointF(polarPoint2.X + ee.Position.X + label.Width / 2, polarPoint2.Y + ee.Position.Y + label.Height / 2);
                    var curPoint = new PointF(ee.Position.X + label.Width / 2, ee.Position.Y + label.Height / 2);
                    points.Add(point5);
                    ee.ChartGraphics.Graphics.DrawLine(pen, curPoint, point3);
                    
                    if (!linesAreDrawn)
                    {
                        foreach (var polar1GvPoint in polar3GVNumbers)
                        {
                            if (polar1GvPoint == 0)
                            {
                                continue;
                            }
                            
                            var mPoint = 360 - polar1GvPoint;
                            var polar = PolarToCartesian(new PointF(mPoint + 90, 140));
                            var point6 = new PointF(polar.X + ee.Position.X + chart1.Width / 2, polar.Y + ee.Position.Y + chart1.Height / 2);
                            Console.WriteLine("point6 " + point6);
                            ee.ChartGraphics.Graphics.DrawLine(new Pen(Brushes.Black, 1), curPoint, point6);
                            var font = new Font("Times New Roman", 12.25f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                            // ee.ChartGraphics.Graphics.DrawString((360 - mPoint).ToString(), font, Brushes.Black,point6);
                        }

                        linesAreDrawn = true;
                    }
                    
                    if (c2++ == 9)
                    {
                        ee.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (var path = new GraphicsPath())
                        {
                            var f = points.ToArray().Distinct().ToArray();
                            
                            path.StartFigure();
                            path.AddPolygon(points.ToArray().Distinct().ToArray());
                            path.CloseFigure();
                            path.FillMode = FillMode.Alternate;
                            using (var brush = new SolidBrush(Color.FromArgb(50, 255, 255, 0)))
                                ee.ChartGraphics.Graphics.FillPath(brush, path);
                        }
                    }
                };
                
                label.Series.Add(arrowSeries);
                label.Series["Series1"].Points.AddXY(triangle, value);
                labelPoints.Add(PolarToCartesian(new PointF((float)triangle, (float)value)));
                label.Series["Series2"].Points.AddXY(triangle, value / 0.9);
                triangle += Math.Round(360 * weightCoef[2][i] / sum, 2);
            }
            value = Convert.ToDouble(complexIndicatorsGV.Rows [1].Cells[4].Value);
            label.Series["Series1"].Points.AddXY(360, value);
            label.Series["Series2"].Points.AddXY(360, value / 0.9);
            
            labelNumbers.Add(0);
            var isFirst = true;
            int lastIndex = labelNumbers.Count - 1;
            
            {
                
                var prev = 0;
                for (int i = 359; i >= 0; i--)
                {
                    if (i == 359)
                    {
                        i = 0;
                    }
                    label.ChartAreas[0].AxisX.Interval = 1;
                    if (polar3GVNumbers.Contains(i))
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
                        var labelText = isFirst ? "" : polar3GVNumbers[lastIndex - 1 < 0 ? 0 : lastIndex--] + "\u00b0";
                        // labelText = "";
                        if (isFirst)
                        {
                            lastIndex--; 
                        }
                        isFirst = false;
                        var cus = new CustomLabel(i - 10, i + 10, labelText, lastIndex, LabelMarkStyle.Box);
                        cus.MarkColor = Color.Blue;
                        cus.LabelMark = LabelMarkStyle.None;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(cus);
                        cus.Axis.LineColor = Color.Blue;
                        if (i == 0 && !isIFixed)
                        {
                            i = 359;
                            isIFixed = true;
                        }
                    }
                    else
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineWidth = 0;
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i - 10, i + 10, "", lastIndex, LabelMarkStyle.Box));
                        // if (label.ChartAreas[0].AxisX.StripLines.Count > 0)
                        // {
                        //     label.ChartAreas[0].AxisX.StripLines[3].BorderColor = Color.Red;
                        // }
                    }
                }
            }

            double GetArea()
            {
                double summ = 0;
                for (int i = 0; i < labelPoints.Count - 1; i++)
                {
                    var cur = labelPoints[i].X * labelPoints[i + 1].Y - labelPoints[i].Y * labelPoints[i + 1].X;
                    var cur2 = Math.Abs(cur);
                    summ += cur2;
                }

                return summ / 4;
            } 
            
            var text = new TextBox();
            text.Text = $"{Math.Round(GetArea(), 2)} ум.од.";
            text.Left = label.Width / 2 - 30;
            text.Top = label.Height / 2 - 10;
            
            var text2ZZZ = new TextBox();
            text2ZZZ.Text = $"Z = {Math.Round(GetArea() / (Math.PI * 10000), 2)}";
            text2ZZZ.Left = label.Width / 2 - 30 + 30;
            text2ZZZ.Top = label.Height / 2 - 10 + 100;
            
            var Hv = new TextBox();
            Hv.Text = "Hв = 0.9";
            Hv.Left = label.Width / 2 - 30 -70;
            Hv.Top = label.Height / 2 - 10 + 60;
            
            var constText = new TextBox();
            constText.Text = "Sкр = 31415,93";
            constText.Left = label.Width / 2 - 30 - 50;
            constText.Top = label.Height / 2 - 10 -50;
            
            label.Controls.Add(text);
            label.Controls.Add(constText);
            label.Controls.Add(Hv);
            label.Controls.Add(text2ZZZ);
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            var label = chart4;
            var labelPoints = polar4GVPoints;
            var labelNumbers = polar4GVNumbers;
            polar4GV.ColumnCount = 4;
            polar4GV.RowCount = 10;

            polar4GV.Columns[0].HeaderText = "Критерії оцінювання";
            polar4GV.Columns[1].HeaderText = "Усереднені оцінки";
            polar4GV.Columns[2].HeaderText = "Зміна Кута";
            polar4GV.Columns[3].HeaderText = "Кут";
            double triangle = 0, value = 0, sum = Sum(weightCoef[3]);
            
            var series2 = new Series("Series2");
            series2.ChartType = SeriesChartType.Polar;
            series2.BorderDashStyle = ChartDashStyle.Dash;
            series2.Color = Color.DimGray;
            label.Series.Add(series2);
            int c2 = 0;
            var points = new List<PointF>();
            var linesAreDrawn = false;
            var isIFixed = false;
            
            for (int i = 0; i<10; i++)
            {
                
                polar4GV.Rows[i].Cells[0].Value = Criteria[i];
                polar4GV.Rows[i].Cells[1].Value = complexIndicatorsGV.Rows[i + 1].Cells[5].Value;
                value = Convert.ToDouble(complexIndicatorsGV.Rows[i + 1].Cells[5].Value);
                polar4GV.Rows[i].Cells[2].Value = Math.Round(360 * weightCoef[3][i] / sum, 2);
                polar4GV.Rows[i].Cells[3].Value = triangle;
                labelNumbers.Add((int)triangle);
                var arrowSeries = new Series();
                arrowSeries.Color = Color.Red;
                // arrowSeries.Points.AddXY(0, 0);
                arrowSeries.ChartType = SeriesChartType.Polar;
                // arrowSeries.Points.AddXY(triangle, value / 0.7);
                
                
                var counter = 0;
                var point2 = new PointF((float)triangle + 90, (float)value / 0.71f);
                var point4 = new PointF((float)triangle + 90, (float)value / 1.5f);
                double lineTension = 0;
                label.PostPaint += (o, ee) =>
                {
                    if (counter++ % 2 == 0)
                    {
                        return;
                    }
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    Pen pen = new Pen(Color.Red, 1);
                    pen.CustomEndCap = bigArrow;
                    var polarPoint = PolarToCartesian(point2);
                    var polarPoint2 = PolarToCartesian(point4);
                    var point3 = new PointF(polarPoint.X + ee.Position.X + label.Width / 2, polarPoint.Y + ee.Position.Y + label.Height / 2);
                    var point5 = new PointF(polarPoint2.X + ee.Position.X + label.Width / 2, polarPoint2.Y + ee.Position.Y + label.Height / 2);
                    var curPoint = new PointF(ee.Position.X + label.Width / 2, ee.Position.Y + label.Height / 2);
                    points.Add(point5);
                    ee.ChartGraphics.Graphics.DrawLine(pen, curPoint, point3);
                   
                    if (!linesAreDrawn)
                    {
                        foreach (var polar1GvPoint in polar4GVNumbers)
                        {
                            if (polar1GvPoint == 0)
                            {
                                continue;
                            }
                            
                            var mPoint = 360 - polar1GvPoint;
                            var polar = PolarToCartesian(new PointF(mPoint + 90, 140));
                            var point6 = new PointF(polar.X + ee.Position.X + chart1.Width / 2, polar.Y + ee.Position.Y + chart1.Height / 2);
                            Console.WriteLine("point6 " + point6);
                            ee.ChartGraphics.Graphics.DrawLine(new Pen(Brushes.Black, 1), curPoint, point6);
                            var font = new Font("Times New Roman", 12.25f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                            // ee.ChartGraphics.Graphics.DrawString((360 - mPoint).ToString(), font, Brushes.Black,point6);
                        }

                        linesAreDrawn = true;
                    }
                    
                    if (c2++ == 9)
                    {
                        ee.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (var path = new GraphicsPath())
                        {
                            var f = points.ToArray().Distinct().ToArray();
                            
                            
                            path.StartFigure();
                            path.AddPolygon(points.ToArray().Distinct().ToArray());
                            path.CloseFigure();
                            path.FillMode = FillMode.Alternate;
                            using (var brush = new SolidBrush(Color.FromArgb(50, 255, 255, 0)))
                                ee.ChartGraphics.Graphics.FillPath(brush, path);
                        }
                    }
                };
                
                label.Series.Add(arrowSeries);
                label.Series["Series1"].Points.AddXY(triangle, value);
                labelPoints.Add(PolarToCartesian(new PointF((float)triangle, (float)value)));
                label.Series["Series2"].Points.AddXY(triangle, value / 0.5);
                triangle += Math.Round(360 * weightCoef[3][i] / sum, 2);
            }
            value = Convert.ToDouble(complexIndicatorsGV.Rows [1].Cells[5].Value);
            label.Series["Series1"].Points.AddXY(360, value);
            label.Series["Series2"].Points.AddXY(360, value / 0.5);
            labelNumbers.Add(0);
            var isFirst = true;
            int lastIndex = labelNumbers.Count - 1;
            
            {
                var prev = 0;
                for (int i = 359; i >= 0; i--)
                {
                    if (i == 359)
                    {
                        i = 0;
                    }
                    label.ChartAreas[0].AxisX.Interval = 1;
                    if (polar4GVNumbers.Contains(i))
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
                        var labelText = isFirst ? "" : polar4GVNumbers[lastIndex - 1 < 0 ? 0 : lastIndex--] + "\u00b0";
                        // labelText = "";
                        if (isFirst)
                        {
                            lastIndex--; 
                        }
                        isFirst = false;
                        var cus = new CustomLabel(i - 10, i + 10, labelText, lastIndex, LabelMarkStyle.Box);
                        cus.MarkColor = Color.Blue;
                        cus.LabelMark = LabelMarkStyle.None;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(cus);
                        cus.Axis.LineColor = Color.Blue;
                        if (i == 0 && !isIFixed)
                        {
                            i = 359;
                            isIFixed = true;
                        }
                    }
                    else
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineWidth = 0;
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i - 10, i + 10, "", lastIndex, LabelMarkStyle.Box));
                        // if (label.ChartAreas[0].AxisX.StripLines.Count > 0)
                        // {
                        //     label.ChartAreas[0].AxisX.StripLines[3].BorderColor = Color.Red;
                        // }
                    }
                }
            }

            double GetArea()
            {
                double summ = 0;
                for (int i = 0; i < labelPoints.Count - 1; i++)
                {
                    var cur = labelPoints[i].X * labelPoints[i + 1].Y - labelPoints[i].Y * labelPoints[i + 1].X;
                    var cur2 = Math.Abs(cur);
                    summ += cur2;
                }

                return summ / 4;
            } 
            
            var text = new TextBox();
            text.Text = $"{Math.Round(GetArea(), 2)} ум.од.";
            text.Left = label.Width / 2 - 30;
            text.Top = label.Height / 2 - 10;
            
            var text2ZZZ = new TextBox();
            text2ZZZ.Text = $"Z = {Math.Round(GetArea() / (Math.PI * 10000), 2)}";
            text2ZZZ.Left = label.Width / 2 - 30 + 30;
            text2ZZZ.Top = label.Height / 2 - 10 + 100;
            
            var Hv = new TextBox();
            Hv.Text = "Hв = 0.5";
            Hv.Left = label.Width / 2 - 30 -70;
            Hv.Top = label.Height / 2 - 10 + 60;
            
            var constText = new TextBox();
            constText.Text = "Sкр = 31415,93";
            constText.Left = label.Width / 2 - 30 - 50;
            constText.Top = label.Height / 2 - 10 -50;
            
            label.Controls.Add(text);
            label.Controls.Add(constText);
            label.Controls.Add(Hv);
            label.Controls.Add(text2ZZZ);
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {
            var label = chart5;
            var labelPoints = polar5GVPoints;
            var labelNumbers = polar5GVNumbers;
            polar5GV.ColumnCount = 4;
            polar5GV.RowCount = 10;

            polar5GV.Columns[0].HeaderText = "Критерії оцінювання";
            polar5GV.Columns[1].HeaderText = "Усереднені оцінки";
            polar5GV.Columns[2].HeaderText = "Кут";
            double triangle = 0, value = 0, sum = Sum(weightCoefGV, 6);
            
            var series2 = new Series("Series2");
            series2.ChartType = SeriesChartType.Polar;
            series2.BorderDashStyle = ChartDashStyle.Dash;
            series2.Color = Color.DimGray;
            label.Series.Add(series2);
            int c2 = 0;
            var points = new List<PointF>();
            label.Series["Series1"].Points.Clear();
            var linesAreDrawn = false;
            var isIFixed = false;
            for (int i = 0; i<10; i++)
            {
                polar5GV.Rows[i].Cells[0].Value = Criteria[i];
                polar5GV.Rows[i].Cells[1].Value = complexIndicatorsGV.Rows[i + 1].Cells[6].Value;
                value = Convert.ToDouble(complexIndicatorsGV.Rows[i + 1].Cells[6].Value);
                polar5GV.Rows[i].Cells[2].Value = Math.Round(360 * Convert.ToDouble(weightCoefGV.Rows[i].Cells[6].Value) / sum, 2);
                polar5GV.Rows[i].Cells[3].Value = triangle;
                labelNumbers.Add((int)triangle);
                var arrowSeries = new Series();
                arrowSeries.Color = Color.Red;
                // arrowSeries.Points.AddXY(0, 0);
                arrowSeries.ChartType = SeriesChartType.Polar;
                // arrowSeries.Points.AddXY(triangle, value / 0.7);
                
                var counter = 0;
                var point2 = new PointF((float)triangle + 90, (float)value / 0.57f);
                var point4 = new PointF((float)triangle + 90, (float)value / 0.57f);
                double lineTension = 0;
                label.PostPaint += (o, ee) =>
                {
                    if (counter++ % 2 == 0)
                    {
                        return;
                    }
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    Pen pen = new Pen(Color.Red, 1);
                    pen.CustomEndCap = bigArrow;
                    var polarPoint = PolarToCartesian(point2);
                    var polarPoint2 = PolarToCartesian(point4);
                    var point3 = new PointF(polarPoint.X + ee.Position.X + label.Width / 2, polarPoint.Y + ee.Position.Y + label.Height / 2);
                    var point5 = new PointF(polarPoint2.X + ee.Position.X + label.Width / 2, polarPoint2.Y + ee.Position.Y + label.Height / 2);
                    var curPoint = new PointF(ee.Position.X + label.Width / 2, ee.Position.Y + label.Height / 2);
                    points.Add(point5);
                    ee.ChartGraphics.Graphics.DrawLine(pen, curPoint, point3);
                   
                    if (!linesAreDrawn)
                    {
                        foreach (var polar1GvPoint in polar5GVNumbers)
                        {
                            if (polar1GvPoint == 0)
                            {
                                continue;
                            }
                            
                            var mPoint = 360 - polar1GvPoint;
                            var polar = PolarToCartesian(new PointF(mPoint + 90, 140));
                            var point6 = new PointF(polar.X + ee.Position.X + chart1.Width / 2, polar.Y + ee.Position.Y + chart1.Height / 2);
                            Console.WriteLine("point6 " + point6);
                            ee.ChartGraphics.Graphics.DrawLine(new Pen(Color.Black, 1), curPoint, point6);
                            var font = new Font("Times New Roman", 12.25f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                            // ee.ChartGraphics.Graphics.DrawString((360 - mPoint).ToString(), font, Brushes.Black,point6);
                        }

                        linesAreDrawn = true;
                    }
                    
                    if (c2++ == 9)
                    {
                        ee.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (var path = new GraphicsPath())
                        {
                            var f = points.ToArray().Distinct().ToArray();
                            
                            
                            path.StartFigure();
                            path.AddPolygon(points.ToArray().Distinct().ToArray());
                            path.CloseFigure();
                            path.FillMode = FillMode.Alternate;
                            using (var brush = new SolidBrush(Color.FromArgb(50, 255, 255, 0)))
                                ee.ChartGraphics.Graphics.FillPath(brush, path);
                        }
                    }
                };
                
                label.Series.Add(arrowSeries);
                label.Series["Series1"].Points.AddXY(triangle, value);
                labelPoints.Add(PolarToCartesian(new PointF((float)triangle, (float)value)));
                // label.Series["Series2"].Points.AddXY(triangle, value / 0.9);
                triangle += Math.Round(360 * Convert.ToDouble(weightCoefGV.Rows[i].Cells[5].Value) / sum, 2);
            }
            value = Convert.ToDouble(complexIndicatorsGV.Rows [1].Cells[6].Value);
            label.Series["Series1"].Points.AddXY(360, value);
            // label.Series["Series2"].Points.AddXY(360, value);
            
            labelNumbers.Add(0);
            var isFirst = true;
            int lastIndex = labelNumbers.Count - 1;
            
            {
                
                var prev = 0;
                for (int i = 359; i >= 0; i--)
                {
                    if (i == 359)
                    {
                        i = 0;
                    }
                    label.ChartAreas[0].AxisX.Interval = 1;
                    if (polar5GVNumbers.Contains(i))
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
                        var labelText = isFirst ? "" : polar5GVNumbers[lastIndex - 1 < 0 ? 0 : lastIndex--] + "\u00b0";
                        // labelText = "";
                        if (isFirst)
                        {
                            lastIndex--; 
                        }
                        isFirst = false;
                        var cus = new CustomLabel(i - 10, i + 10, labelText, lastIndex, LabelMarkStyle.Box);
                        cus.MarkColor = Color.Blue;
                        cus.LabelMark = LabelMarkStyle.None;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(cus);
                        cus.Axis.LineColor = Color.Blue;
                        if (i == 0 && !isIFixed)
                        {
                            i = 359;
                            isIFixed = true;
                        }
                    }
                    else
                    {
                        label.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineColor = Color.Transparent;
                        // label.ChartAreas[0].AxisX.LineWidth = 0;
                        label.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        label.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i - 10, i + 10, "", lastIndex, LabelMarkStyle.Box));
                        // if (label.ChartAreas[0].AxisX.StripLines.Count > 0)
                        // {
                        //     label.ChartAreas[0].AxisX.StripLines[3].BorderColor = Color.Red;
                        // }
                    }
                }
            }

            double GetArea()
            {
                double summ = 0;
                for (int i = 0; i < labelPoints.Count - 1; i++)
                {
                    var cur = labelPoints[i].X * labelPoints[i + 1].Y - labelPoints[i].Y * labelPoints[i + 1].X;
                    var cur2 = Math.Abs(cur);
                    summ += cur2;
                }

                return summ / 4;
            } 
            
            var text = new TextBox();
            text.Text = $"{Math.Round(GetArea(), 2)} ум.од.";
            text.Left = label.Width / 2 - 30;
            text.Top = label.Height / 2 - 10;
            
            var text2ZZZ = new TextBox();
            text2ZZZ.Text = $"Z = {Math.Round(GetArea() / (Math.PI * 10000), 2)}";
            text2ZZZ.Left = label.Width / 2 - 30 + 30;
            text2ZZZ.Top = label.Height / 2 - 10 + 100;
            
            var constText = new TextBox();
            constText.Text = "Sкр = 31415,93";
            constText.Left = label.Width / 2 - 30 - 50;
            constText.Top = label.Height / 2 - 10 -50;
            
            label.Controls.Add(text);
            label.Controls.Add(constText);
            label.Controls.Add(text2ZZZ);
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {
            // common series
            polarGV.Series["Series1"].Points.Clear();
            polarGV.Series["Series2"].Points.Clear();
            polarGV.Series["Series3"].Points.Clear();
            polarGV.Series["Series4"].Points.Clear();

            polarGV.ChartAreas[0].AxisX.Interval = 360;
            var otherCharts = new[] { chart1, chart2, chart3, chart4 };

            for (int i = 0; i < 4; i++)
            {
                var series2 = new Series(i.ToString());
                series2.ChartType = SeriesChartType.Polar;
                series2.BorderDashStyle = ChartDashStyle.Dash;
                series2.Color = Color.DimGray;
                polarGV.Series.Add(series2);
            }
            
            double value = 0, triangle = 0;
            var counter = 0;
            
            for (var j = 0; j < otherCharts.Length; j++)
            {
                var chart = otherCharts[j];
                for (int i = 0; i < 10; i++)
                {
                    var point2 = new PointF((float)chart.Series["Series2"].Points[i].XValue + 90,
                        (float)chart.Series["Series2"].Points[i].YValues[0] / 0.875f);
                   
                    // Console.WriteLine(point2);
                    polarGV.Series[j.ToString()].Points.AddXY((float)chart.Series["Series2"].Points[i].XValue,(float)chart.Series["Series2"].Points[i].YValues[0]);
                    polarGV.PostPaint += (o, args) =>
                    {
                        if (counter++ >= 40)
                        {
                            return;
                        }
                        Console.WriteLine(point2);
                        AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                        Pen pen = new Pen(Color.Red, 1);
                        pen.CustomEndCap = bigArrow;
                        var polarPoint = PolarToCartesian(point2);
                        var curPoint = new PointF(args.Position.X - 70 + polarGV.Width / 2,
                            args.Position.Y - 10 + polarGV.Height / 2);
                        // var point3 = new PointF(polarPoint.X + ee.Position.X + chart1.Width / 2, polarPoint.Y + ee.Position.Y + chart1.Height / 2);
                        var point3 = new PointF(polarPoint.X + curPoint.X,
                            polarPoint.Y + curPoint.Y);
                        args.ChartGraphics.Graphics.DrawLine(pen, curPoint, point3);
                    };
                }
            }
            
            for(int i = 0; i<10; i++)
            {
                
                value = Convert.ToDouble(polar1GV.Rows[i].Cells[1].Value);
                triangle = Convert.ToDouble(polar1GV.Rows[i].Cells[3].Value);
                polarGV.Series["Series1"].Points.AddXY(triangle, value);
                
                value = Convert.ToDouble(polar2GV.Rows[i].Cells[1].Value);
                triangle = Convert.ToDouble(polar2GV.Rows[i].Cells[3].Value);
                polarGV.Series["Series2"].Points.AddXY(triangle, value);

                value = Convert.ToDouble(polar3GV.Rows[i].Cells[1].Value);
                triangle = Convert.ToDouble(polar3GV.Rows[i].Cells[3].Value);
                polarGV.Series["Series3"].Points.AddXY(triangle, value);

                value = Convert.ToDouble(polar4GV.Rows[i].Cells[1].Value);
                triangle = Convert.ToDouble(polar4GV.Rows[i].Cells[3].Value);
                polarGV.Series["Series4"].Points.AddXY(triangle, value);
            }
            value = Convert.ToDouble(polar1GV.Rows[0].Cells[1].Value);
            polarGV.Series["Series1"].Points.AddXY(360, value);
            value = Convert.ToDouble(polar2GV.Rows[0].Cells[1].Value);
            polarGV.Series["Series2"].Points.AddXY(360, value);
            value = Convert.ToDouble(polar3GV.Rows[0].Cells[1].Value);
            polarGV.Series["Series3"].Points.AddXY(360, value);
            value = Convert.ToDouble(polar4GV.Rows[0].Cells[1].Value);
            polarGV.Series["Series4"].Points.AddXY(360, value);
            for (var j = 0; j < otherCharts.Length; j++)
            {
                var chart = otherCharts[j];
                polarGV.Series[j.ToString()].Points.AddXY((float)chart.Series["Series2"].Points[0].XValue,(float)chart.Series["Series2"].Points[0].YValues[0]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        private void weightCoefGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void polar1GV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
