using Microsoft.EntityFrameworkCore;

namespace PontosDeInteresse
{
    public class PoisService
    {
        public async Task<IResult> GetAll(PoisDb db)
        {
            var AllPois = await db.PoisModel.ToListAsync();

            return TypedResults.Ok(AllPois);
        }

        public async Task<IResult> FindBydId(int id, PoisDb db)
        {
            var PoiFound = await db.PoisModel.FindAsync(id);

            if (PoiFound is not null && PoiFound is PoisModel)
            {
                return TypedResults.Ok(PoiFound);
            }

            return TypedResults.NotFound($"O ponto de interesse com id {id} não foi encontrado.");
        }

        public async Task<IResult> RegisterPois(PoisModel input, PoisDb db)
        {
            await db.PoisModel.AddAsync(input);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/pois/ver/{input.Id}", input);
        }
    }
}
