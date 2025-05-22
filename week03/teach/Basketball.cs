/*
 * CSE 212 Lesson 6C
 *
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 *
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 *
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            if (int.TryParse(fields[8], out int points))
            {
                if (players.ContainsKey(playerId))
                {
                    players[playerId] += points;
                }
                else
                {
                    players[playerId] = points;
                }
            }
            else
            {
                Console.WriteLine($"Warning: Could not parse points for player ID: {playerId}, value: {fields[8]}");
            }
        }

        // Convert the dictionary to a list of key-value pairs so we can sort it
        var sortedPlayers = players.OrderByDescending(pair => pair.Value).ToList();

        Console.WriteLine("Top 10 Players by Total Points:");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Rank | Player ID | Total Points");
        Console.WriteLine("-----|-----------|--------------");

        int count = 0;
        foreach (var player in sortedPlayers)
        {
            if (count < 10)
            {
                Console.WriteLine($"{count + 1,-4} | {player.Key,-9} | {player.Value,-12}");
                count++;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine("----------------------------------");
    }
}