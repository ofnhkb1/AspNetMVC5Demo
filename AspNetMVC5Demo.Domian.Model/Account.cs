namespace AspNetMVC5Demo.Domian.Model
{
    public class Account : EntityBase
    {
        public Account()
        {

        }

        public Account(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}