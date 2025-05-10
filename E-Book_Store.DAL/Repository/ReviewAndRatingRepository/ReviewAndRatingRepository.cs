using E_Book_Store.DAL.Context;
using E_Book_Store.DAL.Repository.BookRepository;

namespace E_Book_Store.DAL.Repository.ReviewAndRatingRepository;

public class ReviewAndRatingRepository :IReviewAndRatingRepository
{
    private readonly EbookContext _Context;

    public ReviewAndRatingRepository(EbookContext ebookContext)
    {
        _Context = ebookContext;
    }
    public IQueryable<ReviewAndRating> GetAll()
    {
        return _Context.ReviewsAndRatings.AsNoTracking();
    }

    public ReviewAndRating? GetById(int id)
    {
        var model = _Context.ReviewsAndRatings.Find(id);
        if (model == null)
            return null;
        
        return model;
    }

    public void insert(ReviewAndRating reviewAndRating)
    {
       _Context.Add(reviewAndRating);
       _Context.SaveChanges();
    }

    public void update(ReviewAndRating reviewAndRating)
    {
        _Context.SaveChanges();
    }

    public void delete(ReviewAndRating reviewAndRating)
    {
       _Context.ReviewsAndRatings.Remove(reviewAndRating);
       _Context.SaveChanges();
    }
}