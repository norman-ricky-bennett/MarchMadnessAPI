﻿using MarchMadness.Data;
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
                                }
                        );

                return query.ToArray();
            }
        }
    }
}