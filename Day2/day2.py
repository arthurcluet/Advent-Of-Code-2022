def score(l):
    dict = {"A": 1, "B": 2, "C": 3, "X": 1, "Y": 2, "Z": 3}
    [a, b] = l.split(' ')
    a = dict[a]
    b = dict[b]
    score = 0
    if a == b:
        score += 3
    elif (b == 3 and a == 2) or (b == 2 and a == 1) or (b == 1 and a == 3):
        score += 6
    score += b
    return score


def part2(l):
    [a, b] = l.split(' ')
    toplay = {
        "A": {
            "X": 3,
            "Y": 1,
            "Z": 2
        },
        "B": {
            "X": 1,
            "Y": 2,
            "Z": 3
        },
        "C": {
            "X": 2,
            "Y": 3,
            "Z": 1
        }
    }
    score = 0
    if b == "X":
        # need to lose
        score += 0
    elif b == "Y":
        score += 3
    elif b == "Z":
        # need to win
        score += 6
    score += toplay[a][b]
    return score


def main():
    f = open("input.txt", "r")
    lines = f.read().splitlines()
    print("Part 1:", sum(map(score, lines)))
    print("Part 2:", sum(map(part2, lines)))


if __name__ == "__main__":
    main()
