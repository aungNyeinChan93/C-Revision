using DatabaseTwo.Models;
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

        public List<Quote>? AllQuotes()
        {
            var quotes = _db.Quotes.AsNoTracking().ToList();
            return quotes;
        }

        public Quote? GetQuote(int id)
        {
            var quote = _db.Quotes.AsNoTracking().FirstOrDefault(q => q.QuoteId == id);
            return quote;
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
