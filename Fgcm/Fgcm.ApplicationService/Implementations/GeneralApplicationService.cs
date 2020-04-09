using System.Collections.Generic;
using System.Threading.Tasks;
using Fgcm.ApplicationService.Definitions;
using Fgcm.Data.Definitions;
using Fgcm.Domain;

namespace Fgcm.ApplicationService.Implementations
{
    public class GeneralApplicationService : IGeneralApplicationService
    {
        private readonly IClientRestRepository _clientRestRepository;

        public GeneralApplicationService(IClientRestRepository clientRestRepository)
        {
            _clientRestRepository = clientRestRepository;
        }

        public async Task<IEnumerable<Photo>> GetAllPhotos()
        {
            return await _clientRestRepository.GetAllPhotos();
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _clientRestRepository.GetAllComments();
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await _clientRestRepository.GetAllAlbums();
        }
    }
}