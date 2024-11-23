namespace PontosDeInteresse
{
    public class PoisSeed(PoisDb db)
    {
        private readonly PoisModel[] Locations = [
            new() { Id = 1, Name = "Lanchonete", CoordX = 27, CoordY = 12 },
            new() { Id = 2, Name = "Posto", CoordX = 31, CoordY = 18 },
            new() { Id = 3, Name = "Joalheria", CoordX = 15, CoordY = 12 },
            new() { Id = 4, Name = "Floricultura", CoordX = 19, CoordY = 21 },
            new() { Id = 5, Name = "Pub", CoordX = 12, CoordY = 8 },
            new() { Id = 6, Name = "Supermercado", CoordX = 23, CoordY = 6 },
            new() { Id = 7, Name = "Churrascaria", CoordX = 28, CoordY = 2 }
        ];

        public async void SeedData()
        {
            try
            {
                Console.WriteLine("-------- START SEED ---------");

                db.PoisModel.AddRange(Locations);
                await db.SaveChangesAsync();

                Console.WriteLine("A basse de dados foi populada");
            } catch (Exception Error)
            {
                Console.WriteLine("Erro ao tentar popular a base de dados");
                Console.WriteLine(Error);
            } finally
            {
                Console.WriteLine("---------- END SEED ---------");
            }
        }
    }
}
