using DotNet8.EFCoreRawSqlSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.EFCoreRawSqlSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            try
            {
                string query = @"
        SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
        FROM [dbo].[Tbl_blog]
        ORDER BY BlogId DESC";

                var lst = _appDbContext.TblBlogs
                    .FromSqlRaw(query)
                    .AsNoTracking()
                    .ToList();

                return Ok(lst);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
