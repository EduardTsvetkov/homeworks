using System.Collections;

/**
 * Лабиринт
 */
public class Maze {
    public int height;
    public int width;
    // private String brick = "\u25A6\u25A6\u25A6";
    public String brick = "####";
    public int[,] platform;
    Compass compass = new Compass();

    /**
     * Конструктор пустого лабиринта
     * @param x - ширина лабиринта
     * @param y - высота лабиринта
     */
    public Maze(int x, int y) {
        this.width = x;
        this.height = y;
        platform = new int[height, width];
        for (int i = 0; i < this.height; i++) {
            platform[i, 0] = -1;
            platform[i, width - 1] = -1;
        }
        for (int i = 1; i < this.width - 1; i++) {
            platform[0, i] = -1;
            platform[this.height - 1, i] = -1;
        }
    }

    /**
     * Метод выводит лабиринт на экран
     */
    public void print() {
        for (int i = 0; i < this.height; i++) {
            for (int j = 0; j < this.width; j++) {
                if (platform[i, j] == -1) {
                    Console.Write(String.Format("\u001B[31m{0, 3}",this.brick));
                } else if (platform[i, j] == 1 || (platform[i, j] == -8)){
                    Console.Write(String.Format("\u001B[32m{0, 3} ",platform[i, j]));       
                } else if (platform[i, j] > 1000){
                    Console.Write(String.Format("\u001B[34m{0, 3} ",platform[i, j] - 1000));      
                } else {
                    Console.Write(String.Format("\u001B[37m{0, 3} ",platform[i, j]));    
                }
                
            }
            Console.WriteLine("\u001B[0m");  // сброс цвета
        }       
    }

    /**
     * Метод маркирует ячейку
     * @param cell - ячейка
     */
    public void markCell(Cell cell) {
        platform[cell.y, cell.x] = cell.value;        
    }

    /**
     * 
     * @param x - координата X
     * @param y - координата Y
     * @param value - искомое значение
     * @return - количество найденных 
     */
    public int howAround(int x, int y, int value) {
        int result = 0;
        int newX, newY;
        for (int i = 0; i < 8; i++) {
            newX = x + compass.delta[i] [0];
            newY = y + compass.delta[i] [1]; 
            if (newX < 0 || newX >= width || newY < 0 || newY >= height) {
                continue;
            }            
            if (platform[newY, newX] == value) {
                result++;
            }
        }
        return result;
    }

    /**
     * Метод проверяет находится ли ячейка на границе
     * @param cell - ячейка
     * @return - да/нет (true/false)
     */
    public bool onBorder(Cell cell) {
        if (cell.x == 0 || cell.x == width - 1 || cell.y == 0 || cell.y == height - 1) {
            return true;
        } 
        return false;
    }

    /**
     * Метод проверяет находится ли ячейка у границы
     * @param cell - ячейка
     * @return - да/нет (true/false)
     */
    public bool nearBorder(Cell cell) {
        int newX;
        int newY;
        for (int i = 0; i < 4; i++) {
            newX = cell.x + compass.delta[i] [0];
            newY = cell.y + compass.delta[i] [1]; 
            if (newX == 0 || newX == width - 1|| newY == 0 || newY == height - 1) {
                return true;
            }         
        }
        return false;
    }

    /**
     * Метод "строит стену"
     * @param currentCell - начальная точка
     * @param wallLength - длина стены
     */
    public void buildWall(Cell currentCell, int wallLength) {
        Random rnd = new Random();
        // Compass compass = new Compass();
        int previousDirection = -1;
        int direction;
        ArrayList blockedDirections = new ArrayList();
        Cell nextCell;
        int counter = 1;
        int bricks;
        bool flag = true;
        bool begin = true;
        bool end = false;
        bool beginNearBorder = false;
        int newX, newY, newValue;
        // проверяем первую точку (можно ли там поставить стену)
        if (platform[currentCell.y, currentCell.x] == -1) {
            return;
        }

        bricks = howAround(currentCell.x, currentCell.y, -1);  // считаем сколько вокруг начальной ячейки "кирпичей"
        if (nearBorder(currentCell))  {
            if (bricks == 3) {  // кроме "стены" рядом ничего, годится
                markCell(currentCell); 
                beginNearBorder = true;
            } else {
                return;
            }          
        } else if (bricks == 0) {  // рядом ничего, годится           
                markCell(currentCell); 
        } else {
            return;
        }
        
        while (counter < wallLength && blockedDirections.Count < 4 && !end) {  // продолжаем "змею" стены

            direction = rnd.Next(1, 5);  // предполагаемое направление движения по "компасу"
            // direction = 3;  // тестовое направление вниз
            if (begin) {  // следующая за первой ячейка
                previousDirection = direction;
            }

            if (blockedDirections.Contains(direction)) {  // это направление было проверено ранее и заблокировано
                flag = false;
                direction = previousDirection;
                continue;
            }

            // создаем ячейку в предполагаемом направлении и далее проверяем ее
            newX = currentCell.x + compass.delta[direction] [0];
            newY = currentCell.y + compass.delta[direction] [1]; 
            newValue = -1;
            nextCell = new Cell(newX, newY, newValue);

            if (onBorder(nextCell)) {  // вышли на границу, блокируем это направление и возвращаемся в исходное
                flag = false;
                blockedDirections.Add(direction);
                direction = previousDirection;
                continue;
            }
           
            bricks = howAround(nextCell.x, nextCell.y, nextCell.value);  // сколько "кирпичей" уже вокруг предполагаемой ячейки

            if (direction == previousDirection) {  // движемся в прежнем направлении

                if (nearBorder(nextCell))  {
                    if (beginNearBorder) {
                        if (begin) {
                            flag = false;
                        } else {
                            flag = false; 
                            end = true;
                        }

                    } else {
                        if (bricks == 4) {  // кроме "стены" и хвоста рядом ничего (начало не у границы), годится
                            flag = true; 
                            end = true;
                        } else {
                            flag = false;
                        }
                    }

                } else {
                    if (bricks == 1) {  // рядом только хвост, годится    
                        flag = true;
                    } else {
                        flag = false;
                    }
                }

            } else {
                if (nearBorder(nextCell))  {
                    if (bricks == 5 && !beginNearBorder) {  // кроме "стены" и хвоста рядом ничего, годится
                        flag = true; 
                        end = true;
                    } else {
                        flag = false;
                    }
                } else if (bricks == 2) {  // рядом только хвост, годится           
                    flag = true;  
                } else {
                    flag = false;
                }
            }

            if (flag) {
                if (nextCell.x > width - 1 || nextCell.y > height - 1) {
                    break;
                }

                markCell(nextCell);

                counter++;
                currentCell = nextCell;
                previousDirection = direction;
    
                blockedDirections = new ArrayList();
                blockedDirections.Add(compass.opposite(previousDirection));  // откуда пришли - туда нельзя...         
                if (begin) {  // следующая за первой ячейка (был первый шаг)
                    begin = false;
                }         
            } else {
                blockedDirections.Add(direction);
                direction = previousDirection;
            }
            
        }
    }

}