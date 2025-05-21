public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
   private static bool AreUniqueLetters(string text)
{
    var seen = new HashSet<char>();

    foreach (char c in text)
    {
        if (seen.Contains(c))
        {
            // If the character is already in the set, it's a duplicate
            return false;
        }

        // Otherwise, add it to the set
        seen.Add(c);
    }

    // If no duplicates are found, return true
    return true;
}

}