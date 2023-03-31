import sys

def cellCount(file):
    count = 0
    for i in file[0]:
        if (i == 'O'):
            count += 1
    return count * len(file)


def get_grids(file):
    file = file[2:]
    grids = []
    
    grid = []
    for line in file:
        if (line != ""):
            grid.append(list(line))
        else:
           grids.append(grid)
           grid = []

    grids.append(grid)
    return grids

def find_wasp(grid):
    pos = []

    for y in range(0, len(grid)):
        for x in range(0, len(grid[y])):
            if (grid[y][x] == "W"):
                pos.append((y, x))

    return pos

def countEmpty(grid, pos):
    cell_pos_list = [
            (pos[0] - 1, pos[1] - 1),
            (pos[0] - 1, pos[1] + 1),
            (pos[0], pos[1] - 2),
            (pos[0], pos[1] + 2),
            (pos[0] + 1, pos[1] - 1),
            (pos[0] + 1, pos[1] + 1),
        ]

    count = 0
    for cell_pos in cell_pos_list:
        if(grid[cell_pos[0]][cell_pos[1]] == "O"):
            count += 1;
    return count


def canEscapeDir(grid, pos, apply):
    new_pos = (pos[0] - apply[0], pos[1] - apply[1])
    if (new_pos[0] < 0 or new_pos[1] < 0):
        return "FREE"
    elif (new_pos[0] >= len(grid) or new_pos[1] >= len(grid[0])):
        return "FREE"
    
    if (grid[new_pos[0]][new_pos[1]] == "O"):
        grid[new_pos[0]][new_pos[1]] = "P"
        return canEscape(grid, new_pos)
    else:
        return "TRAPPED"

def canEscape(grid, wasp):
    dirs = [
            (-1, -1),
            (-1, +1),
            (0, -2),
            (0, +2),
            (+1, -1),
            (+1, +1),
        ]
    for dir in dirs:
        esc = canEscapeDir(grid, wasp, dir)
        if (esc == "FREE"):
            return esc
    return "TRAPPED"



def get_content(filename):
    input_file = open(filename, "r")
    file_content = input_file.readlines()

    content = [] 
    for i in file_content:
        if (len(i) == 0):
            continue
        if (i[len(i)-1] == '\n'):
            content.append(i[:len(i)-1])
        else:
            content.append(i)
    return content

content = get_content(sys.argv[1])
grids = get_grids(content)

for grid in grids:
    wasp = (find_wasp(grid))[0]
    barrier_count = int(grid[0][0])
    print(canEscape(grid, wasp, barrier_count))
