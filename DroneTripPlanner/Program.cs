using DroneTripsPlanner.Generics;
using DroneTripsPlanner.Model;
using DroneTripsPlanner.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DroneTripsPlanner;

class Program
{
    const string RegexPattern = "\\[([(A-Z)]\\w+)\\], \\[([0-9]+)\\]";

    static void Main(string[] args)
    {
        try
        {
            var inputFileContent = ReadInputFile();

            var drones = GetDronesFromInputFile(inputFileContent);
            var dropPoints = GetDropsFromInputFile(inputFileContent);

            var planner = new TripsPlanner(drones.List.Select(t => new Drone(t)).ToList(), dropPoints.List.Select(t => new DropPoint(t)).ToList()).Plan();
            var output = GenerateOutput(planner);

            SaveOutputFile(output);

        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }


    }

    static string ReadInputFile()
    {
        var inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
        if (File.Exists(inputFilePath))
        {
            using (var stream = new StreamReader(inputFilePath))
            {
                return stream.ReadToEnd().ToString();
            }
        }
        else
            throw new Exception("Error: input.txt file was not found");
    }

    static void SaveOutputFile(string output)
    {
        var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.txt");
        File.WriteAllText(outputFilePath, output);
    }
    static GenericList<Drone> GetDronesFromInputFile(string inputFileContent)
    {
        var drones = new GenericList<Drone>();
        var contentSplitted = inputFileContent.Split(Environment.NewLine);
        if (contentSplitted.Length > 0)
        {
            var dronesPlain = Regex.Matches(contentSplitted[0], RegexPattern);
            if (dronesPlain.Any())
            {
                foreach (Match match in dronesPlain)
                    drones.AddItem(match.Groups[1].Value, match.Groups[2].Value);
            }
        }

        return drones;
    }

    static GenericList<DropPoint> GetDropsFromInputFile(string inputFileContent)
    {
        var drones = new GenericList<DropPoint>();
        var contentSplitted = inputFileContent.Split(Environment.NewLine);
        if (contentSplitted.Length > 1)
        {
            for (int count = 1; count < contentSplitted.Length; count++)
            {
                var dropPointsPlain = Regex.Matches(contentSplitted[count], RegexPattern);
                if (dropPointsPlain.Any())
                {
                    foreach (Match match in dropPointsPlain)
                        drones.AddItem(match.Groups[1].Value, match.Groups[2].Value);
                }
            }
        }

        return drones;
    }

    static string GenerateOutput(List<Drone> drone)
    {
        StringBuilder output = new StringBuilder();
        var droneCount = 0;
        foreach (var record in drone)
        {
            droneCount++;
            output.AppendLine($"[Drone #{droneCount} {record.Name}]");
            var tripCount = 0;
            foreach (var trip in record.Trips)
            {
                if (!trip.DropPoints.Any())
                    continue;

                tripCount++;
                output.AppendLine("Trip #" + tripCount);
                var dropCount = 0;
                foreach (var drop in trip.DropPoints)
                {
                    dropCount++;
                    output.Append($"[Location #{dropCount} {drop.Name}], ");
                }

                output.AppendLine(string.Empty);
            }
            output.AppendLine(string.Empty);
        }

        return output.ToString();
    }
}







