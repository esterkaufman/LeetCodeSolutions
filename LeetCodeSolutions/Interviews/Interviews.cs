namespace LeetCodeSolutions.Interviews
{
    internal class Interviews
    {
        //Preffer to solved this using PriorityQueu
        //https://www.geeksforgeeks.org/microsoft-interview-experience-4-years-experienced-3/
        public int pollutionsMinFilters(int[] A)
        {
            int filtersCount = 0;
            double totalPollution = A.Sum();
            double requiredTotal = totalPollution / 2, currentTotal = totalPollution;

            // Sort the pollutions by desc order
            Array.Sort(A, (a, b) => b.CompareTo(a));

            for (int i = 0; requiredTotal < currentTotal && i < A.Length;)
            {
                if (A[i] <= 0)
                {
                    i++;
                    continue;
                }

                float reduceSum = 0;
                if (A[i] > A[i + 1])
                {
                    reduceSum = A[i] / 2f;
                    A[i] = (int)reduceSum;
                }
                else
                {
                    reduceSum = A[i + 1] / 2f;
                    A[i + 1] = (int)reduceSum;
                    i++;
                }

                currentTotal -= reduceSum;
                filtersCount++;
            }

            return filtersCount;
        }
    }
}
