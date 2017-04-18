using System;

namespace AspNetMVC5Demo.Domian.Model
{
    public class AbortTask : EntityBase
    {
        public AbortTask()
        {

        }

        public AbortTask(string name, string content)
        {
            this.Name = name;
            this.Content = content;
        }

        public string Name { get; set; }

        public string Content { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public void Translate(int from, int to)
        {
            this.From = from;
            this.To = to;
        }

        public void Translate(Account from, Account to)
        {
            if (from == null)
            {
                throw new ArgumentNullException();
            }
            if (to == null)
            {
                throw new ArgumentNullException();
            }

            this.From = from.Id;
            this.To = to.Id;
        }
    }
}