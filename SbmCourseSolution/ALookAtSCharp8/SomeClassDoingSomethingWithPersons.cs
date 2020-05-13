namespace ALookAtSCharp8
{
    public class SomeClassDoingSomethingWithPersons
    {
        public string CreateNameLine(SomeClassDefiningAPerson person)
        {
            return person.FirstName + " " + person.LastName + "(aka " + person.NickName.ToUpper() + ")";
        }

    }
}