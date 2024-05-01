Divides position 0 by position 1
Stores quotient in position 0 and reminader in position 1

Memory Layout:
DIVIDEND/QUOTIENT DIVISOR/REMAINDER COPY1 COPY2/FLAG COPY3 TempQUOTIENT

#
// Set dividend and divisor
+++++++++++
>+++

[->+>+<<] // move divisor to copy1 and copy2
>>[-<<+>>]<< // move copy2 to divisor

// While A not 0
<[
    >>-<<- // Decrement copy1 and dividend

    // If copy1 = 0
    >>>+ // set flag
    <[>-<[->>+<<]] // if not 0 break flag and copy
    >>[-<<+>>]< // Move copy back
    // If copy1 = 0 block
    [
        - // break flag
        <<[->+>+<<] // Copy divisor to copy1 and copy2
        >>[-<<+>>] // Copy copy2 to divisor
        >>+<< // Increment tempQuotient
    ]<<<
]

>>[-<->] // Calculate Remainder
>>>[-<<<<<+>>>>>]<<< // Move TempQuotient