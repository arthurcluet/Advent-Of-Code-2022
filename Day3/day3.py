def main():
    f = open("input.txt", "r")
    lines = f.read().splitlines()
    priorities = ".abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    part1 = 0
    for l in lines:
        a = l[:len(l)//2]
        b = l[len(l)//2:]
        for c in a:
            if c in b:
                part1 += priorities.index(c)
                break
    print("Part 1:", part1)

    part2 = 0
    for i in range(0, len(lines)//3):
        for c in lines[i*3]:
            if c in lines[(i*3)+1] and c in lines[(i*3)+2]:
                part2 += priorities.index(c)
                break
    print("Part 2:", part2)


if __name__ == "__main__":
    main()
