// CRT screen rendering
string RenderCRT(string programInput)
{
    int x = 1;
    int cycle = 0;
    StringBuilder crtOutput = new StringBuilder();

    foreach (string instruction in programInput.Split('\n'))
    {
        switch (instruction)
        {
            case "noop":
                // Render the current pixel and increment the cycle
                RenderPixel(cycle, x, ref crtOutput);
                cycle++;
                break;
            default:
                int addx = int.Parse(instruction.Split(' ')[1]);
                // addx instruction takes two cycles to complete
                RenderPixel(cycle, x, ref crtOutput);
                cycle++;
                RenderPixel(cycle, x, ref crtOutput);
                cycle++;
                x += addx;
                break;
        }
    }

    return crtOutput.ToString();
}

// Render a singel pixel
void RenderPixel(int cycle, int x, ref StringBuilder crtOutput)
{
    // Calculate the current pixel position 
    int currentPixel = cycle % 40;
    // If current pixel is at the end of line
    if (currentPixel == 0)
        crtOutput.Append('\n');
    // Check if current pixel is with in sprite position
    if (currentPixel >= x - 1 && currentPixel <= x + 1)
        crtOutput.Append('#');
    else
        crtOutput.Append(' ');
}
