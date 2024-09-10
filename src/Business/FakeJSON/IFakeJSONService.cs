using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FakeJSON
{
    public interface IFakeJSONService
    {
        Task<string> GetPosts();
        Task<string> GetPostsById(int id );

        Task<string> GetComments(); 
        Task<string> GetAlbums(); 
        Task<string> GetPhotos();
        Task<string> GetTodos();
        Task<string> GetUsers();
        Task<string> GetCommentsOfPost(int postId);

    }
}
