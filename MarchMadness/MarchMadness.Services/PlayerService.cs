using MarchMadness.Data;
using MarchMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Services
{
    public class PlayerService
    {
        private readonly Guid _userId;

        public PlayerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlayer(PlayerCreate model)
        {
            var entity =
                new Player()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Position = model.Position,
                    SeasonTotalPoints = model.SeasonTotalPoints
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PlayerListItem
                                {
                                    PlayerId = e.PlayerId,
                                    Name = e.Name,
                                    SeasonTotalPoints = e.SeasonTotalPoints
                                }
                        );

                return query.ToArray();
            }
        }

        public PlayerDetail GetPlayerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == id && e.OwnerId == _userId);
                return
                    new PlayerDetail
                    {
                        PlayerId = entity.PlayerId,
                        Name = entity.Name,
                        Position = entity.Position,
                        SeasonTotalPoints = entity.SeasonTotalPoints,
                    };
            }
        }

        public bool UpdatePlayer(PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.PlayerId && e.OwnerId == _userId);

                entity.SeasonRebounds = model.SeasonRebounds;
                entity.SeasonAssists = model.SeasonAssists;
                entity.SeasonTotalPoints = model.SeasonTotalPoints;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
