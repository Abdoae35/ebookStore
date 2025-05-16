using E_Book_Store.BLL.Dtos.ReviewAndRatingDtos;

namespace E_Book_Store.BLL.Manager.ReviewAndRatingsManager;

public interface IReviewAndRatingManager
{
    IEnumerable<ReviewAndRatingReadDto> GetAll();
    ReviewAndRatingReadDto GetById(int id);
    void insert(ReviewAndRatingAddDto reviewAndRatingAddDto);
    void update(ReviewAndRatingUpdateDto reviewAndRatingUpdateDto);
    void delete(int id);
}