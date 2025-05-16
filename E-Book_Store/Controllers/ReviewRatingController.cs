using E_Book_Store.BLL.Dtos.ReviewAndRatingDtos;
using E_Book_Store.BLL.Manager.ReviewAndRatingsManager;
using Microsoft.AspNetCore.Mvc;

namespace E_Book_Store.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReviewRatingController : ControllerBase
{
  private readonly IReviewAndRatingManager  _reviewAndRatingManager;

  public ReviewRatingController(IReviewAndRatingManager reviewAndRatingManager)
  {
    _reviewAndRatingManager = reviewAndRatingManager;
  }


  [HttpGet]
  public IActionResult GetAll()
  {
   var models = _reviewAndRatingManager.GetAll();
   if (models == null)
        return BadRequest();
   return Ok(models);
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
      var model = _reviewAndRatingManager.GetById(id);
      if (model == null)
          return BadRequest();
      return Ok(model);
  }

  [HttpPost]
  public IActionResult Post(ReviewAndRatingAddDto reviewAndRatingAddDto)
  {
       _reviewAndRatingManager.insert(reviewAndRatingAddDto);
       return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(int id, ReviewAndRatingUpdateDto reviewAndRatingUpdateDto)
  {
      if (id !=reviewAndRatingUpdateDto.RateId)
        return BadRequest();
      
      var model = _reviewAndRatingManager.GetById(reviewAndRatingUpdateDto.RateId);
      
      if (model == null)
          return NotFound();
      
      _reviewAndRatingManager.update(reviewAndRatingUpdateDto);

      return Ok();

  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
      var model = _reviewAndRatingManager.GetById(id);
      _reviewAndRatingManager.delete(id);
      return Ok("Rated review deleted");
  }
  
  
  
  
  
}