using System.Collections;

public class Wave {
    private Cell entrance;
    private Cell exit1;
    private Cell exit2;
    private Cell exit3;
    private Queue<Cell> forProcessing = new Queue<Cell>(); 
    public ArrayList exits = new ArrayList();
    
    Maze maze;

    public Wave(Maze maze) {
        this.maze = maze;
    }

    /**
     * Метод расставляет по четырем четвертям лабиринта вход и выход/ы 
     */
    public void initDoors() {
        Random rnd = new Random();
        int x, y;
        int halfHeight = maze.height / 2;
        int halfWidth = maze.width / 2;
        
        x = rnd.Next(1, halfWidth);  // вход в верхней левой четверти
        y = rnd.Next(1, halfHeight);
        entrance = new Cell(x, y, 1); 
        maze.markCell(entrance);
        forProcessing.Enqueue(entrance);

        x = rnd.Next(halfWidth + 1, maze.width - 2);  // выход в верхней правой четверти
        y = rnd.Next(1, halfHeight - 1);
        exit1 = new Cell(x, y, -8); 
        maze.markCell(exit1);

        x = rnd.Next(1, halfWidth - 1);  // выход в нижней левой четверти
        y = rnd.Next(halfHeight + 1, maze.height - 2);
        exit2 = new Cell(x, y, -8); 
        maze.markCell(exit2);

        x = rnd.Next(halfWidth + 1, maze.width - 1);  // выход в нижней правой четверти
        y = rnd.Next(halfHeight + 1, maze.height - 1);
        exit3 = new Cell(x, y, -8); 
        maze.markCell(exit3);

        Console.Write(String.Format("Вход  {0} \n", entrance));
        Console.Write(String.Format("Вход  {0} \n", exit1));
        Console.Write(String.Format("Вход  {0} \n", exit2));
        Console.Write(String.Format("Выход  {0} \n", exit3));

    }


    /**
     * Метод запускает "волну"
     */
    public void makeWave() {
        Cell currentCell;
        int newX, newY;
        Cell cellForProcessing;
        Compass compass = new Compass();

        while (forProcessing.Count > 0) {
            currentCell = forProcessing.Dequeue();

            for (int i = 0; i < 4; i++) {  // волна по 4 направлениям
                newX = currentCell.x + compass.delta[i][0];
                newY = currentCell.y + compass.delta[i][1]; 
                if (maze.platform[newY, newX] == 0 || maze.platform[newY, newX] == -8) {  // пусто или выход
                    cellForProcessing = new Cell(newX, newY, currentCell.value + 1);

                    if (maze.platform[newY, newX] == -8) {  // выход добавляем в список выходов
                        exits.Add(cellForProcessing);
                    }

                    maze.platform[newY, newX] = currentCell.value + 1;
                    forProcessing.Enqueue(cellForProcessing);
                }            
            }
        }
    }



    public void pathFinding() {
        Cell currentCell = new Cell();
        currentCell = (Cell) exits[0];
        int newValue = currentCell.value;
        Cell nextCell = new Cell();
        int newX, newY;
        Compass compass = new Compass();

        while (currentCell.value > 2) {

            for (int i = 3; i >= 0; i--) {  // проверка по 4 направлениям
                newX = currentCell.x + compass.delta[i] [0];
                newY = currentCell.y + compass.delta[i] [1]; 
                nextCell = new Cell(newX, newY, currentCell.value - 1);
                
                if (maze.platform[newY, newX] != -1 && maze.platform[newY, newX] == nextCell.value) {  // "ближайшая" ячейка
                    newValue = maze.platform[newY, newX] + 1000;  // добавляем 1000 для последующего выделения
                    maze.platform[newY, newX] = newValue;
                    currentCell = nextCell;
                }            
            }           
        }  
        foreach (Cell cell in exits) {
            newValue = maze.platform[cell.y, cell.x] + 1000;  // добавляем 1000 для последующего выделения
            maze.platform[cell.y, cell.x] = newValue;
        }  
    }
}