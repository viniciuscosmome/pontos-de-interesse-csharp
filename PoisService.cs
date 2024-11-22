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
                double CO = (double) Math.Abs(x - Poi.CoordX);
                double CA = (double) Math.Abs(y - Poi.CoordY);

                double PowerCO = Math.Pow(CO, 2.0d);
                double PowerCA = Math.Pow(CA, 2.0d);

                double Hypotenuse = Math.Round(Math.Sqrt(PowerCO + PowerCA));

                bool IsValidRange = Hypotenuse <= d;

                if (IsValidRange)
                {
                    PoisResponse.Add(Poi);
                }
            }

            if (PoisResponse.Count < 1)
            {
                return TypedResults.NotFound($"Não encontramos nenhum POI à {d} metros da localização informada.");
            }

            return TypedResults.Ok(PoisResponse);
        }

        public async Task<IResult> RegisterPois(PoisModel input, PoisDb db)
        {
            db.PoisModel.Add(input);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/pois/ver/{input.Id}", input);
        }
    }
}
