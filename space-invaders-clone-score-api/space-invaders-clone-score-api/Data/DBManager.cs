using space_invaders_clone_score_api.Entities;

namespace space_invaders_clone_score_api.Data
{
    public class DBManager
    {
        private readonly List<Player> players = [];

        public DBManager()
        {
            players.Add(new Player() { Name = "Pixel Man", Score = 10530});
            players.Add(new Player() { Name = "Bug Boy", Score = 120450 });
        }

        public List<Player> GetPlayers()
        {
            // Aqui vai fazer a comunicação com o banco de dados
            return [.. players.OrderByDescending(player => player.Score)];
        }

        public void AddPlayer(Player player)
        {
            // Aqui vai fazer a comunicação com o banco de dados
            // Ainda falta fazer uma lógida decente para essa parte, já que não vai ter a lista players e sim o retorno do banco
            players.Add(player);
            players.OrderByDescending(player => player.Score);
        }
    }
}
