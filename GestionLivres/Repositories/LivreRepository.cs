using GestionLivres.DataModels;
using GestionLivres.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net;
using Dapper;

namespace GestionLivres.Repositories
{
    public class LivreRepository : ILivreRepository
    {
        private readonly GestionLivresContext context;
        public LivreRepository(GestionLivresContext context)
        {
            this.context = context;
        }

        public async Task<Livre> AddLivreAsync(Livre request)
        {
            var livre = await context.Livres.AddAsync(request);
            await context.SaveChangesAsync();

            return livre.Entity;
        }

        public async Task<Livre> DeleteLivreAsync(int livreId)
        {
            var livre = await GetLivreAsync(livreId);

            if (livre != null)
            {
                context.Livres.Remove(livre);
                await context.SaveChangesAsync();

                return livre;
            }

            return null;
        }

        public async Task<bool> Exist(int livreId)
        {
            return await context.Livres.AnyAsync(s => s.Id == livreId);
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await context.Category.
                ToListAsync();
        }

        public async Task<Livre> GetLivreAsync(int livreId)
        {
            return await context.Livres
                 .FirstOrDefaultAsync(u => u.Id == livreId);
        }

        public async Task<ICollection> GetLivresAsync()
        {

            var books =  await context.Livres.Include(nameof(Category)).ToListAsync();
            var booksToSend = books.Select(b => new
            {
                b.Id,
                b.Titre,
                b.Category.Libelle,
                b.Category.SubCategory,
                b.Price,
                available = !b.Ordered,
                b.Auteur,
            }).ToList();
            return booksToSend;
        }

        

        public async Task<Livre> UpdateLivreAsync(int livreId, Livre request)
        {
            var existingLivre = await GetLivreAsync(livreId);

            if (existingLivre != null)
            {
                existingLivre.Titre = request.Titre;
                existingLivre.Auteur = request.Auteur;
                existingLivre.CategoryId = request.CategoryId;
                existingLivre.DateEdition = request.DateEdition;
                existingLivre.Disponible = request.Disponible;
                existingLivre.Description = request.Description;
                

                await context.SaveChangesAsync();

                return existingLivre;

            }

            return null;
        }

        public Task<bool> UpdateLivreImage(int livreId, string livreImageUrl)
        {
            throw new NotImplementedException();
        }


        public bool OrderBook(int userId, int livreId)
        {
            var ordered = false;

            var order = new Order
            {
                UserId = userId,
                LivreId = livreId,
                OrderDate = DateTime.Now,
                Returned = 0
            };

            context.Orders.Add(order);
            int rowsAffected = context.SaveChanges();

            if (rowsAffected == 1)
            {
                var livre = context.Livres.Find(livreId);

                if (livre != null)
                {
                    livre.Ordered = true;
                    context.SaveChanges();
                    ordered = true;
                }
            }

            return ordered;
        }

        public IList<Order> GetOrdersOfUser(int userId)
        {
            var user = context.Users.Find(userId);

            var orders = context.Orders
            .Where(o => o.UserId == userId)
            .Select(o => new Order
            {
                Id = o.Id,
                UserId = o.UserId,
                Name = user.FirstName + " " + user.LastName,
                LivreId = o.LivreId,
                BookName = o.Livre.Titre,
                OrderDate = o.OrderDate,
                Returned = o.Returned
            })
            .ToList();

            return orders;
        }

        public IList<Order> GetAllOrders()
        {
            var orders = context.Orders
            .Select(o => new Order
            {
                Id = o.Id,
                UserId = o.UserId,
                Name = o.User.FirstName + " " + o.User.LastName,
                LivreId = o.LivreId,
                BookName = o.Livre.Titre,
                OrderDate = o.OrderDate,
                Returned = o.Returned
            })
            .ToList();

            return orders;
        }

        public bool ReturnBook(int userId, int livreId)
        {
              var returned = false;

            var order = context.Orders
                .Where(o => o.UserId == userId && o.LivreId == livreId && o.Returned == 0)
                .FirstOrDefault();

            if (order != null)
            {
                order.Returned = 1;
                order.OrderDate = DateTime.Now;
                context.SaveChanges();

                var livre = context.Livres.Find(livreId);

                if (livre != null)
                {
                    livre.Ordered = false;
                    context.SaveChanges();
                    returned = true;
                }
            }

            return returned;    
        }
    }
}
