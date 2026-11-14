using System;

namespace TicTacToad
{
    public class BiasProfile
    {
        public double Aggression { get; private set; }
        public double Caution { get; private set; }
        public double DiagonalPreference { get; private set; }
        public double EarlyGameConservatism { get; private set; }

        public int Seed { get; private set; }

        private BiasProfile() { }

        public static BiasProfile Generate(int? seed = null)
        {
            int actualSeed = seed ?? Environment.TickCount;
            var rnd = new Random(actualSeed);

            return new BiasProfile
            {
                Seed = actualSeed,
                Aggression = rnd.NextDouble(),
                Caution = rnd.NextDouble(),
                DiagonalPreference = rnd.NextDouble(),
                EarlyGameConservatism = rnd.NextDouble()
            };
        }

        public double PlayerDiagonalMultiplier => 1.5 + DiagonalPreference * 1.5;
        public double AiStraightMultiplier => 1.5 + Aggression * 2.0;
        public double AiDiagonalMultiplier => 2.0 + ((Aggression + DiagonalPreference) / 2.0) * 2.0;
        public double CautionMultiplier => 1.0 + Caution;

        public bool AvoidsEdgeCenterOpening => EarlyGameConservatism > 0.4;

        public override string ToString()
        {
            return $"BiasProfile(seed={Seed}, Aggression={Aggression:F2}, Caution={Caution:F2}, " +
                   $"DiagonalPreference={DiagonalPreference:F2}, EarlyGameConservatism={EarlyGameConservatism:F2})";
        }
    }
}