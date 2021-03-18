using MarchMadness.Data;
using MarchMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Services
{
    public class CoachService
    {
        private readonly Guid _userId;
        public CoachService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCoach(CoachCreate model)
        {
            var entity =
                new Coach()
                {
                    CoachName = model.CoachName,
                    SeasonRecord = model.SeasonRecord,
                    OverallRecord = model.OverallRecord,
                    MarchMadnessRecord = model.MarchMadnessRecord,
                    TeamId = model.TeamId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Coach.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CoachListItem> GetCoach()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Coach
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CoachListItem
                                {
                                    CoachID = e.CoachId,
                                    CoachName = e.CoachName,
                                    SeasonRecord = e.SeasonRecord,
                                    OverallRecord = e.OverallRecord,
                                    MarchMadnessRecord = e.MarchMadnessRecord,
                                    TeamId = e.TeamId,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateCoach(CoachEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Coach
                        .Single(e => e.CoachName == model.CoachName && e.OwnerId == _userId);

                entity.CoachName = model.CoachName;
                entity.SeasonRecord = model.SeasonRecord;
                entity.OverallRecord = model.OverallRecord;
                entity.MarchMadnessRecord = model.MarchMadnessRecord;
                entity.TeamId = model.TeamId;


                return ctx.SaveChanges() == 1;


            }
        }

        public bool DeleteCoach(int coachId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Coach
                        .Single(e => e.CoachId == coachId && e.OwnerId == _userId);

                ctx.Coach.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
