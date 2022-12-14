
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;


namespace WebApi.BookOPerations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
             var bookList=_dbcontext.Books.OrderBy(x=> x.Id).ToList<Book>();
             List<BooksViewModel> vm =_mapper.Map<List<BooksViewModel>>(bookList);//new List<BooksViewModel>();
             //foreach (var book in bookList)
             //{
             //   vm.Add(new BooksViewModel(){
             //       Title=book.Title,
             //       Genre=((GenreEnum)book.GenreId).ToString(),
             //       PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
             //       PageCount=book.PageCount
             //   });
             //}

            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        
    }
}