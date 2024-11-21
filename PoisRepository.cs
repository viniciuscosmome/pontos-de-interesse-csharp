using Microsoft.EntityFrameworkCore;

namespace PontosDeInteresse
{
    public class PoisRepository
    {
        public async Task<IResult> GetAll(PoisDb db)
        {
            var AllPois = await db.PoisModel.ToListAsync();

            return TypedResults.Ok(AllPois);
        }

        public async Task<IResult> RegisterPois(PoisModel input, PoisDb db)
        {
            await db.PoisModel.AddAsync(input);
            await db.SaveChangesAsync();

            return TypedResults.Created("/pois");
        }
    }
}
