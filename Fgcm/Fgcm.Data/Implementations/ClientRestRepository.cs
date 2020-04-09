using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fgcm.Common;
using Fgcm.Data.Definitions;
using Fgcm.Domain;

namespace Fgcm.Data.Implementations
{
    public class ClientRestRepository : BaseRestClient, IClientRestRepository
    {
        public async Task<IEnumerable<Photo>> GetAllPhotos()
        {
            return await Get<IEnumerable<Photo>>("photos");
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await Get<IEnumerable<Comment>>("comments");
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await Get<IEnumerable<Album>>("albums");
        }

        public ClientRestRepository() : base("https://jsonplaceholder.typicode.com/")
        {
        }
    }
}
