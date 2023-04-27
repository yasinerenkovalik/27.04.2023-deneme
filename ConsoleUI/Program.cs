// See https://aka.ms/new-console-template for more information
using Bussines.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using DataAccess.Concrete.InMemory;

Console.WriteLine("Hello, World!");

NewMethod();
//NewMethod1();

static void NewMethod()
{
    ProductManager productManager = new ProductManager(new EfProductDal());


    foreach (var item in productManager.GetDetail().Data)
    {

        Console.WriteLine(item.CategoryName);
    }
}

static void NewMethod1()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var item in categoryManager.GetAll())
    {

        Console.WriteLine(item.CategoryId);
    }
}