# Problem solving. Medium. Roll string

Roll the string with the ascii [a-z]

Input: string str = "abz", int[] roll {3, 2, 1}

Output: string str = "dda".

Explanation:
```
first item in roll array - 3, than roll first 3 characters ins str 
a -> b
b -> c
z -> a
result string = "bca"

second item in roll array - 2, than roll first 2 characters ins str 
b -> c
c -> d

result = "cda"

last item in roll array - 1, than roll first 1 characters ins str 
c -> d

result = "dda"
```