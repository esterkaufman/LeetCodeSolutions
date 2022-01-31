namespace LeetCodeSolutions
{
    internal class ArraysManipulations
    {
        //https://leetcode.com/problems/rotate-array/
        public void Rotate_UsingSpace(int[] nums, int k)
        {
            if (k > 0 && nums != null && nums.Length > 1 && (k %= nums.Length) > 0)
            {
                var rotated = new int[nums.Length];
                for (int i = 0, start = nums.Length - k; i < nums.Length; i++)
                {
                    rotated[i] = nums[start++];
                    if (start >= nums.Length) start = 0;
                }
                Array.Copy(rotated, nums, nums.Length);
            }
        }
        public void Rotate(int[] nums, int k)
        {
            if (k > 0 && nums != null && nums.Length > 1 && (k %= nums.Length) > 0)
            {               
                reverse(nums, 0, nums.Length - k - 1);
                reverse(nums, nums.Length - k, nums.Length - 1);
                reverse(nums, 0, nums.Length - 1);
            }
        }

        private void reverse(int[] nums, int i, int j)
        {
            while (i < j)
            {
                int tmp = nums[i];
                nums[i] = nums[j];
                nums[j] = tmp;
                i++;
                j--;
            }
        }
        public void RotateByJumpingIdx_NotCompleted(int[] nums, int k)
        {
            if (k > 0 && nums != null && nums.Length > 1 && (k %= nums.Length) > 0)
            {            
                var cnt = 0;
                while (cnt < k)// this loop is to repeat when the arr.len % k==0 (len=6 k=3 / len=8 k=4)
                {
                    var start = nums.Length - k + cnt;//the new first element after rotation
                    var i = Math.Abs(nums.Length - (start + k));//calc the newIndex for this element
                    int temp, current = nums[start];

                    while (i != start)
                    {
                        temp = nums[i];
                        nums[i] = current;
                        current = temp;
                        i = (i + k) % nums.Length;
                    }
                    nums[start] = current;//copy last element saved in current
                    if (nums.Length % k == 0) cnt++;//need to repeat for next element to rotate
                    else break;//done rotating
                }
            }
        }
        public void Run()
        {
            var arr = new int[] { 1, 2, 3,4};
            Rotate(arr, 9);
            Console.WriteLine(string.Join(",", arr));


            arr = new int[] { 1, 2, 3, 4 ,5,6,7,8};
            Rotate(arr, 4);
            Console.WriteLine(string.Join(",", arr));

            arr = new int[] { 1, 2, 3, 4, 5 };
            Rotate(arr, 4);
            Console.WriteLine(string.Join(",", arr));

            arr = new int[] { 1, 2, 3, 4, 5 };
            Rotate(arr, 3);
            Console.WriteLine(string.Join(",", arr));

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Rotate(arr, 5);
            Console.WriteLine(string.Join(",", arr));

            arr = new int[] { 1, 2, 3, 4 ,5,6,7,8,9};
            Rotate(arr, 6);
            Console.WriteLine(string.Join(",", arr));

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Rotate(arr, 6);
            Console.WriteLine(string.Join(",", arr));
        }


        //https://leetcode.com/problems/koko-eating-bananas/
        public int MinEatingSpeed(int[] piles, int h)
        {
            // Initalize the left and right boundaries 
            int left = 1, right = 1;
            foreach (int pile in piles)
            {
                right = Math.Max(right, pile);
            }

            while (left < right)
            {
                // Get the middle index between left and right boundary indexes.
                // hourSpent stands for the total hour Koko spends.
                int middle = (left + right) / 2;
                int hourSpent = 0;

                // Iterate over the piles and calculate hourSpent.
                // We increase the hourSpent by ceil(pile / middle)
                foreach (int pile in piles)
                {
                    hourSpent += (int)Math.Ceiling((double)pile / middle);
                }

                // Check if middle is a workable speed, and cut the search space by half.
                if (hourSpent <= h)
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }

            // Once the left and right boundaries coincide, we find the target value,
            // that is, the minimum workable eating speed.
            return right;
        }
    }
}
