using AutoMapper;
using GestionLivres.DataModels;
using GestionLivres.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionLivres.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public LivreController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllLivres()
        {
            var livres = await uow.LivreRepository.GetLivresAsync();

            return Ok(livres);
        }

        [HttpGet]
        [Route("AllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var categoryList = await uow.LivreRepository.GetAllCategory();

            if (categoryList == null || !categoryList.Any())
            {
                return NotFound();
            }

            return Ok(categoryList);
        }

        [HttpPost]
        [Route("InsertBook")]
        public async Task<IActionResult> AddLivreAsync([FromBody] Livre request)
        {
            //Add livre
            await uow.LivreRepository.AddLivreAsync(request);

            //Return livre
            return Ok(new { Message = "Livre added successfully !!" });

        }

        [HttpGet]
        [Route("/Livres/{livreId:int}")]
        public async Task<IActionResult> GetLivre(int livreId)
        {
            var livre = await uow.LivreRepository.GetLivreAsync(livreId);

            if (livre == null)
            {
                return NotFound();
            }

            return Ok(livre);

        }

        [HttpPut]
        [Route("/Livres/{livreId:int}")]
        public async Task<IActionResult> UpdateLivreAsync([FromRoute] int livreId, [FromBody] Livre requet)
        {
            //Check livre exist
            if (await uow.LivreRepository.Exist(livreId))
            {
                //Update livre
                var updatedLivre = await uow.LivreRepository.UpdateLivreAsync(livreId, requet);

                if (updatedLivre != null)
                {
                    //Return livre
                    return Ok(updatedLivre);
                }

            }
            return NotFound();

        }

        [HttpDelete]
        [Route("/DeleteBook/{livreId:int}")]
        public async Task<IActionResult> deleteLivreAsync([FromRoute] int livreId)
        {
            //Check livre exist
            if (await uow.LivreRepository.Exist(livreId))
            {
                //Delete livre
                var deletedLivre = await uow.LivreRepository.DeleteLivreAsync(livreId);

                if (deletedLivre != null)
                {
                    //Return livre
                    return Ok("success");
                }

            }
            //Livre not found
            return Ok("fail");

        }

        [HttpGet("OrderBook/{userId}/{bookId}")]
        public IActionResult OrderBook(int userId, int bookId)
        {
            var result = uow.LivreRepository.OrderBook(userId, bookId) ? "success" : "fail";

            return Ok(result) ;
            
        }

        [HttpGet("GetOrders/{id}")]
        public IActionResult GetOrders(int id)
        {
            var orders = uow.LivreRepository.GetOrdersOfUser(id);

            return Ok(orders);
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = uow.LivreRepository.GetAllOrders();

            return Ok(orders);
        }

        [HttpGet("ReturnBook/{bookId}/{userId}")]
        public IActionResult ReturnBook(string bookId, string userId)
        {
            var result = uow.LivreRepository.ReturnBook(int.Parse(userId), int.Parse(bookId)) ? "success" : "Not returned";

            return Ok(result);
        }

        [HttpPost("InsertCategory")]
        public IActionResult InsertCategory(Category category)
        {
            category.Libelle = category.Libelle.ToLower();
            category.SubCategory = category.SubCategory.ToLower();
            uow.LivreRepository.InsertCategory(category);
            return Ok("Inserted");
        }

    
    }
}
