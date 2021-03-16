using MarchMadness.Data;
using MarchMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Services
{
    public class StadiumService
    {
        private readonly Guid _userId;

        public StadiumService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStadium(StadiumCreate model)
        {
            var entity =
                new Stadium()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Location = model.Location,
                    Capacity = model.Capacity
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stadium.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StadiumListItem> GetStadium()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stadium
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new StadiumListItem
                                {
                                    StadiumId = e.StadiumId,
                                    Name = e.Name,
                                    Location = e.Location,
                                    Capacity = e.Capacity
                                }
                        );

                return query.ToArray();
            }
        }

        public StadiumDetail GetStadiumById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stadium
                        .Single(e => e.StadiumId == id && e.OwnerId == _userId);
                return
                    new StadiumDetail
                    {
                        StadiumId = entity.StadiumId,
                        Name = entity.Name,
                        Location = entity.Location,
                        Capacity = entity.Capacity,
                        BuildDate = entity.BuildDate,
                    };
            }
        }
    }
