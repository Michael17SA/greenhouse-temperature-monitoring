namespace GreenhouseTemperatureMonitoring;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the Greenhouse Temperature Monitoring System!");

        int sectionCount = ReadPositiveInteger("Enter the number of sections in the greenhouse: ");
        int readingCount = ReadPositiveInteger("Enter the number of temperature readings per section: ");

        double[,] sensorData = new double[sectionCount, readingCount];

        for (int section = 0; section < sectionCount; section++)
        {
            Console.WriteLine($"\nEntering readings for Section {section + 1}:");

            for (int reading = 0; reading < readingCount; reading++)
            {
                sensorData[section, reading] = ReadTemperature($"  Enter temperature reading {reading + 1}: ");
            }
        }

        DisplaySensorData(sensorData);
        DisplayAverageTemperatures(sensorData);

        Console.WriteLine("\nTemperature Monitoring Module Finished.");
    }

    private static int ReadPositiveInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a positive whole number.");
        }
    }

    private static double ReadTemperature(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double temperature))
            {
                return temperature;
            }

            Console.WriteLine("  Invalid input. Please enter a numeric temperature.");
        }
    }

    private static void DisplaySensorData(double[,] sensorData)
    {
        Console.WriteLine("\nSensor Data Summary:");

        for (int section = 0; section < sensorData.GetLength(0); section++)
        {
            Console.Write($"Section {section + 1}: ");

            for (int reading = 0; reading < sensorData.GetLength(1); reading++)
            {
                Console.Write($"{sensorData[section, reading]:F1} C  ");
            }

            Console.WriteLine();
        }
    }

    private static void DisplayAverageTemperatures(double[,] sensorData)
    {
        Console.WriteLine("\nTemperature Analysis:");

        for (int section = 0; section < sensorData.GetLength(0); section++)
        {
            double total = 0;

            for (int reading = 0; reading < sensorData.GetLength(1); reading++)
            {
                total += sensorData[section, reading];
            }

            double average = total / sensorData.GetLength(1);
            Console.WriteLine($"  Section {section + 1} Average Temperature: {average:F2} C");
        }
    }
}
