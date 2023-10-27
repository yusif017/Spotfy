using Microsoft.EntityFrameworkCore;
using Spotfy.Core.DataAccess.EntitFramework;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.AlibomDTOs;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using SpotfyDataAccess.Concrete.EntityFramework;
using Sptfy.DataAccsess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sptfy.DataAccsess.Concrete.EntityFramework
{
    public class EFAlibomDAL : EFRepositoryBase<Alibom, AppDbContext>, IAlibomDAL
    {
        public List<AlibomGetAllDTO> GetByUserAlibomList()
        {
            using var context = new AppDbContext();
            var result = context
                .Aliboms.Include(x=>x.User)
                .Include(x => x.AlibomMusics)
                .ThenInclude(a => a.Music)
          
                .Select(x => new AlibomGetAllDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    PhotoUrl = x.PhotoUrl,
                    FirstName=x.User.FirstName,
                    LastName=x.User.LastName,
                    userId=x.User.Id,
                    AlbomItems = x.AlibomMusics.Select(z => new AlbomItemsDto
                    {
                        MusicId = z.MusicId,
                        Name = z.Music.Title,
                        PhotoUrl = z.Music.PhotoUrl,
                        MusicUrl=z.Music.MusicUrl
                        
                    }).ToList(),
                })
                .ToList();
            return result;
        }
        public AlibomGetAllDTO GetByAlibomList(int id)
        {
            using var context = new AppDbContext();
            var result = context
                .Aliboms.Include(x => x.User)
                .Include(x => x.AlibomMusics)
                .ThenInclude(a => a.Music)
                .Where(x=>x.Id==id)
                .Select(x => new AlibomGetAllDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    PhotoUrl = x.PhotoUrl,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    userId = x.User.Id,
                    AlbomItems = x.AlibomMusics.Select(z => new AlbomItemsDto
                    {
                        MusicId = z.MusicId,
                        Name = z.Music.Title,
                        PhotoUrl = z.Music.PhotoUrl,
                        MusicUrl = z.Music.MusicUrl

                    }).ToList(),
                }).FirstOrDefault();
            return result;
        }

    }
}
