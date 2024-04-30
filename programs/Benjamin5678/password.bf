//Password Checker//

This program takes a sequence of input from the user and checks that it equals the key in memory
If it does it will print :) else it will print ):

How to use:
Simply initialize the tape with the following format then return the cursor to index 0
{flag} {input} {keys} {buffer} : )
You can have any number of key values between {input} and {buffer}; look up an ascii table to see what these values are
{flag} {input} and {buffer} are reserved by the program and should be left 0

How it works (simple explanation):
The program works by checking if to the right of the input address there is a key or the buffer
If there is a key it takes user input and checks if it is equal to the key
If it is then it destroys the key and input; moves over one place; and loops the above steps
If it isnt then it terminates by printing ):
If the buffer is next then no more keys remain so the program terminates with :)


//Initialize//
password: brain
state: 0 0 b r a i n 0 : )
>>++++++[-<++++++++>]<[->++>++>++>++>++>>+>+<<<<<<<<]>++>++++++++++++++++++>+>+++++++++>++++++++++++++>>++++++++++>-------<<<<<<<<<

///CHECK INPUT MAIN///
#>+ set input
[
    <+> set flag
    >[ run if key next
        <,> make input then move to first key
        ![-<->]# subtract key from input
        <[ input remains so input not = key
            >>[>] find buffer
            >>.<. ):
            >>> stop loop
        ]
        <[ else input = key
            - destroy flag
            >>+< move input over one and set
        ]
    ]
    <[ run if buffer found
        >>.>. :)
        > stop loop
    ]>>
]