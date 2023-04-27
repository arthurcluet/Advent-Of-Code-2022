/*

    The Monkey class represents a monkey as described in the input file.
    It contains:
        - the items held by the monkey (as a number, the worry level)
        - an operation function
            (how your worry level changes as that monkey inspects an item)
        - a test function
            (shows how the monkey uses your worry level to decide where to throw an item next)

    https://adventofcode.com/2022/day/11

*/

#ifndef Monkey_hpp
#define Monkey_hpp

#include <vector>
#include <functional>

class Monkey
{
private:
    std::vector<long> _items;
    std::function<long(long)> _operation;
    std::function<int(long)> _test;
    int _inspections;

public:
    Monkey(std::vector<long> items, std::function<long(long)> operationFunc, std::function<int(long)> testFunc)
    {
        _operation = operationFunc;
        _test = testFunc;
        _items = items;
        _inspections = 0;
    }

    long operation(long x)
    {
        return _operation(x);
    }

    int test(long x)
    {
        return _test(x);
    }

    long shiftItems()
    {
        long e = _items.front();
        _items.erase(_items.begin());
        return e;
    }

    void addItem(long e)
    {
        _items.push_back(e);
    }

    std::vector<long> getItems()
    {
        return _items;
    }

    void incrementInspections()
    {
        _inspections++;
    }

    int getInspections()
    {
        return _inspections;
    }
};

#endif