
/**
 * @param {string} path
 * @return {boolean}
 */
var isPathCrossing = function (path) {
    const moves = {'N': [-1, 0], 'S': [1, 0], 'E': [0, 1], 'W': [0, -1]};
    const visited = new Set();
    let previousX = 0;
    let previousY = 0;
    visited.add(previousX + ", " + previousY);

    for (const direction of path) {
        const nextX = previousX + moves[direction][0];
        const nextY = previousY + moves[direction][1];
        if (visited.has(nextX + ", " + nextY)) {
            return true;
        }
        visited.add(nextX + ", " + nextY);
        previousX = nextX;
        previousY = nextY;
    }

    return false;
};
