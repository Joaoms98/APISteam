using APISteam.Domain.Entities;
using APISteam.Infra.Data;
using Bogus;

namespace Tests.Helpers;

public class FakeDataHelper
{
    private readonly Faker Fake;
    private DataContext _context;

    public FakeDataHelper(DataContext context)
    {
        Fake = new Faker("en");
        _context = context;
    }

    public Genre SetupGenre(Genre baseData = null)
    {
        var genre = new Genre()
        {
            Id = baseData?.Id ?? Guid.NewGuid(),
            Type = baseData?.Type ?? Fake.Random.Int(0,8),
            Image =  baseData?.Image ?? Fake.Image.LoremPixelUrl("random"),
        };

        _context.Add(genre);
        _context.SaveChanges();

        return genre;
    }

    public User SetupUser(User baseData = null)
    {
        var user = new User()
        {
            Id = baseData?.Id ?? Guid.NewGuid(),
            NickName = baseData?.NickName ?? Fake.Internet.UserName(),
            Email =  baseData?.Email ?? Fake.Internet.Email(),
            Password =  baseData?.Email ?? Fake.Internet.Password(),
            RealName = baseData?.RealName ?? Fake.Person.FullName,
            Resume = baseData?.Resume ?? Fake.Lorem.Text(),
            Country = baseData?.Country ?? Fake.Address.Country(),
            State = baseData?.State ?? Fake.Address.State(),
            City = baseData?.City ?? Fake.Address.City(),
            Photo = baseData?.Photo ?? Fake.Image.LoremPixelUrl("people")
        };

        _context.Add(user);
        _context.SaveChanges();

        return user;
    }
}
