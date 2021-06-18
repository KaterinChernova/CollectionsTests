namespace Collections
{
    public class Model
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Model ? this.Id == (obj as Model).Id : false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
