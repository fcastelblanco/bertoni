using System.Collections.Generic;
using System.Threading.Tasks;
using Fgcm.Domain;

namespace Fgcm.ApplicationService.Definitions
{
    public interface IGeneralApplicationService
    {
        Task<IEnumerable<Photo>> GetAllPhotos();

        Task<IEnumerable<Comment>> GetAllComments();

        Task<IEnumerable<Album>> GetAllAlbums();
    }
}
