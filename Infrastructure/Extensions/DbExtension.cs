using Domain.Entities;
using Npgsql;

namespace Infrastructure.Extensions;

public static class DbExtension
{
    public static void Initialize()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Status>("advert_status");
    }
}