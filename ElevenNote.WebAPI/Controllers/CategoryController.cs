using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryServices CreateCategoryService()
        {
            var categoryService = new CategoryServices();
            return categoryService;
        }

        public IHttpActionResult Post(CategoryCreate category)
        {
            if (ModelState.IsValid)
            {
                var service = CreateCategoryService();

                if (!service.CreateCategory(category))
                {
                    return InternalServerError();
                }
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult Get()
        {
            CategoryServices categoryService = CreateCategoryService();
            var category = categoryService.GetAll();
            return Ok(category);
        }

        public IHttpActionResult Get(int id)
        {
            CategoryServices categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            return Ok(category);
        }

        public IHttpActionResult Put(CategoryEdit category)
        {
            if (ModelState.IsValid)
            {
                var service = CreateCategoryService();
                if (!service.UpdateCategory(category))
                {
                    return InternalServerError();
                }
                return Ok();

            }
            return BadRequest(ModelState);
        }



        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
                return InternalServerError();
            
            return Ok();
        }
    }
}
