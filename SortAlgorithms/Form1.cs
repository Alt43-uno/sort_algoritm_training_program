using Algorithm;
using Algorithm.DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SortAlgorithms
{
    public partial class Form1 : Form
    {
        private List<SortedItem> items = new List<SortedItem>();
        private const int sleep = 10;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Программа знакомства с Алгоритмами";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(AddTextBox.Text, out int value))
            {
                var item = new SortedItem(value, items.Count);
                items.Add(item);
            }

            RefreshItems();

            AddTextBox.Text = "";
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(FillTextBox.Text, out int value))
            {
                var rnd = new Random();
                for (int i = 0; i < value; i++)
                {
                    var item = new SortedItem(rnd.Next(100), items.Count);
                    items.Add(item);
                }
            }

            RefreshItems();

            FillTextBox.Text = "";
        }

        private void DrawItems(List<SortedItem> items)
        {
            panel3.Controls.Clear();
            panel3.Refresh();

            foreach (var item in items)
            {
                panel3.Controls.Add(item.ProgressBar);
                panel3.Controls.Add(item.Label);
            }

            panel3.Refresh();
        }

        private void RefreshItems()
        {
            foreach(var item in items)
            {
                item.Refresh();
            }

            DrawItems(items);
        }

        private void AlgorithmSwopEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Aqua);
            e.Item2.SetColor(Color.Brown);
            panel3.Refresh();

            Thread.Sleep(sleep);

            var temp = e.Item1.Number;
            e.Item1.SetPosition(e.Item2.Number);
            e.Item2.SetPosition(temp);
            panel3.Refresh();

            Thread.Sleep(sleep);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            panel3.Refresh();

            Thread.Sleep(sleep);
        }

        private void AlgorithmCompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);
            panel3.Refresh();

            Thread.Sleep(sleep);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            panel3.Refresh();

            Thread.Sleep(sleep);
        }

        private void AlgorithmSetEvent(object sender, Tuple<int, SortedItem> e)
        {
            e.Item2.SetColor(Color.Red);
            panel3.Refresh();

            Thread.Sleep(sleep);

            e.Item2.SetPosition(e.Item1);
            panel3.Refresh();

            Thread.Sleep(sleep);

            e.Item2.SetColor(Color.Blue);
            panel3.Refresh();

            Thread.Sleep(sleep);
        }

        private void BtnClick(AlgorithmBase<SortedItem> algorithm)
        {
            RefreshItems();

            for (int i = 0; i < algorithm.Items.Count; i++)
            {
                algorithm.Items[i].SetPosition(i);
            }
            panel3.Refresh();

            algorithm.CompareEvent += AlgorithmCompareEvent;
            algorithm.SwopEvent += AlgorithmSwopEvent;
            algorithm.SetEvent += AlgorithmSetEvent;
            var time = algorithm.Sort();

            TimeLbl.Text = "Время: " + time.Seconds;
            SwopLbl.Text = "Количество обменов: " + algorithm.SwopCount;
            CompareLbl.Text = "Количество сравнений: " + algorithm.ComparisonCount;
        }

        private void TimSortBtn_Click(object sender, EventArgs e)
        {
            if (items.Count <= 0)
            {
                MessageBox.Show("Добавьте элементы массива!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tim = new TimSort<SortedItem>(items);
                BtnClick(tim);

                // Создайте новое окно для вывода итераций
                Form iterationsForm = new Form
                {
                    Text = "Итерации сортировки Тима"
                };

                // Создайте элемент управления TextBox для отображения итераций
                TextBox iterationsTextBox = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Text = tim.GetIterationHistory() // Получите историю итераций из алгоритма сортировки
                };

                // Добавьте TextBox на форму
                iterationsForm.Controls.Add(iterationsTextBox);

                // Отобразите форму
                iterationsForm.Show();
            }
        }


        public bool IsPowerOfTwo(int n)
        {
            if (n == 0)
            {
                return false;
            }
            while (n != 1)
            {
                if (n % 2 != 0)
                {
                    return false;
                }
                n = n / 2;
            }
            return true;
        }


        private void BitonisSortBtn_Click(object sender, EventArgs e)
        {
            if (items.Count <= 0)
            {
                MessageBox.Show("Добавьте элементы массива!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (IsPowerOfTwo(items.Count))
                {
                    var bitonic = new BitonicSort<SortedItem>(items);
                    BtnClick(bitonic);
                    // Создайте новое окно для вывода итераций
                    Form iterationsForm = new Form
                    {
                        Text = "Итерации сортировки Тима"
                    };

                    // Создайте элемент управления TextBox для отображения итераций
                    TextBox iterationsTextBox = new TextBox
                    {
                        Dock = DockStyle.Fill,
                        Multiline = true,
                        ReadOnly = true,
                        ScrollBars = ScrollBars.Vertical,
                        Text = bitonic.GetIterationHistory() // Получите историю итераций из алгоритма сортировки
                    };

                    // Добавьте TextBox на форму
                    iterationsForm.Controls.Add(iterationsTextBox);

                    // Отобразите форму
                    iterationsForm.Show();
                }
                else
                {
                    MessageBox.Show("Длина массива не равна степени 2ки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MergeSortBtn_Click(object sender, EventArgs e)
        {
            if (items.Count <= 0)
            {
                MessageBox.Show("Добавьте элементы массива!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var merge = new MergeSort<SortedItem>(items);
                BtnClick(merge);

                // Создайте новое окно для вывода итераций
                Form iterationsForm = new Form
                {
                    Text = "Итерации сортировки слиянием"
                };

                // Создайте элемент управления TextBox для отображения итераций
                TextBox iterationsTextBox = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Text = merge.GetIterationHistory() // Получите историю итераций из алгоритма сортировки
                };

                // Добавьте TextBox на форму
                iterationsForm.Controls.Add(iterationsTextBox);

                // Отобразите форму
                iterationsForm.Show();
            }
        }


        private void mergeSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgoInfo algoInfo = new AlgoInfo("MergeSort");
            algoInfo.ShowDialog();
        }

        private void timSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgoInfo algoInfo = new AlgoInfo("TimSort");
            algoInfo.ShowDialog();
        }

        private void bitonicSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgoInfo algoInfo = new AlgoInfo("BitonicSort");
            algoInfo.ShowDialog();
        }

        private void delElements_Click(object sender, EventArgs e)
        {
            items.Clear();

            RefreshItems();
        }

    }
}
