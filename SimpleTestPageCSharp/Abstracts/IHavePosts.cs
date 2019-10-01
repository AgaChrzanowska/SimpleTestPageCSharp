using SimpleTestPageCSharp.Pages;
using SimpleTestPageCSharp.Pages.Fragments;

namespace SimpleTestPageCSharp.Abtracts
{
    public interface IHavePosts
    {
        PostsPageObject GetPosts();
    }
}