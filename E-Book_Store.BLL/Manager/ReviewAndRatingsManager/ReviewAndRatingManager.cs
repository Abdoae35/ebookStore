using E_Book_Store.BLL.Dtos.ReviewAndRatingDtos;
using E_Book_Store.DAL.Repository.ReviewAndRatingRepository;

namespace E_Book_Store.BLL.Manager.ReviewAndRatingsManager;

public class ReviewAndRatingManager : IReviewAndRatingManager
{
    private readonly IReviewAndRatingRepository  _reviewAndRatingRepository;

    public ReviewAndRatingManager(IReviewAndRatingRepository reviewAndRatingRepository)
    {
        _reviewAndRatingRepository = reviewAndRatingRepository;
    }
    public IEnumerable<ReviewAndRatingReadDto> GetAll()
    {
        var model = _reviewAndRatingRepository.GetAll().Select(a=> new ReviewAndRatingReadDto
        {
          NumStar = a.NumStar,
          Description = a.Description,
          BookId =a.BookId,
          UserId = a.UserId
        }).ToList();
        return model;
    }

    public ReviewAndRatingReadDto GetById(int id)
    {
      var model = _reviewAndRatingRepository.GetById(id);
      ReviewAndRatingReadDto modelDto = new ReviewAndRatingReadDto()
      {
          NumStar = model.NumStar,
          Description = model.Description,
          BookId = model.BookId,
          UserId = model.UserId,
      };
      
      return modelDto;
    }

    public void insert(ReviewAndRatingAddDto reviewAndRatingAddDto)
    {
        ReviewAndRating model = new ReviewAndRating()
        {
            NumStar = reviewAndRatingAddDto.NumStar,
            Description = reviewAndRatingAddDto.Description,
            BookId = reviewAndRatingAddDto.BookId,
            UserId = reviewAndRatingAddDto.UserId,
        };
         _reviewAndRatingRepository.insert(model);
    }

    public void update(ReviewAndRatingUpdateDto reviewAndRatingUpdateDto)
    {
        var modelfromDb = _reviewAndRatingRepository.GetById(reviewAndRatingUpdateDto.RateId);
        modelfromDb.NumStar = reviewAndRatingUpdateDto.NumStar;
        modelfromDb.Description = reviewAndRatingUpdateDto.Description;
        modelfromDb.BookId = reviewAndRatingUpdateDto.BookId;
        modelfromDb.UserId = reviewAndRatingUpdateDto.UserId;
        _reviewAndRatingRepository.update(modelfromDb);
    }

    public void delete(int id)
    {
        var model = _reviewAndRatingRepository.GetById(id);
        _reviewAndRatingRepository.delete(model);
    }
}