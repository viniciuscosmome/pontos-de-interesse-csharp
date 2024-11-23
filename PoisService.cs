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

        public async Task<IResult> FindByDistance(int d, int x, int y, PoisDb db)
        {
            int TopLimit = y + d;
            int BottomLimit = y - d;
            int RightLimit = x + d;
            int LeftLimit = x - d;

            List<PoisModel> PoisResponse = [];

            var ApproximatePoisFound = await db.PoisModel.Where((poi) => (            
                poi.CoordX <= RightLimit &&
                poi.CoordX >= LeftLimit &&
                poi.CoordY <= TopLimit &&
                poi.CoordY >= BottomLimit
            )).ToListAsync();

            foreach(PoisModel Poi in ApproximatePoisFound)
            {
                double PowerCO = Math.Pow(x - Poi.CoordX, 2.0d);
                double PowerCA = Math.Pow(y - Poi.CoordY, 2.0d);

                double PoisDistance = Math.Sqrt(PowerCO + PowerCA);

                bool IsValidRange = PoisDistance <= d;

                if (IsValidRange)
                {
                    PoisResponse.Add(Poi);
                }
            }

            if (PoisResponse.Count < 1)
            {
                return TypedResults.NotFound($"Não encontramos nenhum POI a {d} metros da localização informada.");
            }

            return TypedResults.Ok(PoisResponse);
        }

        public async Task<IResult> RegisterPois(PoisModel input, PoisDb db)
        {
            db.PoisModel.Add(input);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/pois/ver/{input.Id}", input);
        }

        public async Task<IResult> UpdatePois(int id, PoisModel input, PoisDb db)
        {
            var PoiFound = await db.PoisModel.FindAsync(id);

            if (PoiFound is null)
            {
                return TypedResults.NotFound("Ponto de interesse não encontrado. (x={input.CoordX}, y={input.CoordY})");
            }

            PoiFound.Name = input.Name;
            PoiFound.CoordX = input.CoordX;
            PoiFound.CoordY = input.CoordY;

            await db.SaveChangesAsync();

            return TypedResults.Ok("Ponto de interesse atualizado");
        }
    }
}
