using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class DbService : IDbService<Musician>
    {
        private readonly s17064Context context;

        public DbService(s17064Context con)
        {
            context = con;
        }
        public IEnumerable<Musician> GetMusician(int id)
        {
            List<Track> list;
            var res = context.Musician.Where(m => m.IdMusician == id).ToList();
            var res1 = context.MusicianTrack.Where(mt => mt.MusicianIdMusician == id).Select(x => new
            {
                idTrack = x.TrackIdTrack

            });
          /*  foreach(var idt in res1)
            {
                var res2 = context.Track.Where(t => t.IdTrack == idt).FirstOrDefault();
            } */
            return res;
            
        }
    }
}
