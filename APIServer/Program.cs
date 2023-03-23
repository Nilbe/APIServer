WebApplication app = WebApplication.Create();

app.Urls.Add("https://localhost:3000");
app.Urls.Add("https://*:3000");

List<Superhero> heroes = new();

heroes.Add(new() {Name = "Superman", Looks = "", Strength = 100});
heroes.Add(new() {Name = "Batman", Looks = "", Strength = 100});
heroes.Add(new() {Name = "Ulf", Looks = "", Strength = 100});

app.MapGet("/", Answer);

app.MapGet("/superhero/", () => {
    return heroes;
});

app.MapGet("/superhero/{num}", (int num) =>
{
    if(num >= 0 && num < heroes.Count)
    {
        return Results.Ok(heroes[num]);
    }

    return Results.NotFound();
});

app.MapPost("/superhero", (Superhero hero) =>
{
    Console.WriteLine("Added superhero" + hero.Name);

    heroes.Add(hero);
});

app.Run();

static string Answer()
{
    return "hello";
}