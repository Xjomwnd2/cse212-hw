/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // Problem 4 - MY CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE: MY CODE HERE
        var currentPosition = (_currX, _currY);
        
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Get the directions array [left, right, up, down]
        var directions = _mazeMap[currentPosition];
        
        // Check if left movement is allowed (index 0)
        if (!directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Move left (decrease x coordinate)
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE: MY CODE HERE
        var currentPosition = (_currX, _currY);
        
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Get the directions array [left, right, up, down]
        var directions = _mazeMap[currentPosition];
        
        // Check if right movement is allowed (index 1)
        if (!directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Move right (increase x coordinate)
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE: MY CODE HERE
        var currentPosition = (_currX, _currY);
        
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Get the directions array [left, right, up, down]
        var directions = _mazeMap[currentPosition];
        
        // Check if up movement is allowed (index 2)
        if (!directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Move up (decrease y coordinate - assuming standard coordinate system)
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE: MY CODE HERE
         var currentPosition = (_currX, _currY);
        
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Get the directions array [left, right, up, down]
        var directions = _mazeMap[currentPosition];
        
        // Check if down movement is allowed (index 3)
        if (!directions[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
        // Move down (increase y coordinate - assuming standard coordinate system)
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}