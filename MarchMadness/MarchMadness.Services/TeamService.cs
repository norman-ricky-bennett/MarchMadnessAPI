using MarchMadness.Data;
using MarchMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    OwnerId = _userId,
                    TeamName = model.TeamName,
                    TeamSeed = model.TeamSeed,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamId,
                                    TeamName = e.TeamName,
                                    TeamSeed = e.TeamSeed
                                }
                        );

                return query.ToArray();
            }
        }

        public TeamDetail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx 
                    .Teams
                    .Single(e => e.TeamId == id && e.OwnerId == _userId);
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        TeamSeed = entity.TeamSeed,
                        Players = 
                        ctx
                        .Players
                        .Where(p => p.TeamId == entity.TeamId)
                        .Select(p =>
                            new PlayerListItem
                            {
                               
                            }
<<<<<<< HEAD
                        ).ToList(),
                        Coach =
                        ctx
                        .Coach
                        .Where(c => c.TeamId == entity.TeamId)
                        .Select(ctx =>
                            new CoachListItem
                            {
                                CoachName = e.CoachName,

                            }
                        
                        )
=======
                        ).ToList()
>>>>>>> 02e1ed31a202094728184ae0c206f7fcb2ad278c
                        //List of PlayerListItem as a prop in TeamDetail
                        //Add TeamId to your Player class
                        //Do a nested query here.
                    };
            }
        }
        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == model.TeamId && e.OwnerId == _userId);
                entity.TeamName = model.TeamName;
                entity.TeamSeed = model.TeamSeed;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

