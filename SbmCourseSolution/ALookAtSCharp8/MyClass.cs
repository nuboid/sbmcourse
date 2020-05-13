namespace ALookAtSCharp8
{
    public class SomeClassDefiningAPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public SomeClassDefiningAPerson()
        {
            LastName = "";
        }
        public SomeClassDefiningAPerson(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        //public SomeClassDefiningAPerson()
        //{
        //    FirstName = "";
        //}

        public string CreateNameLine()
        {
            return this.FirstName + " " + this.LastName + "(aka " + this.NickName.ToUpper() + ")";
        }
    }
}