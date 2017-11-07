namespace Leaf
{
    public class Attribute
    {
        public string Name { get; }
        public string Value { get; set; }
        public Attribute(string name, string value = null)
        {
            Name = name;
            Value = value;
        }
    }
    public static partial class Extensions
    {
        public static Attribute Copy(this Attribute @this)
            => new Attribute(@this.Name, @this.Value);
    }
}
