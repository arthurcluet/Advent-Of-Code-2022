def main():
    f = open("input.txt", "r")
    lines = f.read().splitlines()
    # The first step is to read the initial position of the crates
    # The content is in position : 1, 5, 9...

    # We need to find the last line that contains crates
    bottomCratesId = 0
    for i in range(0, len(lines)):
        if "[" in lines[i]:
            bottomCratesId = i
        else:
            break
    # We calculate the number of columns:
    nbCols = (len(lines[bottomCratesId]) + 1)//4
    cols = [[] for _ in range(0, nbCols)]
    cols2 = [[] for _ in range(0, nbCols)]
    # Now we read the content
    for i in range(bottomCratesId, -1, -1):
        for j in range(0, nbCols):
            if lines[i][1 + 4*j] != " ":
                cols[j].append(lines[i][1 + 4*j])
                cols2[j].append(lines[i][1 + 4*j])

    # Now we read the instructions
    for l in lines[bottomCratesId+3:]:
        # Not the best way to do it but it works
        [n, origin, destination] = list(
            map(int, [l.split(' ')[i] for i in [1, 3, 5]]))
        # We count from 0
        origin -= 1
        destination -= 1

        # We move the crates (Part 1)
        for i in range(n):
            cols[destination].append(cols[origin].pop())

        # We move the crates (Part 2)
        temp = []
        for i in range(n):
            temp.append(cols2[origin].pop())
        for i in range(len(temp)):
            cols2[destination].append(temp.pop())

    result1 = "".join([col[-1] for col in cols])
    print("Part 1:", result1)

    result2 = "".join([col[-1] for col in cols2])
    print("Part 2:", result2)


if __name__ == "__main__":
    main()
