using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using LpSolveDotNet;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day10 : IDay<long>
    {
        public long Part1(string input)
        {
            IList<(uint lights, IList<uint> bitmasks, IList<int> jolts)> inputData = ProcessInput(input);

            var result = 0;

            foreach (var (lights, bitmasks, jolts) in inputData)
            {
                result += CalculateToggles(lights, bitmasks, 0, 0);
            }
            return result;
        }

        public static int CalculateToggles(uint lights, IList<uint> bitmasks, uint currentLightsOn, int position)
        {

            // try to get the "lights" value as result for currentLightsOn by applying the bitmasks in any combination


            // check if currentLightsOn is equal to lights, after applying the next bitmask

            if (currentLightsOn == lights)
            {
                return 0;
            }
            if (position >= bitmasks.Count)
            {
                return int.MaxValue;
            }

            var val1 = CalculateToggles(lights, bitmasks, currentLightsOn ^ bitmasks[position], position + 1);
            var val2 = CalculateToggles(lights, bitmasks, currentLightsOn, position + 1);
            return Math.Min(val1 == int.MaxValue ? int.MaxValue : val1 + 1, val2);

        }

        public long Part2(string input)
        {
            LpSolve.Init();
            var Ncol = 2;
            using var lp = LpSolve.make_lp(3, Ncol);

            const double Ignored = 0;

            IList<(IList<IList<int>> buttons, IList<int> jolts)> inputData = Process2Input(input);

            var result = 0;

            foreach (var (buttons, jolts) in inputData)
            {
                result += CalculateJolts(jolts, buttons);
            }

            return result;
        }

        public int CalculateJolts(IList<int> joltEndstate, IList<IList<int>> buttons)
        {
            // We build a model with 3 constraints and 2 variables
            int NVariables = buttons.Count;
            int Nconstraints = joltEndstate.Count;
            using var lp = LpSolve.make_lp(Nconstraints, NVariables);

            // NOTE: set_obj_fnex/add_constraintex should be preferred on set_obj_fn/add_constraint
            //       as they can specify only non-zero elements when working with big model.
            //       The methods without _ex_ suffix will ignore the first array element so
            //       let's use a constant for this for clarity.
            const double Ignored = 0;

            // set the objective function: maximize (143 x + 60 y)
            lp.set_minim();
            
            // Set all output values to be integers
            for(int i = 0; i < NVariables; i++)
            {
                lp.set_int(i + 1, true);
            }

            var objFn = new double[NVariables + 1];
            objFn[0] = Ignored;
            for (int i = 0; i < NVariables; i++)
            {
                // We want to have the minimum of all the buttons pressed,
                // and the variable is the number of times a button is pressed
                objFn[i + 1] = 1;
            }

            lp.set_obj_fn(objFn);

            // add constraints to the model
            lp.set_add_rowmode(true);

            for (int i = 0; i < Nconstraints; i++)
            {
                var constraint = new double[NVariables + 1];
                constraint[0] = Ignored;
                for (int j = 0; j < NVariables; j++)
                {
                    // Each constraint corresponds to a jolt value we want to reach
                    // If the button is pressed, it contributes to the jolt value
                    if (buttons[j].Contains(i))
                    {
                        constraint[j + 1] = 1;
                    }
                    else
                    {
                        constraint[j + 1] = 0;
                    }
                }
                lp.add_constraint(constraint, lpsolve_constr_types.EQ, joltEndstate[i]);
            }

            lp.set_add_rowmode(false);

            // We only want to see important messages on screen while solving
            lp.set_verbose(lpsolve_verbosity.IMPORTANT);

            // Now let lp_solve calculate a solution
            lpsolve_return s = lp.solve();
            if (s == lpsolve_return.OPTIMAL)
            {
                Console.WriteLine("Objective value: " + lp.get_objective());

                var results = new double[NVariables];
                lp.get_variables(results);
                return Convert.ToInt32(lp.get_objective());
            }

            //
            return 0;
        }

        

        public static IList<(uint lights, IList<uint> bitmasks, IList<int> jolts)> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<(uint lights, IList<uint> bitmasks, IList<int> jolts)>();


            var bracketRegex = new Regex(@"\[.*\]");
            var bitmaskRegex = new Regex(@"\(.*?\)");
            var joltsRegex = new Regex(@"\{.*\}");
            foreach (var line in lines)
            {
                var lights = 0u;
                var bitmasks = new List<uint>();
                //regex all between brackets, and convert the string with dots and hashtags to zero's and ones as bitwise representation of an int
                var match = bracketRegex.Match(line);
                var lightsLength = 0;
                if (match.Success)
                {
                    var inner = match.Groups[0].Value[1..^1];
                    lights = CalculateLightEndstate(inner);
                    lightsLength = inner.Length;
                }

                var match2 = bitmaskRegex.Matches(line);
                if (match2.Count > 0)
                {
                    foreach (var group in match2)
                    {
                        uint bitmask = CalculateLightswitch(lightsLength, group.ToString()[1..^1]);
                        bitmasks.Add(bitmask);
                    }
                }

                match = joltsRegex.Match(line);
                var jolts = new List<int>();
                if (match.Success)
                {
                    var inner = match.Groups[0].Value[1..^1].Split(',');

                    for (int i = 0; i < inner.Length; i++)
                    {
                        jolts.Add(int.Parse(inner[i]));
                    }

                }
                result.Add((lights, bitmasks, jolts));
            }
            return result;
        }

        public static IList<(IList<IList<int>> buttons, IList<int> jolts)> Process2Input(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<(IList<IList<int>> buttons, IList<int> jolts)>();

            var bitmaskRegex = new Regex(@"\(.*?\)");
            var joltsRegex = new Regex(@"\{.*\}");
            foreach (var line in lines)
            {
                var buttons = new List<IList<int>>();
                var match2 = bitmaskRegex.Matches(line);

                foreach (var group in match2)
                {
                    var inner = group.ToString()[1..^1].Split(',').Select(v => int.Parse(v)).ToList();
                    buttons.Add(inner);
                }

                var match = joltsRegex.Match(line);
                var jolts = match.Groups[0].Value[1..^1].Split(',').Select(v => int.Parse(v)).ToList();

                result.Add((buttons, jolts));
            }
            return result;
        }

        public static uint CalculateLightEndstate(string lightEndstate)
        {
            var bitmask = Convert.ToUInt32(lightEndstate.Replace(".", "0").Replace("#", "1"), 2);
            return bitmask;
        }

        public static uint CalculateLightswitch(int lightsLength, string switchData)
        {
            var inner = switchData.Split(',');
            char[] mask = new char[lightsLength];
            for (int j = 0; j < mask.Length; j++)
            {
                mask[j] = '0';
            }

            for (int i = 0; i < inner.Length; i++)
            {
                int maskIndex = int.Parse(inner[i]);
                mask[maskIndex] = '1';
            }

            var bitmask = Convert.ToUInt32(new string(mask), 2);
            return bitmask;
        }
    }

}
