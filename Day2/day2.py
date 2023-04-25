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


def main():
    f = open("input.txt", "r")
    lines = f.read().splitlines()
    print(sum(map(score, lines)))


if __name__ == "__main__":
    main()
