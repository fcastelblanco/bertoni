using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Fgcm.Domain;

namespace Fgcm.Data.Definitions
{
    public interface IClientRestRepository
    {
        Task<IEnumerable<Photo>> GetAllPhotos();

        Task<IEnumerable<Comment>> GetAllComments();

        Task<IEnumerable<Album>> GetAllAlbums();
    }
}
