# Problem solving. Intermediate. Sorted sums.

For a sequence of integers [ a1, a2,..., an ], define the function f(i) as follows:
- Take the first i elements of a ( a1, a2, ..., ai) and sort them in non-desceding order. Call this new sequence s.
- Let f(i) = 1*s1 + 2*s2 + ... + i*si

Given a sequence of n integers, sort them in non-descending order then compute f(1) + ... + f(n). As the result may be very large, return it modulo (10^9 + 7).

Example:
```
n = 4
a = [ 4, 3, 2, 1 ]

s1 = [4], f(1) = 1*4 = 4
s2 = [3, 4], f(2) = 1*3 + 2*4 = 11
s3 = [2, 3, 4], f(3) = 1*2 + 2*3 + 3*4 = 20
s4 = [1, 2, 3, 4], f(4) = 1*1 + 2*2 + 2*3 + 4*4 = 30

sum(f(i)) = 65 mod(10^9 +7) = 65
```