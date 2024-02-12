namespace PosgreSqlWithC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PosgresqlWithCsharpClass posgresqlWithCsharpClass = new PosgresqlWithCsharpClass();

            //posgresqlWithCsharpClass.CreateTables();

            //posgresqlWithCsharpClass.InsertTables();



            //posgresqlWithCsharpClass.GetAll();


            //posgresqlWithCsharpClass.GetById(1);

            //posgresqlWithCsharpClass.DeleteAutherCategory();


            //posgresqlWithCsharpClass.UpdateBooks();


            //posgresqlWithCsharpClass.getLike("Turk");


            //posgresqlWithCsharpClass.CreateColumnBooks();


            //posgresqlWithCsharpClass.CreateColumnDefaultBooks();


            //posgresqlWithCsharpClass.RenameColumn();

            posgresqlWithCsharpClass.CreateDatabase1();

            posgresqlWithCsharpClass.CreateDatabase1_FOR_Tables();
        }
    }
}
