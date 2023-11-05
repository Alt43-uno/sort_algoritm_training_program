using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class BitonicSort<T> : AlgorithmBase<T> where T : IComparable
    {
        // Добавьте поле для хранения истории итераций
        private StringBuilder iterationHistory;

        public BitonicSort(IEnumerable<T> items) : base(items)
        {
            iterationHistory = new StringBuilder();
        }

        public BitonicSort()
        {
            iterationHistory = new StringBuilder();
        }

        protected override void MakeSort()
        {
            int up = 1;
            BitonicSortAlgorithm(0, Items.Count, up);
        }

        private void BitonicSortAlgorithm(int low, int cnt, int dir)
        {
            if (cnt > 1)
            {
                int k = cnt / 2;
                BitonicSortAlgorithm(low, k, 1);
                BitonicSortAlgorithm(low + k, k, 0);
                BitonicMerge(low, cnt, dir);
            }
        }

        private void BitonicMerge(int low, int cnt, int dir)
        {
            if (cnt > 1)
            {
                int k = GreatestPowerOfTwoLessThan(cnt);
                for (int i = low; i < low + cnt - k; i++)
                {
                    if (dir == (Compare(Items[i], Items[i + k]) > 0 ? 1 : 0))
                    {
                        Swop(i, i + k);

                        // Сохраните итерацию в истории
                        iterationHistory.AppendLine($"Swop: {Items[i]}, {Items[i + k]}");
                        iterationHistory.AppendLine($"Result: {string.Join(", ", Items)}");
                        iterationHistory.AppendLine($"\n");
                    }
                }

                BitonicMerge(low, k, dir);
                BitonicMerge(low + k, cnt - k, dir);
            }
        }

        private int GreatestPowerOfTwoLessThan(int n)
        {
            int k = 1;
            while (k > 0 && k < n)
            {
                k = k << 1;
            }
            return k >> 1;
        }

        // Метод для получения истории итераций
        public string GetIterationHistory()
        {
            return iterationHistory.ToString();
        }
    }
}
