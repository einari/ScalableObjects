namespace Objects
{
    public class Color
    {
        public Color() { }

        public Color(float red, float green, float blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public override bool Equals(object obj)
        {
            var otherColor = obj as Color;
            return otherColor.Red == Red && otherColor.Green == Green && otherColor.Blue == Blue;
        }

        public override int GetHashCode()
        {
            return Red.GetHashCode() + Green.GetHashCode() + Blue.GetHashCode();
        }
    }
}
