using Microsoft.EntityFrameworkCore;

namespace PontosDeInteresse
{
    public class PoisRepository
    {
        public async Task<IResult> getAll(PoisDb db)
        {
            var AllPois = await db.PoisModel.ToListAsync();

            return TypedResults.Ok(AllPois);
        }
    }
}
