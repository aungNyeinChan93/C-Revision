using DatabaseTwo.Models;
using Domain_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_01.Features
{
    public class QuoteService
    {
        private AppDbContext _db;

        public QuoteService()
        {
            _db = new AppDbContext();
        }

        public ResponseModel<List<Quote>>? AllQuotes()
        {
            var responseModel = new ResponseModel<List<Quote>>();
            var quotes = _db.Quotes.AsNoTracking().ToList();
            if(quotes is null)
            {
                responseModel.ResCode = 400;
                responseModel.ResDesc = "Quotes Not Found!";
                responseModel.ResType = EnumResponseType.Error;
                responseModel.IsSuccess = false;
                return responseModel;
            }
            responseModel.ResCode = 200;
            responseModel.ResDesc = "Get All Quotes";
            responseModel.ResType = EnumResponseType.Success;
            responseModel.IsSuccess = true;
            responseModel.Result = quotes;
            return responseModel;
        }

        public ResponseModel<Quote>? GetQuote(int id)
        {
            var quote = _db.Quotes.AsNoTracking().FirstOrDefault(q => q.QuoteId == id);
            if(quote is null)
            {
                return ResponseModel<Quote>.Error(400, "Not Found Quote");
            }
            return ResponseModel<Quote>.Success(200, "Get Quote", quote);
        }

        public bool Create(Quote quote)
        {
            _db.Quotes.Add(quote);
            var res = _db.SaveChanges();
            return res >=1 ? true : false;
        }

        public bool Update(int id,Quote quote)
        {
            var oldQuote = _db.Quotes.AsNoTracking().FirstOrDefault(q => q.QuoteId == id);
            if (oldQuote is null) return false;
            oldQuote.Quote1 = quote.Quote1;
            oldQuote.Author = quote.Author;
            _db.Entry(oldQuote).State = EntityState.Modified;
            var res = _db.SaveChanges();
            return res >= 1 ? true : false;

        }

        public bool Delete(int id)
        {
            var oldQuote = _db.Quotes.AsNoTracking().FirstOrDefault(q => q.QuoteId == id);
            if (oldQuote is null) return false;
            _db.Quotes.Remove(oldQuote);
            _db.Entry(oldQuote).State = EntityState.Deleted;
            var res = _db.SaveChanges();
            return res >= 1 ? true :false;

        }
    }
}
