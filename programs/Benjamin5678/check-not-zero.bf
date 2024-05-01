Set a flag to 1 if a target is not zero

Memory Layout:
FLAG TARGET COPY

#
>< // Target = 0

>[<+>[->+<]]> // If target not 0 set flag 1 and copy
[-<+>]<< // Move copy back


>++++< // Target = 4

>[<+>[->+<]]> // If target not 0 set flag 1 and copy
[-<+>]<< // Move copy back