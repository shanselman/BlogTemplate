using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogTemplate.Models;

namespace BlogTemplate.Pages
{
    public class EditModel : PageModel
    {
        private Blog _blog;
        public Blog Blog { get; set; }

        public EditModel(Blog blog)
        {
            _blog = blog;
        }

        [BindProperty]
        public Post NewPost { get; set; }

        public Post OldPost { get; set; }
        public void OnGet()
        {
            InitializePost();
        }

        private void InitializePost()
        {
            string slug = RouteData.Values["slug"].ToString();
            BlogDataStore dataStore = new BlogDataStore();
            NewPost = OldPost = dataStore.GetPost(slug);

            if(OldPost == null)
            {
                RedirectToPage("/Index");
            }
        }

        public IActionResult OnPostPublish()
        {
            string slug = RouteData.Values["slug"].ToString();
            NewPost.IsPublic = true;
            UpdatePost(NewPost, slug);
            return Redirect($"/Post/{NewPost.Slug}");
        }

        public IActionResult OnPostSaveDraft()
        {
            string slug = RouteData.Values["slug"].ToString();
            NewPost.IsPublic = false;
            UpdatePost(NewPost, slug);
            return Redirect("/Index");
        }

        public void UpdatePost(Post newPost, string slug)
        {
            BlogDataStore dataStore = new BlogDataStore();
            OldPost = dataStore.GetPost(slug);
            newPost.Tags = Request.Form["Tags"][0].Replace(" ", "").Split(",").ToList();
            
            SlugGenerator slugGenerator = new SlugGenerator();
            newPost.Slug = slugGenerator.CreateSlug(newPost.Title);
            newPost.Comments = OldPost.Comments;

            dataStore.UpdatePost(newPost, OldPost);
        }
    }
}