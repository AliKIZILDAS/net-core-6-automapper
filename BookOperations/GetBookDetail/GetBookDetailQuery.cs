
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;


namespace WebApi.BookOPerations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;

        public int BookId{get;set;}
        private readonly IMapper _mapper;

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book=_dbcontext.Books.Where(book=> book.Id==BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");
            BookDetailViewModel vm=_mapper.Map<BookDetailViewModel>(book);//new BookDetailViewModel();
            //vm.Title=book.Title;
            //vm.PageCount=book.PageCount;
            //vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy");
            //vm.Genre=((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        
    }
}