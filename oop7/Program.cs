
public class Programm {
    public static void Main(string[] args) {
        Random rnd = new Random();
        int height = 20;
        int width = 30;
        Maze maze = new Maze(width, height);
        
        int x, y, length;
        Cell beginCell;
        for (int i = 0; i < width * height / 2; i++) { 
            x = rnd.Next(1, width - 1);
            y = rnd.Next(1, height - 1);
            length = rnd.Next(10, 31);
            beginCell = new Cell(x, y, -1);
            maze.buildWall(beginCell, length);
        }

        Wave wave = new Wave(maze);
        wave.initDoors();
        Console.WriteLine("Исходный лабиринт:");
        maze.print();

        wave.makeWave();
        Console.WriteLine();  
        Console.WriteLine("Координаты выходов и расстояния до них:");
        foreach (Cell cell in wave.exits)
        {
            Console.WriteLine(cell);
        }

        wave.pathFinding(); 
        Console.WriteLine();  
        Console.WriteLine("Лабиринт после \"волны\" с кратчайшим путём:");
        maze.print();
    }
    
}