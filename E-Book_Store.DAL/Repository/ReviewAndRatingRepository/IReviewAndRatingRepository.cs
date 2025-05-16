namespace E_Book_Store.DAL.Repository.ReviewAndRatingRepository;

public interface IReviewAndRatingRepository
{
    IQueryable<ReviewAndRating> GetAll();
    ReviewAndRating GetById(int id);
    void insert(ReviewAndRating reviewAndRating);
    void update(ReviewAndRating reviewAndRating);
    void delete(ReviewAndRating reviewAndRating);
}