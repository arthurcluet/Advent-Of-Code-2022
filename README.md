# Advent Of Code 2022

![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![C++](https://img.shields.io/badge/c++-%2300599C.svg?style=for-the-badge&logo=c%2B%2B&logoColor=white)

### 🌟 Days 1-5
Days 1 to 5 were made in `Python`. You can use your favorite Python interpreter to run it:
```shell
cd Day1
python3 day1.py
```

### 🌟 Days 6-10
Days 6 to 10 were made in `C#`. You can compile and run the code with the _.NET SDK_:
```shell
cd Day5
dotnet run
```

### 🌟 Days 11-15
I'm planning to do days 11 to 15 in `C++`. I use a script `run.sh` to compile and run the program. It works as follows:
```shell
cd Day11
# Create bin folder
mkdir -p bin
# Compiltion with Apple clang (need C++11 for lambdas)
clang++ day11.cpp -std=c++11 -o bin/day11
# Make executable
chmod +x ./bin/day11
# Run
./bin/day11
```
_Feel free to use any C++ compiler. The code above should work on any Mac with XCode or clang installed._

### Progress Capture

<details>
  <summary>Advent Of Code 2022</summary>
  
  <img src="capture.png" alt="Capture" width="600">
  
</details>

#### System Information

_Code should work with older versions and OS._

| Program | Version |
| ---------------- | --- |
| macOS | 13.3.1 (22E261) |
| Python | 3.10.0 |
| .NET | 7.0.203 (Arm64) |
| clang | 14.0.3 (clang-1403.0.22.14.1) |
