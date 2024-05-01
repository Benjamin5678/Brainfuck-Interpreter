Set a flag to 1 if a target is zero

Memory Layout:
FLAG TARGET COPY

#
>< // Target = 0

+ // Set Flag
>[<->[->+<]]> // If target not 0 set flag 0 and copy
[-<+>]<< // Move copy back


>++++< // Target = 4

+ // Set Flag
>[<->[->+<]]> // If target not 0 set flag 0 and copy
[-<+>]<< // Move copy back