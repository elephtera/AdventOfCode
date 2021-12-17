namespace AdventOfCode2021.Assignments
{
    /**
     * 
     */
    public class Day17 : IDay
    {


        public string PartA()
        {
            //target area: x=138..184, y=-125..-71

            // We can get the highest Y if x "stops" in the range of the trench. Because we can shoot the probe high in the air, and it will drop down untill the trench is reached.
            var validXes = new List<int>();
            for(int x = 0; x < 50; x++)
            {
                var xRes = x * (x / 2.0);
                if (138 <= xRes && xRes <= 184)
                {
                    validXes.Add(x);
                }
            }

            var maxY = 0;

            foreach(var x in validXes)
            {
                for(int y = 0; y < 2000; y++)
                {
                    var probe = new Probe(x, y);
                    while (probe.Step()) ;
                    if (probe.IsInTrench())
                    {
                        maxY = Math.Max(maxY, probe.MaxY);
                    }
                }
            }
            
            return maxY.ToString();
        }

        public string PartB()
        {
            var count = 0;

            // Only X-es between 17 and 185 can reach the trench.
            for (int x = 17; x < 185; x++)
            {

                for (int y = -125; y < 2000; y++)
                {
                    var probe = new Probe(x, y);
                    while (probe.Step()) ;
                    if (probe.IsInTrench())
                    {
                        count++;
                    }
                }
            }

            return count.ToString();
        }

    }

    public class Probe
    {
        private int y;

        public int X { get; private set; }
        public int Y
        {
            get => y;

            private set
            {
                y = value;
                MaxY = Math.Max(y, MaxY);
            }
        }

        public int MaxY { get; private set; }

        public int VelocityX { get; private set; }
        public int VelocityY { get; private set; }

        public Probe(int velocityX, int velocityY)
        {
            X = 0;
            Y = 0;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        /**
         * Perform a step with the following actions
         * The probe's x position increases by its x velocity.
         * The probe's y position increases by its y velocity.
         * Due to drag, the probe's x velocity changes by 1 toward the value 0; that is, it decreases by 1 if it is greater than 0, increases by 1 if it is less than 0, or does not change if it is already 0.
         * Due to gravity, the probe's y velocity decreases by 1.
        */
        public bool Step()
        {
            X += VelocityX;
            Y += VelocityY;

            if (VelocityX > 0)
            {
                VelocityX--;
            }
            else if (VelocityX < 0)
            {
                VelocityX++;
            }

            VelocityY--;

            return ShouldContinueStepping();
        }

        public bool ShouldContinueStepping()
        {
            return !IsInTrench() && !Overshoot();
        }

        public bool IsInTrench()
        {
            var validX = 138 <= X && X <= 184;
            var validY = -125 <= Y && Y <= -71;
            return validX && validY;
        }

        public bool Overshoot()
        {
            return X > 184 || Y < -125;
        }

    }


}
