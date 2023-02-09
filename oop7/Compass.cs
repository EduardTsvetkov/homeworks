

public class Compass {

    const int N = 0;
    const int E = 1;
    const int S = 2;
    const int W = 3;
    const int NE = 4;
    const int SE = 5;
    const int SW = 6;
    const int NW = 7;
    public Dictionary<int, int[]> delta = new Dictionary<int, int[]>(){
        [N] = new int[2]{0, -1},
        [E] = new int[2] {1, 0},
        [S] = new int[2] {0, 1},
        [W] = new int[2] {-1, 0},
        [NE] = new int[2] {1, -1},
        [SE] = new int[2] {1, 1},
        [SW] = new int[2] {-1, 1},
        [NW] = new int[2] {-1, -1}
    };



    public int opposite(int direction) {
        switch (direction) {
            case N:
                return S;
            case S:
                return N;
            case W:
                return E;
            case E:
                return W;
            case NE:
                return SW;
            case SE:
                return NW;
            case SW:
                return NE;
            case 7:
                return NW;
                
            default:
                return 1000;
        }
    }

}