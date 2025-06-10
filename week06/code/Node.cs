public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Base case: if we found the value
        if (value == this.Data)
        {
            return true;
        }
        // If value is less than current node, search left subtree
        else if (value < this.Data)
        {
            if (this.Left is null)
                return false; // Value not found
            else
                return this.Left.Contains(value); // Recursive call
        }
        // If value is greater than current node, search right subtree
        else
        {
            if (this.Right is null)
                return false; // Value not found
            else
                return this.Right.Contains(value); // Recursive call
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}