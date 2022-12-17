namespace AdventOfCode2022Tests.Input
{
    public class Day11Input
    {
        public List<Monkey> ExampleMonkeys => new List<Monkey>(){
            new Monkey()
            {
                ID = 0,
                Items = new List<long>() { 79, 98 },
                Operation = (long old) => { return old * 19; },
                ModuloValue = 23,
                MonkeyTrue = 2,
                MonkeyFalse = 3,
            },
            new Monkey()
            {
                ID = 1,
                Items = new List<long>() { 54, 65, 75, 74 },
                Operation = (long old) => { return old + 6; },
                ModuloValue = 19,
                MonkeyTrue = 2,
                MonkeyFalse = 0,
            },
            new Monkey()
            {
                ID = 2,
                Items = new List<long>() { 79, 60, 97 },
                Operation = (long old) => { return old * old; },
                ModuloValue =  13,
                MonkeyTrue = 1,
                MonkeyFalse = 3,
            },
            new Monkey()
            {
                ID = 3,
                Items = new List<long>() { 74 },
                Operation = (long old) => { return old + 3; },
                ModuloValue = 17,
                MonkeyTrue = 0,
                MonkeyFalse = 1,
            },
        };
        
        public List<Monkey> Monkeys => new List<Monkey>(){
            new Monkey()
            {
                ID = 0,
                Items = new List<long>() { 54, 82, 90, 88, 86, 54 },
                Operation = (long old) => { return old * 7; },
                ModuloValue = 11,
                MonkeyTrue = 2,
                MonkeyFalse = 6,
            },
            new Monkey()
            {
                ID = 1,
                Items = new List<long>() { 91, 65 },
                Operation = (long old) => { return old * 13; },
                ModuloValue = 5,
                MonkeyTrue = 7,
                MonkeyFalse = 4,
            },
            new Monkey()
            {
                ID = 2,
                Items = new List<long>() { 62, 54, 57, 92, 83, 63, 63 },
                Operation = (long old) => { return old + 1; },
                ModuloValue = 7,
                MonkeyTrue = 1,
                MonkeyFalse = 7,
            },
            new Monkey()
            {
                ID = 3,
                Items = new List<long>() { 67, 72, 68 },
                Operation = (long old) => { return old * old; },
                ModuloValue = 2,
                MonkeyTrue = 0,
                MonkeyFalse = 6,
            },
            new Monkey()
            {
                ID = 4,
                Items = new List<long>() { 68, 89, 90, 86, 84, 57, 72, 84 },
                Operation = (long old) => { return old + 7; },
                ModuloValue = 17,
                MonkeyTrue = 3,
                MonkeyFalse = 5,
            },
            new Monkey()
            {
                ID = 5,
                Items = new List<long>() { 79, 83, 64, 58 },
                Operation = (long old) => { return old + 6; },
                ModuloValue = 13,
                MonkeyTrue = 3,
                MonkeyFalse = 0,
            },
            new Monkey()
            {
                ID = 6,
                Items = new List<long>() { 96, 72, 89, 70, 88 },
                Operation = (long old) => { return old + 4; },
                ModuloValue = 3,
                MonkeyTrue = 1,
                MonkeyFalse = 2,
            },
            new Monkey()
            {
                ID = 7,
                Items = new List<long>() { 79 },
                Operation = (long old) => { return old + 8; },
                ModuloValue = 19,
                MonkeyTrue = 4,
                MonkeyFalse = 5,
            },
        };
    }
}
