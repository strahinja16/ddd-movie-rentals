using System;
namespace Core.Models
{
    public class FullName : ValueObject<FullName>
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        private FullName() { }

        public static FullName Create(string name, string lastName)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));

            return new FullName() { Name = name, LastName = lastName };
        }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}
