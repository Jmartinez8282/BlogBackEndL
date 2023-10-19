using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackEndL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        //Create a variable to hold our data
        private readonly BlogitemService _data;

        //constructor
        public BlogController(BlogitemService dataFromService)
        {
            _data = dataFromService;
        }
        //AddBlogItems
        [HttpPost("AddBlogItems")]
        public bool AddBlogItem(BlogitemModel newBlogItem) {

            return _data.AddBlogItem(newBlogItem);
        }
        //GetAllBlogItems
        [HttpGet("GetBlogItem")]

        public IEnumerable<BlogitemModel> GetAllBlogItems() 
        {
                return _data.GetAllBlogItems();
        }

        //GetBlogItemsByCategory
        [HttpGet("GetItemsByCategory/{Category}")]
        public IEnumerable<BlogitemModel> GetItemsByCategory(string Category) 
        {
                return _data.GetItemsByCategory(Category);
        }
        //GetAllBlgoItemsByTags
        [HttpGet("GetItemsByTag/{Tag}")]
        public List<BlogitemModel> GetItemsByTag(string Tag) 
        {
                return _data.GetItemsByTag(Tag);
        }
        //GetBlogItesmByDate
        [HttpGet("GetItemsByDate/{Date}")]

        public IEnumerable<BlogitemModel> GetItemsByDate(string Date)
        {
            return _data.GetItemsByDate(Date);
        }
        //UpdateBlogItems
        [HttpPost("UpdateBlogItems")]
        public bool UpdateBlogItems(BlogitemModel BlogUpdate)
            {
                return _data.UpdateBlogItems(BlogUpdate);
            }
        //DeleteBlogItems
        [HttpPost("DeleteBlogItem/{BlogItemToDelete}")]

            public bool DeleteBlogItem(BlogitemModel BlogDelete)
            {
                return _data.DeleteBlogItem(BlogDelete);
            }
        //GetPublishedBlogItems
        [HttpGet("GetPublishedItems")]

        public IEnumerable<BlogitemModel> GetPublishedItems()
        {
            return _data.GetPublishedItems();
        }

    [HttpGet("GetItemsByUserID/{UserID}")]

    public IEnumerable<BlogitemModel> GetItemsByUserID(int UserID)
    {
        return _data.GetItemsByUserID(UserID);
    }

    }
}