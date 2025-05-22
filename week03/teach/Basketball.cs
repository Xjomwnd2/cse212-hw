using System;
using System.Collections.Generic;

public static class Basketball
{
    public static void Run()
    {
        Console.WriteLine("Basketball team statistics using sets...");
        
        // Sample data for demonstration (no external file needed)
        HashSet<string> team1Players = new HashSet<string> { "Alice", "Bob", "Charlie", "David", "Eve" };
        HashSet<string> team2Players = new HashSet<string> { "Bob", "Frank", "Grace", "David", "Helen" };
        HashSet<string> team3Players = new HashSet<string> { "Alice", "Grace", "Ivan", "Jack", "Eve" };
        
        Console.WriteLine($"Team 1 players: {string.Join(", ", team1Players)}");
        Console.WriteLine($"Team 2 players: {string.Join(", ", team2Players)}");
        Console.WriteLine($"Team 3 players: {string.Join(", ", team3Players)}");
        Console.WriteLine();
        
        // Demonstrate set operations
        
        // Find players who played in both Team 1 and Team 2
        HashSet<string> playersInBothTeams = new HashSet<string>(team1Players);
        playersInBothTeams.IntersectWith(team2Players);
        Console.WriteLine($"Players in both Team 1 and Team 2: {string.Join(", ", playersInBothTeams)}");
        
        // Find all unique players across all teams
        HashSet<string> allPlayers = new HashSet<string>(team1Players);
        allPlayers.UnionWith(team2Players);
        allPlayers.UnionWith(team3Players);
        Console.WriteLine($"All unique players: {string.Join(", ", allPlayers)}");
        
        // Find players only in Team 1
        HashSet<string> onlyTeam1 = new HashSet<string>(team1Players);
        onlyTeam1.ExceptWith(team2Players);
        onlyTeam1.ExceptWith(team3Players);
        Console.WriteLine($"Players only in Team 1: {string.Join(", ", onlyTeam1)}");
        
        // Find players who appear in at least 2 teams
        HashSet<string> multiTeamPlayers = new HashSet<string>();
        
        foreach (string player in allPlayers)
        {
            int teamCount = 0;
            if (team1Players.Contains(player)) teamCount++;
            if (team2Players.Contains(player)) teamCount++;
            if (team3Players.Contains(player)) teamCount++;
            
            if (teamCount >= 2)
            {
                multiTeamPlayers.Add(player);
            }
        }
        
        Console.WriteLine($"Players on multiple teams: {string.Join(", ", multiTeamPlayers)}");
        
        // Demonstrate symmetric difference (players in Team 1 or Team 2, but not both)
        HashSet<string> symmetricDiff = new HashSet<string>(team1Players);
        symmetricDiff.SymmetricExceptWith(team2Players);
        Console.WriteLine($"Players in Team 1 OR Team 2 (but not both): {string.Join(", ", symmetricDiff)}");
    }
}