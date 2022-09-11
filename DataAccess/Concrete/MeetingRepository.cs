using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class MeetingRepository : BaseRepository<Meeting>
    {
        public MeetingRepository(MeetingDbContext meetingDbContext) : base(meetingDbContext)
        {
        }
    }
}


//1'e çok tablo
//Repository
//Katmanlı 
//WFA
//Fluent Api 
//Buna Git Koyalım Hocam -> Değişiklikleri yapıp gönderelim.