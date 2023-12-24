
#include <string>
#include <unordered_set>
using namespace std;

class Solution {

    struct Point {
        int x;
        int y;

        Point(int x, int y) : x{x}, y{y} {}

        bool operator==(const Point& other) const {
            return this->x == other.x && this->y == other.y;
        }

        struct Hash {
            auto operator()(const Point& other) const {
                return std::hash<int>()(other.x) ^ std::hash<int>()(other.y);
            }
        };
    };

    inline static const unordered_map<char, array<int, 2>> moves {
        {'N', array<int, 2>{-1, 0}},
        {'S', array<int, 2>{1, 0}},
        {'E', array<int, 2>{0, 1}},
        {'W', array<int, 2>{0, -1}} };

public:
    //Alternatively, C++17: ...(string_view path)...
    bool isPathCrossing(const string& path) const {
        unordered_set<Point, Point::Hash> visited;
        int previousX = 0;
        int previousY = 0;
        visited.insert(Point(previousX, previousY));

        for (const auto& direction : path) {
            int nextX = previousX + moves.at(direction)[0];
            int nextY = previousY + moves.at(direction)[1];
            if (visited.contains(Point(nextX, nextY))) {
                return true;
            }

            visited.insert(Point(nextX, nextY));
            previousX = nextX;
            previousY = nextY;
        }

        return false;
    }
};
