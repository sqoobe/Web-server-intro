var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Library library = new Library();


app.MapGet("/book/available", () =>
{
    return library.ListAvailableBooks();
});

app.MapPost("/loan/borrow", (LoanRequest loanRequest) =>
{
    Book? book = library.BorrowBook(loanRequest.Title);

    if (book == null)
    {
        Console.WriteLine("hei");
        //vi har ingen bøker tilgjengelig
        return Results.BadRequest();

    }
    else
    {
        //vi har en bok tilgjengelig
        return Results.Ok(book);
    }
});

app.MapPost("/loan/return", () => "return a book");

app.Run();
