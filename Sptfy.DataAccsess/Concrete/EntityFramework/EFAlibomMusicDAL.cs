using Microsoft.EntityFrameworkCore;
using Spotfy.Core.DataAccess.EntitFramework;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using SpotfyDataAccess.Concrete.EntityFramework;
using Sptfy.DataAccsess.Abstract;

namespace Sptfy.DataAccsess.Concrete.EntityFramework
{
    public class EFAlibomMusicDAL : EFRepositoryBase<AlibomMusic, AppDbContext>, IAlibomMusicDAL
    {
        public List<AlibomListItemDTO> GetAlibomList(int userId)
        {
            using var context = new AppDbContext();
            var result = context
                .Aliboms
                .Include(x => x.AlibomMusics)
                .ThenInclude(a => a.Music)
                .Where(x => x.UserId == userId)
                .Select(x => new AlibomListItemDTO
                {
                    AlibomId = x.Id,
                    Musics = x.AlibomMusics.Select(z => new AlbomMusicItemsDto
                    {
                        MusicId = z.MusicId,
                        Name = z.Music.Title,
                        PhotoUrl = z.Music.PhotoUrl,
                        MusicUrl = z.Music.MusicUrl
                    }).ToList(),
                })
                .ToList();
            return result;
        }
        public List<AlibomListItemDTO> GetAllAlibomList()
        {
            using var context = new AppDbContext();
            var result = context
                .Aliboms
                .Include(x => x.AlibomMusics)
                .ThenInclude(a => a.Music)
                .Where(x => x.IsAcrive == true)
                .Select(x => new AlibomListItemDTO
                {
                    AlibomId = x.Id,
                    IsAcrive = x.IsAcrive,
                    Musics = x.AlibomMusics.Select(z => new AlbomMusicItemsDto
                    {
                        MusicId = z.MusicId,
                        Name = z.Music.Title,
                        PhotoUrl = z.Music.PhotoUrl,
                        MusicUrl = z.Music.MusicUrl
                    }).ToList(),
                })
                .ToList();
            return result;
        }

    }
}
