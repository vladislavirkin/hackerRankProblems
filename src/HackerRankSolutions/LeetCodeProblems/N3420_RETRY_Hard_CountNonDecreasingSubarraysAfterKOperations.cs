using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Sliding window + queue.
/// <see cref="CountNonDecreasingSubarrays"/>
/// RT = 13 ms, beats 100%.
/// M = 65 MB, beats 100%.
/// <see cref="CountNonDecreasingSubarrays_Second"/>
/// RT = 332 ms, beats 100%.
/// M = 102 MB, beats 50%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/")]
public class N3420_RETRY_Hard_CountNonDecreasingSubarraysAfterKOperations
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        // yield return new TestCaseData(new [] { 6, 3, 1, 2, 4, 4 }, 7, 17);
        // yield return new TestCaseData(new [] { 6, 3, 1, 3, 6 }, 4, 12);
        yield return new TestCaseData(new [] { 1000000000, 1, 1, 1, 1 }, 1_000_000_000, 12);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int k, int expected)
    {
        var ret = CountNonDecreasingSubarrays(nums, k);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public long CountNonDecreasingSubarrays(int[] nums, int k)
    {
        long ret = 0;
        
        var n = nums.Length;
        var starts = new int[n]; // where each plateau starts, left to right: starts[head..tail)

        int head = n, tail = n;
        long water = 0;
        var right = n - 1;
        
        for (var left = n - 1; left >= 0; left--)
        {
            var x = nums[left];
            while (head < tail && nums[starts[head]] <= x) // x floods the plateau that starts at starts[head]
            {  
                var start = starts[head++];
                var end = head < tail ? starts[head] : right + 1;
                water += (long)(x - nums[start]) * (end - start);
            }
            
            starts[--head] = left;
            while (water > k) // the right end leaves with its water
            {  
                water -= nums[starts[tail - 1]] - nums[right];
                if (starts[tail - 1] == right)
                    tail--;
                
                right--;
            }
            ret += right - left + 1;
        }
        
        return ret;
    }
    
     public long CountNonDecreasingSubarrays_Second(int[] nums, int k)
     {
        int n = nums.Length;
        long ans = 0;
        long operations = 0;
        // Maintain the window maximum with a priority queue
        var q = new PriorityQueue<(int val, int idx), int>();
        // Record the set of elements covered by this index
        var cnt = new List<int>[n];
        for (int i = 0; i < n; i++) {
            cnt[i] = new List<int>();
        }
        // Index of the first greater-or-equal element to the right
        var pos = new int[n];
        Array.Fill(pos, n);
        // Decreasing monotonic stack
        var st = new Stack<int>();

        for (int left = 0, right = 0; right < n; right++) {
            // Maintain the monotonic stack
            while (st.Count > 0 && nums[right] >= nums[st.Peek()]) {
                pos[st.Peek()] = right;
                st.Pop();
            }
            // The stack top is the nearest greater element to the left of
            // nums[right]
            if (st.Count > 0) {
                cnt[st.Peek()].Add(right);
            }
            st.Push(right);

            // The priority queue front is the window maximum
            q.Enqueue((nums[right], right), -nums[right]);
            // Adding nums[right] increases the operation count
            operations += Math.Max(0, q.Peek().val - nums[right]);

            // The minimum operation count exceeds k; shrink the window
            while (operations > k) {
                // Removing nums[left] from the window decreases the operation
                // count
                foreach (int i in cnt[left]) {
                    // Subtract the contribution
                    operations -= (long)(nums[left] - nums[i]) *
                                  (Math.Min(pos[i], right + 1) - i);
                }
                left++;
            }

            // Remove elements with indices less than left from the priority
            // queue
            while (q.Count > 0 && q.Peek().idx < left) {
                q.Dequeue();
            }

            // There are right - left + 1 valid contiguous subarrays ending at
            // right
            ans += right - left + 1;
        }

        return ans;
    }
}