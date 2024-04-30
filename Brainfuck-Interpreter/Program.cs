//Welcome To My Awesome BrainFuck Interpreter!
//Learn About this language: https://gist.github.com/roachhd/dce54bec8ba55fb17d3a
//Source of sample codes: https://esolangs.org/wiki/Brainfuck#Hello,_World!

using System.Runtime;
using System.Runtime.CompilerServices;


// - CODES - //

string code = File.ReadAllText(".\\Programs\\online-scripts\\hello-world.bf");
//string code = File.ReadAllText(".\\Programs\\Benjamin5678\\password.bf");
//string code = File.ReadAllText(".\\Programs\\Benjamin5678\\multiply-preserve.bf");

//User variables
int memorySize = 30000;
int startingPosition = 0;
bool wrapping = false;

bool useDebug = true; //If enabled: start debugging in your program with #, turn off with !

int[] printStateRange = [0, 15]; //From which cell to which cell is printed by the printState method




//Initialize Computer
code = postProcess(code);

int cursor = startingPosition;
byte[] tape = new byte[memorySize];

int codePointer = 0;
string output = "";

bool debug = false;

//Main Loop
while (codePointer < code.Length)
{
    run();
}
Console.WriteLine("\nFinal State:");
printState();
if (output.Length > 0) { Console.WriteLine("Final Output: " + output); }


//Methods
void run()
{
    switch (code[codePointer])
    {
        case '<': //Move Left
            cursor--;
            break;
        
        case '>': //Move Right
            cursor++;
            break;
        
        case '+': //Increment
            tape[cursor]++;
            break;
        
        case '-': //Decrement
            tape[cursor]--;
            break;

        case '[': //Start Loop
            loop();
            break;

        case ',': //Take Input
            if (debug)
            {
                Console.Write("Input: ");
            }
            char input = Console.ReadKey().KeyChar;
            if (debug)
            {
                Console.WriteLine();
            }
            tape[cursor] = (byte)input;
            break;

        case '.': //Print Output
            if (debug)
            {
                Console.WriteLine("Output: " + (char)tape[cursor]);
            }
            else
            {
                Console.Write((char)tape[cursor]);
            }

            output += (char)tape[cursor];

            break;

        case '#': //debug mode on
            Console.WriteLine("\nDebugging enabled.");
            debug = true;
            break;

        case '!': //debug mode off
            Console.WriteLine("\nDebugging disabled.");
            debug = false;
            break;
    }

    if (debug)
    {
        printState();
        Console.ReadLine();
    }

    if (cursor < 0 && wrapping)
    {
        cursor += memorySize;
    }
    if (cursor > memorySize - 1 && wrapping)
    {
        cursor -= memorySize;
    }

    codePointer++;
}

void loop()
{
    codePointer++;

    //Save Code Enter Point
    int loopEnter = codePointer;

    //Find Exit Point
    int counter = 0; //For ignoring irrelevant '['s or ']'s
    while (true)
    {
        if (code[codePointer] == ']' && counter == 0)
        {
            break;
        }

        if (code[codePointer] == '[')
        {
            counter++;
        }

        if (code[codePointer] == ']')
        {
            counter--;
        }

        codePointer++;
    }
    int loopExit = codePointer;

    //Start Loop
    while (tape[cursor] > 0)
    {
        if (codePointer == loopExit)
        {
            codePointer = loopEnter;
        }

        while (codePointer < loopExit)
        {
            run();
        }
    }
}

void printState()
{
    //PrintCode
    for (int i = 0; i < code.Length; i++)
    {
        if (i == codePointer) //Highlight Current Position
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write(code[i]);
    }

    Console.WriteLine();

    //Print Tape
    for (int i = printStateRange[0]; i < printStateRange[1]; i++)
    {
        if (i == cursor) //Highlight Current Position
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write(tape[i] + ", ");
    }

    Console.WriteLine("\n");
}

string postProcess(string code)
{
    string processedText = "";

    foreach (char c in code)
    {
        if (new char[] { '<', '>', '+', '-', '[', ']', ',', '.' }.Contains(c))
        {
            processedText += c;
        }
        if (useDebug && new char[] { '#', '!' }.Contains(c))
        {
            processedText += c;
        }
    }

    return processedText;
}