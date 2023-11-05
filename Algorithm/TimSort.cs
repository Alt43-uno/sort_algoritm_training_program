using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class TimSort<T> : AlgorithmBase<T> where T : IComparable
    {
        private const int RUN = 32;

        // Добавьте поле для хранения истории итераций
        private StringBuilder iterationHistory;

        public TimSort(IEnumerable<T> items) : base(items)
        {
            iterationHistory = new StringBuilder();
        }

        public TimSort()
        {
            iterationHistory = new StringBuilder();
        }

        protected override void MakeSort()
        {
            int n = Items.Count;
            for (int i = 0; i < n; i += RUN)
            {
                InsertionSort(i, Math.Min((i + 31), (n - 1)));
            }

            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    Merge(left, mid, right);
                }
            }
        }

        private void InsertionSort(int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                T temp = Items[i];
                int j = i - 1;
                while (j >= left && Compare(Items[j], temp) > 0)
                {
                    Swop(j, j + 1);
                    j--;

                    // Сохраните итерацию в истории
                    iterationHistory.AppendLine($"InsertionSort: {string.Join(", ", Items)}");
                }
                Set(j + 1, temp);
            }
        }

        private void Merge(int left, int mid, int right)
        {
            int len1 = mid - left + 1, len2 = right - mid;
            List<T> leftArr = new List<T>(len1);
            List<T> rightArr = new List<T>(len2);
            for (int x = 0; x < len1; x++)
            {
                leftArr.Add(Items[left + x]);
            }
            for (int x = 0; x < len2; x++)
            {
                rightArr.Add(Items[mid + 1 + x]);
            }

            int i = 0;
            int j = 0;
            int k = left;

            while (i < len1 && j < len2)
            {
                if (Compare(leftArr[i], rightArr[j]) <= 0)
                {
                    Set(k, leftArr[i]);
                    i++;
                }
                else
                {
                    Set(k, rightArr[j]);
                    j++;
                }
                k++;

                // Сохраните итерацию в истории
                iterationHistory.AppendLine($"Merge: {string.Join(", ", Items)}");
            }

            while (i < len1)
            {
                Set(k, leftArr[i]);
                k++;
                i++;

                // Сохраните итерацию в истории
                iterationHistory.AppendLine($"Merge: {string.Join(", ", Items)}");
            }

            while (j < len2)
            {
                Set(k, rightArr[j]);
                k++;
                j++;

                // Сохраните итерацию в истории
                iterationHistory.AppendLine($"Merge: {string.Join(", ", Items)}");
            }
        }



        // Метод для получения истории итераций
        public string GetIterationHistory()
        {
            return iterationHistory.ToString();
        }
    }
}
