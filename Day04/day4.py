def main():
    f = open("input.txt", "r")
    lines = f.read().splitlines()
    count1 = 0
    count2 = 0
    for l in lines:
        ranges = l.split(',')
        ranges = list(map(lambda x: [int(y) for y in x.split('-')], ranges))
        [[a, b], [c, d]] = ranges
        # Ranges : [a, b] / [c, d]
        if (a <= c and b >= d) or (c <= a and d >= b):
            count1 += 1
        if not ((min(a, c) == a and b < c) or (min(a, c) == c and d < a)):
            count2 += 1

    print("Part 1:", count1)
    print("Part 2:", count2)


if __name__ == "__main__":
    main()
