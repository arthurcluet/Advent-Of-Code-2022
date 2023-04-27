#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <functional>
#include "Monkey.hpp"

std::vector<std::string> split(std::string input, std::string delimiter)
{
    std::vector<std::string> items;
    int start = 0;
    while (input.find(delimiter, start) != std::string::npos)
    {
        int index = input.find(delimiter, start);
        items.push_back(input.substr(start, index - start));
        start = index + delimiter.length();
    }
    items.push_back(input.substr(start, input.length() - start));

    return items;
}

long compute(bool part2 = false)
{
    // Lecture du fichier
    std::string filename = "input.txt";
    std::ifstream reader(filename);
    std::vector<std::string> lines;
    for (std::string line; getline(reader, line);)
    {
        lines.push_back(line);
    }

    // Transformation en objets
    std::vector<Monkey *> monkeys;
    int smod = 1;

    for (int i = 0; i < (lines.size() + 1) / 7; i++)
    {

        // Items
        std::vector<long> items;
        std::string itemsStr = lines[i * 7 + 1].substr(18);
        int start = 0;
        while (itemsStr.find(", ", start) != std::string::npos)
        {
            int index = itemsStr.find(", ", start);
            // std::cout << itemsStr.substr(start, index - start) << std::endl;
            items.push_back(std::stol(itemsStr.substr(start, index - start)));
            start = index + 2;
        }
        items.push_back(std::stol(itemsStr.substr(start, itemsStr.length() - start)));

        // Operation
        std::string operationStr = lines[i * 7 + 2].substr(19);
        // Parsing
        std::vector<std::string> operands = split(operationStr, " ");

        std::function<long(long)> operation = [operands](long old)
        {
            long a;
            if (operands[0] == "old")
                a = old;
            else
                a = stol(operands[0]);

            long b;
            if (operands[2] == "old")
                b = old;
            else
                b = stol(operands[2]);

            if (operands[1] == "*")
            {
                // *
                return a * b;
            }
            else
            {
                // +
                return a + b;
            }
        };

        // Test

        int n = stoi(lines[i * 7 + 3].substr(21));
        int a = stoi(lines[i * 7 + 4].substr(29));
        int b = stoi(lines[i * 7 + 5].substr(30));
        smod *= n;

        std::function<int(long)> test = [n, a, b](long old)
        {
            return (old % n == 0) ? a : b;
        };
        Monkey *monkey = new Monkey(items, operation, test);
        monkeys.push_back(monkey);
    }

    // Now we got monkeys
    int nb_rounds = part2 ? 10000 : 20;

    for (int k = 0; k < nb_rounds; k++)
    {
        for (int i = 0; i < monkeys.size(); i++)
        {
            auto monkey = monkeys[i];
            while (monkey->getItems().size() > 0)
            {
                long item = monkey->shiftItems();
                monkey->incrementInspections();
                item = monkey->operation(item);
                if (part2)
                    item %= smod;
                else
                    item /= 3;
                int target = monkey->test(item);
                if (item < 0)
                    std::cout << item << std::endl;
                monkeys[target]->addItem(item);
            }
        }
    }

    std::vector<int> inspections;
    for (int i = 0; i < monkeys.size(); i++)
    {
        auto monkey = monkeys[i];
        inspections.push_back(monkey->getInspections());
    }
    sort(inspections.begin(), inspections.end());

    long m1 = inspections[inspections.size() - 1];
    long m2 = inspections[inspections.size() - 2];
    long result = m1 * m2;

    return result;
}

int main()
{
    std::cout << compute(true) << std::endl;
    return 0;
}