using System;

namespace AppData.DataModels
{
    public class PowerOutput
    {
        public string Name { get; set; }
        
        public decimal P { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is null))
            {
                var other = (PowerOutput)obj;
                return other.Name == Name && other.P == P;
            }
            return false;
        }

        protected bool Equals(PowerOutput other)
        {
            return Name == other.Name && P == other.P;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, P);
        }
    }
}