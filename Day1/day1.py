def main():
    f = open("input.txt", "r")
    arr = [0]
    count = 0
    lines = f.read().splitlines()
    for l in lines:
        if len(l) > 0:
            arr[count] += int(l)
        else:
            count += 1
            arr.append(0)
    print(max(arr))


if __name__ == "__main__":
    main()
