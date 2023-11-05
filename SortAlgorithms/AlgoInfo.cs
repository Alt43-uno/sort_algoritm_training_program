using Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public partial class AlgoInfo : Form
    {
        public string AlgorithmName { get; set; }

        public AlgoInfo(string algorithmName)
        {
            InitializeComponent();
            this.AlgorithmName = algorithmName;
        }

        private void AlgoInfo_Load(object sender, EventArgs e)
        {
            this.Text = "Информация о "+AlgorithmName;
            if (this.AlgorithmName == "MergeSort")
            {
                algo_title.Text = "Сортировка слиянием";
                algo_image.Image = Properties.Resources.mergeSort;
            } else if (this.AlgorithmName == "BitonicSort")
            {
                algo_title.Text = "Битонная сортировка";
                algo_image.Image = Properties.Resources.bitonicSort;
            }
            else if (this.AlgorithmName == "TimSort")
            {
                algo_title.Text = "Сортировка Тима";
                algo_image.Image = Properties.Resources.timSort;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Label label = new Label();
            // Установите свойство AutoSize в false
            label.AutoSize = false;

            // Установите размер метки равным размеру панели
            label.Size = panel1.Size;
            label.Font = new Font(label.Font.FontFamily, 14);
            if (this.AlgorithmName == "MergeSort")
            {
                label.Text = "Сортировка слиянием (MergeSort):\nСортировка слиянием - это эффективный алгоритм сортировки, основанный на принципе 'разделяй и властвуй'. Он работает следующим образом:\n\n1. Разделение: Алгоритм делит массив на две равные половины.\n2. Завоевание: Алгоритм рекурсивно сортирует каждую половину.\n3. Объединение: Алгоритм объединяет отсортированные половины в один отсортированный массив.";
            }
            else if (this.AlgorithmName == "BitonicSort")
            {
                label.Text = "Битонная Сортировка (BitonicSort):\nБитонная сортировка - это классический параллельный алгоритм сортировки. Он работает следующим образом:\n\n1. Создание битонной последовательности: Алгоритм делит массив на подмассивы фиксированного размера, называемые 'прогонами', каждый из которых сортируется независимо.\n2. Сортировка битонной последовательности: Отсортированные прогоны объединяются в один отсортированный массив.";
            }
            else if (this.AlgorithmName == "TimSort")
            {
                label.Text = "Сортировка Тима (TimSort):\nСортировка Тима - это гибридный алгоритм сортировки, производный от сортировки слиянием и сортировки вставками. Он был разработан для эффективной работы с многими видами реальных данных. Он работает следующим образом:\n\n1. Создание прогонов: Алгоритм делит массив на небольшие подмассивы, называемые 'прогонами', которые уже отсортированы.\n2. Сортировка прогонов: Прогоны сортируются с помощью модифицированного алгоритма сортировки слиянием.";
            }


            panel1.Controls.Add(label);
        }

    }
}
