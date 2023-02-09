public class Cell {
    public int x;
    public int y;
    public int value;

    public Cell(int x, int y, int value) {
        this.x = x;
        this.y = y;
        this.value = value;
    }

    public Cell() {
        
    }


    public override string ToString()
    {
        return String.Format("x = {0}, y = {1}, value = {2}", this.x, this.y, this.value);
    }

}

