using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        // If the value equals current node's data, don't insert (maintain uniqueness)
        if (value == this.Data)
        {
            return; // Exit without inserting duplicate
        }
        else if (value < this.Data)
        {
            // Insert to the left
            if (this.Left is null)
                this.Left = new Node(value);
            else
                this.Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (this.Right is null)
                this.Right = new Node(value);
            else
                this.Right.Insert(value);
        }
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
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

    // Problem 4: Tree Height
    public int GetHeight()
    {
        // Get height of left subtree (0 if no left child)
        int leftHeight = (this.Left is null) ? 0 : this.Left.GetHeight();
        
        // Get height of right subtree (0 if no right child)
        int rightHeight = (this.Right is null) ? 0 : this.Right.GetHeight();
        
        // Height is 1 plus the maximum of left and right subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        // Create a new tree if _root is null.
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Check to see if the tree contains a certain value
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        return numbers;
    }

    // Problem 3: TraverseBackward
    private void TraverseBackward(Node? node, List<int> values)
    {
        // Check if node is not null before proceeding (base case)
        if (node is not null)
        {
            // For backward traversal (largest to smallest):
            // 1. First traverse the RIGHT subtree (larger values)
            TraverseBackward(node.Right, values);
            
            // 2. Then add the current node's data
            values.Add(node.Data);
            
            // 3. Finally traverse the LEFT subtree (smaller values)
            TraverseBackward(node.Left, values);
        }
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

// Problem 5: Create Tree from Sorted List
// NOTE: The test expects this class to be named "Trees" (not "TreeUtilities")
public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: if first > last, we've processed all elements in this range
        if (first > last)
            return;

        // Find the middle index
        int middle = (first + last) / 2;
        
        // Insert the middle value into the BST
        bst.Insert(sortedNumbers[middle]);
        
        // Recursively insert from the left half (first to middle-1)
        InsertMiddle(sortedNumbers, first, middle - 1, bst);
        
        // Recursively insert from the right half (middle+1 to last)
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}

// Extension method for formatting (as provided in your code)
public static class IntArrayExtensionMethods 
{
    public static string AsString(this IEnumerable array) 
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}