namespace Collections
{
    public class NewModel
    {
        public NewModel(long id, string name, string fullName)
        {
            Id = id;
            Name = name;
            FullName = fullName;
        }

        public long Id { get; }

        public string Name { get; }

        public string FullName { get; }
    }
}
