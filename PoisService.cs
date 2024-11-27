using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace PontosDeInteresse
{
    public class PoisService
    {
        public async Task<IResult> GetAll(PoisDb db)
        {
            var AllPois = await db.PoisModel.ToListAsync();

            object responseBody = new { count = AllPois.Count, data = AllPois };

            return TypedResults.Ok(responseBody);
        }

        public async Task<IResult> FindBydId(int id, PoisDb db)
        {
            object responseBody;
            var PoiFound = await db.PoisModel.FindAsync(id);

            if (PoiFound is null)
            {
                responseBody = new { message = $"O ponto de interesse não foi encontrado." };
                return TypedResults.NotFound(responseBody);
            }

            responseBody = new { data = PoiFound };

            return TypedResults.Ok(responseBody);
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

            object responseBody;

            if (PoisResponse.Count < 1)
            {
                responseBody = new { message = $"Não encontramos nenhum POI a {d} metros da localização informada." };

                return TypedResults.NotFound(responseBody);
            }

            responseBody = new { count = PoisResponse.Count, data = PoisResponse };

            return TypedResults.Ok(responseBody);
        }

        public async Task<IResult> RegisterPois(PoisModel input, PoisDb db)
        {
            db.PoisModel.Add(input);
            await db.SaveChangesAsync();

            object responseBody = new { data = input };

            return TypedResults.Created($"/pois/ver/{input.Id}", responseBody);
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

            object responseBody = new { message = "Ponto de interesse atualizado" };

            return TypedResults.Ok(responseBody);
        }

        public async Task<IResult> DeletePois(int id, PoisDb db)
        {
            var Poi = await db.PoisModel.FindAsync(id);

            if (Poi is null)
            {
                return TypedResults.NotFound("O ponto de interesse informado não existe na base de dados");
            }

            db.PoisModel.Remove(Poi);
            await db.SaveChangesAsync();

            object responseBody = new { message = "Ponto de interesse removido da base de dados." };

            return TypedResults.Ok(responseBody);
        }
    }
}
