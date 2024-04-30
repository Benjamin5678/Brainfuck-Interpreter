Memory Layout:
A B COPYA COPYB C

++++ //A = 4
>+++++ //B = 5

<[->>+>+<<<] Move A to COPYA and COPYB
>>>[-<<<+>>>] Move COPYB to A

<<<[ //While A not 0
    -
    >[->>+>+<<<] //Move B to COPYB and C
    >>[-<<+>>] //Move COPYB to B
    <<<
]

>>[-<<+>>] //Move COPYA to A
<<