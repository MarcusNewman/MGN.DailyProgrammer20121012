From http://www.reddit.com/r/dailyprogrammer/comments/122c4t/10252012_challenge_107_easy_all_possible_decodings/

Consider the translation from letters to numbers a -> 1 through z -> 26. Every sequence of letters can be translated into a string of numbers this way, with the numbers being mushed together. For instance hello -> 85121215. Unfortunately the reverse translation is not unique. 85121215 could map to hello, but also to heaubo. Write a program that, given a string of digits, outputs every possible translation back to letters.
Sample input:
123
Sample output:
abc
aw
lc