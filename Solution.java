
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

class Solution {

    /*
    Alternatively, we could apply the immutable class 'record' (JDK14)
    e.g. record Point(int x, int y){}, which implements 'equals()', 'hashCode()' 
    and 'toString()' methods, based on the parameters in the constructor.
     */
    private final class Point {

        int x;
        int y;

        Point(int x, int y) {
            this.x = x;
            this.y = y;
        }

        @Override
        public boolean equals(Object object) {
            if (this == object) {
                return true;
            }
            if (!(object instanceof Point)) {
                return false;
            }
            Point other = (Point) object;
            return this.x == other.x && this.y == other.y;
        }

        @Override
        public int hashCode() {
            int hash = 19;
            hash = 89 * hash + this.x;
            hash = 89 * hash + this.y;
            return hash;
        }
    }

    private final static Map<Character, int[]> moves = Map.of(
            'N', new int[]{-1, 0},
            'S', new int[]{1, 0},
            'E', new int[]{0, 1},
            'W', new int[]{0, -1});

    public boolean isPathCrossing(String path) {
        Set<Point> visited = new HashSet<>();
        int previousX = 0;
        int previousY = 0;
        visited.add(new Point(previousX, previousY));

        for (char direction : path.toCharArray()) {
            int nextX = previousX + moves.get(direction)[0];
            int nextY = previousY + moves.get(direction)[1];
            if (!visited.add(new Point(nextX, nextY))) {
                return true;
            }

            previousX = nextX;
            previousY = nextY;
        }

        return false;
    }
}
