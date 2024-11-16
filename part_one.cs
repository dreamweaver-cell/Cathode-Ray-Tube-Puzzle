string programInput = @"addx 15
addx -11 
...";


//Calculates the sum of signal strengths at specific cycles (20th, 60th, 100th, 140th, 180th, and 220th)
int GetSignalStrengthSum(string programInput)
{
    int x = 1;
    int cycle = 0;
    int signalStrengthSum = 0;

    foreach (string instruction in programInput.Split('\n'))
    {
        switch (instruction)
        {
            case "noop":
                cycle++;
                // Check if we are at a cycle where we need to calculate signal strength
                if (cycle == 20 || (cycle - 20) % 40 == 0)
                    signalStrengthSum += cycle * x;
                break;
            default:
                int addx = int.Parse(instruction.Split(' ')[1]);
                // addx instruction takes two cycles to complete
                cycle++;
                if (cycle == 20 || (cycle - 20) % 40 == 0)
                    signalStrengthSum += cycle * x;
                cycle++;
                if (cycle == 20 || (cycle - 20) % 40 == 0)
                    signalStrengthSum += cycle * x;
                x += addx;
                break;
        }
    }

    return signalStrengthSum;
}
